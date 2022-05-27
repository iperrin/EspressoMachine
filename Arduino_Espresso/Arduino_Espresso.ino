// Libaries + Setup
#include <SPI.h>
#include <Wire.h>
#include <AutoPID.h>
#include <Adafruit_MCP4725.h>
#include <HX711.h>
#include <PwFusion_MAX31865.h>
#include <movingAvg.h>
#include <limits.h>

#define heater 2
#define gh_heater 3
#define groupValve 6
#define loopValve 5
#define ducer A0

float freq = 100;

//121 elemeent lookup for pressures 0:0.1:12 (motor speed corresponding to temperature target)
int motorSpeedLookup[] = {0, 6, 7, 8, 8, 9, 10, 11, 11, 12, 13, 13, 14, 14, 15, 16, 16, 17, 17, 17, 18, 18, 19, 19, 20, 20, 21, 21, 22, 22, 23, 23, 23, 24, 24, 25, 25, 26, 26, 26, 27, 27, 28, 28, 28, 29, 29, 29, 30, 30, 30, 31, 31, 31, 32, 32, 32, 32, 33, 33, 33, 34, 34, 34, 34, 35, 35, 35, 36, 36, 36, 36, 37, 37, 37, 37, 38, 38, 38, 38, 39, 39, 39, 39, 40, 40, 40, 40, 40, 41, 41, 41, 41, 42, 42, 42, 42, 43, 43, 43, 43, 44, 44, 44, 44, 45, 45, 45, 45, 45, 46, 46, 46, 46, 47, 47, 47, 47, 48, 48, 48};

//basic moving filters setup
movingAvg filteredPressure(20);
movingAvg filteredWaterTemp(40);
movingAvg filteredGHTemp(40);
#define flowKalman 0.04

//weight history and filtering scheme using single point kalman
#define weightAveragingSize 20
#define weightKalman 0.05
int weightData[weightAveragingSize];

//Set temp SPI CS pin
const int CS_0_PIN = 9;
MAX31865 rtd0;
const int CS_1_PIN = 10;
MAX31865 rtd1;

//Scale setup
HX711 scale;
float calibration_factor = 5030;
#define Scale_DOUT 7
#define Scale_CLK 8

//PT100 reference resistors
#define ref_res_0 430
#define ref_res_1 430

// DAC
Adafruit_MCP4725 dac;

// Target values supplied over serial
double pumpSpeed = 0.25;    //0-1 value given by
double pressureSet = -1;     //target pressure -1 if not using pressureSet
double tempSet = 85;        //celcius
double flowSet = -1;         //ml/s -1 if not using flowSet
boolean groupState = false; //Energize group - normally closed
boolean loopState = false;  //Energize loop  - normally open

// Measured/Enacted System State
double pressure = 0;        //bars
double temp = 0;            //celcius
double temp_gh = 0;         //celcius
double weight = 0;          //grams
double flowRate = 0;        //ml/s

// values for tracking heater state
boolean heating = false;

//PID output variables
double pump_PID_Output = 0;
double gh_heater_PID_Output = 0;
double main_heater_PID_Output = 0;
double flow_PID_Output = 0;


#define flowIntGain 2.4

//AutoPID PIDNAME(&[Measure], &[Target], &[Output], OUTPUT_MIN, OUTPUT_MAX, KP, KI, KD);
AutoPID pumpPID(&pressure, &pressureSet, &pump_PID_Output, -2, 2, 0.01, 0.04, 0);
AutoPID flowPID(&flowRate, &flowSet, &flow_PID_Output, 0, 50, 0.5 , flowIntGain, 0);
AutoPID ghHeaterPID(&temp_gh, &tempSet, &gh_heater_PID_Output, 0, 1, 0.04, 0.0015, 0);
AutoPID mainHeaterPID(&temp, &tempSet, &main_heater_PID_Output, 0, 0.5, 0.15, 0.001, 0);

//Variable for tracking refresh rate
long int timeSave = 0;
boolean updateMasterNow = true;

void setup() {

  Serial.begin(115200);
  Serial.setTimeout(1);

  //Serial.println("_startup");

  filteredPressure.begin();
  filteredWaterTemp.begin();
  filteredGHTemp.begin();

  //intialize weight filtering scheme
  for (int i = 0; i < weightAveragingSize; i++) {
    weightData[i] = 0;
  }

  //initialize SPI bus, temp CS pin, and configure RTD sensor
  SPI.begin();
  pinMode(CS_0_PIN, OUTPUT);
  rtd0.begin(CS_0_PIN, RTD_3_WIRE, ref_res_0);
  rtd0.setLowFaultTemperature(0);
  rtd0.setHighFaultTemperature(120);

  pinMode(CS_1_PIN, OUTPUT);
  rtd1.begin(CS_1_PIN, RTD_3_WIRE, ref_res_1);
  rtd1.setLowFaultTemperature(0);
  rtd1.setHighFaultTemperature(120);

  //Serial.println("_rtd setup");

  //initialize IO pins
  pinMode(groupValve, OUTPUT);
  pinMode(loopValve, OUTPUT);
  pinMode(heater, OUTPUT);
  pinMode(gh_heater, OUTPUT);
  digitalWrite(groupValve, LOW);
  digitalWrite(loopValve, LOW);
  digitalWrite(heater, LOW);
  digitalWrite(gh_heater, LOW);

  //start I2C DAC and initialize pump
  dac.begin(0x62);
  updatePump();

  //Serial.println("_DAC setup");

  //Start scale
  scale.begin(Scale_DOUT, Scale_CLK);
  scale.set_scale();
  scale.tare(); //Reset the scale to 0
  scale.set_scale(calibration_factor);

  //Serial.println("_scale setup");

  //Set timestep for PID loop
  pumpPID.setTimeStep(25);
  flowPID.setTimeStep(25);
  ghHeaterPID.setTimeStep(25);
  mainHeaterPID.setTimeStep(25);

}

void loop() {

  //updateSensors
  updatePressure();
  updateTemperature_0();
  updateTemperature_1();
  updateWeight();
  updateFlowRate();

  //updateValves/hardware
  updateValves();
  updatePump();
  updateHeater();

  //communications update
  checkInput();
  if(updateMasterNow){
    updateMaster();
    updateMasterNow = false;
  }else{
    updateMasterNow = true;
  }

}

void checkInput() {
  int data;
  while (Serial.available() > 12) {
    char d1 = Serial.read();

    if (d1 == 'S') {

      String valveMessage = readSerialString(2);
      String motorMessage = readSerialString(4);
      String TempMessage = readSerialString(3);
      char termination = Serial.read();

      //      Serial.println("V: "+valveMessage);
      //      Serial.println("M: "+motorMessage);
      //      Serial.println("T: "+TempMessage);
      //      Serial.println(termination);
      //      Serial.println("\n");

      //if message has valid termination - nothing dropped
      if (termination == 'K') {

        //process valve
        if (valveMessage.charAt(0) == '1')
          loopState = true;
        else if (valveMessage.charAt(0) == '0')
          loopState = false;

        if (valveMessage.charAt(1) == '1')
          groupState = true;
        else if (valveMessage.charAt(1) == '0')
          groupState = false;


        //process motor state
        char pumpMode = motorMessage.charAt(0);
        int pumpValue = motorMessage.substring(1).toInt();
        if (pumpMode == 'M') {

          pressureSet = -1;
          flowSet = -1;
          pumpSpeed = ((float)pumpValue) / 100;

        } else if (pumpMode == 'P') {

          pressureSet = (float)pumpValue / 10;
          flowSet = -1;

        } else if (pumpMode == 'F') {

          flowSet = (float)pumpValue/100;
          pressureSet = -1;
        }

        //process temp state
        int tempInput = TempMessage.toInt();
        if (tempInput != 0) {
          heating = true;
          tempSet = ((double)tempInput) / 10;
        } else
          heating = false;

      }

    } else if (d1 == 'R') {
      char d2 = Serial.read();
      if (d2 == '1') {
        //clear PID constants
        pumpPID.reset();
        ghHeaterPID.reset();
        mainHeaterPID.reset();

      } else if (d2 == '2') {
        //calibrate scale
        scale.tare();
      }
    }
  }
}

void updateMaster() {

  //Send update string - "SPPPPPPPPTTTTTTTTGGGGGGGGWWWWWWWWRRRRRRRRFFFFFFFF\n" - " 50 characters"
  //S = start character "S"
  //PPPPPPPP =    (pressure+1000)*100 (with leading zeros)
  //TTTTTTTT = (temperature+1000)*100 (with leading zeros)
  //GGGGGGGG = (temperature+1000)*100 (with leading zeros)
  //WWWWWWWW =      (weight+1000)*100 (with leading zeros)
  //RRRRRRRR =   (flow rate+1000)*100 (with leading zeros)
  //FFFFFFFF =   (frequency+1000)*100 (with leading zeros)

  //Initialize message
  String outputMessage = "S";

  //Add pressure
  String pressureMessage = String((pressure + 1000) * 100, 0);
  while (pressureMessage.length() != 8) {
    if (pressureMessage.length() < 8)
      pressureMessage = "0" + pressureMessage;
    else
      pressureMessage = "99999999";
  }
  outputMessage = outputMessage + pressureMessage;

  //Add Temperature
  String tempMessage = String((temp + 1000) * 100, 0);
  while (tempMessage.length() != 8) {
    if (tempMessage.length() < 8)
      tempMessage = "0" + tempMessage;
    else
      tempMessage = "99999999";
  }
  outputMessage = outputMessage + tempMessage;

  //Add GH Temperature
  String tempghMessage = String((temp_gh + 1000) * 100, 0);
  while (tempghMessage.length() != 8) {
    if (tempghMessage.length() < 8)
      tempghMessage = "0" + tempghMessage;
    else
      tempghMessage = "99999999";
  }
  outputMessage = outputMessage + tempghMessage;

  //Add Weight
  String weightMessage = String((weight + 1000) * 100, 0);
  while (weightMessage.length() != 8) {
    if (weightMessage.length() < 8)
      weightMessage = "0" + weightMessage;
    else
      weightMessage = "99999999";
  }
  outputMessage = outputMessage + weightMessage;

  //Add Flowrate
  String flowMessage = String((flowRate + 1000) * 100, 0);
  while (flowMessage.length() != 8) {
    if (flowMessage.length() < 8)
      flowMessage = "0" + flowMessage;
    else
      flowMessage = "99999999";
  }
  outputMessage = outputMessage + flowMessage;

  //calculate refresh rate
  String UpdateFrequency = "F";
  long int timeMeasure = millis();
  freq = 1000 / (timeMeasure - timeSave);

  timeSave = timeMeasure;

  //Add refresh rate
  String speedMessage = String((freq + 1000) * 100, 0);
  while (speedMessage.length() != 8) {
    if (speedMessage.length() < 8)
      speedMessage = "0" + speedMessage;
    else
      speedMessage = "99999999";
  }
  outputMessage = outputMessage + speedMessage;

  Serial.println(outputMessage);

}

void updateWeight() {

  //calculate weight using kalman scale with previous data
  weight = weightKalman*scale.get_units()+(1-weightKalman)*weight;
  
  //shift weight history values and append latest value
  for(int i = 0; i<weightAveragingSize-1; i++){
    weightData[i] = weightData[i+1];
  }
  weightData[weightAveragingSize-1] = (int)(100 * weight);
}

void updateFlowRate(){

  //calculate flow rate by performing slope linear regression on weight set
  float timeHistory[weightAveragingSize];
  float weightHistory[weightAveragingSize];

  float AverageTime = 0;
  float AverageWeight = 0;

  for(int i = 0; i<weightAveragingSize; i++){
    weightHistory[i] = (float)weightData[i]/100;
    timeHistory[i] = ((float)i)/(float(freq));

    AverageTime += timeHistory[i];
    AverageWeight += weightHistory[i];

  }

  AverageTime = AverageTime/weightAveragingSize;
  AverageWeight = AverageWeight/weightAveragingSize;

  float numerator = 0;
  float denominator = 0;
  for(int i = 0; i<weightAveragingSize; i++){
      numerator+=(timeHistory[i]-AverageTime)*(weightHistory[i]-AverageWeight);
      denominator+=(timeHistory[i]-AverageTime)*(timeHistory[i]-AverageTime);
  }
  float rawFlow = numerator/denominator;

  flowRate = (flowKalman*rawFlow) + ((1-flowKalman)*flowRate);
  
}

void updateHeater() {
  //heater settting - between 0 and 1
  float mainHeater_setting = 0;
  float gh_heater_setting = 0;

  if (heating) {

    //grouphead heater
    if (temp_gh - tempSet > 5) {
      gh_heater_setting = 0;
      //ghHeaterPID.reset();
    } else if (temp_gh - tempSet < -5) {
      gh_heater_setting = 1;
      //ghHeaterPID.reset();
    } else {
      //PID GH heater setting
      ghHeaterPID.run();
      gh_heater_setting = gh_heater_PID_Output;
    }

    //main heater
    if (temp - tempSet > 5) {
      mainHeater_setting = 0;
      //reset PID on a high overshoot (likely due to initial haet
      mainHeaterPID.reset();
    } else if (temp - tempSet < -2) {
      mainHeater_setting = 1;
      //mainHeaterPID.reset();
    } else {
      //PID main heater setting
      mainHeaterPID.run();
      mainHeater_setting = main_heater_PID_Output;
    }

  }


  //write heater settings to pins using PWM on GH and MC on main
  analogWrite(gh_heater, (int)(gh_heater_setting * 255));
  if ((int)(100 * mainHeater_setting) > random(100)) {
    digitalWrite(heater, HIGH);
  } else {
    digitalWrite(heater, LOW);
  }

}

void updateValves() {

  if (groupState) {
    digitalWrite(groupValve, HIGH);
  } else {
    digitalWrite(groupValve, LOW);
  }

  if (loopState) {
    digitalWrite(loopValve, HIGH);
  } else {
    digitalWrite(loopValve, LOW);
  }

}

void updatePump() {

  //run PID update
  if (pressureSet > 0) {
    pumpPID.run();
    int baseSpeedIndex = (int)(10 * pressureSet);
    pumpSpeed = (float)motorSpeedLookup[baseSpeedIndex];
    pumpSpeed = (pumpSpeed / 100);
    pumpSpeed = pumpSpeed + pump_PID_Output / 10;
  } else {
    pumpPID.reset();
    pumpPID.stop();
  }

  if (flowSet > 0) {
    if(flowPID.isStopped()){
      flowPID.run();
      flowPID.setIntegral(((double)pumpSpeed)*(100/flowIntGain));
    }
    flowPID.run();
    pumpSpeed = flow_PID_Output/100;
  } else {
    flowPID.reset();
    flowPID.stop();
  }

  dac.setVoltage((int)(pumpSpeed * 4096), false);
}

void updateTemperature_0() {

  uint8_t fault = rtd0.getStatus();
  if (fault != 0) {
    rtd0.begin(CS_0_PIN, RTD_3_WIRE, ref_res_0);
  }

  rtd0.sample();
  float resistance = rtd0.getResistance();
  float rawTemp = ((resistance - 100) / 0.384);
      
  filteredWaterTemp.reading((int)(100 * rawTemp));
  
  temp = (float)filteredWaterTemp.getAvg() / 100;
}

void updateTemperature_1() {

  uint8_t fault = rtd1.getStatus();
  if (fault != 0) {
    rtd1.begin(CS_1_PIN, RTD_3_WIRE, ref_res_1);
  }

  rtd1.sample();
  float resistance = rtd1.getResistance();
  float rawTemp = ((resistance - 100) / 0.384);
      
  filteredGHTemp.reading((int)(100*rawTemp));

  temp_gh = (float)filteredGHTemp.getAvg() / 100;
}

void updatePressure() {

  double input, raw;
  float rawPressure;
  input = analogRead(ducer);
  raw = input * 0.0165918 - 1.88442;
  if (raw < 0)
    rawPressure = 0;
  else
    rawPressure = raw;

  filteredPressure.reading((int)(100 * rawPressure));
  pressure = (float)filteredPressure.getAvg() / 100;

}

String readSerialString(int spots) {
  String output = "";
  for (int i = 0; i < spots; i++)
    if (Serial.available())
      output = output + String((char)Serial.read());
  return output;
}
