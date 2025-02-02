using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
namespace Coursework
{ public partial class OrganizersForm : Form
    {

        // Загружаем список организаторов из JSON-файла
        List<Organizer> organizersInTown = LoadOrganizersFromJson();
        List<Competition> sortCompetitions = new List<Competition>(); // Список для отсортированных соревнований
        Organizer neededOrganizer = null; // Переменная для хранения выбранного организатора
        public OrganizersForm()
        {
            InitializeComponent();
            this.Text = "Спортивные организации города";
            comboBoxSort.Items.Add("Общая информация");
            comboBoxSort.Items.Add("Проведенные соревнования");
            comboBoxSort.SelectedItem = "Общая информация"; 
            printOrganizers(organizersInTown); // Выводим список организаторов на форму
        }
        static public List<Organizer> LoadOrganizersFromJson()
        {
            try
            {
                // Проверяем существование файла organizers.json
                if (File.Exists("organizers.json"))
                {
                    string json = File.ReadAllText("organizers.json"); // Чтение содержимого файла
                    return JsonConvert.DeserializeObject<List<Organizer>>(json); // Десериализация JSON в список объектов Organizer
                }
                else
                {
                    return new List<Organizer>(); // Возвращаем пустой список, если файл не найден
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке организаторов из JSON: {ex.Message}","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error); // Отображение сообщения об ошибке
                return new List<Organizer>(); // Возвращаем пустой список в случае ошибки
            }
        }

        // Метод для сохранения списка организаторов в JSON-файл
        static public void SaveOrganizersToJson(List<Organizer> organizers)
        {
            try
            {
                string json = JsonConvert.SerializeObject(organizers, Formatting.Indented); // Сериализация списка организаторов в JSON с отступами
                File.WriteAllText("organizers.json", json); // Запись JSON в файл
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Отображение сообщения об ошибке при сохранении
            }
        }

        // Метод для отображения списка организаторов на форме
        public void printOrganizers(List<Organizer> organizers)
        {
            listBoxOrganizers.Items.Clear();
            if (organizers.Count != 0) // Проверяем, есть ли организаторы
            {
                foreach (var organizer in organizers)
                {
                    listBoxOrganizers.Items.Insert(0, organizer.Name); // Добавляем имя организатора в список
                }
            }
            else
            {
                listBoxOrganizers.Items.Add("Организаторов не найдено."); // Сообщение, если организаторы отсутствуют
            }
        }

        // Метод для отображения списка соревнований
        public void printCompetitions(List<Competition> competitions)
        {
            listBoxInformation.Items.Clear(); 
            if (competitions.Count != 0) // Проверяем, есть ли соревнования
            {
                foreach (var competition in competitions)
                {
                    listBoxInformation.Items.Insert(0, competition.Name); // Добавляем название соревнования в список
                }
            }
            else
            {
                listBoxInformation.Items.Add("Организатор не проводил соревнования"); // Сообщение, если соревнования отсутствуют
            }
        }

        // Обработчик события изменения выбора организатора в списке
        private void listBoxOrganizers_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Organizer organizer in organizersInTown)
            {
                if (organizer.Name == listBoxOrganizers.Text)
                    neededOrganizer = organizer; // Сохраняем выбранного организатора
            }
        }

        // Обработчик нажатия кнопки для отображения информации или соревнований
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBoxSort.SelectedIndex) 
            {
                case 0: // Общая информация
                    listBoxInformation.Items.Clear(); // Очищаем список информации
                    if (neededOrganizer != null) // Проверяем, выбран ли организатор
                    {
                        listBoxInformation.Items.Add($"Название:{neededOrganizer.Name} Тип: {neededOrganizer.Type}");
                        listBoxInformation.Items.Add($"Количество проведенных соревнований: {neededOrganizer.HeldCompetitions.Count()}"); // Выводим информацию об организаторе
                    }
                    else
                    {
                        listBoxInformation.Items.Insert(0, "Информация об организаторе не найдена"); // Сообщение, если организатор не найден
                    }
                    break;


                case 1: // Проведенные соревнования
                    if (neededOrganizer != null)
                    {
                        listBoxInformation.Items.Clear(); // Очищаем список информации
                        SortCompetitions organizerCompetitionsSort = new SortCompetitions(neededOrganizer.GetCompetitions());
                        organizerCompetitionsSort.ShowDialog();
                        sortCompetitions = organizerCompetitionsSort.getCompetitionsSort();
                        printCompetitions(sortCompetitions); // Выводим список соревнований для выбранного организатора
                        listBoxInformation.Items.Insert(0, $"Количество проведенных соревнований: {sortCompetitions.Count()}"); 
                    }
                    break;
            }
        }

        // Обработчик изменения выбора в комбобоксе сортировки
        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Organizer organizer in organizersInTown)
            {
                if (organizer.Name == listBoxOrganizers.Text)
                    neededOrganizer = organizer; // Сохраняем выбранного организатора
            }

        }
        // Обработчик нажатия кнопки для добавления нового организатора
        private void button4_Click(object sender, EventArgs e)
        {
            AddChangeForm Add = new AddChangeForm("Add", "Organizers");
            Add.ShowDialog();
            organizersInTown = LoadOrganizersFromJson();
            printOrganizers(organizersInTown); 
        }
        // Обработчик нажатия кнопки для изменения информации об организаторе
        private void button3_Click(object sender, EventArgs e)
        {
            AddChangeForm Change = new AddChangeForm("Change", "Organizers");
            Change.ShowDialog(); 
            organizersInTown = LoadOrganizersFromJson(); 
            printOrganizers(organizersInTown); 
        }
        // Обработчик нажатия кнопки для удаления организатора
        private void button2_Click(object sender, EventArgs e)
        {
          
            Delete delete = new Delete("Organizers");
            delete.ShowDialog(); 
            organizersInTown = LoadOrganizersFromJson(); 
            printOrganizers(organizersInTown); 
        }
        // Обработчик выбора пункта меню для перехода к спортивным сооружениям
        private void спортивныеСооруженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacilitiesForm facilities = new FacilitiesForm(); // Создаем объект для формы спортивных сооружений
            facilities.Show();
            facilities.Location = this.Location;
            this.Hide();
        }
        // Обработчик выбора пункта меню для перехода к спортсменам
        private void соревнованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportsmenForm sportsmen = new SportsmenForm(); // Создаем объект для формы спортсменов
            sportsmen.Show();
            sportsmen.Location = this.Location;
            this.Hide();
        }
        // Обработчик выбора пункта меню для перехода к тренерам
        private void тренерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoachesForm coaches = new CoachesForm(); // Создаем объект для формы тренеров
            coaches.Show();
            coaches.Location = this.Location;
            this.Hide();
        }
        // Обработчик выбора пункта меню для перехода к соревнованиям
        private void соревнованияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CompetitionsForm competitions = new CompetitionsForm(); // Создаем объект для формы соревнований
            competitions.Show();
            competitions.Location = this.Location;
            this.Hide();
        }
        // Обработчик выбора пункта меню для перехода к клубам
        private void клубыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClubsForm clubs = new ClubsForm(); // Создаем объект для формы клубов
            clubs.Show();
            clubs.Location = this.Location;
            this.Hide();
        }
        // Обработчик выбора пункта меню для перехода к видам спорта
        private void видыСпортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportsForm sports = new SportsForm(); // Создаем объект для формы видов спорта
            sports.Show();
            sports.Location = this.Location;
            this.Hide();
        }
    }
}