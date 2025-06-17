using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace HospitalInterfaceApp1
{
    public partial class Form7 : Form
    {
         WelcomePage _parent;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        BarcodeReader Reader;
        bool isArabic;
        private System.Windows.Forms.Timer lockTimer; // Timer for locking the screen
        private DateTime lockEndTime;

        public Form7(WelcomePage parent, bool arabic = false)
        {
            InitializeComponent();
            _parent = parent; 
            isArabic = arabic;
            timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 1000; // Set interval (e.g., 1000ms = 1 second)
            timer2.Tick += new EventHandler(timer2_Tick);
            lockTimer = new System.Windows.Forms.Timer();
            lockTimer.Interval = 1000; // Check every second
            lockTimer.Tick += LockTimer_Tick; // Event handler for lock timer
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _parent.Show(); // Show Form6
            this.Hide(); // Hide Form7List
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if (isArabic)
            {
                label4.Text = "الرجوع"; // Back button
                label2.Text = "يبدأ"; // Start button
                label3.Text = "حل الشفرة"; // Decode button
                label5.Text = "التقاط الصورة"; // Take photo button
                label1.Text = "اختر كاميرا من القائمة المنسدلة، ثم اضغط على زر البدء لتمكين معاينة الكاميرا،" +
                              " ثم اضغط على زر فك التشفير ووجه الكاميرا إلى رمز الاستجابة السريعة." +
                              " يجب أن تظهر بيانات رمز الاستجابة السريعة في مربع القائمة أعلاه."; // Label text in Arabic
                txtResult.Name = "نتيجة النص"; // TextBox name in Arabic

            }
            // this will list the available cameras
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
                cboCamera.Items.Add(Device.Name);
            cboCamera.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // start the camera device
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
            videoCaptureDevice.Start();
        }
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // show the video in the picturebox
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close the camera device when the app is closed
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
        }

        

        private void btnDecode_Click(object sender, EventArgs e)
        {
            // start the decoder looking for QR codes
            timer2.Start();
            Reader = new BarcodeReader();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            // Try and detect a barcode/qrcode in the image frame
            if (pictureBox1.Image != null)
            {
                Result result = Reader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    txtResult.Items.Add(result.Text);

                    // Lock the screen and disable all controls
                    LockScreen();

                    // Start the 30-second lock timer
                    lockEndTime = DateTime.Now.AddSeconds(30);
                    lockTimer.Start();
                }
            }
        }
        private void LockScreen()
        {
            // Disable all controls on the form
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }

            // Optionally, display a message or overlay to indicate the screen is locked
            MessageBox.Show("The screen is locked for 30 sec", "تم القفل", MessageBoxButtons.OK, MessageBoxIcon.Information); // Locked message in Arabic
        }
        private void UnlockScreen()
        {
            // Re-enable all controls on the form
            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
            }

            // Navigate back to the welcome page
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Hide();
        }
        private void LockTimer_Tick(object sender, EventArgs e)
        {
            // Check if the lock time has elapsed
            if (DateTime.Now >= lockEndTime)
            {
                lockTimer.Stop(); // Stop the timer
                UnlockScreen(); // Unlock the screen and return to the welcome page
            }
        }
        private void FinalFrame_NewFramePhoto(object sender, NewFrameEventArgs eventArgs)
        {
            // show the video in the picturebox
            pictureBox2.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void takePhoto_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);

            // Stop the video source
            videoCaptureDevice.SignalToStop();

            videoCaptureDevice.NewFrame += FinalFrame_NewFramePhoto;

            // Save the current frame to the clipboard
            //Clipboard.SetImage(pictureBox2.Image);
            // Restart the video source
            videoCaptureDevice.Start();
        }

        private void cboCamera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
