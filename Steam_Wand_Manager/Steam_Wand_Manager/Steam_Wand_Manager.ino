/*************************************************** 
  This is a library for the Adafruit PT100/P1000 RTD Sensor w/MAX31865

  Designed specifically to work with the Adafruit RTD Sensor
  ----> https://www.adafruit.com/products/3328

  This sensor uses SPI to communicate, 4 pins are required to  
  interface
  Adafruit invests time and resources providing this open source code, 
  please support Adafruit and open-source hardware by purchasing 
  products from Adafruit!

  Written by Limor Fried/Ladyada for Adafruit Industries.  
  BSD license, all text above must be included in any redistribution
 ****************************************************/

#include <Adafruit_MAX31865.h>

// Use software SPI: CS, DI, DO, CLK
Adafruit_MAX31865 thermo = Adafruit_MAX31865(10, 11, 12, 13);
// use hardware SPI, just pass in the CS pin
//Adafruit_MAX31865 thermo = Adafruit_MAX31865(10);

// The value of the Rref resistor. Use 430.0 for PT100 and 4300.0 for PT1000
#define RREF      430.0
// The 'nominal' 0-degrees-C resistance of the sensor
// 100.0 for PT100, 1000.0 for PT1000
#define RNOMINAL  100.0

#define heater_pin 6
#define deadband 0
#define setPoint 0

boolean heating = false;
float hex_temp;

int counter = 1;

void setup() {
  Serial.begin(115200);
  Serial.println("Adafruit MAX31865 PT100 Sensor Test!");

  thermo.begin(MAX31865_3WIRE);  // set to 2WIRE or 4WIRE as necessary

  pinMode(heater_pin, OUTPUT);
  digitalWrite(heater_pin, HIGH);
  
}


void loop() {
  hex_temp = thermo.temperature(RNOMINAL, RREF);

  if(!heating){
    if(hex_temp < setPoint){
      heating = true;
    }
  }else if(hex_temp > setPoint+deadband){
    heating = false;
  }
  
  Serial.print("Temperature = "); Serial.println(hex_temp);
  Serial.print("Heating = "); Serial.println(heating);
  
  Serial.println("");

  counter++;

  if(heating){
    if(counter%2 == 0){
      digitalWrite(heater_pin, HIGH);
    }
    else{
      digitalWrite(heater_pin, LOW);
    }
    
  }else{
    digitalWrite(heater_pin, LOW);
  }
  
}
