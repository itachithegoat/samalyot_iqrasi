namespace samalyot_iqrasi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Panel skyPanel;
        private PictureBox planePic;
        private PictureBox sparklePic;
        private Button landingButton;
        private Button turbulenceButton;
        private Button beltsButton;
        private Button thanksButton;
        private Button beepButton;
        private Button gasButton;
        private Button brakeButton;
        private Button onOffButton;
        private System.Windows.Forms.Timer blinkTimer;
        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.Timer brakeTimer;
        private System.Windows.Forms.Timer shakeTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            skyPanel = new Panel();
            planePic = new PictureBox();
            sparklePic = new PictureBox();
            landingButton = new Button();
            turbulenceButton = new Button();
            beltsButton = new Button();
            thanksButton = new Button();
            beepButton = new Button();
            gasButton = new Button();
            brakeButton = new Button();
            onOffButton = new Button();
            blinkTimer = new System.Windows.Forms.Timer(components);
            moveTimer = new System.Windows.Forms.Timer(components);
            brakeTimer = new System.Windows.Forms.Timer(components);
            shakeTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)planePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sparklePic).BeginInit();
            skyPanel.SuspendLayout();
            SuspendLayout();
            skyPanel.BackColor = Color.DimGray;
            skyPanel.Controls.Add(sparklePic);
            skyPanel.Controls.Add(planePic);
            skyPanel.Location = new Point(0, 0);
            skyPanel.Name = "skyPanel";
            skyPanel.Size = new Size(230, 450);
            skyPanel.TabIndex = 0;
            skyPanel.Visible = true;
            planePic.BackColor = Color.Transparent;
            planePic.Location = new Point(62, 310);
            planePic.Name = "planePic";
            planePic.Size = new Size(105, 130);
            planePic.SizeMode = PictureBoxSizeMode.Zoom;
            planePic.TabIndex = 0;
            planePic.TabStop = false;
            planePic.Visible = true;
            sparklePic.BackColor = Color.Transparent;
            sparklePic.Location = new Point(94, 265);
            sparklePic.Name = "sparklePic";
            sparklePic.Size = new Size(40, 40);
            sparklePic.SizeMode = PictureBoxSizeMode.Zoom;
            sparklePic.TabIndex = 1;
            sparklePic.TabStop = false;
            sparklePic.Visible = false;
            ConfigureButton(landingButton, "Eniş hazırlığı", new Point(243, 10), new Size(320, 42));
            ConfigureButton(turbulenceButton, "Turbulans", new Point(243, 62), new Size(320, 42));
            ConfigureButton(beltsButton, "Kəmərlər", new Point(243, 114), new Size(320, 42));
            ConfigureButton(thanksButton, "Təşəkkürlər", new Point(243, 166), new Size(320, 42));
            ConfigureButton(beepButton, "Beep", new Point(243, 218), new Size(320, 42));
            gasButton.BackColor = Color.Green;
            gasButton.FlatStyle = FlatStyle.Standard;
            gasButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gasButton.ForeColor = Color.White;
            gasButton.Location = new Point(243, 275);
            gasButton.Name = "gasButton";
            gasButton.Size = new Size(120, 68);
            gasButton.TabIndex = 6;
            gasButton.Text = "GAS";
            gasButton.UseVisualStyleBackColor = false;
            brakeButton.BackColor = Color.FromArgb(192, 0, 0);
            brakeButton.FlatStyle = FlatStyle.Standard;
            brakeButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            brakeButton.ForeColor = Color.White;
            brakeButton.Location = new Point(375, 275);
            brakeButton.Name = "brakeButton";
            brakeButton.Size = new Size(125, 68);
            brakeButton.TabIndex = 7;
            brakeButton.Text = "Break";
            brakeButton.UseVisualStyleBackColor = false;
            onOffButton.BackColor = Color.FromArgb(0, 0, 192);
            onOffButton.FlatStyle = FlatStyle.Standard;
            onOffButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            onOffButton.ForeColor = Color.White;
            onOffButton.Location = new Point(243, 398);
            onOffButton.Name = "onOffButton";
            onOffButton.Size = new Size(337, 42);
            onOffButton.TabIndex = 8;
            onOffButton.Text = "ON/OFF";
            onOffButton.UseVisualStyleBackColor = false;
            blinkTimer.Interval = 500;
            blinkTimer.Tick += blinkTimer_Tick;
            moveTimer.Interval = 20;
            moveTimer.Tick += moveTimer_Tick;
            brakeTimer.Interval = 100;
            brakeTimer.Tick += brakeTimer_Tick;
            shakeTimer.Interval = 50;
            shakeTimer.Tick += shakeTimer_Tick;
            landingButton.Click += landingButton_Click;
            turbulenceButton.Click += turbulenceButton_Click;
            beltsButton.Click += beltsButton_Click;
            thanksButton.Click += thanksButton_Click;
            beepButton.Click += beepButton_Click;
            gasButton.Click += gasButton_Click;
            brakeButton.Click += brakeButton_Click;
            onOffButton.Click += onOffButton_Click;
            ClientSize = new Size(590, 450);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            Controls.Add(skyPanel);
            Controls.Add(onOffButton);
            Controls.Add(brakeButton);
            Controls.Add(gasButton);
            Controls.Add(beepButton);
            Controls.Add(thanksButton);
            Controls.Add(beltsButton);
            Controls.Add(turbulenceButton);
            Controls.Add(landingButton);
            planePic.BringToFront();
            sparklePic.BringToFront();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Plane";
            FormClosing += Form1_FormClosing;
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            skyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)planePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)sparklePic).EndInit();
            ResumeLayout(false);
        }

        private void ConfigureButton(Button button, string text, Point location, Size size)
        {
            button.BackColor = Color.FromArgb(255, 128, 0);
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.Location = location;
            button.Name = text;
            button.Size = size;
            button.TabIndex = Controls.Count;
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }

        #endregion
    }
}
