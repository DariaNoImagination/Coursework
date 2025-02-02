using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Coursework
{
    public partial class AddCompetition : Form
    {
        // Загружаем списки данных из JSON-файлов
        private List<SportFacility> facilities = FacilitiesForm.LoadSportFacilitiesFromJson();
        private List<Competition> competitions = CompetitionsForm.LoadCompetitionsFromJson();
        private List<Sport> sports = SportsForm.LoadSportFromJson();
        private List<Organizer> organizers = OrganizersForm.LoadOrganizersFromJson();
        private List<Sportsman> sportsmen = SportsmenForm.LoadSportsmenFromJson();
        // Список для хранения выбранных победителей соревнования
        private List<Sportsman> competitors = new List<Sportsman>();

        public AddCompetition()
        {
            InitializeComponent(); // Инициализируем компоненты формы
            this.Text = "Добавление соревнования";
            // Заполняем checkedListBox списком всех спортсменов
            foreach (Sportsman sportsman in sportsmen)
            {
                checkedListBox1.Items.Add($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}");
            }

            // Заполняем comboBoxSports списком всех видов спорта
            foreach (Sport sport in sports)
            {
                comboBoxSports.Items.Add(sport.Name);
            }

            // Заполняем comboBoxOrganizer списком всех организаторов
            foreach (Organizer organizer in organizers)
            {
                comboBoxOrganizer.Items.Add(organizer.Name);
            }

            // Заполняем comboBoxFacility списком всех спортивных сооружений
            foreach (SportFacility facility in facilities)
            {
                comboBoxFacility.Items.Add(facility.Name);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)   // Обработчик события нажатия на кнопку "Добавить"
        {
            // Проверяем, что поле textBoxCode на корректность
            if (textBoxCode.Text == null)
            {
                MessageBox.Show("Некорректное значение кода соревнования", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); // Выводим сообщение об ошибке, если код некорректный
                return; // Выходим из метода
            }

            // Проверяем, что поле textBoxName на корректность
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Некорректное значение названия", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); // Выводим сообщение об ошибке, если название пустое
                return; // Выходим из метода
            }

            // Проверяем textBoxBegin и textBoxEnd на корректность
            if (!DateTime.TryParse(textBoxBegin.Text, out DateTime beginDate) ||
              !DateTime.TryParse(textBoxEnd.Text, out DateTime endDate))
            {
                MessageBox.Show("Некорректные даты начала или окончания соревнования.", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error); // Выводим сообщение об ошибке, если даты некорректны
                return;
            }
            
            // Проверяем, что дата начала не позже даты окончания
            if (beginDate >= endDate)
            {
                MessageBox.Show("Дата начала должна быть раньше даты окончания.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Выводим сообщение об ошибке, если дата начала позже даты окончания
                return; 
            }

            // Получаем выбранный вид спорта, организатора и спортивное сооружение
            Sport selectedSport = GetSelectedSport();
            Organizer selectedOrganizer = GetSelectedOrganizer();
            SportFacility selectedFacility = GetSelectedSportFacility();

            // Создаем новый объект соревнования и заполняем его свойствами
            Competition competition = new Competition(textBoxName.Text, textBoxCode.Text, beginDate, endDate, selectedSport, selectedOrganizer, selectedFacility);

            for (int i = 0; i < competitors.Count; i++) // Перебираем список участников соревнования
            {
                Sportsman sportsman = competitors[i]; 
                competition.AddWinner(sportsman, i + 1); // Добавляем спортсмена в список победителей с местом
            }

            competitions.Add(competition); // Добавляем соревнование в общий список соревнований
            CompetitionsForm.SaveCompetitionsToJson(competitions); // Сохраняем список соревнований в JSON-файл

            this.Close();

        }

        //Метод для получения выбранного пользователем вида спорта
        private Sport GetSelectedSport()
        {
            if (comboBoxSports.SelectedItem is string selectedSportName)
            {
                return sports.FirstOrDefault(s => s.Name == selectedSportName);
            }
            return new Sport();

        }

        // Метод для получения выбранного пользователем организатора
        private Organizer GetSelectedOrganizer()
        {
            if (comboBoxOrganizer.SelectedItem is string selectedOrganizerName)
            {
                return organizers.FirstOrDefault(o => o.Name == selectedOrganizerName);
            }
            return new Organizer();
        }

        //Метод для получения выбранного  пользователем спортивного сооружения
        private SportFacility GetSelectedSportFacility()
        {
            if (comboBoxFacility.SelectedItem is string selectedFacilityName)
            {
                return facilities.FirstOrDefault(f => f.Name == selectedFacilityName);
            }
            return null;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            // Перебираем все выбранные элементы в checkedListBox1
            foreach (var item in checkedListBox1.CheckedItems)
            {
                
                // Фильтруем список спортсменов (sportsmen), оставляя тех, чье полное имя соответствует выбранному элементу

                var filteredCompetitors = (sportsmen.Where(c => $"{c.SecondName} {c.Name} {c.Patronymic}" == item.ToString())).ToList();

                
                competitors.AddRange(filteredCompetitors);
            }
        }
    }
}


  
