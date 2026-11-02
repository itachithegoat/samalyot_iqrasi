using System.IO;
using System.Media;
using System.Speech.Synthesis;
using System.Drawing.Drawing2D;

namespace samalyot_iqrasi
{
    public partial class Form1 : Form
    {
        private bool engineOn = false;
        private int speed = 0;
        private bool shaking = false;
        private int shakeCount = 0;
        private readonly int planeOriginalX = 62;
        private readonly int sparkleOriginalX = 94;
        private readonly SpeechSynthesizer voice = new SpeechSynthesizer();

        // Creates the game form.
        public Form1()
        {
            InitializeComponent();
            planePic.Image = CreatePlaneBitmap();
            sparklePic.Image = CreateSparkleBitmap();
            try
            {
                voice.Rate = -1;
                voice.Volume = 100;
            }
            catch
            {
            }
        }

        // Draws a top-view passenger jet pointing upward.
        private Bitmap CreatePlaneBitmap()
        {
            Bitmap planeBitmap = new Bitmap(105, 130);

            using (Graphics graphics = Graphics.FromImage(planeBitmap))
            using (Pen outlinePen = new Pen(Color.FromArgb(80, 85, 95), 2F))
            using (SolidBrush bodyBrush = new SolidBrush(Color.LightGray))
            using (SolidBrush wingBrush = new SolidBrush(Color.WhiteSmoke))
            using (SolidBrush engineBrush = new SolidBrush(Color.FromArgb(95, 100, 110)))
            using (SolidBrush cockpitBrush = new SolidBrush(Color.FromArgb(25, 55, 85)))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(Color.Transparent);

                graphics.FillEllipse(bodyBrush, 43, 4, 19, 118);
                graphics.DrawEllipse(outlinePen, 43, 4, 19, 118);

                Point[] leftMainWing =
                {
                    new Point(45, 43), new Point(8, 77), new Point(18, 87), new Point(46, 70)
                };
                Point[] rightMainWing =
                {
                    new Point(59, 43), new Point(97, 77), new Point(87, 87), new Point(58, 70)
                };
                graphics.FillPolygon(wingBrush, leftMainWing);
                graphics.FillPolygon(wingBrush, rightMainWing);
                graphics.DrawPolygon(outlinePen, leftMainWing);
                graphics.DrawPolygon(outlinePen, rightMainWing);

                Point[] leftTailWing =
                {
                    new Point(45, 94), new Point(28, 112), new Point(42, 116), new Point(50, 103)
                };
                Point[] rightTailWing =
                {
                    new Point(59, 94), new Point(77, 112), new Point(63, 116), new Point(54, 103)
                };
                graphics.FillPolygon(wingBrush, leftTailWing);
                graphics.FillPolygon(wingBrush, rightTailWing);
                graphics.DrawPolygon(outlinePen, leftTailWing);
                graphics.DrawPolygon(outlinePen, rightTailWing);

                graphics.FillEllipse(engineBrush, 25, 70, 11, 22);
                graphics.FillEllipse(engineBrush, 69, 70, 11, 22);
                graphics.DrawEllipse(outlinePen, 25, 70, 11, 22);
                graphics.DrawEllipse(outlinePen, 69, 70, 11, 22);

                graphics.FillEllipse(cockpitBrush, 47, 15, 11, 19);
                graphics.DrawEllipse(outlinePen, 47, 15, 11, 19);
            }

            return planeBitmap;
        }

        // Draws a glowing four-point sparkle.
        private Bitmap CreateSparkleBitmap()
        {
            Bitmap sparkleBitmap = new Bitmap(40, 40);

            using (Graphics graphics = Graphics.FromImage(sparkleBitmap))
            using (SolidBrush glowBrush = new SolidBrush(Color.FromArgb(55, Color.White)))
            using (SolidBrush starBrush = new SolidBrush(Color.White))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(Color.Transparent);
                graphics.FillEllipse(glowBrush, 5, 5, 30, 30);

                Point[] starPoints =
                {
                    new Point(20, 1), new Point(24, 16), new Point(39, 20),
                    new Point(24, 24), new Point(20, 39), new Point(16, 24),
                    new Point(1, 20), new Point(16, 16)
                };
                graphics.FillPolygon(starBrush, starPoints);
            }

            return sparkleBitmap;
        }

        // Turns the engine on or off.
        private void onOffButton_Click(object sender, EventArgs e)
        {
            engineOn = !engineOn;
            SpeakAnnouncement(engineOn ? "Engines on" : "Engines off");

            if (engineOn == true)
            {
                sparklePic.Visible = true;
                blinkTimer.Start();
            }
            else
            {
                StopAllTimers();
                speed = 0;
                sparklePic.Visible = false;
                planePic.Location = new Point(planeOriginalX, planePic.Location.Y);
                sparklePic.Location = new Point(sparkleOriginalX, sparklePic.Location.Y);
            }
        }

        // Blinks the sparkle above the plane.
        private void blinkTimer_Tick(object sender, EventArgs e)
        {
            sparklePic.Visible = !sparklePic.Visible;
        }

        // Adds speed and starts plane movement.
        private void gasButton_Click(object sender, EventArgs e)
        {
            PlaySound("Windows Notify System Generic.wav");

            if (engineOn == false)
            {
                MessageBox.Show("Əvvəlcə mühərriki yandırın (ON/OFF)");
                return;
            }

            if (speed < 10)
            {
                speed++;
            }

            moveTimer.Start();
        }

        // Moves the plane and sparkle upward.
        private void moveTimer_Tick(object sender, EventArgs e)
        {
            if (planePic.Location.Y > 0)
            {
                planePic.Location = new Point(planePic.Location.X, planePic.Location.Y - speed);
                sparklePic.Location = new Point(sparklePic.Location.X, sparklePic.Location.Y - speed);
            }
            else
            {
                planePic.Location = new Point(planePic.Location.X, 0);
                sparklePic.Location = new Point(sparklePic.Location.X, planePic.Location.Y - sparklePic.Height);
                moveTimer.Stop();
                speed = 0;
                MessageBox.Show("Təyyarə yuxarı həddə çatdı");
            }
        }

        // Starts slowing the plane down.
        private void brakeButton_Click(object sender, EventArgs e)
        {
            Task.Run(PlayFallingSound);
            brakeTimer.Start();
        }

        // Reduces the plane speed by one.
        private void brakeTimer_Tick(object sender, EventArgs e)
        {
            if (speed > 0)
            {
                speed--;
            }

            if (speed == 0)
            {
                brakeTimer.Stop();
                moveTimer.Stop();
            }
        }

        // Starts the turbulence effect.
        private void turbulenceButton_Click(object sender, EventArgs e)
        {
            shakeCount = 0;
            shaking = true;
            Task.Run(() =>
            {
                PlayConsoleBeep(200, 150);
                PlayConsoleBeep(200, 150);
                PlayConsoleBeep(200, 150);
                SpeakAnnouncement("Ladies and gentlemen, we are experiencing some turbulence. Please remain seated.");
            });
            shakeTimer.Start();
        }

        // Moves the plane side to side during turbulence.
        private void shakeTimer_Tick(object sender, EventArgs e)
        {
            if (shakeCount < 40)
            {
                int direction = shakeCount % 2 == 0 ? -4 : 4;
                planePic.Location = new Point(planePic.Location.X + direction, planePic.Location.Y);
                sparklePic.Location = new Point(sparklePic.Location.X + direction, sparklePic.Location.Y);
                shakeCount++;
            }
            else
            {
                shakeTimer.Stop();
                shaking = false;
                planePic.Location = new Point(planeOriginalX, planePic.Location.Y);
                sparklePic.Location = new Point(sparkleOriginalX, sparklePic.Location.Y);
            }
        }

        // Sets a lower speed for landing preparation.
        private void landingButton_Click(object sender, EventArgs e)
        {
            PlaySound("chimes.wav");
            SpeakAnnouncement("Ladies and gentlemen, we are preparing for landing. Please return to your seats and fasten your seat belts.");
            speed = 2;
            MessageBox.Show("Eniş hazırlığı başladı");
        }

        // Shows the seat belt instruction.
        private void beltsButton_Click(object sender, EventArgs e)
        {
            PlaySound("chimes.wav");
            SpeakAnnouncement("Please fasten your seat belts.");
            MessageBox.Show("Zəhmət olmasa kəmərlərinizi bağlayın");
        }

        // Shows the thank-you message.
        private void thanksButton_Click(object sender, EventArgs e)
        {
            PlaySound("tada.wav");
            SpeakAnnouncement("Thank you for flying with us. We hope you enjoyed your flight.");
            MessageBox.Show("Bizimlə uçduğunuz üçün təşəkkür edirik!");
        }

        // Plays the beep sound.
        private void beepButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => PlayConsoleBeep(1000, 300));
        }

        // Speaks an announcement without blocking the plane.
        private void SpeakAnnouncement(string text)
        {
            try
            {
                voice.SpeakAsyncCancelAll();
                voice.SpeakAsync(text);
            }
            catch
            {
            }
        }

        // Plays a Windows sound without blocking the plane.
        private void PlaySound(string fileName)
        {
            string soundPath = Path.Combine("C:\\Windows\\Media", fileName);

            try
            {
                if (File.Exists(soundPath))
                {
                    using SoundPlayer soundPlayer = new SoundPlayer(soundPath);
                    soundPlayer.Play();
                }
                else
                {
                    PlayFallbackBeep();
                }
            }
            catch
            {
                PlayFallbackBeep();
            }
        }

        // Plays the fallback beep when a sound file is unavailable.
        private void PlayFallbackBeep()
        {
            PlayConsoleBeep(800, 300);
        }

        // Plays a console beep without crashing if it is unavailable.
        private void PlayConsoleBeep(int frequency, int duration)
        {
            try
            {
                Console.Beep(frequency, duration);
            }
            catch
            {
            }
        }

        // Plays the short falling brake sound.
        private void PlayFallingSound()
        {
            PlayConsoleBeep(600, 100);
            PlayConsoleBeep(400, 150);
        }

        // Moves the plane left or right with the keyboard.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                MoveSideways(-15);
            }
            else if (e.KeyCode == Keys.Right)
            {
                MoveSideways(15);
            }
        }

        // Keeps both images inside the sky panel.
        private void MoveSideways(int amount)
        {
            int newX = planePic.Location.X + amount;
            int maximumX = skyPanel.ClientSize.Width - planePic.Width;

            if (newX < 0)
            {
                newX = 0;
            }
            if (newX > maximumX)
            {
                newX = maximumX;
            }

            planePic.Location = new Point(newX, planePic.Location.Y);
            sparklePic.Location = new Point(newX + sparkleOriginalX - planeOriginalX, sparklePic.Location.Y);
        }

        // Stops every game timer.
        private void StopAllTimers()
        {
            blinkTimer.Stop();
            moveTimer.Stop();
            brakeTimer.Stop();
            shakeTimer.Stop();
            shaking = false;
        }

        // Confirms that the player wants to close the game.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure game exit?", "Plane", MessageBoxButtons.YesNo);

            if (answer == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
