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
    public partial class Form3 : Form
    {
        public Tour selectedTour = new Tour();
        public TrainTicket ticket = new TrainTicket();
        public AirplaneTicket ticket0 = new AirplaneTicket();
        public Form3(Tour selectedTour, TrainTicket ticket)
        {
            InitializeComponent();
            this.selectedTour = selectedTour;
            this.ticket = ticket;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ticket.Tour = selectedTour;
            ticket.RailwayCarriage = (int)numericUpDown1.Value;
            if (radioButton3.Checked)
                ticket.Class = "Плацкарт";
            else if (radioButton4.Checked)
                ticket.Class = "Купе";
            ticket.Site = (int)numericUpDown2.Value;
            Hide();
            Form5 newForm = new Form5(selectedTour, ticket0, ticket, 2);
            newForm.Show();
        }
    }
}
