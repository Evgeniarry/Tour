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
    public partial class Form5 : Form
    {
        public Tour selectedTour = new Tour();
        public AirplaneTicket airplaneTicket = new AirplaneTicket();
        public TrainTicket trainTicket = new TrainTicket();
        int type;
        public Form5(Tour tour, AirplaneTicket ticket, TrainTicket ticket1, int type)
        {
            InitializeComponent();
            selectedTour = tour;
            airplaneTicket = ticket;
            trainTicket = ticket1;
            this.type = type;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = selectedTour.TourInformation();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client(textBox9.Text, textBox1.Text, textBox3.Text, (long)numericUpDown7.Value,
                textBox2.Text + comboBox5.Text, (int)numericUpDown9.Value, (int)numericUpDown8.Value);
            if (type == 1)
            {
                airplaneTicket.Client = client;
                if (textBox3.Text != "")
                    richTextBox2.Text = airplaneTicket.TicketsInformation(true);
                else
                   richTextBox2.Text = airplaneTicket.TicketsInformation();
            }
            else
            {
                trainTicket.Client = client;
                if (textBox3.Text != "")
                    richTextBox2.Text = trainTicket.TicketsInformation(true);
                else
                    richTextBox2.Text = trainTicket.TicketsInformation();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 newForm = new Form1();
            newForm.Show();
        }
    }
}
