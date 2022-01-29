
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

#define PID_MOTOR_OUTPUT_MIN 0
#define PID_MOTOR_OUTPUT_MAX 0.8
#define KP1 .01
#define KI1 0.04
#define KD1 0.5
double MOTOR_PID_setPoint = 0;
double MOTOR_PID_output = 0;

#define PID_HEATER_OUTPUT_MIN 0
#define PID_HEATER_OUTPUT_MAX 0.8
#define KP2 .01
#define KI2 0.04
#define KD2 0.5
double HEATER_PID_setPoint = 0;
double HEATER_PID_output = 0;

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
double temperature = 0;
int heater_control = 0;

double MAX_SPEED = 0.5;
double MIN_SPEED = 0;

GFXcanvas1 canvas(128, 32);

AutoPID motorPID(&pressure, &MOTOR_PID_setPoint, &MOTOR_PID_output, 0, 1023, KP1, KI1, KD1);
AutoPID heaterPID(&temperature, &HEATER_PID_setPoint, &HEATER_PID_output, 0, 255, KP2, KI2, KD2);

void setup(void) {
 // while (!Serial);     // used for leonardo debugging
 
  Serial.begin(9600);
  Serial.println("Motor Control");
  
  tft.begin();
  dac.begin(0x62);
  
  dac.setVoltage(speed_control, false);
  
  if (!ts.begin()) {
    Serial.println("Couldn't start touchscreen controller");
    while (1);
  }
  Serial.println("Touchscreen started");
  
  tft.fillScreen(ILI9341_BLACK);
  tft.fillRect(10,10,220,80,WHITE);
  tft.fillRect(10,230,220,80,WHITE);

  tft.setTextColor(BLACK, WHITE);
  tft.setTextSize(6);
  tft.setCursor(50,30);
  tft.println("FAST");
  tft.setCursor(50,250);
  tft.println("SLOW");


  
//  canvas.println("I like cake");
//  tft.drawBitmap(100, 160, canvas.getBuffer(), 128, 32, WHITE, BLACK); 

  motorPID.setTimeStep(50);

  setSpeed(0);

}


void loop()
{
  // See if there's any  touch data for us
  if (!ts.touched()) {
    updatePressure();
    motorPID.run();
    setSpeed(MOTOR_PID_output);
    Serial.println(speed_control);
    return;
  }

  // Retrieve a point  
  TS_Point p = ts.getPoint();
  
 /*
  Serial.print("X = "); Serial.print(p.x);
  Serial.print("\tY = "); Serial.print(p.y);
  Serial.print("\tPressure = "); Serial.println(p.z);  
 */
 
  // Scale from ~0->4000 to tft.width using the calibration #'s
  p.x = map(p.x, TS_MINX, TS_MAXX, 0, tft.width());
  p.y = map(p.y, TS_MINY, TS_MAXY, 0, tft.height());

  /*
  Serial.print("("); Serial.print(p.x);
  Serial.print(", "); Serial.print(p.y);
  Serial.println(")");
  */

  if(p.y < 90 && p.y >10){
    setPressure(MOTOR_PID_setPoint+0.2);
    delay(5);
  }

  if(p.y < 310 && p.y >230){
    setPressure(MOTOR_PID_setPoint-0.2);
    delay(5);
  }
  
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
    MOTOR_PID_setPoint = input;

  tft.fillRect(10,90,220,140,BLACK);  
  tft.setCursor(20,140);
  tft.setTextColor(WHITE, BLACK);
  tft.setTextSize(8);
  tft.println(MOTOR_PID_setPoint);
  
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
