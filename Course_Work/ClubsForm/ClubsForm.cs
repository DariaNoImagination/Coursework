using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
namespace Coursework
{
    public partial class ClubsForm : Form
    {
        // Индекс выбранного клуба
        int index;
        // Список клубов, загружаемых из JSON-файла
        List<Club> clubsinTown = LoadClubsFromJson();
        // Список спортсменов, участвовавших в соревнованиях
        List<Sportsman> sortMembers = new List<Sportsman>();
        public ClubsForm()
        {
            InitializeComponent();
            this.Text = "Спортивные организации города";
            comboBoxSortMembers.Items.Add("Общая информация");
            comboBoxSortMembers.Items.Add("Участники клуба,участвовавшие в соревнованиях");
            comboBoxSortMembers.SelectedItem = "Общая информация"; 
            // Вывод клубов на форму
            printClubs(clubsinTown);
        }
        static public List<Club> LoadClubsFromJson() //Загрузка из файла
        {
            try
            {
                // Проверяем существование файла clubs.json
                if (File.Exists("clubs.json"))
                {
                    string json = File.ReadAllText("clubs.json"); // Чтение содержимого файла
                    return JsonConvert.DeserializeObject<List<Club>>(json); // Десериализация JSON в список объектов Club
                }
                else
                {
                    return new List<Club>(); // Возвращаем пустой список, если файл не найден
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке клубов из JSON: {ex.Message}","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Отображение сообщения об ошибке
                return new List<Club>(); // Возвращаем пустой список в случае ошибки
            }
        }

        // Метод для сохранения списка клубов в JSON-файл
        static public void SaveClubsToJson(List<Club> clubs)
        {
            try
            {
                string json = JsonConvert.SerializeObject(clubs, Formatting.Indented); // Сериализация списка клубов в JSON с отступами
                File.WriteAllText("clubs.json", json); // Запись JSON в файл
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Отображение сообщения об ошибке при сохранении
            }
        }
         public void printClubs(List<Club> clubs) //Метод для вывода клубов на форму
        {
            listBoxClubs.Items.Clear();

            if (clubs.Count != 0) // Проверка на наличие клубов
            {
                foreach (var club in clubs) // Проход по каждому клубу
                {
                    listBoxClubs.Items.Insert(0, $"{club.Name}"); // Добавление названия клуба в ListBox
                }
            }
            else
            {
                listBoxClubs.Items.Add("Клубов не найдено."); // Сообщение об отсутствии клубов
            }
        }

        // Метод для отображения информации о клубе в ListBox
        public void printInfoOfClubs(Club club)
        {
            listBoxInfo.Items.Clear(); 
            listBoxInfo.Items.Insert(0, $"Вид спорта: {club.Sport.Name}");
                if (club.GetMembers().Count != 0) // Проверка на наличие участников
                {
                    listBoxInfo.Items.Add("Участники клуба: ");
                    foreach (var member in club.GetMembers()) // Проход по каждому участнику
                    {
                        // Форматирование строки с ФИО участника и добавление в ListBox
                        listBoxInfo.Items.Add($"{member.SecondName} {member.Name} {member.Patronymic}");
                    }
                }
            
                else
                {
                    listBoxInfo.Items.Add("В клубе нет участников."); // Сообщение об отсутствии спортсменов
                }
        }

        // Обработчик события изменения выбранного индекса в ListBox с клубами
        private void listBoxClubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listBoxClubs.SelectedIndex; // Сохранение индекса выбранного клуба
        }

        // Обработчик события нажатия кнопки для отображения участников клуба
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBoxSortMembers.SelectedIndex) 
            {
                case 0: // "Общая информация"
                    {
                        listBoxInfo.Items.Clear();

                        if (index >= 0 && clubsinTown != null) 
                        {
                            string selectedClubName = listBoxClubs.Items[index].ToString(); // Получение названия выбранного клуба
                            Club selectedClub = clubsinTown.FirstOrDefault(club => club.Name == selectedClubName); // Поиск выбранного клуба

                            if (selectedClub != null) // Если клуб найден
                            printInfoOfClubs(selectedClub); // Вывод участников на форму
                            else
                            listBoxInfo.Items.Add("Информация не найдена"); // Сообщение об отсутствии участников
                         }
                        else
                        {
                            listBoxInfo.Items.Add("Нет данных о клубе");
                        }

                        break;
                    }
                case 1: // "Участвовавшие в соревнованиях"
                    {
                        switch (comboBoxSortMembers.SelectedIndex)
                        {
                            case 1: // Если выбран элемент "Учавствовавшие в соревнованиях"
                                    // Проверяем, что индекс выбранного клуба меньше количества клубов
                                if (index < clubsinTown.Count)
                                {
                                    // Проходим по всем клубам в списке clubsinTown
                                    foreach (Club club in clubsinTown)
                                    {
                                        // Если название клуба совпадает с выбранным в ListBox
                                        if (club.Name == listBoxClubs.Items[index].ToString())
                                        {
                                           
                                            // Создаем новый экземпляр формы SortClubs, передавая выбранный клуб
                                            SortClubs settings = new SortClubs(club);
                                            settings.ShowDialog(); 

                                            // Получаем отсортированных участников из формы SortClubs
                                            sortMembers = settings.GetSortMembers();
                                        }
                                    }
                                }
                                break; 
                        }

                        listBoxInfo.Items.Clear();
                        listBoxInfo.Items.Add($"Количество спортсменов: {sortMembers.Count}"); // Вывод количества спортсменов

                        foreach (var member in sortMembers) // Проход по каждому участнику
                        {
                            // Форматирование строки с ФИО участника и добавление в ListBox
                            listBoxInfo.Items.Insert(0, $"{member.SecondName} {member.Name} {member.Patronymic}");
                        }
                        break;
                    }
            }
        }
   
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddChangeForm Add = new AddChangeForm("Add", "Clubs");
            Add.ShowDialog();
            clubsinTown.Clear();
            clubsinTown = LoadClubsFromJson();
            printClubs(clubsinTown);
        }
        private void buttonChange_Click(object sender, EventArgs e)
        {
            AddChangeForm Change = new AddChangeForm("Change", "Clubs");
            Change.ShowDialog();
            clubsinTown.Clear();
            clubsinTown = LoadClubsFromJson();
            printClubs(clubsinTown);
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete("Club");
            delete.ShowDialog();
            clubsinTown.Clear();
            clubsinTown = LoadClubsFromJson();
            printClubs(clubsinTown);
        }
        private void спортивныеСооруженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacilitiesForm facilities = new FacilitiesForm();
            facilities.Show();
            facilities.Location = this.Location;
            this.Hide();
        }
        private void соревнованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompetitionsForm competitions = new CompetitionsForm();
            competitions.Show();
            competitions.Location = this.Location;
            this.Hide();
        }
        private void спортсменыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportsmenForm sportsmen = new SportsmenForm();
            sportsmen.Show();
            sportsmen.Location = this.Location;
            this.Hide();
        }
        private void организаторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrganizersForm organizers = new OrganizersForm();
            organizers.Show();
            organizers.Location = this.Location;
            this.Hide();
        }
        private void видыСпортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportsForm sports = new SportsForm();
            sports.Show();  
            sports.Location = this.Location;
            this.Hide();
        }
        private void тренерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoachesForm coaches = new CoachesForm();
            coaches.Show();
            coaches.Location = this.Location;
            this.Hide();
        }
    }
}
    
    

