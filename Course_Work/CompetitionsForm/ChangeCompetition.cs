using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Coursework
{
    public partial class ChangeCompetition : Form
    {
        // Объявляем и загружаем списки данных из JSON файлов
        private List<SportFacility> facilities = FacilitiesForm.LoadSportFacilitiesFromJson();
        private List<Competition> competitions = CompetitionsForm.LoadCompetitionsFromJson();
        private List<Sport> sports = SportsForm.LoadSportFromJson();
        private List<Organizer> organizers = OrganizersForm.LoadOrganizersFromJson();
        private List<Sportsman> sportsmen = SportsmenForm.LoadSportsmenFromJson();
        // Список для хранения участников соревнования
        private List<Sportsman> competitors = new List<Sportsman>();
        // Объект соревнования, который будет редактироваться
        private Competition selectedCompetition = new Competition();
        public ChangeCompetition()
        {
            InitializeComponent();
            this.Text = "Редактирование соревнования";
            // Заполняем checkedListBox1 списком всех спортсменов
            foreach (Sportsman sportsman in sportsmen)
            {
                checkedListBox1.Items.Add($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}");
            }

            // Заполняем comboBoxChoose списком всех соревнований
            foreach (Competition competition in competitions)
            {
                comboBoxChoose.Items.Add(competition.Name);
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

        // Обработчик события нажатия на кнопку "Изменить"
        private void buttonChange_Click(object sender, EventArgs e)
        {
            // Проверяем корректность кода соревнования
            if (textBoxCode.Text == null)
            {
                MessageBox.Show("Некорректное значение кода соревнования", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // Проверяем, что корректность названия
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Некорректное значение названия", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем корректность дат начала и окончания соревнования
            if (!DateTime.TryParse(textBoxBegin.Text, out DateTime beginDate) ||
                !DateTime.TryParse(textBoxEnd.Text, out DateTime endDate))
            {
                MessageBox.Show("Некорректные даты начала или окончания соревнования.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Проверяем, что дата начала раньше даты окончания
            if (beginDate >= endDate)
            {
                MessageBox.Show("Дата начала должна быть раньше даты окончания.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем выбранный пользователем вид спорта, организатора и спортивное сооружение
            Sport selectedSport = GetSelectedSport();
            Organizer selectedOrganizer = GetSelectedOrganizer();
            SportFacility selectedFacility = GetSelectedSportFacility();


            // Удаляем старое соревнование из списка
            competitions.RemoveAll(competitionToRemove => competitionToRemove.Name == comboBoxChoose.Text);

            // Создаем новое соревнование с обновленными данными
            Competition competition = new Competition(textBoxName.Text, textBoxCode.Text, beginDate, endDate, selectedSport, selectedOrganizer, selectedFacility);
           
            // Добавляем победителей в список
            for (int i = 0; i < competitors.Count; i++)
            {
                Sportsman sportsman = competitors[i];
                competition.AddWinner(sportsman, i + 1);
            }

            competitions.Add(competition); // Добавляем новое соревнование в список
            CompetitionsForm.SaveCompetitionsToJson(competitions); // Сохраняем список соревнований в файл

            this.Close(); // Закрываем форму
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

        //Метод для получения выбранного пользователем спортивного сооружения
        private SportFacility GetSelectedSportFacility()
        {
            if (comboBoxFacility.SelectedItem is string selectedFacilityName)
            {
                return facilities.FirstOrDefault(f => f.Name == selectedFacilityName);
            }
         
            return new Stadium();
        }

        private void button5_Click(object sender, EventArgs e) //Обработка нажатия кнопки добавления призеров
        {
            // Перебираем все выбранные элементы в checkedListBox1
            foreach (var item in checkedListBox1.CheckedItems)
            {
                //Фильтруем список спортсменов (sportsmen), оставляя тех, чьи полные имена соответствуют выбранным элементам
                var filteredCompetitors = (sportsmen.Where(c => $"{c.SecondName} {c.Name} {c.Patronymic}" == item.ToString())).ToList();
                competitors.AddRange(filteredCompetitors);
            }
        }

        // Обработчик события изменения выбранного элемента в comboBoxChoose
        private void comboBoxChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ищем выбранное для изменений соревнование в списке соревнований 
            foreach (Competition competition in competitions)
            {
                if ($"{competition.Name}" == comboBoxChoose.Text)
                {
                    selectedCompetition = competition; // Сохраняем выбранное соревнование
                }
            }

            // Заполняем текстовые поля данными выбранного соревнования
            textBoxCode.Text = selectedCompetition.Code;
            textBoxName.Text = selectedCompetition.Name;
            textBoxBegin.Text = selectedCompetition.Begin.ToShortDateString();
            textBoxEnd.Text = selectedCompetition.End.ToShortDateString();
            comboBoxSports.Text = selectedCompetition.Type.Name;
            comboBoxOrganizer.Text = selectedCompetition.Organizer.Name;
            comboBoxFacility.Text = selectedCompetition.Location.Name;
        }}}
   