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
            textBox2.Text = selectedTour.TravelCity;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = true;
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("error");
            }
            else
            {
                if (radioButton2.Checked)
                {
                    TrainTicket ticket = new TrainTicket();
                    ticket.DepartureCity = textBox1.Text;
                    
                        //Открытие формы 2 и передача ей выбранного тура
                        Form3 newForm = new Form3(selectedTour, ticket);
                        newForm.Size = new Size(300, 300);
                        newForm.Show();
                    
                }
                if (radioButton1.Checked)
                {
                    AirplaneTicket ticket = new AirplaneTicket();
                    ticket.DepartureCity = textBox1.Text;
                      
                        //Открытие формы 2 и передача ей выбранного тура
                        Form4 newForm = new Form4(selectedTour, ticket);
                        newForm.Size = new Size(300, 300);
                        newForm.Show();
                    
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems == null)
                selectedTour.meals = "Без питания";
            if (checkedListBox1.GetItemChecked(0))
                selectedTour.meals += "Завтрак";
            if (checkedListBox1.GetItemChecked(1))
                selectedTour.meals += "Обед ";
            if (checkedListBox1.GetItemChecked(2))
                selectedTour.meals += "Ужин ";
            richTextBox1.Text += "Питание: " + selectedTour.meals + ".";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 newForm = new Form1();
            newForm.Show();
        }
    }
}
