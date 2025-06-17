using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalInterfaceApp1
{
    
    public partial class Form3 : Form
    {
        
        Form2 _parent;
        bool isArabic; // Flag for Arabic language
        public Form3(Form2 parent, bool arabic = false)
        {
            InitializeComponent();
            _parent = parent; // Store Form2 reference
            isArabic = arabic; // Store language preference
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (isArabic)
            {
                label1.Text = "اختر الطريقة التي تريد بها العثور على القسم"; // Keyboard
                label4.Text = "لوحة المفاتيح"; // Keyboard
                label5.Text = "رمز"; // QR Code
                label6.Text = "قائمة"; // list
                label7.Text = "العودة";//back
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 keyboardForm = new Form4(this, isArabic);
            this.Hide(); // Hide Form3
            keyboardForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 qrCodeForm = new Form5(this, isArabic);
            this.Hide(); // Hide Form3
            qrCodeForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 listForm = new Form6(this, isArabic);
            this.Hide(); // Hide Form3
            listForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _parent.Show(); // Show Form3
            this.Hide(); // Hide Form4
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
