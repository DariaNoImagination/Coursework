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
    public partial class SportsmenForm : Form
    {
        List<Sportsman> sportsmenInTown = LoadSportsmenFromJson(); //Загрузка спортсменов из файла
        List<Sportsman> sportsmenInTownSort = new List<Sportsman>(); //Отсортированный список спортсменов
        public SportsmenForm()
        {
            InitializeComponent();
            this.Text = "Спортивные организации города";
            comboBoxSportsmen.Items.Add("Все cпортсмены");
            comboBoxSportsmen.Items.Add("Занимающиеся спортом");
            comboBoxSportsmen.Items.Add("Занимающиеся у тренера");
            comboBoxSportsmen.Items.Add("По количеству видов спорта");
            comboBoxSportsmen.Items.Add("Не участвующие в соревнованиях");
            comboBoxProperties.Items.Add("Общая информация");
            comboBoxProperties.Items.Add("Виды спорта");
            comboBoxProperties.Items.Add("Тренеры");
            comboBoxProperties.Items.Add("Участие в соревнованиях");
            comboBoxSportsmen.SelectedItem = "Все cпортсмены";
            comboBoxProperties.SelectedItem = "Общая информация";
            printSportsmen(sportsmenInTown);
        }



        static public List<Sportsman> LoadSportsmenFromJson() //Загрузка списка спортсменов из файла JSON
        {
            try
            {
                // Проверяем существование файла sportsmen.json
                if (File.Exists("sportsmen.json"))
                {
                    string json = File.ReadAllText("sportsmen.json"); // Чтение содержимого файла
                    return JsonConvert.DeserializeObject<List<Sportsman>>(json); // Десериализация JSON в список объектов Sportsman
                }
                else
                {
                    return new List<Sportsman>(); // Возвращаем пустой список, если файл не найден
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"Ошибка при загрузке спортсменов из JSON: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Отображение сообщения об ошибке
                return new List<Sportsman>(); // Возвращаем пустой список в случае ошибки
            }
        }




        // Метод для сохранения списка спортсменов в JSON-файл
        static public void SaveSportsmenToJson(List<Sportsman> sportsmen)
        {
            try
            {
                string json = JsonConvert.SerializeObject(sportsmen, Formatting.Indented); // Сериализация списка спортсменов в JSON с отступами
                File.WriteAllText("sportsmen.json", json); // Запись JSON в файл
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Отображение сообщения об ошибке при сохранении
            }
        }
        public void printSportsmen(List<Sportsman> sportsmen) //Вывод спортсменов на форму
        {
           
            SportsmenChoice.Items.Clear();
            if (sportsmen.Count != 0) // Проверяем, есть ли спортсмены в списке
            {
                foreach (Sportsman sportsman in sportsmen) // Перебираем всех спортсменов
                {
                    // Выводим ФИО спортсмена 
                    SportsmenChoice.Items.Insert(0, $"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}");
                }
            }
            else SportsmenChoice.Items.Add("Спортсменов не найдено."); // Добавляем сообщение, если спортсмены не найдены
        }



        public void printInfo(Sportsman sportsman) //Вывод информации о спортсмене
        {
           
            SportsmenProperties.Items.Clear();
            if (sportsman != null) // Проверяем, что спортсмен не null
            {
                // Добавляем информацию о спортсмене в список свойств
                SportsmenProperties.Items.Insert(0, $"Фамилия:{sportsman.SecondName} Имя: {sportsman.Name} Отчество: {sportsman.Patronymic} Код:{sportsman.Code} Клуб: {sportsman.ParticipationInClub.Name}");
            }
            else
            {
                SportsmenProperties.Items.Insert(0, "Информация не найдена");  // Добавляем сообщение, если информация не найдена
            }
        }



        private string GetCategoryNameInRussian(SportsCategory? category)
        {
            // Возвращаем название спортивной категории на русском
            switch (category)
            {
                case SportsCategory.FirstSportsRank:
                    return "Первый спортивный разряд";
                case SportsCategory.SecondSportsRank:
                    return "Второй спортивный разряд";
                case SportsCategory.ThirdSportsRank:
                    return "Третий спортивный разряд";
                case SportsCategory.FirstYouthSportsRank:
                    return "Первый юношеский спортивный разряд";
                case SportsCategory.SecondYouthSportsRank:
                    return "Второй юношеский спортивный разряд";
                case SportsCategory.ThirdYouthSportsRank:
                    return "Третий юношеский спортивный разряд";
                case SportsCategory.CandidateMasterOfSport:
                    return "Кандидат в мастера спорта";
                default:
                    return "Неизвестная категория"; // На случай, если категория не распознана
            }
        }



        private void comboBoxSportsmen_SelectedIndexChanged(object sender, EventArgs e)   // Обработка выбора пункта из списка сортировки спортсменов
        {
           
            switch (comboBoxSportsmen.SelectedIndex)
            {
                case 0: // Если выбрано "Все спортсмены"
                    printSportsmen(sportsmenInTown); // Выводим всех спортсменов
                    break;


                case 1: // Если выбрана сортировка по виду спорта
                    sortSportsmen sortSportsmenBySport = new sortSportsmen("Sport"); // Создаем форму для сортировки по виду спорта
                    sortSportsmenBySport.ShowDialog(); 
                    sportsmenInTownSort = sortSportsmenBySport.GetSortedSportsman(); // Получаем отсортированных спортсменов
                    printSportsmen(sportsmenInTownSort); // Выводим отсортированных спортсменов
                    break;


                case 2:  // Если выбрана сортировка по тренеру
                    sortSportsmen sortSportsmenByCoach = new sortSportsmen("Coach"); // Создаем форму для сортировки по тренеру
                    sortSportsmenByCoach.ShowDialog();  // Показываем 
                    sportsmenInTownSort = sortSportsmenByCoach.GetSortedSportsman(); // Получаем отсортированных спортсменов
                    printSportsmen(sportsmenInTownSort); // Выводим отсортированных спортсменов
                    break;


                case 3: // Если выбран пункт "Спортсмены, занимающиеся несколькими видами спорта"
                    SportsmenChoice.Items.Clear();
                    SportsmenProperties.Items.Clear();                                      
                    foreach (Sportsman sportsman in sportsmenInTown) // Перебираем всех спортсменов
                    {
                        // Получаем список видов спорта, которыми занимается спортсмен
                        List <SportInfo> sportsInfoList = sportsman.SportInfoList;
                        // Проверяем, занимается ли спортсмен более чем одним видом спорта
                        if (sportsInfoList.Count > 1)
                        {
                            SportsmenChoice.Items.Insert(0,$"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}");

                            // Выводим все виды спорта спортсмена в список свойств
                            List<string> sportsNames = new List<string>();
                            foreach (SportInfo sportInfo in sportsInfoList)
                            {
                                Sport sport = sportInfo.GetSport();
                                sportsNames.Add(sport.Name);
                            }

                            string sportsList = string.Join(", ", sportsNames);

                            // Добавляем информацию о спортсмене и видах спорта
                            SportsmenProperties.Items.Add($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}\nКоличество видов спорта - {sportsInfoList.Count}: {sportsList}");
                        }
                    }
                    // Если не нашлось спортсменов, занимающихся несколькими видами спорта
                    if (SportsmenProperties.Items.Count == 0) SportsmenChoice.Items.Insert(0, "Все спортсмены занимаются одним видом спорта");
                    break;


                case 4:  // Если выбран пункт "Спортсмены, не участвовавшие в соревнованиях"
                    SportsmenChoice.Items.Clear(); 
                    SortCompetitions2 sortsportsmenByCompetitions = new SortCompetitions2("По дате"); 
                    sortsportsmenByCompetitions.ShowDialog(); 
                    List<Competition> sortedCompetitions = sortsportsmenByCompetitions.getSortCompetitions(); //Соревнования, проведенные в заданный период
                    if (sortedCompetitions != null)
                    {
                        var sortedCompetitionNames = new HashSet<string>(sortedCompetitions.Select(c => c.Name));
                        foreach (Sportsman sportsman in sportsmenInTown)
                        {
                            // Получаем список соревнований, в которых участвовал спортсмен
                            var participatedCompetitions = sportsman.GetCompetitions();

                            // Проверяем, участвовал ли спортсмен в любом из отсортированных соревнований
                            bool participated = participatedCompetitions.Any(v => sortedCompetitionNames.Contains(v.Name));

                            if (!participated)
                            {
                                SportsmenChoice.Items.Insert(0, $"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}");
                            }
                        }
                    }
                    if (SportsmenChoice.Items.Count == 0) { SportsmenChoice.Items.Add("Все спортсмены участвовали в"); SportsmenChoice.Items.Add("соревнованиях в заданный период"); }
                    break;
            }
        }



        private void button4_Click(object sender, EventArgs e) //Обработка нажатия кнопки для вывода информации о спортсмене
        {
           
            if (sportsmenInTown == null || sportsmenInTown.Count == 0) // Если список спортсменов пустой
            {
                SportsmenProperties.Items.Add("Список спортсменов пуст."); // Выводим сообщение, что список пуст
                return; 
            }
            Sportsman neededSportsman = null;
                                                         
            foreach (Sportsman sportsman in sportsmenInTown) // Находим выбранного спортсмена
                if ($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}" == SportsmenChoice.Text) neededSportsman = sportsman;
            
            SportsmenProperties.Items.Clear(); 

            
            switch (comboBoxProperties.SelectedIndex)
            {
                case 0:  // Если выбран пункт "Общая информация"
                    if (neededSportsman != null) 
                    printInfo(neededSportsman); // Выводим общую информацию о спортсмене
                    else SportsmenProperties.Items.Insert(0, "Информация не найдена"); 
                    break;


                case 1: // Если выбран пункт "Виды спорта"
                    SportsmenProperties.Items.Clear();
                    if (neededSportsman != null)
                    {
                        List<Sport> sports = new List<Sport>();
                        List<SportInfo> sportsInfoList = neededSportsman.SportInfoList;
                        foreach (SportInfo sportinfo in sportsInfoList) sports.Add(sportinfo.Sport); // Получаем список видов спорта, которыми занимается спортсмен

                        // Проверяем, что список видов спорта не пустой
                        if (sports != null && sports.Count != 0)
                        {
                            // Выводим информацию о видах спорта и спортивном разряде
                            foreach (Sport sport in sports)
                            {
                                SportsmenProperties.Items.Insert(0, $"{sport.Name} {GetCategoryNameInRussian(neededSportsman.GetCategoryBySport(sport))}");
                            }
                        }
                        else SportsmenProperties.Items.Insert(0, "Информация о видах спорта не найдена.");
                    }
                    else
                    {
                        SportsmenProperties.Items.Insert(0, "Информация о видах спорта не найдена."); // Выводим сообщение, если виды спорта не найдены
                    }
                    break;


                case 2: // Если выбран пункт "Тренеры"
                    SportsmenProperties.Items.Clear();
                    if (neededSportsman != null)
                    {
                        List<Coach> coaches = new List<Coach>();
                        List<SportInfo> sportsInfoList = neededSportsman.SportInfoList;
                        foreach (SportInfo sportinfo in sportsInfoList) coaches.AddRange(sportinfo.GetCoaches()); // Получаем список тренеров

                        if (coaches != null && coaches.Count != 0)  // Проверяем, что список тренеров не пустой
                        {
                            // Выводим информацию о тренерах
                            foreach (Coach coach in coaches)
                            {
                                SportsmenProperties.Items.Insert(0, $"{coach.SecondName} {coach.Name} {coach.Patronymic} Вид спорта: {coach.Sport.Name}");
                            }
                        }
                        else
                        {
                            SportsmenProperties.Items.Insert(0, "Спортсмен не тренируется у тренеров."); // Выводим сообщение, если у спортсмена нет тренеров
                        }
                    }
                    else SportsmenProperties.Items.Insert(0, "Информация не найдена");
                    break;


                case 3: // Если выбран пункт "Соревнования"
                    SportsmenProperties.Items.Clear();
                    if (neededSportsman != null)
                    {
                        List<Competition> competitions = new List<Competition>();
                        competitions = neededSportsman.GetCompetitions(); //Получаем соревнования, в которых учавствовал спортсмен
                        if (competitions != null && competitions.Count != 0) //Если список не пуст
                        {
                            // Выводим информацию о соревнованиях
                            foreach (Competition competition in competitions)
                            {
                                SportsmenProperties.Items.Insert(0, competition.Name);
                            }
                        }
                        else
                        {
                            SportsmenProperties.Items.Insert(0, "Спортсмен не участвовал в соревнованиях."); // Иначе выводим сообщение, что спортсмен не участвовал в соревнованиях
                        }
                    }
                    else
                    {
                        SportsmenProperties.Items.Insert(0, "Информация не найдена"); // Иначе выводим сообщение, что спортсмен не участвовал в соревнованиях
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddChangeForm2 add = new AddChangeForm2("Add", "Sportsmen");
            add.ShowDialog();
            sportsmenInTown = LoadSportsmenFromJson();
            printSportsmen(sportsmenInTown);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddChangeForm2 change = new AddChangeForm2("Change", "Sportsmen");
            change.ShowDialog();
            sportsmenInTown = LoadSportsmenFromJson();
            printSportsmen(sportsmenInTown);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete("Sportsmen");
            delete.ShowDialog();
            sportsmenInTown = LoadSportsmenFromJson();
            printSportsmen(sportsmenInTown);
        }

        private void спорToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacilitiesForm facilities = new FacilitiesForm();
            facilities.Show();
            facilities.Location = this.Location;
            this.Hide();
        }
        
        private void тренерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoachesForm coaches = new CoachesForm();
            coaches.Show();
            coaches.Location = this.Location;
            this.Hide();
        }

        private void соревнованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompetitionsForm competitions = new CompetitionsForm();
            competitions.Show();
            competitions.Location = this.Location;
            this.Hide();
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

        private void видыСпортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SportsForm sports = new SportsForm();
            sports.Show();
            sports.Location = this.Location;
            this.Hide();
        }

        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(SportsmenProperties.Items[e.Index].ToString(), SportInfo.Font, SportInfo.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (SportsmenProperties.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(SportsmenProperties.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }
    }
}

   
        