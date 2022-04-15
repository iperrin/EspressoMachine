// Libaries + Setup
#include <SPI.h>
#include <Wire.h>
#include <AutoPID.h>
#include <Adafruit_MCP4725.h>
#include <DFRobot_HX711_I2C.h>
#include <Ewma.h>
#include <EwmaT.h>
#include <PwFusion_MAX31865.h>
#include <movingAvg.h>

// Pinouts
//unused pins: D4 (relay 2), A1 A2 A3

#define heater 2
#define gh_heater 3
#define groupValve 6
#define loopValve 5
#define ducer A0

//146 element lookup for 85:0.1:99.5 (duty cycle corresponding to temperature target)
int dutyCycleLookup[] = {23, 23, 23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 30, 30, 30, 30, 30, 30, 30, 30, 30, 31, 31, 31, 31, 31, 31, 31, 31, 32, 32, 32, 32, 32, 32, 32, 32, 33, 33, 33, 33, 33, 33, 34, 34, 34, 34, 34, 35, 35, 35, 35, 35, 36, 36, 36, 37, 37, 37, 38, 38, 38, 39, 39, 40, 40, 40, 41, 41, 42, 42, 43, 44, 45, 47, 50};

//146 element lookup for 85:0.1:99.5 (duty cycle corresponding to temperature target)
int GH_dutyCycleLookup[] = {23, 23, 23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 30, 30, 30, 30, 30, 30, 30, 30, 30, 31, 31, 31, 31, 31, 31, 31, 31, 32, 32, 32, 32, 32, 32, 32, 32, 33, 33, 33, 33, 33, 33, 34, 34, 34, 34, 34, 35, 35, 35, 35, 35, 36, 36, 36, 37, 37, 37, 38, 38, 38, 39, 39, 40, 40, 40, 41, 41, 42, 42, 43, 44, 45, 47, 50};


//121 elemeent lookup for pressures 0:0.1:12 (motor speed corresponding to temperature target)
int motorSpeedLookup[] = {0, 6, 7, 8, 8, 9, 10, 11, 11, 12, 13, 13, 14, 14, 15, 16, 16, 17, 17, 17, 18, 18, 19, 19, 20, 20, 21, 21, 22, 22, 23, 23, 23, 24, 24, 25, 25, 26, 26, 26, 27, 27, 28, 28, 28, 29, 29, 29, 30, 30, 30, 31, 31, 31, 32, 32, 32, 32, 33, 33, 33, 34, 34, 34, 34, 35, 35, 35, 36, 36, 36, 36, 37, 37, 37, 37, 38, 38, 38, 38, 39, 39, 39, 39, 40, 40, 40, 40, 40, 41, 41, 41, 41, 42, 42, 42, 42, 43, 43, 43, 43, 44, 44, 44, 44, 45, 45, 45, 45, 45, 46, 46, 46, 46, 47, 47, 47, 47, 48, 48, 48};

//Weight system setup - weight tracking variable and initialize sensor on DAC
movingAvg filteredWeight(10);
movingAvg filteredTemp_0(25);
movingAvg filteredTemp_1(25);
movingAvg filteredPressure(10);

//Ewma filteredWeight(0.2);
DFRobot_HX711_I2C MyScale(&Wire, 0x64);
boolean previousDataErrorFlag = false;

//Set temp SPI CS pin
const int CS_0_PIN = 9;
MAX31865 rtd0;
const int CS_1_PIN = 10;
MAX31865 rtd1;

#define ref_res_0 430
#define ref_res_1 430

// DAC
Adafruit_MCP4725 dac;

// Pressure control PID parameters
#define OUTPUT_MIN -1
#define OUTPUT_MAX 1
#define KP 0.01
#define KI 0.04
#define KD 0
double PID_Output = 0;


// Target values supplied over serial
double pumpSpeed = 0;  //0-1 value given by
double pressureSet = 0;    //target pressure -1 if using pumpSpeed
double tempSet = 85;    //celcius
boolean groupState = false; //Energize group - normally closed
boolean loopState = false;  //Energize loop  - normally open

// Measured/Enacted System State
double pressure = 0;    //bars
double temp = 0;        //celcius
double temp_gh = 0;     //celcius
double weight = 0;      //grams

// values for tracking heater state
boolean heating = false;
int heaterDutyCycle = 0;
int heaterDutyCycleCounter = 0;
int heaterDutyCycleLimit = 100;

int gh_heaterDutyCycle = 0;
int gh_heaterDutyCycleCounter = 0;
int gh_heaterDutyCycleLimit = 100;

AutoPID myPID(&pressure, &pressureSet, &PID_Output, OUTPUT_MIN, OUTPUT_MAX, KP, KI, KD);

//Variable for tracking refresh rate
long int timeSave = 0;

void setup() {

  Serial.begin(115200);
  Serial.setTimeout(1);

  //Serial.println("_startup");

  filteredWeight.begin();
  filteredTemp_0.begin();
  filteredTemp_1.begin();
  filteredPressure.begin();

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
  digitalWrite(gh_heater, HIGH);

  //start I2C DAC and initialize pump
  dac.begin(0x62);
  updatePump();

  //Serial.println("_DAC setup");

  //start I2C scale and set calbration value
  MyScale.begin();
  MyScale.setCalibration(2025.37);
  MyScale.peel();

  //Serial.println("_scale setup");

  //Set timestep for PID loop
  myPID.setTimeStep(25);

}

void loop() {

  //updateSensors
  updatePressure();
  updateTemperature_0();
  updateTemperature_1();
  updateWeight();
  
  //updateValves/hardware
  updateValves();
  updatePump();
  updateHeater();

  //communications update
  updateMaster();
  checkInput();

}

void checkInput() {
  int data;
  while (Serial.available()) {
    char d1 = Serial.read();

    if (d1 == 'T') {
      //processing new temp value
      data = Serial.parseInt();
      float newTemp = (float)data;
      newTemp = newTemp / 10;
      if (newTemp > 84.9 && newTemp < 99.6) {
        tempSet = newTemp;
        heating = true;
      } else {
        heating = false;
      }

      //processing new valve configruation
    } else if (d1 == 'V') {
      char nextChar = Serial.read();
      if (nextChar == '1') {
        loopState = true;
      } else if (nextChar == '0') {
        loopState = false;
      }

      nextChar = Serial.read();
      if (nextChar == '1') {
        groupState = true;
      } else if (nextChar == '0') {
        groupState = false;
      }
      //processing direct motor speed setting
    } else if (d1 == 'M') {
      data = Serial.parseInt();
      pressureSet = -1;
      pumpSpeed = ((float)data) / 100;

      //processing new pressure settting
    } else if (d1 == 'P') {
      data = Serial.parseInt();
      pressureSet = ((float)data) / 10;

      //check for a reset/cal value
    } else if (d1 == 'R') {
      char d2 = Serial.read();
      if (d2 == '1') {
        //clear PID constants
        myPID.reset();

      } else if (d2 == '2') {
        //calibrate scale
        MyScale.peel();
      }
    }

  }
}

void updateMaster() {

  //Send update string - "SPPPPPPPPTTTTTTTTGGGGGGGGWWWWWWWWFFFFFFFF\r" - " 42 characters"
  //S = start character "S"
  //PPPPPPPP =    (pressure+1000)*100 (with leading zeros)
  //TTTTTTTT = (temperature+1000)*100 (with leading zeros)
  //GGGGGGGG = (temperature+1000)*100 (with leading zeros)
  //WWWWWWWW =      (weight+1000)*100 (with leading zeros)
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

  //calculate refresh rate
  String UpdateFrequency = "F";
  long int timeMeasure = millis();
  float freq = 1000 / (timeMeasure - timeSave);

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

  //read weight
  float rawData = MyScale.readWeight(1);

  //if data reading is more than 100g away from current reading, skip, but don't skip twice
  if (((rawData - weight) > 100 || (rawData - weight) < -100) && !previousDataErrorFlag) {

    previousDataErrorFlag = true;
    return;
  }

  filteredWeight.reading((int)(100 * rawData));
  float fweight = filteredWeight.getAvg();
  weight = fweight / 100;
  previousDataErrorFlag = false;

}

void updateHeater() {
  if (heating) {

    float tempError = temp - tempSet;
    int baseTempSetting = dutyCycleLookup[(int)((tempSet - 85) * 10)];

    if (tempError < -2) {
      heaterDutyCycle = 100;
    } else if (tempError > 2) {
      heaterDutyCycle = 0;
    } else if (tempError > 0) {
      heaterDutyCycle = baseTempSetting - 5;
    } else {
      heaterDutyCycle = baseTempSetting + 3;
    }

    //stochastic main heater
    if(random(100)<=heaterDutyCycle){
      digitalWrite(heater, HIGH);
    }else{
      digitalWrite(heater, LOW);
    }





    heaterDutyCycleCounter++;
    heaterDutyCycleCounter = heaterDutyCycleCounter % heaterDutyCycleLimit;
    if (heaterDutyCycleCounter < heaterDutyCycle) {
      digitalWrite(gh_heater, LOW);
    } else {
      digitalWrite(gh_heater, HIGH);
    }


    

    

    
  } else {
    digitalWrite(heater, LOW);
    digitalWrite(gh_heater, HIGH);
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
    myPID.run();
    int baseSpeedIndex = (int)(10 * pressureSet);
    pumpSpeed = (float)motorSpeedLookup[baseSpeedIndex];
    pumpSpeed = (pumpSpeed / 100);
    pumpSpeed = pumpSpeed + PID_Output / 10;
  } else {
    myPID.stop();
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
  filteredTemp_0.reading((int)(100 * rawTemp));
  temp = (float)filteredTemp_0.getAvg() / 100;
}

void updateTemperature_1() {

  uint8_t fault = rtd1.getStatus();
  if (fault != 0) {
      rtd1.begin(CS_1_PIN, RTD_3_WIRE, ref_res_1);
  }
  
  rtd1.sample();
  float resistance = rtd1.getResistance();
  float rawTemp = ((resistance - 100) / 0.384);
  filteredTemp_1.reading((int)(100 * rawTemp));
  temp_gh = (float)filteredTemp_1.getAvg() / 100;
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
