
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

#define OUTPUT_MIN 0
#define OUTPUT_MAX 0.8
#define KP .01
#define KI 0.04
#define KD 0.5
double PID_setPoint = 0;
double PID_Output = 0;


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

double MAX_SPEED = 0.5;
double MIN_SPEED = 0;

GFXcanvas1 canvas(128, 32);

AutoPID myPID(&pressure, &PID_setPoint, &PID_Output, 0, 1023, KP, KI, KD);

void setup(void) {
 
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

  myPID.setTimeStep(50);

  setSpeed(0);

}


void loop()
{
  // See if there's any  touch data for us
  if (!ts.touched()) {
    updatePressure();
    myPID.run();
    setSpeed(PID_Output);
    Serial.print("PID Output: ");
    Serial.println(PID_Output);
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
    setPressure(PID_setPoint+0.2);
    delay(5);
  }

  if(p.y < 310 && p.y >230){
    setPressure(PID_setPoint-0.2);
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
    PID_setPoint = input;

  tft.fillRect(10,90,220,140,BLACK);  
  tft.setCursor(20,140);
  tft.setTextColor(WHITE, BLACK);
  tft.setTextSize(8);
  tft.println(PID_setPoint);
  
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
