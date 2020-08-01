#include <SoftwareSerial.h>
#include "dht.h"
#define dht_apin 9 // Analog Pin sensor is connected to
 
dht DHT;
 
SoftwareSerial EEBlue(2,4); // RX | TX

//sensors data
int sendByte=0;
int humidity=0;
int temperature=0;

void setup()

{

Serial.begin(57600);
EEBlue.begin(9600); //Baud Rate for command Mode. 
Serial.println("Enter AT commands!");

}

void loop()
{
  DHT.read11(dht_apin);

//// Feed all data from termial to bluetooth

// Feed any data from bluetooth to Terminal.
//if (Serial.available()){
  sendByte=Serial.read();//command START
//  EEBlue.write(sendByte);
  EEBlue.print(DHT.humidity);
  Serial.print(DHT.temperature);
  EEBlue.write("%");
  EEBlue.print(DHT.temperature);
  EEBlue.write("C");
  
//Serial.println(sendByte,DEC);
//}
delay(5000);
}
