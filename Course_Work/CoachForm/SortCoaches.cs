using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Coursework
{ public partial class SortCoaches : Form
    {
        List<Coach> coaches = CoachesForm.LoadCoachesFromJson(); // Загрузка из файлов
        List<Sport> sports = SportsForm.LoadSportFromJson(); 
        List<Coach> sortCoaches = new List<Coach>(); // Список для отсортированных тренеров
        public SortCoaches() 
        {
            InitializeComponent();
            this.Text = "Сортировка";
            foreach (Sport sport in sports) // Добавление видов спорта в ComboBox
            {
                comboBoxSports.Items.Add(sport.Name); 
            }
        }
        private void button1_Click(object sender, EventArgs e) 
        {
            // Фильтрация тренеров по виду спорта
            var selectedCoaches = coaches.Where(coachToSort => coachToSort.Sport.Name == comboBoxSports.Text);
            sortCoaches = selectedCoaches.ToList(); 
            this.Close();
        }
        public List<Coach> getCoaches() // Метод для получения отсортированного списка тренеров
        {
            return sortCoaches; 
        }}}
