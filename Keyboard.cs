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
    public partial class Keyboard : Form
    {
        TextBox tt;
        bool isArabic;
        public Keyboard(bool arabic = false)
        {
            InitializeComponent();
            this.TopMost = true;
            isArabic = arabic;
            UpdateButtonTexts();

        }
        public void setTextBoxForOutput(TextBox t)
        {
            tt = t;
        }
        private void UpdateButtonTexts()
        {
            if (isArabic)
            {
                // Set button texts to Arabic letters
                button1.Text = "ا";  // Arabic letter for A
                button2.Text = "ب";  // Arabic letter for B
                button14.Text = "ت"; // Arabic letter for C
                button13.Text = "ث"; // Arabic letter for D
                button12.Text = "ج"; // Arabic letter for E
                button11.Text = "ح"; // Arabic letter for F
                button10.Text = "خ"; // Arabic letter for G
                button8.Text = "د";  // Arabic letter for H
                button6.Text = "ذ";  // Arabic letter for I
                button5.Text = "ر";  // Arabic letter for J
                button4.Text = "ز";  // Arabic letter for K
                button20.Text = "س";  // Arabic letter for L
                button19.Text = "ش";  // Arabic letter for M
                button18.Text = "ص";  // Arabic letter for N
                button17.Text = "ض";  // Arabic letter for O
                button15.Text = "ط";  // Arabic letter for P
                button25.Text = "ظ";  // Arabic letter for Q
                button16.Text = "ع";  // Arabic letter for R
                button24.Text = "غ";  // Arabic letter for S
                button23.Text = "ف";  // Arabic letter for T
                button22.Text = "ق";  // Arabic letter for U
                button21.Text = "ك";  // Arabic letter for W
                button26.Text = "ل";  // Arabic letter for X
                button27.Text = "م";  // Arabic letter for Y
                button28.Text = "ن";  // Arabic letter for Z
                button29.Text = "ه";  // Arabic letter for V
                button3.Text = "إغلاق"; // Close button (Arabic for Close)
                button31.Text = "و";
                button30.Text = "ي";
                button7.Text = "مسح";
                button9.Text = "فراغ";
            }
            else
            {
                // Set the button texts back to English 
                button1.Text = "A";
                button2.Text = "B";
                button14.Text = "C";
                button13.Text = "D";
                button12.Text = "E";
                button11.Text = "F";
                button10.Text = "G";
                button8.Text = "H";
                button6.Text = "I";
                button5.Text = "J";
                button4.Text = "K";
                button20.Text = "L";
                button19.Text = "M";
                button18.Text = "N";
                button17.Text = "O";
                button15.Text = "P";
                button25.Text = "Q";
                button16.Text = "R";
                button24.Text = "S";
                button23.Text = "T";
                button22.Text = "U";
                button21.Text = "W";
                button26.Text = "X";
                button27.Text = "Y";
                button28.Text = "Z";
                button29.Text = "V";
                button3.Text = "Close";  // Close button (English for Close)
                                         // Hide button31 and button30 for English
                button31.Visible = false;
                button30.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Check the Name property to decide the button's functionality
            if (clickedButton.Name == "button7") // Delete button
            {
                if (!string.IsNullOrEmpty(tt.Text))
                {
                    // Remove the last character from the TextBox
                    tt.Text = tt.Text.Substring(0, tt.Text.Length - 1);
                }
            }
            else if (clickedButton.Name == "button9") // Space button
            {
                tt.Text += " "; // Add a space
            }
            else // Regular button
            {
                // Append the button's text to the TextBox
                tt.Text += clickedButton.Text;
            }
        }
        private void Keyboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Optionally, hide the form instead of closing it
            e.Cancel = true;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Keyboard_Load(object sender, EventArgs e)
        {

        }
    }
}
