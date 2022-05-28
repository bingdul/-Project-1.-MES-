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


int h;
int t = 0;
static os_timer_t intervalTimer;
String s = "";
String num = "";
String num2 = "";
String num3 = "";
char input[] = "";
char message1[500];
char message2[500];
int Gas = 0;
int GasPin = A0;

//----------------
static void replyToServer(void* arg) {
  AsyncClient* client = reinterpret_cast<AsyncClient*>(arg);

  // send reply
  if (client->space() > 32 && client->canSend()) {

    //char inputString[] = "{\"SENDER_TYPE\":\"SENSOR\",\"MESSAGE_TYPE\":\"INIT\",\"NAME\":\"SENSORS\"}";
    char inputString[] = "{\"SENDER_TYPE\":\"SENSOR\",\"MESSAGE_TYPE\":\"INIT\",\"NAME\":\"GAS_SENSOR\",\"MAC_ADDRESS\":\"98:cd:ac:3c:hj:9g\"}";
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
    //    char* dust_num;
    //    sprintf(dust_num, "%d", t); //dust_density
    //strcat(strcat("{\"SENDER_TYPE\":\"SENSOR\",\"MESSAGE_TYPE\":\"MEASURE_DATA\",\"NAME\":\"DUST_SENSOR\",\"VALUE:\"", dust_num), "\"}\n");
    String ex = "{\"SENDER_TYPE\":\"SENSOR\",\"MESSAGE_TYPE\":\"MEASURE_DATA\",\"NAME\":\"GAS_SENSOR\",\"MAC_ADDRESS\":\"98:cd:ac:3c:hj:9g\",\"VALUE\":\"" + String(Gas) + "\"}";
    //Serial.println("GAS : "Gas);
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

//---------------------

void onConnect(void* arg, AsyncClient* client) {
  Serial.printf("\n client has been connected to %s on port %d \n", SERVER_HOST_NAME, TCP_PORT);

  replyToServer(client);
}


void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  delay(20);
  WiFi.mode(WIFI_STA);
  WiFi.begin(SSID, PASSWORD);
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print('.');
    delay(500);
  }
  pinMode(GasPin, INPUT);
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
    //demoParse();
  }, client);
  client->onConnect(&onConnect, client);
  client->connect(SERVER_HOST_NAME, TCP_PORT);
  //Serial.println(s);
  os_timer_disarm(&intervalTimer);
  os_timer_setfn(&intervalTimer, &replyToValue, client);
  os_timer_arm(&intervalTimer, 10000, true);
}

void loop() {
  Gas = analogRead(GasPin);
  Serial.println("Gas : " + Gas);
  delay(10);
}
