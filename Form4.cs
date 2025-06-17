using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace HospitalInterfaceApp1
{
    public partial class Form4 : Form
    {
        
        Form3 _parent;
        bool isArabic;
        Keyboard keyboard;
        List<string> departmentsEnglish = new List<string>
        {
            "Emergency Department", "Accident & Emergency", "Surgery Department",
            "Intensive Care Unit", "ICU", "Anesthesiology", "Cardiology", "Neurology",
            "Oncology", "Orthopaedics", "Paediatrics", "Obstetrics and Gynaecology",
            "OB/GYN", "Urology", "Gastroenterology", "Pulmonology", "Nephrology",
            "Rheumatology", "Dermatology", "Ophthalmology", "Otolaryngology", "ENT",
            "Plastic Surgery", "Radiology", "Imaging", "X-ray", "MRI", "CT", "Ultrasound",
            "Pathology", "Laboratory Services", "Blood tests", "Biopsies", "Histology",
            "Pharmacy", "Physical Therapy", "Rehabilitation", "Respiratory Therapy",
            "Nuclear Medicine", "Dialysis"
        };

        List<string> departmentsArabic= new List<string>
        {
             "قسم الطوارئ" , "الحوادث والطوارئ" ,"قسم الجراحة" ,"التخدير" , "أمراض القلب" ,"الأعصاب","العناية المركزة" ,
            "وحدة العناية المركزة" ,"التوليد وأمراض النساء","طب الأطفال" , "جراحة العظام" ,"الأورام","طبيب النساء والتوليد" ,
            "أمراض الكلى" ,"طب الرئة","طب الجهاز الهضمي" , "جراحة المسالك البولية"
            ,"الأنف والأذن والحنجرة","طب العيون" , "الأمراض الجلدية" ,"الروماتيزم" ,"الأنف والأذن والحنجرة" ,
            "الأشعة فوق الصوتية" ,"الأشعة المقطعية","الرنين المغناطيسي" , "أشعة إكس" ,"الطب الإشعاعي","الأشعة" ,
            "علم الأنسجة" ,"الخزعات","تحاليل الدم" , "خدمات المختبر" ,"علم الأمراض","العلاج التنفسي" , "إعادة التأهيل" ,
            "العلاج الطبيعي" , "الصيدلة" ,  "الغسيل الكلوي" , "الغسيل الكلوي"
        };

        List<string> departments;

               
        public Form4(Form3 parent, bool arabic = false)
        {
            InitializeComponent();
            _parent = parent;  // Store the reference to Form3
            isArabic = arabic;
            keyboard = new Keyboard();
            keyboard = new Keyboard(isArabic);

        }
        
        
      

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            TextBox1.Enter += TextBox1_Enter;
            TextBox1.TextChanged += textBox1_TextChanged; // Detect text change
            button2.Enabled = false; // Disable the button initially
            if (isArabic)
            {
                label3.Text = "رجوع"; // Back 
                label2.Text = "عرض الخريطة"; // See Map
                TextBox2.Text = "إذا أغلقت لوحة المفاتيح المنبثقة اضغط هنا ثم في مربع النص الأول";
                textBox3.Text = "إذا واجهت صعوبة اضغط رجوع للبدء من جديد";
            }
        }
        private void InitializeDepartments()
        {
            // Now, based on the language setting, decide which list to use
            if (isArabic)
            {
                departments = departmentsArabic; // Use Arabic department names
            }
            else
            {
                departments = departmentsEnglish; // Use English department names
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _parent.Show(); // Show Form3
            this.Hide(); // Hide Form4
            

            // Find exact or close match
            

            
                
                   
           
        }
        
        private void TextBox1_Enter(object sender, EventArgs e)
        {
            // Show the keyboard form and pass the TextBox reference
            keyboard.setTextBoxForOutput(TextBox1);
            keyboard.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            InitializeDepartments();
            string input = TextBox1.Text.Trim().ToLower(); // Normalize input (case insensitive)

            bool isValid = departments.Any(d => d.ToLower() == input); // Check if it matches any department

            button2.Enabled = isValid; // Enable button only if valid

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitializeDepartments();
            string input = TextBox1.Text.Trim().ToLower();
            bool isValid = departments.Any(d => d.ToLower() == input);

            if (!isValid)
            {
                MessageBox.Show(
                    isArabic ? "اسم القسم غير صحيح. يرجى التحقق من التهجئة." : "Department name is incorrect. Please check spelling.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; // Exit without showing the map
            }
            string imagePath = Path.Combine(Application.StartupPath, "map", "The-hospital-map-of-the-first-floor.png");
            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                // Set map location and size
                pictureBox1.Location = new Point(136, 54);
                pictureBox1.Size = new Size(1000, 430);
            }
            else
            {
                MessageBox.Show("Image not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Image = null;
            }

            // Hide all controls
            button2.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;    // "Back" text label
             
            button1.Visible = true;   // Back button
            

            // Show the map
            pictureBox1.Visible = true;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}