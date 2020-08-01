#include <SoftwareSerial.h>
#define USE_ARDUINO_INTERRUPTS true // Set-up low-level interrupts for most acurate BPM math.
#include <PulseSensorPlayground.h>  // Includes the PulseSensorPlayground Library.
#include "dht.h"

#define dht_apin 9               // humidity and temperature
#define READ_DATA_INTERVAL 1000 //miliseconds
#define SEND_DATA_INTERVAL 2000
#define BPM_READ_INTERVAL 100

String data_TH = "";
String data_Pulse = "";
String data_ECG;

//pulse sensor nu e ala de lab

int sensorPin = 0;
double alpha = 0.75;
int period = 100;
double change = 0.0;
double minval = 0.0;

/*GLOBAL VARIABLES*/
dht DHT;
double myBPM = 0;
int EKG = 0;
int Threshold = 550;

double myBPM_avg = 0;
float EKG_avg = 0;
double humidity_avg = 0;
double temp_avg = 0;

int readingsCounter = 3; // 3 readings allowed if send interval is 30 seconds
int readingsPulse = 0;
//software timers for scheduling

unsigned long timer_10s = 0;
unsigned long timer_30s = 0;
unsigned long timer_100ms = 0;

/*PINOUT*/
const byte BTpin = 6;
boolean BTconnected = false;
SoftwareSerial EEBlue(2, 4); // RX | TX

void setup()
{
  //begin serial communication

  //Serial.begin(57600); //debug level over 9000
  EEBlue.begin(9600); //REMEBER 9600 HC 05  ....115200 MATE SILVER AD-15
}

void loop()
{
  // Serial.println(time_previous);
  Serial.println("CYCLE MEASUREMENT START ! ");

  //wait 10 seconds then read data from sensors
  if (millis() > timer_100ms + BPM_READ_INTERVAL)
  {
    timer_100ms = millis();
    readingsPulse++;

    static double oldValue = 0;
    static double oldChange = 0;

    int rawValue = analogRead(sensorPin);
    double value = alpha * oldValue + (1 - alpha) * rawValue;
    oldValue = value;
    value=value/10;
    //myBPM_avg=myBPM_avg+value;

    if (readingsPulse < 20)
    {
      String pct2;
      pct2 = ":";
      //data_Pulse = data_Pulse + value + pct2;
      data_Pulse = value;
    }
    else
    {
    }
  }

  if (millis() > timer_10s + READ_DATA_INTERVAL)
  {
    timer_10s = millis();

    // READ HUMIDITY + TEMPERATURE
    DHT.read11(dht_apin);
    humidity_avg = DHT.humidity;
    temp_avg = DHT.temperature;
  }

  //Send data to Android interval 30 seconds 
  if ((millis() > timer_30s + SEND_DATA_INTERVAL) && readingsPulse > 19)
  {

    readingsPulse = 0;
    timer_30s = millis();

    //myBPM_avg=myBPM_avg / 3000;

    //send average readings
    String data;
    String puncte2;
    puncte2 = ":";

    data = "ds";
    data_TH = data + puncte2 + humidity_avg + puncte2 + temp_avg + puncte2;

    //EEBlue.print(data_TH);

    String pulse;
    pulse = "pulse:";
    //EEBlue.print(pulse+data_Pulse);

    String data_tx;
    data_tx = "start" + data_TH + pulse + data_Pulse + "end";

    EEBlue.print("d" + data_TH);
    EEBlue.flush();
    delay(20);
    EEBlue.print(data_Pulse + ":f");
    EEBlue.flush();
    
    Serial.println(data_tx);
    data_tx = "";
    data_TH = "";
    data_Pulse = "";

    EEBlue.flush();

    //EEBlue.write("%");
    //   EEBlue.write(":");
    //
    //   EEBlue.print(temp_avg);
    //   //EEBlue.write("C");
    //   EEBlue.write(":");
    //   EEBlue.write("puls");
    //   EEBlue.print(myBPM_avg);
    //   EEBlue.write(":");
    //   EEBlue.write("end");

    //  EEBlue.print(EKG_avg);
    //  EEBlue.write(":");

    // EEBlue.print(temperature);
    // EEBlue.write(":");

    // EEBlue.print(humidity);
    // EEBlue.write(":");

    // EEBlue.print(myBPM);
    // EEBlue.write(":");

    // EEBlue.print(EKG);
    // EEBlue.write(":");
  }
  Serial.println("CYCLE MEASUREMENT END ! ");
}
