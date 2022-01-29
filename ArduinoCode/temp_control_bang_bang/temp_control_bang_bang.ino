#include <Adafruit_GFX.h>    // Core graphics library
#include <SPI.h>
#include <Wire.h>
#include <Adafruit_ILI9341.h>
#include <Adafruit_STMPE610.h>
#include <Adafruit_TFTLCD.h> // Hardware-specific library
#include <AutoPID.h>
#include <OneWire.h>
#include <DallasTemperature.h>
#include <Adafruit_MCP4725.h>

#define setPoint 93
#define ONE_WIRE_BUS 2
#define heat_control 5
#define valve 3

// Setup a oneWire instance to communicate with any OneWire device
OneWire oneWire(ONE_WIRE_BUS); 
DallasTemperature sensors(&oneWire);

boolean heater = true;
float temp;

void setup(void)
{
  sensors.begin();  // Start up the library
  Serial.begin(9600);

  Adafruit_MCP4725 dac;
  dac.begin(0x62);  
  dac.setVoltage(1600, false);

  pinMode(valve, OUTPUT);
  pinMode(heat_control, OUTPUT);
  
  digitalWrite(valve, LOW);
  
}

void loop(void)
{ 
  // Send the command to get temperatures
  sensors.requestTemperatures(); 

  temp = sensors.getTempCByIndex(0);

  //print the temperature in Celsius
  Serial.print("Temperature: ");
  Serial.print(temp);
  Serial.println(" C");


  if(heater && temp > (setPoint-0.25))
    heater = false;

  if(!heater && temp < (setPoint-0.25))
    heater = true;

  if(heater){
    Serial.println("Heater ON");
    digitalWrite(heat_control, HIGH);
  } else{
    Serial.println("Heater OFF");
    digitalWrite(heat_control, LOW);
  }
}
