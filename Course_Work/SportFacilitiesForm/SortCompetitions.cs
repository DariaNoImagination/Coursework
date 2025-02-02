using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Coursework
{
    public partial class SortCompetitions : Form
    {
        List<Competition> competitionsSort = new List<Competition>(); //Отсортированный соревнования
        List<Competition> competitionsToSort = new List<Competition>(); //Соревнования, которые надо отсортировать

        public SortCompetitions(List<Competition> competitions)
        {
            InitializeComponent();
            this.Text = "Сортировка";
            competitionsToSort = competitions;
            comboBoxSortCompetitions.Items.Add("Любые");
            comboBoxSortCompetitions.Items.Add("По дате проведения");
            comboBoxSortCompetitions.Items.Add("По виду спорта");
            textBoxBegin.Hide();
            textBoxEnd.Hide();
            textBoxSport.Hide();
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
        }


        private void comboBoxSortCompetitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обрабатываем выбор типа сортировки соревнований
            switch (comboBoxSortCompetitions.SelectedIndex)
            {
                case 0: // Если выбран пункт "Без сортировки"
                    textBoxBegin.Hide(); 
                    textBoxEnd.Hide(); 
                    textBoxSport.Hide(); 
                    label2.Text = "";
                    label3.Text = ""; 
                    label4.Text = ""; 
                    break;
                case 1:  // Если выбрана сортировка по дате
                    textBoxSport.Hide(); 
                    label4.Text = ""; 
                    label2.Text = "Начало";
                    label3.Text = "Конец"; 
                    textBoxBegin.Show();
                    textBoxEnd.Show();
                    break;
                case 2: // Если выбрана сортировка по виду спорта
                    textBoxBegin.Hide(); 
                    textBoxEnd.Hide(); 
                    textBoxSport.Show(); 
                    label2.Text = ""; 
                    label3.Text = "";
                    label4.Text = "Вид спорта"; 
                    break;
            }
        }


        private void Отсортировать_Click(object sender, EventArgs e)
        {
            // Обрабатываем нажатие кнопки для сортировки соревнований
            switch (comboBoxSortCompetitions.SelectedIndex)
            {
                case 0:  // Если выбран пункт "Без сортировки"
                    competitionsSort = competitionsToSort; // Присваиваем исходный список отсортированному
                    break;
                case 1: // Если выбрана сортировка по дате
                        // Проверяем корректность ввода начальной даты
                    if (!DateTime.TryParse(textBoxBegin.Text, out DateTime begin))
                    {
                        MessageBox.Show("Некорректное значение даты.","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Проверяем корректность ввода конечной даты
                    if (!DateTime.TryParse(textBoxEnd.Text, out DateTime end))
                    {
                        MessageBox.Show("Некорректное значение даты.","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (begin > end)
                    {
                        MessageBox.Show("Некорректное значение даты.\n Дата начала не может быть позже даты конца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Фильтруем соревнования по дате
                    var selectedCompetitions = competitionsToSort.Where(competitionSort => competitionSort.Begin >= begin && competitionSort.End <= end);
                    competitionsSort = selectedCompetitions.ToList(); 
                    break;
                case 2: // Если выбрана сортировка по виду спорта
                        // Проверяем корректность ввода вида спорта
                    if (String.IsNullOrEmpty(textBoxSport.Text))
                    {
                        MessageBox.Show("Некорректное значение вида спорта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Фильтруем соревнования по виду спорта
                    selectedCompetitions = competitionsToSort.Where(competitionSort => competitionSort.Type.Name == textBoxSport.Text);
                    competitionsSort = selectedCompetitions.ToList(); 
                    break;
            }
            this.Close(); 
        }

        public List<Competition> getCompetitionsSort()
        {
            return competitionsSort; // Возвращаем отсортированный список соревнований
        }
    }
}