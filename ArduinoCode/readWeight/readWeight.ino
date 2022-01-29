#include <Ewma.h>
#include <EwmaT.h>

/*!
 * @file readWeight.ino
 * @brief Get the weight of the object, press the RST button on the module, the 
 * @n program will automatically remove the skin
 * @copyright  Copyright (c) 2010 DFRobot Co.Ltd (http://www.dfrobot.com)
 * @licence     The MIT License (MIT)
 * @author [fengli](li.feng@dfrobot.com)
 * @version  V1.0
 * @date  2020-12-26
 * @get from https://www.dfrobot.com
 * @https://github.com/DFRobot/DFRobot_HX711_I2C
*/

#include <DFRobot_HX711_I2C.h>

double weight = 0;
double current = 0;
double last = 0;

Ewma filteredWeight(0.2);

/*!
 * @brief Constructor 
 * @param pWire I2c controller
 * @param addr  I2C address(0x64/0x65/0x660x67)
 */
DFRobot_HX711_I2C MyScale(&Wire,0x64);

void setup() {
  Serial.begin(115200);
  while (!MyScale.begin()) {
    Serial.println("The initialization of the chip is failed, please confirm whether the chip connection is correct");
    delay(1000);
  }
  //Manually set the calibration values
  MyScale.setCalibration(2025.37);
  //remove the peel
  MyScale.peel();

  pinMode(13, OUTPUT);
}

void loop() {
  // Get the weight of the object
  weight = MyScale.readWeight(1);
  last = current;
  current = millis();

  float fweight = filteredWeight.filter(weight);
  
  Serial.print("weight is: ");
  Serial.print(fweight, 2);
  Serial.println(" g");
  Serial.print("Rate: ");
  Serial.print((1000/(current-last)),2);
  Serial.println(" HZ");

  digitalWrite(13, HIGH);
  
}
