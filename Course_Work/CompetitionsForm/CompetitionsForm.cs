using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Coursework
{
    public partial class CompetitionsForm : Form
    {
        int index;
        List<Competition> heldCompetitionsinTown = LoadCompetitionsFromJson(); //Загрузка из файла
        List<Competition> sortCompetitions = new List<Competition>(); //Отсортированные соревнования
        public CompetitionsForm() 
        {

            InitializeComponent();
            this.Text = "Спортивные организации города";
            comboBoxCompetitions.Items.Add("Все соревнования");
            comboBoxCompetitions.Items.Add("По дате");
            comboBoxCompetitions.Items.Add("По дате и организатору"); 
            comboBoxCompetitions.Items.Add("Проведенные организатором");
            comboBoxProperties.Items.Add("Общая информация");
            comboBoxProperties.Items.Add("Призеры");
            comboBoxProperties.SelectedItem = "Общая информация";
            comboBoxCompetitions.SelectedItem = "Все соревнования";
        }
        static public List<Competition> LoadCompetitionsFromJson()
        {
            try
            {
                // Проверяем существование файла 
                if (File.Exists("competitions.json"))
                {
                    string json = File.ReadAllText("competitions.json"); // Чтение содержимого файла
                    return JsonConvert.DeserializeObject<List<Competition>>(json); 
                }
                else
                {
                    return new List<Competition>(); // Возвращаем пустой список, если файл не найден
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке соревнований из JSON: {ex.Message}","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error); // Отображение сообщения об ошибке
                return new List<Competition>(); // Возвращаем пустой список в случае ошибки
            }
        }
       
        // Метод для сохранения списка соревнований в JSON-файл
        static public void SaveCompetitionsToJson(List<Competition> competitions)
        {
            try
            {
                string json = JsonConvert.SerializeObject(competitions, Formatting.Indented); // Сериализация списка соревнований в JSON 
                File.WriteAllText("competitions.json", json); // Запись JSON в файл
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Отображение сообщения об ошибке при сохранении
            }
        }

        public void printCompetitions(List<Competition> competitions) //Вывод соревнований на форму
        {
            listBoxCompetitions.Items.Clear();

            if (competitions.Count != 0) // Проверяем, что список соревнований не пуст
            {
                foreach (var competition in competitions) // Перебираем каждое соревнование в списке
                {
                    listBoxCompetitions.Items.Insert(0, competition.Name); 
                }
            }
            else
            {
                listBoxCompetitions.Items.Add("Соревнований не найдено."); // Если список пуст, выводим сообщение
            }
        }

        // Обработчик события изменения выбранного элемента в comboBoxCompetitions
        private void comboBoxCompetitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxCompetitions.Text) // В зависимости от выбранного текста в comboBoxCompetitions
            {
                case "Все соревнования": // Если выбрано "Все соревнования"
                    {
                        printCompetitions(heldCompetitionsinTown); // Выводим все соревнования
                        break;
                    }

                default: // Если выбрано что-то другое 
                    {
                        // Создаем экземпляр формы SortCompetitions2 для сортировки соревнований
                        SortCompetitions2 settings = new SortCompetitions2(comboBoxCompetitions.Text);
                        settings.ShowDialog(); 
                        sortCompetitions = settings.getSortCompetitions(); // Получаем отсортированный список соревнований
                        if (sortCompetitions != null) printCompetitions(sortCompetitions); // Если список не пуст, выводим отсортированные соревнования
                        break;
                    }
            }
        }

        private void listBoxCompetitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listBoxCompetitions.SelectedIndex; // Сохраняем индекс выбранного соревнования
        }

        private void button4_Click(object sender, EventArgs e) //Обработчик нажатия на кнопку вывода информации о соревновании
        {
            switch (comboBoxProperties.SelectedIndex)
            {
                case 0: //Вся информация

                    listBoxProperties.Items.Clear();
                    if (heldCompetitionsinTown != null) //Если список не пуст
                    {
                        foreach (Competition competition in heldCompetitionsinTown) //Перебираем все соревнования
                        {
                            if (competition.Name == listBoxCompetitions.Items[index].ToString()) //Находим нужное соревнование
                                listBoxProperties.Items.Insert(0, competition.ToString()); //Выводим информацию о соревновании

                        }
                    }
                    break;
                case 1: //Победители
                    listBoxProperties.Items.Clear();
                    if (listBoxCompetitions.SelectedIndex != -1 && heldCompetitionsinTown != null) //Если список соревнований не пуст
                    {
                        string selectedCompetitionName = listBoxCompetitions.SelectedItem.ToString(); //Название выбранного соревнования
                        foreach (Competition competition in heldCompetitionsinTown)
                        {
                            if (competition.Name == selectedCompetitionName) //Если название соревнования совпадает с названием выбранного соревнования
                            {
                                if (competition.GetWinners().Count != 0) 
                                {
                                   
                                    foreach (var winner in competition.GetWinners())
                                    { listBoxProperties.Items.Add($"{competition.GetPlaceBySportsman(winner)} место - {winner.SecondName} {winner.Name} {winner.Patronymic}"); //Выводим победителей соревнования

                                    }
                                    return;
                                }
                                else
                                {
                                    listBoxProperties.Items.Add("Победители не найдены.");
                                    return;
                                }
                            }

                        }
                        listBoxProperties.Items.Add("Нет данных о победителях."); 
                    }
                    break;
            }
        }
        private void спортивныеСооруженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacilitiesForm sportFacilities = new FacilitiesForm();
            sportFacilities.Show();
            sportFacilities.Location = this.Location;
            this.Hide();
        }
        private void видыСпортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportsForm sports = new SportsForm();
            sports.Show();
            sports.Location = this.Location;
            this.Hide();
        }
        private void клубыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClubsForm clubs = new ClubsForm();
            clubs.Show();
            clubs.Location = this.Location;
            this.Hide();
        }
        private void спортсменыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportsmenForm sportsmen = new SportsmenForm();
            sportsmen.Show();
            sportsmen.Location = this.Location;
            this.Hide();
        }
        private void тренерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoachesForm coaches = new CoachesForm();
            coaches.Show();
            coaches.Location = this.Location;
            this.Hide();
        }
        private void организаторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrganizersForm organizers = new OrganizersForm();
            organizers.Show();
            organizers.Location = this.Location;
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddCompetition add = new AddCompetition();
            add.ShowDialog();
            heldCompetitionsinTown = LoadCompetitionsFromJson(); 
            printCompetitions(heldCompetitionsinTown);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ChangeCompetition change = new ChangeCompetition();
            change.ShowDialog();
            heldCompetitionsinTown = LoadCompetitionsFromJson();
            printCompetitions(heldCompetitionsinTown);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete("Competition");
            delete.ShowDialog();
            heldCompetitionsinTown = LoadCompetitionsFromJson();
            printCompetitions(heldCompetitionsinTown);
        }
        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(listBoxProperties.Items[e.Index].ToString(), listBoxProperties.Font, listBoxProperties.Width).Height;
        }
        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (listBoxProperties.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(listBoxProperties.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }}}
