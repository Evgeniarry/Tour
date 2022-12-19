using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            //запрет на добавление новых путевок пользователем
            dataGridView1.AllowUserToAddRows = false;

            //Заполение comboBox1 странами
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Manager.country);

            //Вывод значений rangeSlider 
            textBox1.Text = Convert.ToString(rangeSlider1.SliderMin + "-" + rangeSlider1.SliderMax);
        }

        private void rangeSlider1_ValueChanged(object sender, EventArgs e)
        {   
            //Вывод значений rangeSlider (при изменении их)
            textBox1.Text = Convert.ToString(rangeSlider1.SliderMin + "-" + rangeSlider1.SliderMax);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Вывод всех путевок в таблицу данных
            Form1.DataView(tours, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e) //Фильтр
        {
            List<Tour> filteredTour = new List<Tour>();

            //Проверка на то что страна выбрана (фильтрация невозможна без выбора страны)
            if (comboBox1.SelectedItem == null)     
                MessageBox.Show("Выберите страну");

            //Проверка на корректность выбранного диапазона дат
            //(фильтрация невозможна если в выбранный дипазон входят даты меньше сегодняшнего числа)
            else if (monthCalendar1.SelectionStart <= DateTime.Now)
                MessageBox.Show("Выбранная дата некорректна");

            //Если все параметры введены верно, тогда происходит фильтрация
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
                //Вывод подходящих путевок
                Form1.DataView(filteredTour, dataGridView1);

                //Если ничего не найдено, то выводится сообщение "По вашему запросу ничего не найдено."
                if (filteredTour.Count == 0)
                MessageBox.Show("По вашему запросу ничего не найдено.");
            }  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Заполнение combobox2 Городами
        {
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            string[] mas;
            switch (comboBox1.Text)
            {
                case "Абхазия":
                    mas = Manager.cities[0];
                    break;
                case "Болгария":
                    mas = Manager.cities[1];
                    break;
                case "Венгрия":
                    mas = Manager.cities[2];
                    break;
                case "Германия":
                    mas = Manager.cities[3];
                    break;
                case "Италия":
                    mas = Manager.cities[4];
                    break;
                case "Китай":
                    mas = Manager.cities[5];
                    break;
                case "Турция":
                    mas = Manager.cities[6];
                    break;
                case "Чехия":
                    mas = Manager.cities[7];
                    break;
                case "Финляндия":
                    mas = Manager.cities[8];
                    break;
                default:
                    mas = null;
                    break;
            }
            comboBox2.Items.AddRange(mas);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)      //Проверка на выбор тура(может быть выбран только один тур)
                MessageBox.Show("Выберите тур");
            else if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Выберите один тур");
            else
            {
                foreach (Tour p in tours)                   //Поиск выбранного тура в изначальном списке туров
                {
                    if ((dataGridView1.SelectedRows[0].Cells[0].Value.Equals(p.TravelCountry)) &&
                        (dataGridView1.SelectedRows[0].Cells[1].Value.Equals(p.TravelCity)) &&
                        (dataGridView1.SelectedRows[0].Cells[2].Value.Equals(p.Start) &&
                        (dataGridView1.SelectedRows[0].Cells[3].Value.Equals(p.CountOfNights)) &&
                        (dataGridView1.SelectedRows[0].Cells[4].Value.Equals(p.Hotel.nameOfHotel))))
                    {
                        // Скрытие 1 формы
                        Hide();

                        //Открытие формы 2 и передача ей выбранного тура
                        Form2 newForm = new Form2(p);
                        newForm.Show();
                        break;
                    }
                }                
            }
        }

        public static void DataView(List<Tour> tours, DataGridView dataGridView)
        {
            DataTable table = new DataTable();

            //Добаление столбцов в таблицу
            table.Columns.Add("Страна", typeof(string));
            table.Columns.Add("Город", typeof(string));
            table.Columns.Add("Дата вылета", typeof(DateTime));
            table.Columns.Add("Количество ночей", typeof(int));
            table.Columns.Add("Название отеля", typeof(string));
            table.Columns.Add("Количество звёзд", typeof(Bitmap));
            table.Columns.Add("Цена от:", typeof(decimal));

            //Заполнение таблицы данными о путевках
            for (int i = 0; i < tours.Count; i++)
            {
                //Вывод картинок с изображением звёзд в таблице
                Bitmap stars;
                switch (tours[i].Hotel.NumberOfStars)
                {
                    case 5:
                        stars = new Bitmap(Image.FromFile(@"C:\Users\79114\source\repos\WindowsFormsApp1\фото\5.png", true), new Size(120, 24));
                        break;
                    case 4:
                        stars = new Bitmap(Image.FromFile(@"C:\Users\79114\source\repos\WindowsFormsApp1\фото\4.png", true), new Size(96, 24));
                        break;
                    case 3:
                        stars = new Bitmap(Image.FromFile(@"C:\Users\79114\source\repos\WindowsFormsApp1\фото\3.png", true), new Size(72, 24));
                        break;
                    case 2:
                        stars = new Bitmap(Image.FromFile(@"C:\Users\79114\source\repos\WindowsFormsApp1\фото\2.png", true), new Size(48, 24));
                        break;
                    default:
                        stars = new Bitmap(Image.FromFile(@"C:\Users\79114\source\repos\WindowsFormsApp1\фото\1.png", true), new Size(24, 24));
                        break;
                }

                //Заполнение строк таблицы
                table.Rows.Add(tours[i].TravelCountry, tours[i].TravelCity, tours[i].Start, tours[i].CountOfNights,
                tours[i].Hotel.nameOfHotel, stars, tours[i].cost);
            }
            dataGridView.DataSource = table;
            dataGridView.Columns[5].Width = 150;
            for (int i = 0; i < table.Rows.Count; i++)
                dataGridView.Rows[i].Height = 24;
        }
    }
}
