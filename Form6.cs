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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalInterfaceApp1
{
    public partial class Form6 : Form
    {
        Form3 _parent;
        
        bool isArabic = false;
        public Form6(Form3 parent, bool arabic = false)
        {
            InitializeComponent();
            _parent = parent;
            isArabic = arabic;
            PopulateListBox();

            listBox1.Items.Add("Emergency Department (ED) / Accident & Emergency (A&E)");
            listBox1.Items.Add("Surgery Department");
            listBox1.Items.Add("Intensive Care Unit");
            listBox1.Items.Add("Anesthesiology");
            listBox1.Items.Add("Cardiology");
            listBox1.Items.Add("Neurology");
            listBox1.Items.Add("Oncology");
            listBox1.Items.Add("Orthopaedics");
            listBox1.Items.Add("Paediatrics");
            listBox1.Items.Add("Obstetrics and Gynaecology (OB/GYN)");
            listBox1.Items.Add("Urology");
            listBox1.Items.Add("Gastroenterology");
            listBox1.Items.Add("Pulmonology");
            listBox1.Items.Add("Nephrology");
            listBox1.Items.Add("Rheumatology");
            listBox1.Items.Add("Dermatology");
            listBox1.Items.Add("Ophthalmology");
            listBox1.Items.Add("Otolaryngology (ENT)");
            listBox1.Items.Add("Plastic Surgery");
            listBox1.Items.Add("Radiology / Imaging X-ray, MRI, CT, Ultrasound");
            listBox1.Items.Add("Pathology / Laboratory Services Blood tests, biopsies, histology");
            listBox1.Items.Add("Pharmacy");
            listBox1.Items.Add("Physical Therapy / Rehabilitation");
            listBox1.Items.Add("Respiratory Therapy");
            listBox1.Items.Add("Nuclear Medicine");
            listBox1.Items.Add("Dialysis");

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            if (isArabic)
            {
                
                label3.Text = "رجوع"; // See Map
                
            }
        }

        private void PopulateListBox()
        {
            listBox1.Items.Clear(); // Clear the previous items

            if (isArabic)
            {
                // Arabic department names
                listBox1.Items.Add("قسم الطوارئ");
                listBox1.Items.Add("قسم الجراحة");
                listBox1.Items.Add("وحدة العناية المركزة");
                listBox1.Items.Add("التخدير");
                listBox1.Items.Add("قسم القلب");
                listBox1.Items.Add("قسم الأعصاب");
                listBox1.Items.Add("الأورام");
                listBox1.Items.Add("جراحة العظام");
                listBox1.Items.Add("طب الأطفال");
                listBox1.Items.Add("التوليد وأمراض النساء");
                listBox1.Items.Add("قسم المسالك البولية");
                listBox1.Items.Add("أمراض الجهاز الهضمي");
                listBox1.Items.Add("أمراض الرئة");
                listBox1.Items.Add("طب الكلى");
                listBox1.Items.Add("الروماتيزم");
                listBox1.Items.Add("الأمراض الجلدية");
                listBox1.Items.Add("طب العيون");
                listBox1.Items.Add("الأنف والأذن والحنجرة");
                listBox1.Items.Add("جراحة التجميل");
                listBox1.Items.Add("الأشعة والتصوير");
                listBox1.Items.Add("مختبر التحاليل");
                listBox1.Items.Add("الصيدلية");
                listBox1.Items.Add("العلاج الطبيعي");
                listBox1.Items.Add("العلاج التنفسي");
                listBox1.Items.Add("الطب النووي");
                listBox1.Items.Add("غسيل الكلى");
            }
            else
            {
                // English department names
                listBox1.Items.Add("Emergency Department (ED) / Accident & Emergency (A&E)");
                listBox1.Items.Add("Surgery Department");
                listBox1.Items.Add("Intensive Care Unit");
                listBox1.Items.Add("Anesthesiology");
                listBox1.Items.Add("Cardiology");
                listBox1.Items.Add("Neurology");
                listBox1.Items.Add("Oncology");
                listBox1.Items.Add("Orthopaedics");
                listBox1.Items.Add("Paediatrics");
                listBox1.Items.Add("Obstetrics and Gynaecology (OB/GYN)");
                listBox1.Items.Add("Urology");
                listBox1.Items.Add("Gastroenterology");
                listBox1.Items.Add("Pulmonology");
                listBox1.Items.Add("Nephrology");
                listBox1.Items.Add("Rheumatology");
                listBox1.Items.Add("Dermatology");
                listBox1.Items.Add("Ophthalmology");
                listBox1.Items.Add("Otolaryngology (ENT)");
                listBox1.Items.Add("Plastic Surgery");
                listBox1.Items.Add("Radiology / Imaging X-ray, MRI, CT, Ultrasound");
                listBox1.Items.Add("Pathology / Laboratory Services Blood tests, biopsies, histology");
                listBox1.Items.Add("Pharmacy");
                listBox1.Items.Add("Physical Therapy / Rehabilitation");
                listBox1.Items.Add("Respiratory Therapy");
                listBox1.Items.Add("Nuclear Medicine");
                listBox1.Items.Add("Dialysis");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure an item is selected
            if (listBox1.SelectedItem == null)
                return;

            // Get the selected item
            string selectedDepartment = listBox1.SelectedItem.ToString();
            string imagePath = Path.Combine(Application.StartupPath, "map", "The-hospital-map-of-the-first-floor.png");

            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                // Set position and size
                pictureBox1.Location = new Point(167, 65);
                pictureBox1.Size = new Size(796, 426);
            }
            else
            {
                MessageBox.Show("Image not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Image = null;
            }




            switch (selectedDepartment)
            {
                case "Anesthesiology":
                case "التخدير": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Intensive Care Unit":
                case "وحدة العناية المركزة": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Surgery Department":
                case "قسم الجراحة": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Emergency Department (ED) / Accident & Emergency (A&E)":
                case "قسم الطوارئ": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Cardiology":
                case "قسم القلب": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Neurology":
                case "قسم الأعصاب": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Oncology":
                case "الأورام": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Orthopaedics":
                case "جراحة العظام": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Paediatrics":
                case "طب الأطفال": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Obstetrics and Gynaecology (OB/GYN)":
                case "التوليد وأمراض النساء": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Urology":
                case "قسم المسالك البولية": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Gastroenterology":
                case "أمراض الجهاز الهضمي": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Pulmonology":
                case "أمراض الرئة": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Nephrology":
                case "طب الكلى": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Rheumatology":
                case "الروماتيزم": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Dermatology":
                case "الأمراض الجلدية": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Ophthalmology":
                case "طب العيون": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Otolaryngology (ENT)":
                case "الأنف والأذن والحنجرة": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Plastic Surgery":
                case "جراحة التجميل": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Radiology / Imaging X-ray, MRI, CT, Ultrasound":
                case "الأشعة والتصوير": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Pathology / Laboratory Services Blood tests, biopsies, histology":
                case "مختبر التحاليل": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Pharmacy":
                case "الصيدلية": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Physical Therapy / Rehabilitation":
                case "العلاج الطبيعي": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Respiratory Therapy":
                case "العلاج التنفسي": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Nuclear Medicine":
                case "الطب النووي": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                case "Dialysis":
                case "غسيل الكلى": // Arabic equivalent
                    pictureBox1.Image = Image.FromFile(Path.Combine(imagePath));
                    break;
                default:
                    pictureBox1.Image = null; // Clear image if no match
                    break;
            }
            listBox1.Visible = false;
            textBox1.Visible = false;

            // Ensure the PictureBox is visible
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            _parent.Show(); // Show Form3
            this.Hide(); // Hide Form6List
        }
    }
}
