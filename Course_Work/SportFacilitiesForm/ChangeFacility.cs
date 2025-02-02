using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Coursework
{    public partial class ChangeFacility : Form
    {
        
        SportFacility facility;
        List<SportFacility> facilities = FacilitiesForm.LoadSportFacilitiesFromJson();
        List<Competition> competitions = CompetitionsForm.LoadCompetitionsFromJson(); 
        List <Competition> competitionsToAdd = new List<Competition>();
        int index;

        public ChangeFacility()
        {
            InitializeComponent();
            this.Text = "Редактирование спортивного сооружения";
            textBoxArea.Hide();
            textBoxCapacity.Hide();
            textBoxTypeOfCoating.Hide();
            textBoxType.Hide();
            textBoxDepth.Hide();
            label4.Text = "";
            foreach (SportFacility facility in facilities)comboBoxObjects.Items.Add(facility.Name);
            foreach (Competition competition in competitions) checkedListBoxCompetitions.Items.Add(competition.Name);

        }


        private void comboBoxObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = comboBoxObjects.SelectedIndex;
            textBoxCode.Text = facilities[index].SportFacilityCode; //Заполняем поля характеристиками выбранного для изменения сооружения
            textBoxName.Text = facilities[index].Name;
            textBoxYear.Text = facilities[index].YearOfConstruction.ToString();
            if (facilities[index] is Stadium stadium) //В зависимости от типа сооружения,обновляем интерфейс и поля
            {
                label4.Text = "Вместимость:";
                textBoxCapacity.Show();
                textBoxArea.Hide();
                textBoxTypeOfCoating.Hide();
                textBoxType.Hide();
                textBoxDepth.Hide();
                textBoxCapacity.Text = stadium.Capacity.ToString(); 
            }
            if (facilities[index] is SwimmingPool pool)
            {
                label4.Text = "Глубина:";
                textBoxArea.Hide();
                textBoxCapacity.Hide();
                textBoxTypeOfCoating.Hide();
                textBoxType.Hide();
                textBoxDepth.Show();
                textBoxDepth.Text = pool.Depth.ToString();
            }
            if (facilities[index] is Court court)
            {
                label4.Text = "Тип покрытия:";
                textBoxArea.Hide();
                textBoxCapacity.Hide();
                textBoxType.Hide();
                textBoxDepth.Hide();
                textBoxTypeOfCoating.Show();
                textBoxTypeOfCoating.Text = court.TypeOfCoating;
            }
            if (facilities[index] is Arena arena)
            {
                label4.Text = "Площадь:";
                textBoxTypeOfCoating.Hide();
                textBoxCapacity.Hide();
                textBoxType.Hide();
                textBoxDepth.Hide();
                textBoxArea.Show();
                textBoxArea.Text = arena.Area.ToString();
            }
            if (facilities[index] is Gym gym)
            {
                label4.Text = "Тип спортзала:";
                textBoxTypeOfCoating.Hide();
                textBoxCapacity.Hide();
                textBoxArea.Hide();
                textBoxDepth.Hide();
                textBoxType.Show();
                textBoxType.Text = gym.Type;
            }

        }


        private void buttonChange_Click(object sender, EventArgs e)
        {
            object neededFacility = null;
            foreach (SportFacility facility in facilities)if (facility.Name == comboBoxObjects.Text)neededFacility = facility; //Присваиваем выбранное для изменения сооружение
            //Проверка на корректность ввода кода сооружения
            if (textBoxCode.Text == null || textBoxCode.Text.Replace(".", "").Length != 11)
            {
                MessageBox.Show("Некорректное значение кода сооружения", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxName.Text)) //Проверка на корректность ввода названия
            {
                MessageBox.Show("Некорректное значение названия", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (SportFacility facility in facilities)
            {
                if (facility.Equals(facilities[index]) == false && textBoxName.Text == facility.Name) //Проверка на уникальность названия
                {
                    MessageBox.Show("Сооружение с таким названием уже есть в городе!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!int.TryParse(textBoxYear.Text, out int year)) //Проверка на корректность года постройки
            {
                MessageBox.Show("Некорректное значение года постройки.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (year > 2025 || 1860 > year)
            {
                MessageBox.Show("Некорректное значение года постройки.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (neededFacility.GetType() == typeof(Stadium)) { //Если изменяемый объект - стадион

                if (!int.TryParse(textBoxCapacity.Text, out int capacity)) //Проверка на корректность ввода вместимости
                {
                    MessageBox.Show("Некорректное значение вместимости.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                if (capacity > 81000 || 10000 > capacity)
                {
                    MessageBox.Show("Некорректное значение вместимости.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    facilities.Remove((Stadium)neededFacility); //Удаляем старый объект из списка спортивных сооружений
                    facility = new Stadium(textBoxCode.Text, capacity, textBoxName.Text, year); //Создаем новый объект
                    foreach (Competition competition in competitionsToAdd)facility.addCompetition(competition); //Добавляем новому объекту соревнования
                    facilities.Add(facility); //Добавляем новый объект
                    FacilitiesForm.SaveSportFacilitiesToJson(facilities); //Записывает обновленный список сооружений в файл

                }
            }
            else if (neededFacility.GetType() == typeof(SwimmingPool)) //Если изменяемый объект - бассейн
            { 
                if (!float.TryParse(textBoxDepth.Text, out float depth)) //Проверка ввода глубины на корректность 
                {
                    MessageBox.Show("Некорректное значение глубины.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                if (depth < 0.9f || depth > 42.15f)
                {
                    MessageBox.Show("Некорректное значение глубины.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    facilities.Remove((SwimmingPool)neededFacility);
                    facility = new SwimmingPool(textBoxCode.Text, depth, textBoxName.Text, year); //Создание нового объекта
                    foreach (Competition competition in competitionsToAdd) facility.addCompetition(competition);
                    facilities.Add(facility); //Добавление нового объекта
                    FacilitiesForm.SaveSportFacilitiesToJson(facilities);

                }
            }
            else if (neededFacility.GetType() == typeof(Court)) //Если изменяемый объект - корт
            { 
                if (string.IsNullOrWhiteSpace(textBoxTypeOfCoating.Text)) //Проверка типа покрытия на корректность 
                {
                    MessageBox.Show("Некорректное значение типа покрытия", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    facilities.Remove((Court)neededFacility);
                    facility = new Court(textBoxCode.Text, textBoxTypeOfCoating.Text, textBoxName.Text, year); //Создание новго объекта
                    foreach (Competition competition in competitionsToAdd) facility.addCompetition(competition);
                    facilities.Add(facility); //Добавление нового объекта
                    FacilitiesForm.SaveSportFacilitiesToJson(facilities);
                } 
            }

            else if (neededFacility.GetType() == typeof(Gym)) //Если изменяемый объект - спортзал
            {
                if (string.IsNullOrWhiteSpace(textBoxType.Text)) //Проверка типа на корректность 
                {
                    MessageBox.Show("Некорректное значение типа спортзала", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    facilities.Remove((Gym)neededFacility);
                    facility = new Gym(textBoxType.Text, textBoxCode.Text, textBoxName.Text, year); //Создание новго объекта
                    foreach (Competition competition in competitionsToAdd) facility.addCompetition(competition);
                    facilities.Add(facility);  //Добавление нового объекта
                    FacilitiesForm.SaveSportFacilitiesToJson(facilities);

                }
            }
            else if (neededFacility.GetType() == typeof(Arena)) //Если изменяемый тип - манеж
            {
                if (!int.TryParse(textBoxArea.Text, out int area)) //Проверка на корректность площади
                {
                    MessageBox.Show("Некорректное значение площади.", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;

                }
                if (area > 8500 || 700 > area)
                {
                    MessageBox.Show("Некорректное значение площади.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    facilities.Remove((Arena)neededFacility);
                    facility = new Arena(textBoxCode.Text, area, textBoxName.Text, year); //Создание нового объекта
                    foreach (Competition competition in competitionsToAdd) facility.addCompetition(competition);
                    facilities.Add(facility); //Добавление нового объекта
                    FacilitiesForm.SaveSportFacilitiesToJson(facilities);

                } 
            }
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxCompetitions.CheckedItems)
            {
            // Выбираем соревнования, которые отметил пользователь в checkedListBox
                List <Competition> filteredCompetitions = competitions
                    .Where(p => p.Name == item.ToString())
                    .ToList();

                // Добавляем отфильтрованные соревнования в список для добавления
                competitionsToAdd.AddRange(filteredCompetitions);

            }
        }
    }
}
