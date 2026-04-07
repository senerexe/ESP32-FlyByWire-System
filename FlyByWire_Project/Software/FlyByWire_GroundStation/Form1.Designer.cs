namespace FlyByWire_GroundStation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cBoxPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.stickPlotter = new System.Windows.Forms.PictureBox();
            this.barThrottle = new System.Windows.Forms.ProgressBar();
            this.lblWarning = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.stickPlotter)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxPort
            // 
            this.cBoxPort.AccessibleName = "cBoxPort";
            this.cBoxPort.FormattingEnabled = true;
            this.cBoxPort.Location = new System.Drawing.Point(13, 13);
            this.cBoxPort.Name = "cBoxPort";
            this.cBoxPort.Size = new System.Drawing.Size(121, 24);
            this.cBoxPort.TabIndex = 0;
            this.cBoxPort.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(35, 89);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "BAĞLAN";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // stickPlotter
            // 
            this.stickPlotter.BackColor = System.Drawing.Color.DarkGray;
            this.stickPlotter.Location = new System.Drawing.Point(238, 134);
            this.stickPlotter.Name = "stickPlotter";
            this.stickPlotter.Size = new System.Drawing.Size(208, 189);
            this.stickPlotter.TabIndex = 2;
            this.stickPlotter.TabStop = false;
            this.stickPlotter.Paint += new System.Windows.Forms.PaintEventHandler(this.stickPlotter_Paint);
            // 
            // barThrottle
            // 
            this.barThrottle.Location = new System.Drawing.Point(505, 300);
            this.barThrottle.Name = "barThrottle";
            this.barThrottle.Size = new System.Drawing.Size(100, 23);
            this.barThrottle.TabIndex = 3;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWarning.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblWarning.Location = new System.Drawing.Point(253, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(245, 38);
            this.lblWarning.TabIndex = 4;
            this.lblWarning.Text = "SİSTEM HAZIR";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1277, 580);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.barThrottle);
            this.Controls.Add(this.stickPlotter);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cBoxPort);
            this.Name = "Form1";
            this.Text = "Uçuş Kontrol";
            ((System.ComponentModel.ISupportInitialize)(this.stickPlotter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.PictureBox stickPlotter;
        private System.Windows.Forms.ProgressBar barThrottle;
        private System.Windows.Forms.Label lblWarning;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
    }
}

