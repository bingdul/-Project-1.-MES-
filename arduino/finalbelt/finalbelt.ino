#include <ESP8266WiFi.h>
#include <ESPAsyncTCP.h>
#include <Arduino_JSON.h>
#include "Base64.h"
extern "C" {
#include <osapi.h>
#include <os_type.h>
}

#include "config.h"

uint8_t MAC_array[6];
char MAC_char[18];

static os_timer_t intervalTimer;
String s = "";
String num = "";
String num2 = "";
String num3 = "";
char input[] = "";
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
char message1[500];
char message2[500];
static void replyToServer(void* arg) {
  AsyncClient* client = reinterpret_cast<AsyncClient*>(arg);
  //
  //  // send reply
  if (client->space() > 32 && client->canSend()) {
    //
    //    char inputString[] = "{\"SENDER_TYPE\":\"ACTUATOR\",\"MESSAGE_TYPE\":\"INIT\",\"NAME\":\"BELT_ONE\",\"MAC_ADDRESS\":\"98:cd:ac:29:c3:e8\"}";
    ////    char inputString[] = "{\"SENDER_TYPE\":\"ACTUATOR\",\"MESSAGE_TYPE\":\"INIT\",\"NAME\":\"BELT_ONE\",\"MAC_ADDRESS\":\"";
    ////    char str2[] = "\"}";
    ////    strcat(strcat(inputString, MAC_char), str2);
    //
    //
    //
    //    int inputStringLength = sizeof(inputString);
    //    int encodedLength = Base64.encodedLength(inputStringLength);
    //    char encodedString[encodedLength];
    //
    //    Base64.encode(encodedString, inputString, inputStringLength);
    //    strcat(encodedString, "\n");
    //    sprintf(message, encodedString);
    client->add(message1, strlen(message1));
    client->send();
  }
}

static void aliveToServer(void* arg) {
  AsyncClient* client = reinterpret_cast<AsyncClient*>(arg);
  // send reply
  if (client->space() > 32 && client->canSend()) {

    //    char inputString[] = "{\"SENDER_TYPE\":\"ACTUATOR\",\"MESSAGE_TYPE\":\"ALIVE\",\"MAC_ADDRESS\":\"98:cd:ac:29:c3:e8\"}";
    ////    char inputString[] = "{\"SENDER_TYPE\":\"ACTUATOR\",\"MESSAGE_TYPE\":\"ALIVE\",\"MAC_ADDRESS\":\"";
    ////    char str2[] = "\"}";
    ////    strcat(strcat(inputString, MAC_char), str2);
    //    //char inputString[sizeof(str1)];
    //    //inputString = str1;
    //
    //    int inputStringLength = sizeof(inputString);
    //    int encodedLength = Base64.encodedLength(inputStringLength);
    //    char encodedString[encodedLength];
    //    Base64.encode(encodedString, inputString, inputStringLength);
    //    strcat(encodedString, "\n");
    //    sprintf(message, encodedString);
    //sprintf(message, "{\"SENDER_TYPE\":\"ACTUATOR\",\"MESSAGE_TYPE\":\"ALIVE\"}\n");
    client->add(message2, strlen(message2));
    client->send();
  }
}
char* inputString;

/* event callbacks */
static void handleData(void* arg, AsyncClient* client, void *data, size_t len) {
  inputString = (char*) data;

  //Base64.decode(s, inputString, 100);



  //sprintf(s, data);
  //s = String((char*)data);
  //Serial.println("가공1:" + decodedString);
  Serial.println(s);
  //input = s;
  demoParse();
  //  num = s.substring(0, s.indexOf("}") + 1);
  //  Serial.println("dong =" + num);
  //  char message[32];
  //  sprintf(message, "%s", s);
  //  client->add(message, strlen(message));
  //  client->send();
  //os_timer_arm(&intervalTimer, 2000, true); // schedule for reply to server at next 2s
}

void onConnect(void* arg, AsyncClient* client) {
  Serial.printf("\n client has been connected to %s on port %d \n", SERVER_HOST_NAME, TCP_PORT);

  replyToServer(client);
}

//
//void findMac() {
//  Serial.print("MAC[STA] ->");
//  WiFi.macAddress(MAC_array);
//  for (int i = 0; i < sizeof(MAC_array); ++i) {
//    sprintf(MAC_char, "%s%02x:", MAC_char, MAC_array[i]);
//  }
//  Serial.println(MAC_char);
//}
static void replyMethod() {
  //REPLY
  char inputString[] = "{\"SENDER_TYPE\":\"ACTUATOR\",\"MESSAGE_TYPE\":\"INIT\",\"NAME\":\"BELT_ONE\",\"MAC_ADDRESS\":\"98:cd:ac:29:c3:e8\"}";
  //    char inputString[] = "{\"SENDER_TYPE\":\"ACTUATOR\",\"MESSAGE_TYPE\":\"INIT\",\"NAME\":\"BELT_ONE\",\"MAC_ADDRESS\":\"";
  //    char str2[] = "\"}";
  //    strcat(strcat(inputString, MAC_char), str2);



  int inputStringLength = sizeof(inputString);
  int encodedLength = Base64.encodedLength(inputStringLength);
  char encodedString[encodedLength];

  Base64.encode(encodedString, inputString, inputStringLength);
  strcat(encodedString, "\n");
  sprintf(message1, encodedString);
}
static void aliveMethod() {
  //
  char inputString2[] = "{\"SENDER_TYPE\":\"ACTUATOR\",\"MESSAGE_TYPE\":\"ALIVE\",\"MAC_ADDRESS\":\"98:cd:ac:29:c3:e8\"}";
  //    char inputString[] = "{\"SENDER_TYPE\":\"ACTUATOR\",\"MESSAGE_TYPE\":\"ALIVE\",\"MAC_ADDRESS\":\"";
  //    char str2[] = "\"}";
  //    strcat(strcat(inputString, MAC_char), str2);
  //char inputString[sizeof(str1)];
  //inputString = str1;

  int inputStringLength = sizeof(inputString2);
  int encodedLength = Base64.encodedLength(inputStringLength);
  char encodedString[encodedLength];
  Base64.encode(encodedString, inputString2, inputStringLength);
  strcat(encodedString, "\n");
  sprintf(message2, encodedString);
}
void setup() {
  Serial.begin(9600);
  delay(20);

  pinMode(12, OUTPUT);              // 5번핀을 출력모드로 설정합니다.
  pinMode(14, OUTPUT);

  replyMethod();
  aliveMethod();



  // connects to access point
  WiFi.mode(WIFI_STA);
  WiFi.begin(SSID, PASSWORD);
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print('.');
    delay(500);
  }

  AsyncClient* client = new AsyncClient;
  //  client->onData(&handleData, client);
  client->onData([](void * arg, AsyncClient * c, void * data, size_t len) {
    s = "";
    Serial.print("\r\nData: ");
    Serial.println(len);
    uint8_t * d = (uint8_t*)data;
    for (size_t i = 0; i < len; i++)
    {
      s += (char)d[i];
    }
    Serial.println(s);
    char buf[len];
    s.toCharArray(buf, len);
    char ss[Base64.decodedLength(buf, strlen(buf))];
    Base64.decode(ss, buf, strlen(buf));
    s = ss;
    Serial.println(s);
    demoParse();
  }, client);
  client->onConnect(&onConnect, client);
  client->connect(SERVER_HOST_NAME, TCP_PORT);
  //Serial.println(s);
  os_timer_disarm(&intervalTimer);
  os_timer_setfn(&intervalTimer, &aliveToServer, client);
  os_timer_arm(&intervalTimer, 10000, true);
}

void loop() {
  //Serial.println(s);
  if (!num2.compareTo("ON")) {
    if (!num3.compareTo("ZERO")) {
      analogWrite(12, 0);
      analogWrite(14, 0);
    }
    if (!num3.compareTo("ONE")) {
      analogWrite(12, 0);
      analogWrite(14, 180);
    }
    if (!num3.compareTo("TWO")) {
      analogWrite(12, 0);
      analogWrite(14, 255);
    }
  }
  else if (!num2.compareTo("OFF")) {
    analogWrite(12, 0);
    analogWrite(14, 0);
  }
}
