#include <ESP8266WiFi.h>
#include <ESPAsyncTCP.h>
#include <Arduino_JSON.h>
#include "Base64.h"
#include "DHT.h" //DHT 라이브러리 호출
extern "C" {
#include <osapi.h>
#include <os_type.h>
}

#include "config.h"

DHT dht(5, DHT22); //DHT 설정(10,DHT22)

//int Mosfet1 = 12 ;
//int Mosfet2 = 14 ;
//int Mosfet3 = 16;
int Temperature = A0;
static os_timer_t intervalTimer;
String s = "";
String num = "";
String num2 = "";
String num3 = "";
char input[] = "";
float h = 0;
float t = 0;

float Val =0;
float val=0;
char message1[500];
char message2[500];

void demoParse() {
  Serial.println("parse");
  Serial.println("=====");

  JSONVar myObject = JSON.parse(s);

  // JSON.typeof(jsonVar) can be used to get the type of the var
  if (JSON.typeof(myObject) == "undefined") {
    Serial.println("Parsing input failed!");
    return;
  }

  Serial.print("JSON.typeof(myObject) = ");
  Serial.println(JSON.typeof(myObject)); // prints: object



  if (myObject.hasOwnProperty("POWER")) {  // on off 값 담기
    Serial.print("myObject[\"POWER\"] = ");

    Serial.println((const char*) myObject["POWER"]);
    num2 = (const char*) myObject["POWER"];
  }

  if (myObject.hasOwnProperty("VALUE")) {  // speed value 담기
    Serial.print("myObject[\"VALUE\"] = ");

    Serial.println((const char*) myObject["VALUE"]);
    num3 = (const char*) myObject["VALUE"];
  }

  //  // JSON vars can be printed using print or println
  //  Serial.print("myObject = ");
  //  Serial.println(myObject);
  //
  //  Serial.println();
}

static void replyToServer(void* arg) {
  AsyncClient* client = reinterpret_cast<AsyncClient*>(arg);

  // send reply
  if (client->space() > 32 && client->canSend()) {

    //char inputString[] = "{\"SENDER_TYPE\":\"HEATER\",\"MESSAGE_TYPE\":\"INIT\",\"NAME\":\"SENSORS\"}";
    char inputString[] = "{\"SENDER_TYPE\":\"COMPOUND\",\"MESSAGE_TYPE\":\"INIT\",\"NAME\":\"HEATER\",\"MAC_ADDRESS\":\"98:cd:ac:4d:6s:fg\"}";
    int inputStringLength = sizeof(inputString);
    int encodedLength = Base64.encodedLength(inputStringLength);
    char encodedString[encodedLength];

    Base64.encode(encodedString, inputString, inputStringLength);
    strcat(encodedString, "\n");
    sprintf(message1, encodedString);
    client->add(message1, strlen(message1));
    client->send();
  }
}
//------------------------------------------------------------------------------------
//데이터 전송부분  // dust_density = 미세먼지값  // h = 습도값 // t = 온도값
static void replyToValue(void* arg) {
  AsyncClient* client = reinterpret_cast<AsyncClient*>(arg);

  // send reply
  if (client->space() > 32 && client->canSend()) {
    //char message[100];
//    char* tt;
//    dtostrf(val,4,1,tt);
    //sprintf(tt, "%f", val); //dust_density
    //strcat(strcat("{\"SENDER_TYPE\":\"HEATER\",\"MESSAGE_TYPE\":\"MEASURE_DATA\",\"NAME\":\"DUST_SENSOR\",\"VALUE:\"", dust_num), "\"}\n");
    String ex ="{\"SENDER_TYPE\":\"COMPOUND\",\"MESSAGE_TYPE\":\"RESULT_DATA\",\"NAME\":\"HEATER\",\"MAC_ADDRESS\":\"98:cd:ac:4d:6s:fg\",\"TEMP\":\""+ String(val)+ "\"}";

    char inputString[400];
    ex.toCharArray(inputString, 400);

    //sprintf(message2, "{\"SENDER_TYPE\":\"SENSOR\",\"MESSAGE_TYPE\":\"MEASURE_DATA\",\"NAME\":\"BELT_TWO\",\"VALUE:\"DATA\"}\n");

    int inputStringLength = sizeof(inputString);
    int encodedLength = Base64.encodedLength(inputStringLength);
    char encodedString[encodedLength];
    Base64.encode(encodedString, inputString, inputStringLength);
    strcat(encodedString, "\n");
    sprintf(message2, encodedString);
    client->add(message2, strlen(message2));
    client->send();
  }
}
//---------------------------------------------------------------------
char* inputString;

/* event callbacks */
static void handleData(void* arg, AsyncClient* client, void *data, size_t len) {
  inputString = (char*) data;

  Serial.println(s);
  demoParse();
}




//-------------------------------
void onConnect(void* arg, AsyncClient* client) {
  Serial.printf("\n client has been connected to %s on port %d \n", SERVER_HOST_NAME, TCP_PORT);

  replyToServer(client);
}




void setup() {
  Serial.begin(9600);
  delay(20);
  
  WiFi.mode(WIFI_STA);
  WiFi.begin(SSID, PASSWORD);
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print('.');
    delay(500);
  }




  AsyncClient* client = new AsyncClient;
  //  client->onData(&handleData, client);
//  client->onData([](void * arg, AsyncClient * c, void * data, size_t len) {
//    s = "";
//    Serial.print("\r\nData: ");
//    Serial.println(len);
//    uint8_t * d = (uint8_t*)data;
//    for (size_t i = 0; i < len; i++)
//    {
//      s += (char)d[i];
//    }
//    Serial.println(s);
//    char buf[len];
//    s.toCharArray(buf, len);
//    char ss[Base64.decodedLength(buf, strlen(buf))];
//    Base64.decode(ss, buf, strlen(buf));
//    s = ss;
//    Serial.println(s);
//    demoParse();
//  }, client);
  client->onConnect(&onConnect, client);
  client->connect(SERVER_HOST_NAME, TCP_PORT);
  //Serial.println(s);
  os_timer_disarm(&intervalTimer);
  os_timer_setfn(&intervalTimer, &replyToValue, client);
  os_timer_arm(&intervalTimer, 10000, true);

//  dht.begin();
//  pinMode(Mosfet1, OUTPUT);
//  pinMode(Mosfet2, OUTPUT);
//  pinMode(Mosfet3, OUTPUT);
// 
}

void loop() {
  int readValue = analogRead(Temperature);
  Val = readValue*5.0 / 1024.0;
  val = Val*100-50;

  Serial.println(val);
  delay(50);

//  // put your main code here, to run repeatedly:
//  t = dht.readTemperature(); //온도값을 t에 저장
//  //  float f = dht.readTemperature(true);// 화씨 온도를 측정합니다.
//  //  float hif = dht.computeHeatIndex(f, h);
//  //  float hic = dht.computeHeatIndex(t, h, false);
//
//  Serial.print("Temperature: ");
//  Serial.print(t); //온도값 출력
//  Serial.println("C");
//
//  if (!num2.compareTo("ON")) {
//    if (!num3.compareTo("ZERO")) {
//      //t = 30
//      if (t < 30) {
//        digitalWrite(Mosfet1, HIGH);
//        digitalWrite(Mosfet2, HIGH);
//        digitalWrite(Mosfet3, HIGH);
//      }
//      else {
//        digitalWrite(Mosfet1, LOW);
//        digitalWrite(Mosfet2, LOW);
//        digitalWrite(Mosfet3, LOW);
//      }
//
//    }
//    //t = 35
//    if (!num3.compareTo("ONE")) {
//      if (35 > t) {
//        digitalWrite(Mosfet1, HIGH);
//        digitalWrite(Mosfet2, HIGH);
//        digitalWrite(Mosfet3, HIGH);
//      }
//      else {
//        digitalWrite(Mosfet1, LOW);
//        digitalWrite(Mosfet2, LOW);
//        digitalWrite(Mosfet3, LOW);
//      }
//    }
//    // t = 40
//    if (!num3.compareTo("TWO")) {
//      if (38 > t) {
//        digitalWrite(Mosfet1, HIGH);
//        digitalWrite(Mosfet2, HIGH);
//        digitalWrite(Mosfet3, HIGH);
//      }
//      else {
//        digitalWrite(Mosfet1, LOW);
//        digitalWrite(Mosfet2, LOW);
//        digitalWrite(Mosfet3, LOW);
//      }
//    }
//  }
//  else if (!num2.compareTo("OFF")) {
//    digitalWrite(Mosfet1, LOW);
//    digitalWrite(Mosfet2, LOW);
//    digitalWrite(Mosfet3, LOW);
  //}
}
