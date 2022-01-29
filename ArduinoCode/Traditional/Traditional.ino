// Libaries + Setup
#include <Adafruit_GFX.h>    // Core graphics library
#include <SPI.h>
#include <Wire.h>
#include <Adafruit_ILI9341.h>
#include <Adafruit_STMPE610.h>
#include <Adafruit_TFTLCD.h> // Hardware-specific library
#include <AutoPID.h>
#include <Adafruit_MCP4725.h>
#include <OneWire.h>
#include <DallasTemperature.h>

// The STMPE610 uses hardware SPI on the shield, and #8
#define STMPE_CS 8
Adafruit_STMPE610 ts = Adafruit_STMPE610(STMPE_CS);
TS_Point p;

// The display also uses hardware SPI, plus #9 & #10
#define TFT_CS 10
#define TFT_DC 9
Adafruit_ILI9341 tft = Adafruit_ILI9341(TFT_CS, TFT_DC);

// This is calibration data for the raw touch data to the screen coordinates
#define TS_MINX 150
#define TS_MINY 130
#define TS_MAXX 3800
#define TS_MAXY 4000

// Color definitions
#define BLACK    0x0000
#define BLUE     0x001F
#define RED      0xF800
#define GREEN    0x07E0
#define CYAN     0x07FF
#define MAGENTA  0xF81F
#define YELLOW   0xFFE0 
#define WHITE    0xFFFF

GFXcanvas1 canvas(128, 32);

// State Variables
boolean heatingMode = false;
boolean pressing = false;
boolean extracting = false;
boolean heating = false;
boolean startSequence = false;

// Coffee Parameters
#define tempSetPoint 95
#define pressSetPoint 9
#define preInfusionTime 2000
#define preInfusionSpeed 1800

// Pinouts
#define valve 3
#define heater 5
#define tempSensors 2
#define ducer A3
#define Idle 1400

// Temp Sensor setup
OneWire oneWire(tempSensors); 
DallasTemperature sensors(&oneWire);

Adafruit_MCP4725 dac;

// Pressure control setup
#define OUTPUT_MIN 0
#define OUTPUT_MAX 0.7
#define KP 0.01
#define KI 0.04
#define KD 0.5
double PID_setPoint = pressSetPoint;
double PID_Output = 0.2;

double speed_control = 0;
double pressure = 0;
double temp;

double MAX_SPEED = 0.5;
double MIN_SPEED = 0.2;

AutoPID myPID(&pressure, &PID_setPoint, &PID_Output, MIN_SPEED, MAX_SPEED, KP, KI, KD);

void setup() {

  Serial.begin(9600);
  
  //initialize IO pins
  pinMode(valve, OUTPUT);
  pinMode(heater, OUTPUT);
  digitalWrite(valve, HIGH);
  digitalWrite(heater, HIGH);

  //start I2C DAC
  dac.begin(0x62);  
  dac.setVoltage(Idle, false);

  //start oneWire line
  sensors.begin();
  
  //initialize states
  heatingMode = false;
  pressing = false;
  extracting = false;

  //initialize display
  tft.begin();
  ts.begin();
  tft.setRotation(1);
  tft.fillScreen(ILI9341_BLACK);
  
  tft.fillRect(9,12,140,65,WHITE);
  tft.fillRect(9,87,140,65,WHITE);
  tft.fillRect(9,162,140,65,WHITE);

  tft.setTextColor(BLACK);
  tft.setTextSize(4.5);

  tft.setCursor(20,28);
  tft.println("Pump");

  tft.setCursor(20,103);
  tft.println("Heat");

  tft.setCursor(20,178);
  tft.println("Valve");

  updateHardware();
  updateGraphics();

  myPID.setTimeStep(50);

  Serial.println("Setup Complete");
  
}

void loop() {

  
  if (!ts.touched()) {
    if(startSequence){
      autoSequence();
      startSequence = false;
      digitalWrite(valve, HIGH);
      extracting = false;
      pressing = false;
    }
    updateHardware();  
    updateGraphics();
    return;
  }
    
  p = ts.getPoint();
  p.x = map(p.x, TS_MINX, TS_MAXX, 0, tft.height());
  p.y = map(p.y, TS_MINY, TS_MAXY, 0, tft.width());
  int tempx = p.x;
  p.x = p.y;
  p.y = tft.height()-tempx;
  

  while(ts.touched())
    delay(20);
  
  if(p.x<160 && p.x>0){
    if(p.y>12 && p.y<77){
      Serial.println("IMPACT: Pressing");
      if(pressing)
        pressing = false;
      else
        pressing = true;
      delay(50);
      
    }else if(p.y>87 && p.y<152){
      Serial.println("IMPACT: Heating");
      if(heatingMode)
        heatingMode = false;
      else
        heatingMode = true;
      delay(50);
      
    }else if(p.y>162 && p.y<227){
      Serial.println("IMPACT: Valve");
      if(extracting)
        extracting = false;
      else
        extracting = true;
      delay(50);
    }  
  }

  if(p.x>160 && p.y>162 && p.y<227 && temp>(tempSetPoint-2))
    startSequence = true;

  while(ts.bufferSize()>0){
    ts.getPoint();
  }
  
}


void updateGraphics(){

  tft.setTextColor(WHITE);
  tft.setTextSize(2.5);
  
  tft.fillRect(150,0,170,280, BLACK);

  tft.setCursor(170,28);
  if(pressing){
    tft.print(pressure);
    tft.println("B");
  }else
    tft.println("Idle");
  
  tft.setCursor(170,103);
  tft.print(temp);
  tft.print("(");
  if(heatingMode){
    tft.print(tempSetPoint);
  }else
  tft.print("--");
  tft.println(")");

  if(temp < tempSetPoint-2)
    tft.fillRect(180,162,140,65,RED);
  else
    tft.fillRect(180,162,140,65,GREEN);
    
  return;
}

void updateHardware(){
  
  //Grouphead Valve
  
  if(extracting)
    digitalWrite(valve, LOW);
  else
    digitalWrite(valve, HIGH);  

  Serial.println("Valve update complete");


  
  //Heater

  //Skips temp cycle if extraction to increase PID update speed
  if(!pressing){
    sensors.requestTemperatures();
    temp = sensors.getTempCByIndex(0);

    Serial.print("Temp recieved: ");
    Serial.println(temp);
  }
  
  if(!heatingMode || extracting || pressing){
    digitalWrite(heater, HIGH);
    heating = false;
  }else{
    
    if(heating && temp > (tempSetPoint-0.25))
      heating = false;
  
    if(!heating && temp < (tempSetPoint-0.25))
      heating = true;
  
    if(heating){
      digitalWrite(heater, LOW);
    }else
      digitalWrite(heater, HIGH);
  }

  //pressure

  updatePressure();

  Serial.print("Pressure found: ");
  Serial.print(pressure);
  Serial.println(" Bars");
  
  if(pressing){
    myPID.run();
    Serial.print("PID Output: ");
    Serial.println(PID_Output);
    double voltSet = PID_Output*4096;
    dac.setVoltage(voltSet, false);
  }else{
    myPID.stop();
    dac.setVoltage(Idle, false);
  }
  
}

void updatePressure(){

  double input, raw;
  
  input = analogRead(ducer);
  raw = input*0.0165918-1.88442;
  
  if(raw<0)
    pressure = 0;
  else
    pressure = raw;

}

void autoSequence(){

  heatingMode = false;
  pressing = false;
  extracting = false;
  heating = false;
  updateHardware();
  dac.setVoltage(0,false);
  manualDisplay("Close Upper");
  delay(5000);
  dac.setVoltage(preInfusionSpeed,false);
  delay(100);
  digitalWrite(valve, LOW);
  manualDisplay("Touch 2 Stop");
  delay(preInfusionTime);
  extracting = true;
  pressing = true;

  PID_Output = 0.2;
  
  while(!ts.touched()){
    updatePressure();
    myPID.run();
    double voltSet = PID_Output*4096;
    dac.setVoltage(voltSet, false);
    Serial.println(PID_Output);
  }

  dac.setVoltage(0,false);
  digitalWrite(valve, HIGH);
  
  while(ts.bufferSize()>0){
    ts.getPoint();
  }

  PID_Output = 0.2;
  delay(5000);

}

void manualDisplay(String input){

  tft.setTextColor(WHITE);
  tft.setTextSize(2.5);
  
  tft.fillRect(150,0,170,280, BLACK);

  tft.setCursor(180,120);
  tft.println(input);

  return;
}
