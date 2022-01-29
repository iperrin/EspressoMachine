
#include <Adafruit_GFX.h>    // Core graphics library
#include <SPI.h>
#include <Wire.h>
#include <Adafruit_ILI9341.h>
#include <Adafruit_STMPE610.h>
#include <Adafruit_TFTLCD.h> // Hardware-specific library
#include <AutoPID.h>

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

#define Transducer  A3

#define PRESS_OUTPUT_MIN 0
#define PRESS_OUTPUT_MAX 0.8
#define press_KP .01
#define press_KI 0.04
#define press_KD 0.5
double press_setPoint = 0;
double press_output = 0;

#define TEMP_OUTPUT_MIN 0
#define TEMP_OUTPUT_MAX 0.8
#define temp_KP .01
#define temp_KI 0.04
#define temp_KD 0.5
double temp_setPoint = 0;
double temp_output = 0;

// DAC Libraries
#include <Wire.h>
#include <Adafruit_MCP4725.h>
Adafruit_MCP4725 dac;

// The STMPE610 uses hardware SPI on the shield, and #8
#define STMPE_CS 8
Adafruit_STMPE610 ts = Adafruit_STMPE610(STMPE_CS);

// The display also uses hardware SPI, plus #9 & #10
#define TFT_CS 10
#define TFT_DC 9
Adafruit_ILI9341 tft = Adafruit_ILI9341(TFT_CS, TFT_DC);

double speed_control = 0;
double pressure = 0;

int heat_control = 0;
double temp = 0;

double MAX_SPEED = 0.5;
double MIN_SPEED = 0;

GFXcanvas1 canvas(128, 32);

AutoPID pressPID(&pressure, &press_setPoint, &press_output, 0, 1023, press_KP, press_KI, press_KD);
AutoPID tempPID(&temp, &temp_setPoint, &temp_output, 0, 1023, temp_KP, temp_KI, temp_KD);

void setup(void) {
 
  Serial.begin(9600);
  
  tft.begin();
  dac.begin(0x62);
  
  dac.setVoltage(speed_control, false);
  
  if (!ts.begin()) {
    Serial.println("Couldn't start touchscreen controller");
    while (1);
  }
  Serial.println("Touchscreen started");

  tft.setRotation(1);
  
  tft.fillScreen(ILI9341_BLACK);
  tft.fillRect(9,9,140,50,WHITE);
  tft.fillRect(170,9,140,50,WHITE);

  tft.drawFastVLine(159, 0, 240, BLUE);
  tft.drawFastVLine(160, 0, 240, BLUE);
  tft.drawFastVLine(161, 0, 240, BLUE);

  tft.setTextColor(BLACK, WHITE);
  tft.setTextSize(4);
  tft.setCursor(19,19);
  tft.println("PRESS");
  tft.setCursor(190,19);
  tft.println("TEMP");

  tft.fillRect(9,179,62,45,GREEN);
  tft.fillRect(85,179,62,45,RED);

  tft.fillRect(170,179,62,45,GREEN);
  tft.fillRect(246,179,62,45,RED);

  tft.setTextColor(BLACK, GREEN);
  tft.setTextSize(3);
  tft.setCursor(14,190);
  tft.println("PID");
  tft.setCursor(176,190);
  tft.println("PID");

  tft.setTextColor(WHITE, RED);
  tft.setTextSize(2);
  tft.setCursor(91,195);
  tft.println("IDLE");
  tft.setCursor(253,195);
  tft.println("IDLE");

  tft.fillRect(9,65,62,50,WHITE);
  tft.fillRect(9,122,62,50,WHITE);
  tft.fillRect(170,65,62,50,WHITE);
  tft.fillRect(170,122,62,50,WHITE);

  tft.setTextColor(BLACK, WHITE);
  tft.setTextSize(3);
  tft.setCursor(20,80);
  tft.println("UP");
  tft.setCursor(14,137);
  tft.println("DWN");
  
  tft.setCursor(181,80);
  tft.println("UP");
  tft.setCursor(175,137);
  tft.println("DWN");


  tempPID.stop();
  pressPID.stop();

  updateDisplay();
  

  tempPID.setTimeStep(50);
  pressPID.setTimeStep(50);
  setSpeed(0);

}


void loop()
{
//  // See if there's any  touch data for us
//  if (!ts.touched()) {
//    updatePressure();
//    pressPID.run();
//    setSpeed(press_output);
//    Serial.println(speed_control);
//    return;
//  }
//
//  // Retrieve a point  
//  TS_Point p = ts.getPoint();
//  
// /*
//  Serial.print("X = "); Serial.print(p.x);
//  Serial.print("\tY = "); Serial.print(p.y);
//  Serial.print("\tPressure = "); Serial.println(p.z);  
// */
// 
//  // Scale from ~0->4000 to tft.width using the calibration #'s
//  p.x = map(p.x, TS_MINX, TS_MAXX, 0, tft.width());
//  p.y = map(p.y, TS_MINY, TS_MAXY, 0, tft.height());
//
//  /*
//  Serial.print("("); Serial.print(p.x);
//  Serial.print(", "); Serial.print(p.y);
//  Serial.println(")");
//  */
//
//  if(p.y < 90 && p.y >10){
//    setPressure(press_setPoint+0.2);
//    delay(5);
//  }
//
//  if(p.y < 310 && p.y >230){
//    setPressure(press_setPoint-0.2);
//    delay(5);
//  }
//  
}



void setSpeed(double input){

  if(input > MAX_SPEED)
    input = MAX_SPEED;

  if(input < MIN_SPEED)
    input = MIN_SPEED;
  
  speed_control = input;

  dac.setVoltage((int)(speed_control*4095/MAX_SPEED), false);
}

void setPressure(double input){

  if(input <= 10 && input >= 0)
    press_setPoint = input;

  tft.fillRect(10,90,220,140,BLACK);  
  tft.setCursor(20,140);
  tft.setTextColor(WHITE, BLACK);
  tft.setTextSize(8);
  tft.println(press_setPoint);
  
}

void updatePressure(){

double input, raw;

input = analogRead(Transducer);
raw = input*0.0165918-1.88442;

if(raw<0)
  pressure = 0;
else
  pressure = raw;
}

void updateDisplay(){

  int temp1 = round(temp);
  int temp2 = round(temp_setPoint);

  double press1 = round(10*(pressure))/10;
  double press2 = round(10*(press_setPoint))/10;

  tft.setTextColor(WHITE, BLACK);

  tft.setTextSize(2);
  tft.setCursor(75,137);
  tft.print("(");
  tft.print(press2,1);
  tft.println(" B)");
  tft.setCursor(240,137);
  tft.print("(");
  tft.print(temp2);
  tft.println(" C)");


  tft.setCursor(240,80);
  if(pressPID.isStopped()){
    tft.print("-----");
  }else{
    tft.print(" ");
    tft.print(temp1);
    tft.print(" C");
  }


  tft.setCursor(75,80);
  if(tempPID.isStopped()){
    tft.print("-----");
  }else{
    tft.print(" ");
    tft.print(press1,1);
    tft.println(" B");
  }
  
}
