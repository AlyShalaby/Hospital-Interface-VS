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
    public partial class Form2 : Form
    {
        WelcomePage _parent;
        
        bool isArabic;
        public Form2(WelcomePage parent)
        {
            InitializeComponent();
            _parent = parent; // Store Form1 refrence
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 nextForm = new Form3(this, true);
            this.Hide(); // Hide Form2
            nextForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isArabic = false;
            Form3 nextForm = new Form3(this, isArabic);
            this.Hide(); // Hide Form2
            nextForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _parent.Show(); // Show form1(home page)
            this.Hide(); // Hide Form2
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
            if (isArabic)
            {
                button1.Text = "إنجليزي"; // English
                button2.Text = "عربي"; // Arabic
                button3.Text = "رجوع"; // Back
                
                
            }
        }
    }
}
