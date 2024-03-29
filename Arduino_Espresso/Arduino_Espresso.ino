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
#define steamValve 4
#define ducer A0

float freq = 100;

//basic moving filters setup
movingAvg filteredPressure(20);
movingAvg filteredWaterTemp(40);
movingAvg filteredGHTemp(40);
#define flowKalman 0.04

//weight history and filtering scheme using single point kalman
#define weightAveragingSize 20
#define weightKalman 0.05
int weightData[weightAveragingSize];
int timingData[weightAveragingSize];

//Set temp SPI CS pin
const int CS_0_PIN = 9;
MAX31865 rtd0;
const int CS_1_PIN = 10;
MAX31865 rtd1;

//Scale setup
HX711 scale;
float calibration_factor = 5331;
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
boolean groupState = false;       //Energize group - normally closed
boolean loopState = false;        //Energize loop  - normally open
boolean steamValveState = false;  //Energize steam valve - normally closed

// Measured/Enacted System State
double pressure = 0;        //bars
double temp = 0;            //celcius
double temp_gh = 0;         //celcius
double weight = 0;          //grams
double flowRate = 0;        //ml/s

// values for tracking heater state
boolean heating = false;
float mainHeater_setting;
float gh_heater_setting;

//PID output variables
double pump_PID_Output = 0;
double gh_heater_PID_Output = 0;
double main_heater_PID_Output = 0;


#define flowIntGain 2.4

//AutoPID PIDNAME(&[Measure], &[Target], &[Output], OUTPUT_MIN, OUTPUT_MAX, KP, KI, KD);
//AutoPID pumpPID(&pressure, &pressureSet, &pump_PID_Output, -2, 2, 0.01, 0.04, 0);
//AutoPID pumpPID(&pressure, &pressureSet, &pump_PID_Output, -2, 2, 0, 0.15, 0);
AutoPID pumpPID(&pressure, &pressureSet, &pump_PID_Output, -2, 2, 0.016, 0.2, 10000.0);
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
    timingData[i] = i;
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
  pinMode(steamValve, OUTPUT);
  pinMode(heater, OUTPUT);
  pinMode(gh_heater, OUTPUT);
  digitalWrite(groupValve, LOW);
  digitalWrite(loopValve, LOW);
  digitalWrite(steamValve, LOW);
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
  if (updateMasterNow) {
    updateMaster();
    updateMasterNow = false;
  } else {
    updateMasterNow = true;
  }

}

void checkInput() {
  int data;
  while (Serial.available() > 13) {
    char d1 = Serial.read();

    if (d1 == 'S') {

      String valveMessage = readSerialString(3);
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

        if (valveMessage.charAt(2) == '1')
          steamValveState = true;
        else if (valveMessage.charAt(2) == '0')
          steamValveState = false;


        //process motor state
        char pumpMode = motorMessage.charAt(0);
        int pumpValue = motorMessage.substring(1).toInt();
        if (pumpMode == 'M') {

          pressureSet = -1;
          flowSet = -1;
          pumpSpeed = ((float)pumpValue) / 100;

        } else if (pumpMode == 'P') {

          // if you are chaning into pressre state reset pid of pump first
          if (pressureSet == -1)
            pumpPID.reset();

          pressureSet = (float)pumpValue / 10;
          flowSet = -1;

        } else if (pumpMode == 'F') {

          flowSet = (float)pumpValue / 100;
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

  //Send update string - "SPPPPPPPPTTTTTTTTGGGGGGGGWWWWWWWWRRRRRRRRFFFFFFFFHHHHHHHHGGGGGGGG\n" - " 66 characters"
  //S = start character "S"
  //PPPPPPPP =    (pressure+1000)*100 (with leading zeros)
  //TTTTTTTT = (temperature+1000)*100 (with leading zeros)
  //GGGGGGGG = (temperature+1000)*100 (with leading zeros)
  //WWWWWWWW =      (weight+1000)*100 (with leading zeros)
  //RRRRRRRR =   (flow rate+1000)*100 (with leading zeros)
  //FFFFFFFF =   (frequency+1000)*100 (with leading zeros)
  //HHHHHHHH = (main heater+1000)*100 (with leading zeros)
  //GGGGGGGG =   (gh heater+1000)*100 (with leading zeros)

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

  //Add refresh rate
  String speedMessage = String((freq + 1000) * 100, 0);
  while (speedMessage.length() != 8) {
    if (speedMessage.length() < 8)
      speedMessage = "0" + speedMessage;
    else
      speedMessage = "99999999";
  }
  outputMessage = outputMessage + speedMessage;

  // add main heater setting
  String main_heater_Message = String((mainHeater_setting + 1000) * 100, 0);
  while (main_heater_Message.length() != 8) {
    if (main_heater_Message.length() < 8)
      main_heater_Message = "0" + main_heater_Message;
    else
      main_heater_Message = "99999999";
  }
  outputMessage = outputMessage + main_heater_Message;

  // add grouphead heater setting
  String gh_heater_Message = String((gh_heater_setting + 1000) * 100, 0);
  while (gh_heater_Message.length() != 8) {
    if (gh_heater_Message.length() < 8)
      gh_heater_Message = "0" + gh_heater_Message;
    else
      gh_heater_Message = "99999999";
  }
  outputMessage = outputMessage + gh_heater_Message;


  Serial.println(outputMessage);

}

void updateWeight() {

  //calculate weight using kalman scale with previous data and calculate time shifts
  weight = weightKalman * scale.get_units() + (1 - weightKalman) * weight;

  long int timeMeasure = millis();
  int timeIncrease = timeMeasure - timeSave;
  timeSave = timeMeasure;

  freq = (float)1 / ((float)timeIncrease / 1000);

  //shift weight history values and append latest value
  for (int i = 0; i < weightAveragingSize - 1; i++) {
    weightData[i] = weightData[i + 1];
    timingData[i] = timingData[i] - timingData[0];
  }
  weightData[weightAveragingSize - 1] = (int)(100 * weight);
  timingData[weightAveragingSize - 1] = timingData[weightAveragingSize - 2] + timeIncrease;
}

void updateFlowRate() {

  //calculate flow rate by performing slope linear regression on weight set
  float timeHistory[weightAveragingSize];
  float weightHistory[weightAveragingSize];

  float AverageTime = 0;
  float AverageWeight = 0;

  for (int i = 0; i < weightAveragingSize; i++) {
    weightHistory[i] = (float)weightData[i] / 100;
    timeHistory[i] = ((float)timingData[i]) / ((float)(1000));

    AverageTime += timeHistory[i];
    AverageWeight += weightHistory[i];

  }

  AverageTime = AverageTime / weightAveragingSize;
  AverageWeight = AverageWeight / weightAveragingSize;

  float numerator = 0;
  float denominator = 0;
  for (int i = 0; i < weightAveragingSize; i++) {
    numerator += (timeHistory[i] - AverageTime) * (weightHistory[i] - AverageWeight);
    denominator += (timeHistory[i] - AverageTime) * (timeHistory[i] - AverageTime);
  }

  //modifier is added on after experimental tests
  float rawFlow = 0.11506 * numerator / denominator;

  flowRate = (flowKalman * rawFlow) + ((1 - flowKalman) * flowRate);

}

void updateHeater() {
  //heater settting - between 0 and 1
  mainHeater_setting = 0;
  gh_heater_setting = 0;

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

  if (steamValveState) {
    digitalWrite(steamValve, HIGH);
  } else {
    digitalWrite(steamValve, LOW);
  }

}

void updatePump() {

  //run PID update
  if (pressureSet > 0) {
    //    pumpSpeed = (float)(-4.98468) + (float)(15.0384) * (float)(sqrt(0.39949 + pressureSet));
    //    pumpSpeed = (float)(-4.98468) + (float)(15.0384) * (float)(sqrt(1.25 + pressureSet));
    //    pumpSpeed = (float)(-18.0) + (float)(20.0) * (float)(sqrt(1.5 + pressureSet));
    pumpSpeed = (float)(-18.0) + (float)(20.0) * (float)(sqrt(0.75 + pressureSet));
    pumpSpeed = (pumpSpeed / 100);

    // only apply PID if you are near target - otherwise rely on lookup table
    float pressure_Error = abs(pressureSet - pressure);
    if (pressure_Error < 1.5) {
      pumpPID.run();
      pumpSpeed = pumpSpeed + pump_PID_Output / 10;
    } else {
      pumpPID.reset();
    }
  } else {
    pumpPID.reset();
    pumpPID.stop();
  }

  if (flowSet > 0) {

    double FlowError = flowRate - flowSet;
    double flowCorrectionGain = 0.004;
    double minPumpSetting = 0.15;
    double maxPumpSetting = 0.40;

    pumpSpeed = max(min((pumpSpeed - (FlowError * flowCorrectionGain)), maxPumpSetting), minPumpSetting);
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

  filteredGHTemp.reading((int)(100 * rawTemp));

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
