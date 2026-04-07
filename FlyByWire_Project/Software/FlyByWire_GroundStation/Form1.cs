using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace FlyByWire_GroundStation
{
    public partial class Form1 : Form
    {
        // Gelen Ham Veriler
        int pitch = 90, roll = 90, throttle = 0;

        // Mantıksal Değişkenler
        bool isStall = false;
        bool isCriticalAngle = false;

        public Form1()
        {
            InitializeComponent();
            // Port listesini cBoxPort her açıldığında yeniler
            cBoxPort.DropDown += new EventHandler(cBoxPort_DropDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PortlariGetir();
            timer1.Interval = 50; // 20 FPS yenileme hızı
            timer1.Start();
        }

        private void cBoxPort_DropDown(object sender, EventArgs e) => PortlariGetir();

        private void PortlariGetir()
        {
            cBoxPort.Items.Clear();
            cBoxPort.Items.AddRange(SerialPort.GetPortNames());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    if (string.IsNullOrEmpty(cBoxPort.Text))
                    {
                        PortlariGetir();
                        if (cBoxPort.Items.Count > 0) cBoxPort.SelectedIndex = 0;
                        else return;
                    }

                    serialPort1.PortName = cBoxPort.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.Open();
                    btnConnect.Text = "KES";
                    btnConnect.BackColor = Color.Green;
                }
                else
                {
                    serialPort1.Close();
                    btnConnect.Text = "BAĞLA";
                    btnConnect.BackColor = Color.Gray;
                }
            }
            catch (Exception ex) { MessageBox.Show("Bağlantı Hatası: " + ex.Message); }
        }

        // --- VERİ OKUMA VE AYRIŞTIRMA ---
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string raw = serialPort1.ReadLine();
                if (raw.Contains("$") && raw.Contains("#"))
                {
                    raw = raw.Replace("$", "").Replace("#", "").Trim();
                    string[] p = raw.Split(',');
                    if (p.Length >= 4)
                    {
                        int.TryParse(p[0], out pitch);
                        int.TryParse(p[1], out roll);
                        int.TryParse(p[2], out throttle);
                        isStall = (p[3] == "1"); // ESP32'den gelen Stall bilgisini oku
                    }
                }
            }
            catch { }
        }

        // --- GÖRSELLEŞTİRME VE KONTROL ---
        private void timer1_Tick(object sender, EventArgs e)
        {
            stickPlotter.Invalidate(); // Çizimi yenile

            // Stall Hesabı: Pitch 180'e çıktığı için 150 ve 30 sınırları kullanılır
            isCriticalAngle = (pitch > 150 || pitch < 30);

            if (isStall || isCriticalAngle)
            {
                lblWarning.Text = "⚠️ STALL UYARISI ⚠️";
                // Yanıp sönme efekti (500ms aralıkla)
                lblWarning.ForeColor = (DateTime.Now.Millisecond < 500) ? Color.Red : Color.Yellow;
            }
            else
            {
                lblWarning.Text = "SİSTEM HAZIR";
                lblWarning.ForeColor = Color.Lime;
            }

            // Gaz Çubuğu Güncelleme (Progress Bar)
            if (barThrottle != null)
            {
                int gazYuzdesi = (int)((throttle / 4095.0) * 100);
                barThrottle.Value = Math.Max(0, Math.Min(100, gazYuzdesi));
            }
        }

        // --- RADAR ÇİZİMİ ---
        private void stickPlotter_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = stickPlotter.Width;
            int h = stickPlotter.Height;

            g.Clear(Color.FromArgb(20, 20, 20));
            g.DrawLine(Pens.Gray, w / 2, 0, w / 2, h); // Dikey Eksen
            g.DrawLine(Pens.Gray, 0, h / 2, w, h / 2); // Yatay Eksen

            // Koordinat hesaplama (0-180 aralığını ekrana yayma)
            int x = (roll * w) / 180;
            int y = h - ((pitch * h) / 180);

            g.FillEllipse(Brushes.Red, x - 10, y - 10, 20, 20); // Joystick imleci
            g.DrawString($"P:{pitch} R:{roll} T:{throttle}", new Font("Consolas", 8), Brushes.White, 5, 5);
        }
    }
}