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
    public partial class WelcomePage : Form
    {
        Form2 f2;
        Form7 f7;
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2 = new Form2(this);
            this.Hide(); // Hide Form1
            f2.Show(); // Show Form2
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 CleaningmodeForm = new Form7(this);
            this.Hide();
            CleaningmodeForm.Show();
        }
    }
}
