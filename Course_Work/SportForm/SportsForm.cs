using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Coursework
{
    public partial class SportsForm : Form
    {
        // Список видов спорта, доступных в городе
        List<Sport> sportsInTown = new List<Sport>();
        int index; // Индекс выбранного вида спорта

        public SportsForm()
        {
            InitializeComponent(); // Инициализация компонентов формы
            InitializeUI(); // Настройка пользовательского интерфейса
            this.Text = "Спортивные организации города";
            sportsInTown = LoadSportFromJson(); // Загрузка видов спорта из JSON файла
            printSports(sportsInTown); // Вывод загруженных видов спорта 
        }

        private void InitializeUI()
        {
            // Скрытие элементов интерфейса, которые не нужны при инициализации
            textBoxCode.Hide();
            textBoxName.Hide();
            button4.Hide();
            label3.Text = ""; // Очистка текста метки
            label4.Hide();
            label5.Hide();
            listBoxInfo.Show(); // Показ списка информации
        }

        static public List<Sport> LoadSportFromJson()
        {
            try
            {
                // Проверяем существование файла sports.json
                if (File.Exists("sports.json"))
                {
                    string json = File.ReadAllText("sports.json"); // Чтение содержимого файла
                    return JsonConvert.DeserializeObject<List<Sport>>(json); // Десериализация JSON в список объектов Sport
                }
                else
                {
                    return new List<Sport>(); // Возвращаем пустой список, если файл не найден
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке спорта из JSON: {ex.Message}"); // Отображение сообщения об ошибке
                return new List<Sport>(); // Возвращаем пустой список в случае ошибки
            }
        }
        static public void SavеSportsToJson(List<Sport> sports)
        {
            try
            {
                string json = JsonConvert.SerializeObject(sports, Formatting.Indented); // Сериализация списка спортов в JSON с отступами
                File.WriteAllText("sports.json", json); // Запись JSON в файл
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}"); // Отображение сообщения об ошибке при сохранении
            }
        }
        public void printSports(List<Sport> sports)
        {
            listBoxSports.Items.Clear(); // Очистка списка видов спорта перед выводом новых данных
            if (sports.Count != 0)
            {
                foreach (var sport in sports)
                {
                    listBoxSports.Items.Insert(0, sport.Name); // Добавление названий видов спорта в список
                }
            }
            else
            {
                listBoxSports.Items.Add("Видов спорта не найдено"); // Сообщение о том, что виды спорта не найдены
            }
        }

        public void printInfo(Sport sport)
        {
            listBoxInfo.Items.Clear(); // Очистка списка информации перед выводом новых данных
            if (sport != null)
            {
                listBoxInfo.Items.Insert(0, $"Название: {sport.Name} Код: {sport.Code}"); // Вывод информации о выбранном виде спорта
            }
            else
            {
                listBoxInfo.Items.Insert(0, "Информация не найдена"); // Сообщение о том, что информация не найдена
            }
        }

        private void listBoxSports_SelectedIndexChanged(object sender, EventArgs e)  // Обработка изменения выбранного элемента в списке видов спорта
        {
            index = sportsInTown.Count -1- listBoxSports.SelectedIndex;
            if (index >= 0 && index < sportsInTown.Count)
            {
                textBoxCode.Text = sportsInTown[index].Code; // Заполнение текстового поля кода выбранного вида спорта
                textBoxName.Text = sportsInTown[index].Name; // Заполнение текстового поля имени выбранного вида спорта
            }
                foreach (Sport sport in sportsInTown)
            {
                if (sport.Name == listBoxSports.Text)
                {
                    printInfo(sport); // Вывод информации о выбранном виде спорта
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Обработка нажатия кнопки для добавления нового вида спорта
        {
            
            textBoxCode.Clear(); 
            textBoxName.Clear(); 
            ShowSportInputFields("Добавить", "Введите характеристики вида спорта:"); 
        }

        private void button2_Click(object sender, EventArgs e)  // Обработка нажатия кнопки для редактирования выбранного вида спорта
        {
          ShowSportInputFields("Изменить", "Измените характеристики вида спорта:");
          printSports(sportsInTown);
        }
        private void button3_Click(object sender, EventArgs e)  // Обработка нажатия кнопки для удаления выбранного вида спорта
        {
           
            if (index >= 0 && index < sportsInTown.Count) 
            {
                sportsInTown.RemoveAt(index); 
                SavеSportsToJson(sportsInTown); // Сохранение обновленного списка в JSON файл
                sportsInTown = LoadSportFromJson(); // Загрузка обновленного списка из файла
                printSports(sportsInTown); // Обновление отображаемого списка видов спорта
            }
        }

        private void button4_Click(object sender, EventArgs e) // Обработка нажатия кнопки для добавления или изменения вида спорта
        {
            
            if (!ValidateInput()) // Проверка корректности введенных данных
                return; // Выход из метода, если данные некорректны

            Sport sport = new Sport
            {
                Name = textBoxName.Text, // Создание нового объекта Sport с введенными данными
                Code = textBoxCode.Text,
            };

            if (button4.Text == "Изменить") // Проверка, если кнопка предназначена для изменения существующего вида спорта
            {
                sportsInTown[index] = sport; // Изменяем существующий элемент в списке
            }
            else
            {
                sportsInTown.Add(sport); // Добавляем новый спорт в список
            }

            SavеSportsToJson(sportsInTown); 
            sportsInTown = LoadSportFromJson(); 
            printSports(sportsInTown);
            textBoxName.Clear(); 
            textBoxCode.Clear(); 
            InitializeUI(); // Восстановление пользовательского интерфейса к начальному состоянию
        }
        private void ShowSportInputFields(string buttonText, string labelText)
        {
            // Отображение полей ввода для добавления или изменения вида спорта
            listBoxInfo.Hide(); 
            textBoxCode.Show(); 
            textBoxName.Show(); 
            label4.Show();
            label5.Show();
            button4.Show();

            button4.Text = buttonText; 
            label3.Text = labelText; 
        }

        private bool ValidateInput()
        {
            // Проверка корректности введенных данных
            if (string.IsNullOrWhiteSpace(textBoxName.Text)) 
            {
                MessageBox.Show("Некорректное значение названия", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error); // Сообщение об ошибке
                return false; // Возвращаем false, если данные некорректны
            }

            foreach (Sport sportInTown in sportsInTown) // Проверка на уникальность названия вида спорта
            {
                if (textBoxName.Text == sportInTown.Name && button4.Text != "Изменить") // Если такой спорт уже есть и не происходит изменение
                {
                    MessageBox.Show("Такой спорт уже добавлен!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); // Сообщение об ошибке
                    return false; // Возвращаем false, если данные некорректны
                }
            }

            // Проверка корректности введенного кода вида спорта
            if (string.IsNullOrWhiteSpace(textBoxCode.Text) ||
                textBoxCode.Text.Replace(".", "").Length != 11 ||
                textBoxCode.Text[0] == '-')
            {
                MessageBox.Show("Некорректное значение кода вида спорта", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); // Сообщение об ошибке
                return false; // Возвращаем false, если данные некорректны
            }

            return true; // Возвращаем true, если все проверки пройдены успешно
        }

        private void спортивныеСооруженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Обработка нажатия пункта меню для перехода к форме спортивных сооружений
            FacilitiesForm facilities = new FacilitiesForm(); 
            facilities.Show(); 
            facilities.Location = this.Location; 
            this.Close(); 
        }
        private void спорстменыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Обработка нажатия пункта меню для перехода к форме спортсменов
            SportsmenForm sportsmen = new SportsmenForm(); 
            sportsmen.Show(); 
            sportsmen.Location = this.Location; 
            this.Close();
        }
        private void тренерыToolStripMenuItem_Click(object sender, EventArgs e) // Обработка нажатия пункта меню для перехода к форме тренеров
        {
            CoachesForm coaches = new CoachesForm();
            coaches.Show();
            coaches.Location = this.Location;
            this.Close();
        }
        private void соревнованияToolStripMenuItem_Click(object sender, EventArgs e) // Обработка нажатия пункта меню для перехода к форме соревнований
        {
            CompetitionsForm competitions = new CompetitionsForm();
            competitions.Show();
            competitions.Location = this.Location;
            this.Close();

        }
        private void клубыToolStripMenuItem_Click(object sender, EventArgs e) // Обработка нажатия пункта меню для перехода к форме клубов
        {
            ClubsForm clubs = new ClubsForm();
            clubs.Show();
            clubs.Location = this.Location;
            this.Close();
        }
        private void организаторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrganizersForm organizers = new OrganizersForm();
            organizers.Show();
            organizers.Location = this.Location;
            this.Close();
        }
    }
}
           