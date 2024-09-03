// Library untuk membaca sensor max6675
#include "max6675.h"

// Inisialisasi ThermoCouple
#define thermo_so_pin  11
#define thermo_cs_pin  12
#define thermo_sck_pin 13
MAX6675 thermocouple(thermo_sck_pin, thermo_cs_pin, thermo_so_pin);

// Inisialisasi Pinout
const int pinLight     = 8; // Active High    
const int pinMedium    = 9; // Active High
const int pinDark      = 10; // Active High
const int pinFinish    = 4; // Active High    
const int pinProses    = 5; // Active High
const int pinFan       = 6; // Active High    
const int pinHeater    = 3; // Active High
const int pinMotor     = 7 ;// Active High

void setup()
{
// Setup Serial
  Serial.begin(9600);

// Setup Pinout
  pinMode(pinLight, INPUT_PULLUP);
  pinMode(pinMedium, INPUT_PULLUP);
  pinMode(pinDark, INPUT_PULLUP);  
  pinMode(pinFinish, OUTPUT);
  pinMode(pinProses, OUTPUT);
  pinMode(pinFan, OUTPUT);
  pinMode(pinHeater, OUTPUT);
  pinMode(pinMotor, OUTPUT);

// Matikan semua aktuator
  digitalWrite(pinFinish, HIGH);
  digitalWrite(pinProses, HIGH);
  digitalWrite(pinFan, LOW);
  digitalWrite(pinHeater, LOW);
  digitalWrite(pinMotor, LOW);
}

#define msglength 40
bool started = false, ended = false;
char incomingByte ;
char msg[msglength];
byte bitPosition;
unsigned long previousMillis = 0;
#define interval 1000
float suhu;
uint16_t TIMEROAST = 0;
uint16_t targettime = 0, WaitFan = 0, suhuint = 0;
bool roast = false, lightroast = false, mediumroast = false, darkroast = false;
bool motoron = false, heateron = false, finishroast = false, FanStay = false;
char dataa[msglength];
char str_temp[6];
void loop()
{
// Function cek penekanan tombol
  CekTombol();

// Function Cek komunikasi serial
  if(Serial.available() > 0)
  {
    incomingByte = Serial.read();
// Jika data yang masuk diawali dengan karakter '#'
    if ((incomingByte == '#'))
    {
      if(incomingByte == '#')
      {
        started = true;
        bitPosition = 0;
        msg[bitPosition] = '\0';
      }
    }
// Jika data yang masuk diakhiri dengan karakter '*'
    else if ((incomingByte == '*'))
    { ended = true; }
    else
    {
      if (bitPosition < msglength)
      {
        msg[bitPosition] = incomingByte;
        bitPosition++;
        msg[bitPosition] = '\0';
      }
    }    
  }

// Jika penanda awal dan akhir sesuai
  if (started && ended)
  {
    if(msg[0] == '1') { targettime = 30*60; lightroast = true; mediumroast = false; darkroast = false; } // Jika inputan yang diterima adalah angka 1, maka mode lightroast
    else if(msg[0] == '2') { targettime = 30*60; lightroast = false; mediumroast = true; darkroast = false; } // Jika inputan yang diterima adalah angka 2, maka mode mediumroast
    else if(msg[0] == '3') { targettime = 30*60; lightroast = false; mediumroast = false; darkroast = true; } // Jika inputan yang diterima adalah angka 3, maka mode darkroast
    else if(msg[0] == '4') { StopRoast(); } // Jika inputan yang diterima adalah angka 4, maka roast berhenti
    else if(msg[0] == '5') { roast = true; } // Jika inputan yang diterima adalah angka 5, maka mode roast mulai

// Hapus penanda awal dan akhir untuk menerima inputan baru
    started = false;
    ended = false;
  }

  unsigned long currentMillis = millis();
// Jika sudah 1 detik
  if (currentMillis - previousMillis >= interval)
  {
    previousMillis = currentMillis;
    suhu = thermocouple.readCelsius();
// Jika sedang roasting kopi
    if(roast)
    {
// Jika waktu roasting masih kurang dari maksimum waktu roasting
      if(TIMEROAST < targettime)
      {
        TIMEROAST++;
// Jika motor ON, maka menghidupkan motor, pemanas, fan dan LED proses dinyalakan dan LED selesai dimatikan        
        if(!motoron)
        {
          digitalWrite(pinMotor, HIGH);
          digitalWrite(pinHeater, HIGH);
          digitalWrite(pinFan, HIGH);
          motoron = true;
          heateron = true;
        }
        digitalWrite(pinProses, LOW); digitalWrite(pinFinish, HIGH);
// Cek suhu roast setiap 1 detik
        CekSuhu(suhu);
      }
// Jika waktu roasting sudah melebihi waktu maksimum roasting, maka menghentikan proses roasting
      else
      {
        StopRoast();
      }
    }
    
// Jika Fan menyala
    if(FanStay)
    {
      WaitFan--;
      if(WaitFan == 0)
      { digitalWrite(pinFan, LOW); FanStay = false; WaitFan = 300; }
    }

// Jika roasting telah selesai
    if(finishroast)
    {
      suhuint = suhu; delay(10);
      if(suhuint < 40)
      {
        digitalWrite(pinProses, HIGH); digitalWrite(pinFinish, LOW);
        digitalWrite(pinMotor, LOW);
        finishroast = false; roast = false; FanStay = true; WaitFan = 300;
      }
    }
    dtostrf(suhu, 4, 2, str_temp); delay(5);
// Kirim data ke PC via serial komunikasi
    sprintf(dataa, "DATA|%d|%s", TIMEROAST, str_temp); delay(5);
    Serial.println(dataa);
  }
}

// Function cek suhu roaster
#define AmbangAtas 15
#define AmbangBawah 5
void CekSuhu(int temp)
{
// Jika roaster mode lightroast
  if(lightroast)
  {
    if(temp > (205 - AmbangAtas))
    { 
      if(heateron) { digitalWrite(pinHeater, LOW); heateron = false; }
    }
    else if(temp < (180 + AmbangBawah)) 
    {
      if(!heateron) { digitalWrite(pinHeater, HIGH); heateron = true;}
    }
  }
// Jika roaster mode mediumroast
  else if(mediumroast)
  {
    if(temp > (220 - AmbangAtas))
    { 
      if(heateron) { digitalWrite(pinHeater, LOW); heateron = false; }
    }
    else if(temp < (210 + AmbangBawah))
    {
      if(!heateron) { digitalWrite(pinHeater, HIGH); heateron = true;}
    }
  }
// Jika roaster mode darkroast
  else if(darkroast)
  {
    if(temp > (240 - AmbangAtas))
    { 
      if(heateron) { digitalWrite(pinHeater, LOW); heateron = false; }
    }
    else if(temp < (225 + AmbangBawah))
    {
      if(!heateron) { digitalWrite(pinHeater, HIGH); heateron = true;}
    }
  }
}

// Function untuk menghentikan proses roast
void StopRoast()
{
  roast = false;
  lightroast = false;
  mediumroast = false;
  darkroast = false;
  heateron = false;
  finishroast = true;
  digitalWrite(pinHeater, LOW);
}

// Function untuk cek penekanan tombol
uint8_t LightState, LastLightState = 0;
uint8_t MediumState, LastMediumState = 0;
uint8_t DarkState, LastDarkState = 0;
void CekTombol()
{
  LightState = digitalRead(pinLight);
  MediumState = digitalRead(pinMedium);
  DarkState = digitalRead(pinDark);

// Jika yang ditekan mode lightroast, kirim data SET|1 mode lightroast ke PC
  if(LightState != LastLightState)
  {
    if(LightState == LOW && !lightroast)
    {
      lightroast = true; mediumroast = false; darkroast = false;
      Serial.print(F("SET|1"));
    }
  }
  LastLightState = LightState;

// Jika yang ditekan mode lightroast, kirim data SET|2 mode mediumroast ke PC
  if(MediumState != LastMediumState)
  {
    if(MediumState == LOW && !mediumroast)
    {
      lightroast = false; mediumroast = true; darkroast = false;
      Serial.print(F("SET|2"));
    }
  }
  LastMediumState = MediumState;

// Jika yang ditekan mode lightroast, kirim data SET|3 mode darkroast ke PC
  if(DarkState != LastDarkState)
  {
    if(DarkState == LOW && !darkroast)
    {
      lightroast = false; mediumroast = false; darkroast = true;
      Serial.print(F("SET|3"));
    }
  }
  LastDarkState = DarkState;
}
