// Libaries + Setup
#include <SPI.h>
#include <Wire.h>
#include <AutoPID.h>
#include <Adafruit_MCP4725.h>
#include <DFRobot_HX711_I2C.h>
#include <Ewma.h>
#include <EwmaT.h>
#include <PwFusion_MAX31865.h>

// Pinouts
#define groupValve 3
#define loopValve 4
#define heater 5
#define ducer A3

//Weight system setup - weight tracking variable and initialize sensor on DAC
Ewma filteredWeight(0.2);
DFRobot_HX711_I2C MyScale(&Wire, 0x64);

//Set temp SPI CS pin
const int CS_PIN = 10;
MAX31865 rtd0;

// DAC
Adafruit_MCP4725 dac;

// Pressure control PID parameters
#define OUTPUT_MIN 0.1
#define OUTPUT_MAX 0.7
#define KP 0.01
#define KI 0.04
#define KD 0.5
double PID_setPoint = 0;
double PID_Output = 0.2;
double MAX_SPEED = 1;
double MIN_SPEED = 0;


// Target values supplied over serial
double motorSet = 0.34;  //0-1 value given by
double pumpSet = -1;    //target pressure -1 if using motorSet
double tempSet = 20;    //celcius
boolean groupState = false; //Energize group - normally closed
boolean loopState = false;  //Energize loop  - normally open

// Measured/Enacted System State
double pumpSpeed = 0;   //0-1
double pressure = 0;    //bars
double temp = 0;        //celcius
double weight = 0;      //grams

//Variable to control weather heater is on
boolean heating = false;

AutoPID myPID(&pressure, &PID_setPoint, &PID_Output, MIN_SPEED, MAX_SPEED, KP, KI, KD);

//Variable for tracking refresh rate
long int timeSave = 1;

void setup() {

  Serial.begin(115200);

  //initialize SPI bus, temp CS pin, and configure RTD sensor
  SPI.begin();
  pinMode(CS_PIN, OUTPUT);
  rtd0.begin(CS_PIN, RTD_3_WIRE, 428);
  rtd0.setLowFaultTemperature(0);
  rtd0.setHighFaultTemperature(120);

  //initialize IO pins
  pinMode(groupValve, OUTPUT);
  pinMode(loopValve, OUTPUT);
  pinMode(heater, OUTPUT);
  digitalWrite(groupValve, LOW);
  digitalWrite(loopValve, LOW);
  digitalWrite(heater, LOW);

  //start I2C DAC and initialize pump
  dac.begin(0x62);
  updatePump();

  //start I2C scale and set calbration value
  MyScale.begin();
  MyScale.setCalibration(2025.37);
  MyScale.peel();

  //Set timestep for PID loop
  myPID.setTimeStep(25);

  boolean handshake = false;
  while(!handshake){
    if(Serial.available()>0){
      if(Serial.read() == 'S'){
        handshake = true;
      }
    }
  }

}

void loop() {

  if (pumpSet == -1) {
    pumpSpeed = motorSet;
  } else {
    //TO BE PROGRAMMED
    //PID LOOP TO DETERMINE PUMP SPEED
  }

  //updateSensors
  updatePressure();
  updateTemperature();
  updateWeight();

  //updateValves/hardware
  updateValves();
  updatePump();
  updateHeater();

  updateMaster();

}

void updateMaster() {
  String PressureOutput = "P";
  PressureOutput = PressureOutput + String(pressure, 2);
  Serial.println(PressureOutput);

  delay(4);

  String TempOutput = "T";
  TempOutput = TempOutput + String(temp, 2);
  Serial.println(TempOutput);

  delay(4);

  String WeightOutput = "W";
  WeightOutput = WeightOutput + String(weight, 2);
  Serial.println(WeightOutput);

  delay(4);

//  String UpdateFrequency = "F";
//  long int timeMeasure = millis();
//  float freq = 1000/(timeMeasure-timeSave);
//  timeSave = timeMeasure;
//  UpdateFrequency = UpdateFrequency+String(freq,2);
//  Serial.println(UpdateFrequency);
//
//  delay(4);
  
}


void updateWeight() {
  float fweight = filteredWeight.filter(MyScale.readWeight(1));
  weight = fweight;
}

void updateHeater() {
  if (temp > (tempSet + 0.5) && heating) {
    heating = false;
  } else if (temp < (tempSet - 0.5) && !heating) {
    heating = true;
  }
  digitalWrite(heater, heating);

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
  dac.setVoltage(pumpSpeed * 4096, false);
}

void updateTemperature() {
  rtd0.sample();
  float resistance = rtd0.getResistance();
  temp = ((resistance - 100) / 0.384);
}

void updatePressure() {

  double input, raw;
  input = analogRead(ducer);
  raw = input * 0.0165918 - 1.88442;
  if (raw < 0)
    pressure = 0;
  else
    pressure = raw;

}
