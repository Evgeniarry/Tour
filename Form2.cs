using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Tour selectedTour = new Tour();
        public Form2(Tour selectedTour)
        {
            InitializeComponent();
            this.selectedTour = selectedTour;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = selectedTour.Photo;
            richTextBox1.Text = selectedTour.TourInformation();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel1.Visible = true;
            }
            else
                panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
