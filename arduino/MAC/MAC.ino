#include <ESP8266WiFi.h>

uint8_t MAC_array[6];
char MAC_char[18];


void setup() {
  char ser_tx_buff[100];

  Serial.begin(115200);

  Serial.println();
  // put your setup code here, to run once:

  Serial.print("MAC[STA] ->");
  WiFi.macAddress(MAC_array);
  for (int i = 0; i < sizeof(MAC_array); ++i) {
    sprintf(MAC_char, "%s%02x:", MAC_char, MAC_array[i]);
  }
  Serial.println(MAC_char);

  MAC_char[0] = 0;
  Serial.print("MAC[SOFTAP] ->");
  WiFi.softAPmacAddress(MAC_array);
  for (int i = 0; i < sizeof(MAC_array); ++i) {
    sprintf(MAC_char, "%s%02x:", MAC_char, MAC_array[i]);
  }
  Serial.println(MAC_char);
}

void loop() {
  // put your main code here, to run repeatedly:
}
