using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Coursework
{
    public partial class FacilitiesForm : Form
    {
        int index;
        List<Competition> sortCompetitions = new List<Competition>(); //Отсортированные соревнования
        List<SportFacility> sportFacilitiesinTown = FacilitiesForm.LoadSportFacilitiesFromJson();  //Загрузка спортивных сооружений из файла

        public FacilitiesForm()
        {

            InitializeComponent();
            this.Text = "Спортивные организации города";
            comboBoxSportFacilities.Items.Add("Все сооружения");
            comboBoxSportFacilities.Items.Add("Стадионы");
            comboBoxSportFacilities.Items.Add("Бассейны");
            comboBoxSportFacilities.Items.Add("Корты");
            comboBoxSportFacilities.Items.Add("Спортзалы");
            comboBoxSportFacilities.Items.Add("Манежи");
            comboBoxSportFacilities.SelectedItem = "Все сооружения";
            comboBoxProperties.Items.Add("Общая информация");
            comboBoxProperties.Items.Add("Cоревнования");
            comboBoxProperties.SelectedItem = "Общая информация";
            printFacilities(sportFacilitiesinTown); //Вывод всех соревнований на форму
        }


        private const string FilePath = "sportfacilities.json";

        public static List<SportFacility> LoadSportFacilitiesFromJson() //Загрузка из файла
        {
            try
            {
                if (File.Exists(FilePath)) // Проверяем, существует ли файл
                {
                    string json = File.ReadAllText(FilePath); // Читаем содержимое файла
                                                             
                    return JsonConvert.DeserializeObject<List<SportFacility>>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto // Обработка информации о типе
                    });
                }
                else
                {
                    return new List<SportFacility>(); // Возвращаем пустой список, если файл не найден
                }
            }
            catch (Exception ex) // Обработка возможных исключений
            {
                MessageBox.Show($"Ошибка при загрузке! {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<SportFacility>(); // Возвращаем пустой список в случае ошибки
            }
        }




        public static void SaveSportFacilitiesToJson(List<SportFacility> facilities) //Сохранение в файл
        {
            try
            {
                // Сериализуем список объектов SportFacility в JSON
                string json = JsonConvert.SerializeObject(facilities, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto // Сохранение информации о типе
                });

                File.WriteAllText(FilePath, json); // Записываем JSON в файл
             
            }
            catch (Exception ex) // Обработка возможных исключений
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void printFacilities(List<SportFacility> sportFacilities) // Вывод спортивных сооружений на форму
        {
            SportFacillityChoice.Items.Clear(); 
            if (sportFacilities != null &&  sportFacilities.Count != 0 ) // Проверяем, есть ли сооружения в списке
            {
                foreach (var facility in sportFacilities) // Перебираем все сооружения
                {
                    SportFacillityChoice.Items.Insert(0, facility.Name); // Добавляем название сооружения на форму
                }
            }
            else SportFacillityChoice.Items.Add("Спортивных сооружений не найдено."); // Иначе добавляем сообщение, если нет сооружений
        }


        public void printFaciliityWithType(object newobject) // Вывод сооружений определенного типа
        {
            // Фильтруем спортивные сооружения по типу
            var sportFacilitiesWithType = sportFacilitiesinTown.Where(facilitySort => facilitySort.getSportFacilitywithType(newobject));
            printFacilities(sportFacilitiesWithType.ToList()); // Выводим отфильтрованные сооружения
        }


        private void comboBoxSportFacilities_SelectedIndexChanged(object sender, EventArgs e) // Обработка выбора типа спортивного сооружения из выпадающего списка
        {
            
            switch (comboBoxSportFacilities.Text)
            {
                case "Все сооружения":
                    {
                        printFacilities(sportFacilitiesinTown); // Выводим все сооружения
                        break;
                    }

                case "Стадионы":
                    {
                        Stadium newobject = new Stadium(); // Создаем объект стадиона
                        SortFacilities settings = new SortFacilities(newobject, "Вместимость");
                        settings.ShowDialog(); 
                        SportFacillityChoice.Items.Clear(); // Очищаем список выбора сооружений           
                        if (settings.getSportFacilitiesinTownSort() != null) printFacilities(settings.getSportFacilitiesinTownSort()); // Выводим отсортированные сооружения или сооружения с выбранным типом
                        else printFaciliityWithType(newobject);
                        break;
                    }
                case "Бассейны":
                    {
                        SwimmingPool newobject = new SwimmingPool(); // Создаем объект бассейна
                        SortFacilities settings = new SortFacilities(newobject, "Глубина"); // Открываем форму для сортировки бассейнов
                        settings.ShowDialog(); 
                        SportFacillityChoice.Items.Clear(); // Очищаем список выбора сооружений                      
                        if (settings.getSportFacilitiesinTownSort() != null) printFacilities(settings.getSportFacilitiesinTownSort()); // Выводим отсортированные сооружения или сооружения с выбранным типом
                        else { printFaciliityWithType(newobject); }
                        break;
                    }
                case "Корты":
                    {
                        Court newobject = new Court(); // Создаем объект корта
                        SortFacilities settings = new SortFacilities(newobject, "Тип покрытия"); // Открываем форму для сортировки кортов
                        settings.ShowDialog(); 
                        SportFacillityChoice.Items.Clear(); // Очищаем список выбора сооружений
                        if (settings.getSportFacilitiesinTownSort() != null) printFacilities(settings.getSportFacilitiesinTownSort());   // Выводим отсортированные сооружения или сооружения с выбранным типом
                        else { printFaciliityWithType(newobject); }
                        break;
                    }
                case "Спортзалы":
                    {
                        Gym newobject = new Gym(); // Создаем объект спортзала     
                        SortFacilities settings = new SortFacilities(newobject, "Тип спортзала");// Открываем форму для сортировки спортзалов
                        settings.ShowDialog(); 
                        SportFacillityChoice.Items.Clear(); // Очищаем список выбора сооружений
                        if (settings.getSportFacilitiesinTownSort() != null) printFacilities(settings.getSportFacilitiesinTownSort()); // Выводим отсортированные сооружения или сооружения с выбранным типом
                        else { printFaciliityWithType(newobject); }
                        break;
                    }
                case "Манежи":
                    {
                        Arena newobject = new Arena(); // Создаем объект манежа
                                                       
                        SortFacilities settings = new SortFacilities(newobject, "Площадь манежа"); // Открываем форму для сортировки манежей
                        settings.ShowDialog(); 
                        SportFacillityChoice.Items.Clear(); // Очищаем список выбора сооружений
                                                            // Выводим отсортированные сооружения или сооружения с выбранным типом
                        if (settings.getSportFacilitiesinTownSort() != null) printFacilities(settings.getSportFacilitiesinTownSort());
                        else { printFaciliityWithType(newobject); }
                        break;
                    }
            }
        }



        private void SportFacillityChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем индекс выбранного элемента из списка сооружений
            index = SportFacillityChoice.SelectedIndex;
            if (SportFacillityChoice.SelectedIndex < 0) index = 0;
            // Очищаем список свойств
            SportFacillityProperties.Items.Clear();
        }


        private void button1_Click(object sender, EventArgs e) // Обработка нажатия кнопки для отображения свойств или соревнований сооружения
        {
            
            switch (comboBoxProperties.SelectedIndex)
            {
                case 0: // Если выбрано отображение основных свойств сооружения

                    SportFacillityProperties.Items.Clear(); 
                    if (sportFacilitiesinTown != null) // Проверяем, что список сооружений не пустой
                    {
                        foreach (SportFacility facility in sportFacilitiesinTown) // Перебираем все сооружения
                        {
                            // Находим выбранное сооружение
                            if (facility.Name == SportFacillityChoice.Items[index].ToString())
                                SportFacillityProperties.Items.Insert(0, facility.ToString()); // Выводим информацию о сооружении
                        }
                    }
                    break;


                case 1: // Если выбрано отображение списка соревнований

                    SportFacillityProperties.Items.Clear(); 
                    {
                        if (sportFacilitiesinTown != null) // Проверяем, что список сооружений не пустой
                        {
                            foreach (SportFacility facility in sportFacilitiesinTown) // Перебираем все сооружения
                            {
                                // Находим выбранное сооружение
                                if (facility.Name == SportFacillityChoice.Items[index].ToString())
                                {
                                    if (facility.getCompetitions().Count() != 0) // Проверяем, есть ли соревнования у сооружения
                                    {
                                        // Открываем форму для сортировки соревнований
                                        SortCompetitions competitionSetting = new SortCompetitions(facility.getCompetitions());
                                        competitionSetting.ShowDialog();
                                        sortCompetitions = competitionSetting.getCompetitionsSort(); // Получаем отсортированный список соревнований
                                        if (sortCompetitions.Count() != 0)
                                        {
                                            foreach (Competition competition in sortCompetitions) // Перебираем отсортированный список соревнований
                                            {
                                                // Выводим информацию о соревнованиях
                                                SportFacillityProperties.Items.Insert(0, $"{competition.Name} Начало - {competition.Begin.ToShortDateString()} Конец - {competition.End.ToShortDateString()}");
                                            }
                                        }
                                        else SportFacillityProperties.Items.Insert(0, "Соревнования с заданными характеристиками не найдены"); // Выводим сообщение, если отсортированный список пуст
                                    }
                                    else
                                    {
                                        SportFacillityProperties.Items.Insert(0, "В данном спортивном сооружении не проводились соревнования."); // Выводим сообщение, если у сооружения нет соревнований
                                    }
                                    break; 
                                }
                            }
                        }
                    }
                    break;
            }
        }


        private void спортсменыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportsmenForm sportsmen = new SportsmenForm();
            sportsmen.Show();
            sportsmen.Location = this.Location;
            this.Hide();

        }

        private void соревнованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompetitionsForm competitions = new CompetitionsForm();
            competitions.Show();
            competitions.Location = this.Location;
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeFacility change = new ChangeFacility();
            change.ShowDialog();
            sportFacilitiesinTown = LoadSportFacilitiesFromJson();
            printFacilities(sportFacilitiesinTown);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFacility add = new AddFacility();
            add.ShowDialog();
            sportFacilitiesinTown.Clear();
            sportFacilitiesinTown = LoadSportFacilitiesFromJson();
            printFacilities(sportFacilitiesinTown);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete("SportFacility");
            delete.ShowDialog();
            sportFacilitiesinTown.Clear();
            sportFacilitiesinTown = LoadSportFacilitiesFromJson();
            printFacilities(sportFacilitiesinTown);

        }


        private void клубыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClubsForm clubs = new ClubsForm();
            clubs.Show();
            clubs.Location = this.Location;
            this.Hide();
        }


        private void организаторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrganizersForm organizers = new OrganizersForm();
            organizers.Show();
            organizers.Location = this.Location;
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SportsForm sport = new SportsForm();
            sport.Show();
            sport.Location = this.Location;
            this.Hide();
        }


        private void тренерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoachesForm coaches = new CoachesForm();
            coaches.Show();
            coaches.Location = this.Location;
            this.Hide();
        }


        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(SportFacillityProperties.Items[e.Index].ToString(), SportFacillityProperties.Font, SportFacillityProperties.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (SportFacillityProperties.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(SportFacillityProperties.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

    }
}

   