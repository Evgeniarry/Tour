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
    public partial class Form4 : Form
    {
        public Tour selectedTour = new Tour();
        public TrainTicket ticket = new TrainTicket();
        public AirplaneTicket ticket0 = new AirplaneTicket();
        public Form4(Tour selectedTour, AirplaneTicket ticket0)
        {
            InitializeComponent();
            this.selectedTour = selectedTour;
            this.ticket0 = ticket0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ticket0.Tour = selectedTour;
            ticket0.baggage = true;
            if (radioButton3.Checked)
                ticket.Class = "Бизнес";
            else if (radioButton4.Checked)
                ticket.Class = "Эконом";
            Hide();
            Form5 newForm = new Form5(selectedTour, ticket0, ticket, 1);
            newForm.Show();
        }
    }
}
