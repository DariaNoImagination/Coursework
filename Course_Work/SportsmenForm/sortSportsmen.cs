using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Coursework
{   public partial class sortSportsmen : Form
    {
        List<Sport> sportsInTown = SportsForm.LoadSportFromJson();  //Загрузка из файлов
        List<Coach> coachesInTown = CoachesForm.LoadCoachesFromJson();
        List<Sportsman> sportsmenInTown = SportsmenForm.LoadSportsmenFromJson();
        List<Sportsman> sportsmenSort = new List<Sportsman>(); //Отсортированные спортсмены
        string howSort; //Значение для определения вида сортировки
        public sortSportsmen(string howSort)
        {
            InitializeComponent();
            this.Text = "Сортировка";
            this.howSort = howSort;
            comboBox2.Items.Add("Любой"); 
            comboBox2.Items.Add("Не ниже кандидата в мастера спорта");
            comboBox2.Items.Add("Не ниже первого спортивного разряда");
            comboBox2.Items.Add("Не ниже второго спортивного разряда");
            comboBox2.Items.Add("Не ниже третьего спортивного разряда");
            comboBox2.Items.Add("Не ниже первого юношеского спортивного разряда");
            comboBox2.Items.Add("Не ниже второго юношеского спортивного разряда");
            comboBox2.Items.Add("Третий юношеский спортивный разряд");

            switch (howSort)
            {
                case "Sport": //Если сортировать по виду спорта
                    label2.Text = "Вид спорта";
                    foreach (Sport addSport in sportsInTown)
                    {            
                        comboBox1.Items.Add(addSport.Name);   
                    }
                    break;

                case "Coach":
                    label2.Text = "Тренер"; //Если сортировать по тренеру
                    foreach (Coach addCoach in coachesInTown)
                    {
                        comboBox1.Items.Add($"{addCoach.SecondName} {addCoach.Name} {addCoach.Patronymic}");
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            List<Sportsman> selectedSportsmen = new List<Sportsman>(); //Отсортированный спортсмены

            switch (howSort) 
            {
                case "Sport": //Если сортировка по виду спорта
                    Sport neededSport = new Sport(); 
                    foreach (Sport sport in sportsInTown) if (sport.Name == comboBox1.Text) neededSport = sport;//Выбранный для сортировки вид спорта 
                    switch (comboBox2.Text)
                        {
                            case "Любой":
                                // Фильтруем спортсменов по видам спорта
                                selectedSportsmen = sportsmenInTown
                                .Where(s => s.SportInfoList.Any(sportInfo => sportInfo.Sport.Equals(neededSport))).ToList();
                                break;

                            default: //Фильтруем спортсменов по виду спорта и спортивному разряду
                                SportsCategory minCategory = (SportsCategory)(comboBox2.SelectedIndex - 1);
                                selectedSportsmen = sportsmenInTown
                                .Where(s => s.SportInfoList.Any(sportInfo =>
                                sportInfo.Sport.Equals(neededSport) &&
                                sportInfo.Category <= minCategory)).ToList();
                                break;
                        }
          
                    break;


                case "Coach": //Если сортировка по тренеру
                        switch (comboBox2.Text)
                        {
                            case "Любой":
                            // Фильтруем спортсменов по тренеру 
                                selectedSportsmen = sportsmenInTown
                                .Where(s => s.SportInfoList.Any(sportInfo => sportInfo.GetCoaches().Any(coach => $"{coach.SecondName} {coach.Name} {coach.Patronymic}" == comboBox1.Text))).ToList();
                            break;


                            default: // Фильтруем спортсменов по тренеру и спортивному разряду
                                Coach neededCoach = new Coach(); 
                                foreach (Coach coach in coachesInTown) if ($"{coach.SecondName} {coach.Name} {coach.Patronymic}" == comboBox1.Text) neededCoach = coach;//Выбранный для сортировки тренер
                                SportsCategory minCategory = (SportsCategory)(comboBox2.SelectedIndex - 1);
                                selectedSportsmen = sportsmenInTown
                                .Where(s => s.SportInfoList.Any(sportInfo => sportInfo.GetCoaches().Any(coach => $"{coach.SecondName} {coach.Name} {coach.Patronymic}" == comboBox1.Text)) && s.GetCategoryBySport(neededCoach.Sport) <= minCategory).ToList();
                                break;
                        }

                    
                    break;
        }
        sportsmenSort = selectedSportsmen; 
        this.Close();
    }
        public List<Sportsman> GetSortedSportsman() //Возврат отсортированных спортсменов
        {
            return sportsmenSort;
        }
 }
}
    