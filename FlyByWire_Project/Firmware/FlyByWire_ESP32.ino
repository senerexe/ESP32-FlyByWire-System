#include <LiquidCrystal.h>

// --- PIN TANIMLAMALARI ---
// Senin verdiğin bağlantı sırası: RS, E, D4, D5, D6, D7
LiquidCrystal lcd(23, 22, 21, 5, 27, 26);

const int buzzerPin = 4;   // Buzzer artı bacağı D4 (GPIO 4) pininde
const int v0Pin = 25;      // LCD Kontrast (V0) ucu D25 pininde
const int potPin = 33;     // Gaz (Throttle) Potansiyometresi
const int pitchPin = 35;   // Joystick Pitch (Yukarı/Aşağı)
const int rollPin = 34;    // Joystick Roll (Sağ/Sol)

void setup() {
  Serial.begin(9600); // C# Yer istasyonu ile aynı baud hızı
  
  pinMode(buzzerPin, OUTPUT);
  pinMode(v0Pin, OUTPUT);
  
  // --- LCD KONTRAST AYARI ---
  // D25 üzerinden kontrastı (V0) PWM ile ayarlıyoruz. 
  // Ekran boşsa veya çok koyuysa 120 değerini (0-255 arası) değiştirin.
  analogWrite(v0Pin, 120); 

  lcd.begin(16, 2);
  lcd.print("FBW SYSTEM V1.0");
  lcd.setCursor(0, 1);
  lcd.print("BOOTING...");
  
  delay(2000); 
  lcd.clear();
}

void loop() {
  // 1. SENSÖR VERİLERİNİ OKU (ESP32: 0-4095)
  int rawPitch = analogRead(pitchPin);
  int rawRoll = analogRead(rollPin);
  int rawThrottle = analogRead(potPin);

  // 2. VERİLERİ ÖLÇEKLENDİR (Mapping)
  int pitch = map(rawPitch, 0, 4095, 0, 180);
  int roll = map(rawRoll, 0, 4095, 0, 180);

  // 3. STALL KONTROLÜ (150 ve 30 sınırları)
  bool stallDurumu = (pitch > 150 || pitch < 30);

  // 4. FİZİKSEL VE GÖRSEL GERİ BİLDİRİM
  if (stallDurumu) {
    digitalWrite(buzzerPin, HIGH); // Buzzer öter
    
    lcd.setCursor(0, 0);
    lcd.print("!!! STALL !!!   ");
    lcd.setCursor(0, 1);
    lcd.print("PITCH: "); lcd.print(pitch); lcd.print(" deg  ");
  } 
  else {
    digitalWrite(buzzerPin, LOW); // Buzzer susar
    
    lcd.setCursor(0, 0);
    lcd.print("P:"); lcd.print(pitch);
    lcd.print(" R:"); lcd.print(roll);
    lcd.print("      "); 
    
    lcd.setCursor(0, 1);
    lcd.print("THRUST: %"); 
    lcd.print(map(rawThrottle, 0, 4095, 0, 100));
    lcd.print("    ");
  }

  // 5. C# YER İSTASYONUNA PAKET GÖNDER
  // FORMAT: $PITCH,ROLL,THROTTLE,STALL#
  Serial.print("$");
  Serial.print(pitch); Serial.print(",");
  Serial.print(roll); Serial.print(",");
  Serial.print(rawThrottle); Serial.print(",");
  Serial.print(stallDurumu ? "1" : "0");
  Serial.println("#");

  delay(50); // 20Hz yenileme hızı
}