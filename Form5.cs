using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// include the libraries
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace HospitalInterfaceApp1
{
   
    public partial class Form5 : Form
    { 

        
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        BarcodeReader Reader;
        Form3 _parent;
        bool isArabic ;



        public Form5(Form3 parent, bool arabic = false)
        {
            InitializeComponent();
            _parent = parent; // Store Form3 reference
            isArabic = arabic;
            timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 1000; // Set interval (e.g., 1000ms = 1 second)
            timer2.Tick += new EventHandler(timer2_Tick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _parent.Show(); // Show Form3
            this.Hide(); // Hide Form5QRCode
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            if (isArabic)
            {
                label5.Text = "الرجوع"; // Back button
                label2.Text = "يبدأ"; // Start button
                label3.Text = "حل الشفرة"; // Decode button
                
                label6.Text = "التقاط الصورة"; // Take photo button
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

        private void textBox1_TextChanged(object sender, EventArgs e)
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
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
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
            if (pictureBox1.Image != null)
            {
                Result result = Reader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    txtResult.Items.Add(result.Text);
                    timer2.Stop();
                    // Show the map when QR code is decoded
                    ShowMap();
                }
            }
            else
            {
                // Optional: Log or handle the case where there's no image in the PictureBox
                Console.WriteLine("No image in PictureBox to decode.");
            }
        }
        private void ShowMap()
        {
            // Stop the camera
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
            }

            string mapImagePath = Path.Combine(Application.StartupPath, "map", "The-hospital-map-of-the-first-floor.png");
            if (File.Exists(mapImagePath))
            {
                // Configure the map PictureBox
                pictureBox3.Image = Image.FromFile(mapImagePath);
                pictureBox3.Size = new Size(825, 350);
                pictureBox3.Location = new Point(81, 90);
                pictureBox3.Visible = true;

                // Hide all buttons, labels, and other controls
                button1.Visible = true;
                btnStart.Visible = false;
                btnDecode.Visible = false;
                
                takePhoto.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                
                label5.Visible = true;
                label6.Visible = false;
                cboCamera.Visible = false;
                txtResult.Visible = false; // Hide the result list if present
                pictureBox1.Visible = false; // Hide the camera preview
            }
            else
            {
                MessageBox.Show("Map image not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
