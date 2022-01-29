using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Espresso_Form : Form
    {
        public Espresso_Form()
        {
            InitializeComponent();
            //serialPort1.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void onButton_Click(object sender, EventArgs e)
        {
            // Send command to turn on pin 13
            serialPort1.Write("A\n");
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            // Send command to turn off pin 13
            serialPort1.Write("a\n");
        }
    }
}
