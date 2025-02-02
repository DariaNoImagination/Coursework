using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Coursework
{
    public partial class CoachesForm : Form
    {
        List<Coach> coachesInTown = LoadCoachesFromJson(); // Загружаем тренеров из JSON-файла
        public CoachesForm()
        {
            InitializeComponent();
            this.Text = "Спортивные организации города";
            comboBoxCoaches.Items.Add("Все тренеры");
            comboBoxCoaches.Items.Add("По виду спорта"); 
            comboBoxProperties.Items.Add("Общая информация"); 
            comboBoxProperties.Items.Add("Спортсмены"); 
            comboBoxCoaches.SelectedItem = "Все тренеры";
            comboBoxProperties.SelectedItem = "Общая информация";

            // Выводим список тренеров на форму
            printCoaches(coachesInTown);
        }
        // Метод для загрузки тренеров из JSON-файла
        static public List<Coach> LoadCoachesFromJson()
        {
            try
            {
                // Проверяем существование файла coaches.json
                if (File.Exists("coaches.json"))
                {
                    string json = File.ReadAllText("coaches.json"); // Чтение содержимого файла
                    return JsonConvert.DeserializeObject<List<Coach>>(json); // Десериализация JSON в список объектов Coach
                }
                else
                {
                    return new List<Coach>(); // Возвращаем пустой список, если файл не найден
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке тренеров из JSON: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Отображение сообщения об ошибке
                return new List<Coach>(); // Возвращаем пустой список в случае ошибки
            }
        }

        // Метод для сохранения списка тренеров в JSON-файл
        static public void SaveCoachesToJson(List<Coach> coaches)
        {
            try
            {
                string json = JsonConvert.SerializeObject(coaches, Formatting.Indented); // Сериализация списка тренеров в JSON с отступами
                File.WriteAllText("coaches.json", json); // Запись JSON в файл
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Отображение сообщения об ошибке при сохранении
            }
        }

       
        
        // Метод для вывода списка тренеров на форму
        public void printCoaches(List<Coach> coaches)
        {
            CoachChoice.Items.Clear(); 
            if (coaches.Count != 0) // Проверяем, есть ли тренеры в списке
            {
                foreach (Coach coach in coaches) // Перебираем каждого тренера
                {
                    CoachChoice.Items.Insert(0, $"{coach.SecondName} {coach.Name} {coach.Patronymic}"); // Добавляем полное имя тренера в комбобокс
                }
            }
            else
            {
                CoachChoice.Items.Add("Тренеров не найдено."); // Если нет тренеров, выводим сообщение
            }
        }



        // Метод для вывода информации о конкретном тренере
        public void printInfo(Coach coach)
        {
            Properties.Items.Clear();
            if (coach != null) // Проверяем, что тренер не равен null
            {
                Properties.Items.Insert(0, $"Фамилия:{coach.SecondName} Имя: {coach.Name} Отчество: {coach.Patronymic} Звание: {coach.Title} Спорт: {coach.Sport.Name} "); // Выводим информацию о тренере
            }
            else
            {
                Properties.Items.Insert(0, "Информация не найдена"); // Если тренер равен null, выводим сообщение об отсутствии информации
            }
        }




        // Метод для вывода списка спортсменов, связанных с тренером
        public void printSportsmen(List<Sportsman> sportsmen)
        {
            Properties.Items.Clear(); 
            if (sportsmen.Count != 0) // Проверяем, есть ли спортсмены в списке
            {
                foreach (Sportsman sportsman in sportsmen) // Перебираем каждого спортсмена
                {
                    Properties.Items.Insert(0, $"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}"); // Добавляем полное имя спортсмена в список свойств
                }
            }
            else
            {
                Properties.Items.Add("Тренер не тренерует спортсменов"); // Если нет спортсменов, выводим сообщение
            }
        }


       
        private void comboBoxCoaches_SelectedIndexChanged(object sender, EventArgs e)   // Обработчик изменения выбранного элемента в комбобоксе
        {
          
            switch (comboBoxCoaches.SelectedIndex)
            {
                case 0: // Если выбран "Все тренеры"
                    printCoaches(coachesInTown); // Выводим всех тренеров
                    break;


                case 1: // Если выбран "По виду спорта"
                    SortCoaches sortCoaches = new SortCoaches(); // Создаем форму для сортировки тренеров
                    sortCoaches.ShowDialog(); 
                    printCoaches(sortCoaches.getCoaches()); // Выводим отсортированных тренеров
                    break;
            }
        }



        private void button4_Click(object sender, EventArgs e)   // Обработчик нажатия кнопки для вывода информации
        {
          
            if (coachesInTown == null || coachesInTown.Count == 0) // Проверяем, есть ли тренеры в списке
            {
                Properties.Items.Add("Список тренеров пуст."); // Если список пуст, выводим сообщение
                return;
            }

            Coach neededCoach = null; 
                                             
            foreach (Coach coach in coachesInTown) 
                if ($"{coach.SecondName} {coach.Name} {coach.Patronymic}" == CoachChoice.Text) // Находим нужного тренера по полному имени
                    neededCoach = coach; // Сохраняем найденного тренера

            Properties.Items.Clear();

            switch (comboBoxProperties.SelectedIndex)
            {
                case 0: // Если выбрана "Общая информация"
                    if (neededCoach != null)
                    printInfo(neededCoach); // Выводим общую информацию о тренере
                    else Properties.Items.Add("Информация не найдена"); 
                    break;


                case 1: // Если выбрана "Спортсмены"
                    if (neededCoach != null)
                    {
                        var Sportsmen = neededCoach.GetSportsmen(); // Получаем список спортсменов, которых тренирует данный тренер
                        printSportsmen(Sportsmen); // Выводим список спортсменов
                    }
                    else Properties.Items.Add("Информация не найдена");
                    break;
            }
        }



        private void button2_Click(object sender, EventArgs e) // Обработчик нажатия кнопки для добавления нового тренера
        {
            
            AddChangeForm2 add = new AddChangeForm2("Add", "Coaches"); 
            add.ShowDialog(); 
            coachesInTown = LoadCoachesFromJson(); 
            printCoaches(coachesInTown); 
        }

        private void button3_Click(object sender, EventArgs e) // Обработчик нажатия кнопки для изменения информации о тренере
        {
            
            AddChangeForm2 change = new AddChangeForm2( "Change", "Coaches"); 
            change.ShowDialog();
            coachesInTown = LoadCoachesFromJson(); 
            printCoaches(coachesInTown); 
        }

        private void button1_Click(object sender, EventArgs e)   // Обработчик нажатия кнопки для удаления тренера
        {
          
            Delete delete = new Delete("Coaches"); 
            delete.ShowDialog(); 
            coachesInTown = LoadCoachesFromJson(); 
            printCoaches(coachesInTown);
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

        private void спорToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacilitiesForm facilities = new FacilitiesForm();
            facilities.Show();
            facilities.Location = this.Location;
            this.Hide();
        }
         private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(Properties.Items[e.Index].ToString(), Properties.Font, Properties.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (Properties.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(Properties.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
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
    }
}

