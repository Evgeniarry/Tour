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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Вызов метода для получения списка всех путевок, составленных менеджером
        List<Tour> tours = Manager.Tours(Manager.Hotels());
        private void Form1_Load(object sender, EventArgs e)
        {
            //запрет на добавление новых путевок
            dataGridView1.AllowUserToAddRows = false;

            //Заполение comboBox1 странами
            Manager.Countries(comboBox1, Manager.country);         
        }

        private void rangeSlider1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(rangeSlider1.SliderMin + "-" + rangeSlider1.SliderMax);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.DataView(tours, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Tour> filteredTour = new List<Tour>();
            if (comboBox1.SelectedItem == null)
                MessageBox.Show("Выберите страну");
            else if (monthCalendar1.SelectionStart < DateTime.Now.AddDays(1))
                MessageBox.Show("Выбранная дата некорректна");
            else
            {
                foreach (Tour p in tours)
                {
                    
                    if ((p.TravelCountry.Equals(comboBox1.Text)) && (numericUpDown1.Value < p.NumberOfFree) &&
                        (p.Start >= monthCalendar1.SelectionStart) && (p.Start <= monthCalendar1.SelectionEnd) &&
                        (p.CountOfNights >= rangeSlider1.SliderMin) && (p.CountOfNights <= rangeSlider1.SliderMax))
                    {  
                        if (comboBox2.SelectedItem == null)
                            filteredTour.Add(p);
                        else if (p.TravelCity.Equals(comboBox2.Text))
                            filteredTour.Add(p);
                    }
                    
                }
            }
            if (filteredTour.Count == 0)
                MessageBox.Show("По вашему запросу ничего не найдено.");
            Manager.DataView(filteredTour, dataGridView1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Manager.Cities(comboBox2, comboBox1.Text);   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 newForm = new Form2();
            newForm.Show();
        }
    }
}
