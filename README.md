# ESP32-FlyByWire-System
Proje Adı: ESP32 Tabanlı Fly-By-Wire Uçuş Kontrol Sistemi
Özet: Bu proje, modern jet uçaklarında kullanılan Fly-By-Wire teknolojisinin mikrodenetleyici tabanlı bir prototipidir. Pilotun joystick hareketleri ESP32 tarafından dijital veriye dönüştürülür, yazılımsal filtrelerden geçirilir ve servo motorlara iletilir. Aynı zamanda gerçek zamanlı uçuş verileri C# ile geliştirilen yer istasyonuna aktarılır.
<img width="722" height="440" alt="Ekran görüntüsü 2026-04-07 190654" src="https://github.com/user-attachments/assets/d61361d6-e710-4ab1-9133-6aa17396dbcb" />
<img width="698" height="468" alt="Ekran görüntüsü 2026-04-07 190729" src="https://github.com/user-attachments/assets/2cd3b2ee-6bac-4c8c-9f3d-58d86635c06c" />
<img width="673" height="463" alt="Ekran görüntüsü 2026-04-07 190746" src="https://github.com/user-attachments/assets/772570ed-03e2-496a-ad2e-2c9f106c4a4a" />
<img width="1332" height="690" alt="Ekran görüntüsü 2026-04-07 193523" src="https://github.com/user-attachments/assets/bd35cc8c-6a3c-43a0-83ea-ca374fabbd5c" />

Öne Çıkan Özellikler:

Akıllı Kontrol: Pitch ve Roll eksenlerinde 0-180 derece hassas kontrol.

Stall Koruma Sistemi: Kritik açılarda (Pitch > 150) buzzer ve LCD üzerinden görsel/işitsel uyarı.

Telemetri: C# arayüzü üzerinden anlık veri takibi ve radar simülasyonu.

Donanım Entegrasyonu: 16x2 LCD ekran ve aktif buzzer ile fiziksel geri bildirim.

Bana Neler Kattı?

Gömülü sistemler (C++) ve masaüstü yazılım (C#) arasında tam senkronizasyon kurmayı öğrendim.

Seri haberleşme protokollerini (UART) özel paketleme yöntemleriyle yönetme deneyimi kazandım.

Havacılık elektroniği (Aviyonik) ve uçuş emniyet algoritmaları üzerine temel yetkinlikler edindim.

🇺🇸 English Description
Project Title: ESP32 Based Fly-By-Wire Flight Control System
Summary: This project is a microcontroller-based prototype of the Fly-By-Wire technology used in modern aircraft. Joystick inputs are converted into digital data by an ESP32, processed through software filters, and sent to servo motors. Simultaneously, real-time flight data is streamed to a custom-built C# Ground Control Station.

Key Features:

Smart Control: Precise 0-180 degree control over Pitch and Roll axes.

Stall Protection System: Visual and audible alerts via LCD and Buzzer during critical flight angles (Pitch > 150).

Telemetry: Real-time data tracking and radar simulation via C# GUI.

Hardware Integration: Physical feedback using a 16x2 LCD and an active buzzer.

Learning Outcomes:

Mastered full synchronization between embedded systems (C++) and desktop applications (C#).

Gained experience in managing Serial Communication (UART) with custom data packet protocols.

Developed foundational skills in avionics electronics and flight safety algorithms.
