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
#define groupValve 3
#define loopValve 4
#define heater 5
#define ducer A3

//146 element lookup for 85:0.1:99.5
int dutyCycleLookup[] = {23,23,23,23,23,23,23,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,26,26,26,26,26,26,26,26,26,26,26,26,26,27,27,27,27,27,27,27,27,27,27,27,28,28,28,28,28,28,28,28,28,28,29,29,29,29,29,29,29,29,29,29,30,30,30,30,30,30,30,30,30,31,31,31,31,31,31,31,31,32,32,32,32,32,32,32,32,33,33,33,33,33,33,34,34,34,34,34,35,35,35,35,35,36,36,36,37,37,37,38,38,38,39,39,40,40,40,41,41,42,42,43,44,45,47,50};

//Weight system setup - weight tracking variable and initialize sensor on DAC
movingAvg filteredWeight(10);
movingAvg filteredTemp(25);
movingAvg filteredPressure(5);

//Ewma filteredWeight(0.2);
DFRobot_HX711_I2C MyScale(&Wire, 0x64);
boolean previousDataErrorFlag = false;

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
double tempSet = 85;    //celcius
boolean groupState = false; //Energize group - normally closed
boolean loopState = false;  //Energize loop  - normally open

// Measured/Enacted System State
double pumpSpeed = 0;   //0-1
double pressure = 0;    //bars
double temp = 0;        //celcius
double weight = 0;      //grams

// values for tracking heater state
boolean heaterState = false;
int heaterDutyCycle = 0;
int heaterDutyCycleCounter = 0;
int heaterDutyCycleLimit = 100;

//Variable to control weather heater is on
boolean heating = false;

AutoPID myPID(&pressure, &PID_setPoint, &PID_Output, MIN_SPEED, MAX_SPEED, KP, KI, KD);

//Variable for tracking refresh rate
long int timeSave = 0;

void setup() {

  Serial.begin(115200);

  filteredWeight.begin();
  filteredTemp.begin();
  filteredPressure.begin();
  
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

  //Send update string - "SPPPPPPPPTTTTTTTTWWWWWWWWFFFFFFFF\r" - " 34 characters"
  //S = start character "S"
  //PPPPPPPP =    (pressure+1000)*100 (with leading zeros)
  //TTTTTTTT = (temperature+1000)*100 (with leading zeros)
  //WWWWWWWW =      (weight+1000)*100 (with leading zeros)
  //FFFFFFFF =   (frequency+1000)*100 (with leading zeros)

  //Initialize message
  String outputMessage = "S";

  //Add pressure
  String pressureMessage = String((pressure+1000)*100, 0);
  while(pressureMessage.length() !=8){
    if(pressureMessage.length() <8)
      pressureMessage = "0"+pressureMessage;
    else
      pressureMessage = "999999999";
  }
  outputMessage = outputMessage+pressureMessage;

  //Add Temperature
  String tempMessage = String((temp+1000)*100, 0);
  while(tempMessage.length() !=8){
    if(tempMessage.length() <8)
      tempMessage = "0"+tempMessage;
    else
      tempMessage = "999999999";
  }
  outputMessage = outputMessage+tempMessage;
  
  //Add Weight
  String weightMessage = String((weight+1000)*100, 0);
  while(weightMessage.length() !=8){
    if(weightMessage.length() <8)
      weightMessage = "0"+weightMessage;
    else
      weightMessage = "999999999";
  }
  outputMessage = outputMessage+weightMessage;

  //calculate refresh rate
  String UpdateFrequency = "F";
  long int timeMeasure = millis();
  //float freq = 1000/(timeMeasure-timeSave);
  float freq = (float)heaterDutyCycle;
  timeSave = timeMeasure;

  //Add refresh rate
  String speedMessage = String((freq+1000)*100, 0);
  while(speedMessage.length() !=8){
    if(speedMessage.length()<8)
      speedMessage = "0"+speedMessage;
    else
      speedMessage = "999999999";
  }
  outputMessage = outputMessage+speedMessage;

  Serial.println(outputMessage);
  
}


void updateWeight() {

  //read weight
  float rawData = MyScale.readWeight(1);

  //if data reading is more than 100g away from current reading, skip, but don't skip twice
  if(((rawData-weight)>100 || (rawData-weight)<-100) && !previousDataErrorFlag){

    previousDataErrorFlag = true;
    return;
  }

  filteredWeight.reading((int)(100*rawData));
  float fweight = filteredWeight.getAvg();
  weight = fweight/100;
  previousDataErrorFlag = false;

}

void updateHeater() {  
  if (heaterState){

    float tempError = temp-tempSet;
    int baseTempSetting = dutyCycleLookup[(int)((tempSet-85)*10)];

    if(tempError<-2){
      heaterDutyCycle = 100;
    }else if(tempError>2){
      heaterDutyCycle = 0;
    }else if(tempError>0){
      heaterDutyCycle = baseTempSetting-5; 
    }else{
      heaterDutyCycle = baseTempSetting+3;
    }
    
    heaterDutyCycleCounter++;
    heaterDutyCycleCounter = heaterDutyCycleCounter%heaterDutyCycleLimit;
      if (heaterDutyCycleCounter<heaterDutyCycle){
        digitalWrite(heater, HIGH);     
      }else{
        digitalWrite(heater, LOW);
      }
  }else{
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
  dac.setVoltage(pumpSpeed * 4096, false);
}

void updateTemperature() {
  rtd0.sample();
  float resistance = rtd0.getResistance();
 
  float rawTemp = ((resistance - 100) / 0.384);
  filteredTemp.reading((int)(100*rawTemp));
  temp = (float)filteredTemp.getAvg()/100;

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

  filteredPressure.reading((int)(100*rawPressure));
  pressure = (float)filteredPressure.getAvg()/100;

}
