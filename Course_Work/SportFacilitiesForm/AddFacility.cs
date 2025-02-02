using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Coursework
{
    public partial class AddFacility : Form
    {
        SportFacility facility;
        List<Competition> competitions = CompetitionsForm.LoadCompetitionsFromJson();
        List<SportFacility> facilities = FacilitiesForm.LoadSportFacilitiesFromJson();
        List<Competition> competitionsToAdd = new List<Competition>(); // Список соревнований,которые надо добавить
      
        public AddFacility()
        {
            InitializeComponent();
            this.Text = "Добавление спортивного сооружения";
            foreach (Competition competition in competitions)
            {
                checkedListBoxCompetitions.Items.Add(competition.Name);
            }
            textBoxCapacity.Hide();
            textBoxDepth.Hide();
            textBoxType.Hide();
            textBoxTypeOfCoating.Hide();
            textBoxArea.Hide();
            comboBoxObjects.Items.Add("Стадион");
            comboBoxObjects.Items.Add("Бассейн");
            comboBoxObjects.Items.Add("Корт");
            comboBoxObjects.Items.Add("Спортзал");
            comboBoxObjects.Items.Add("Манеж");
        }

        private void comboBoxObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxObjects.SelectedIndex) //Изменяем отображение полей в зависимости от выбранного объекта
            {
                case 0: //Стадион
                    label4.Text = "Вместимость";
                    textBoxCapacity.Show();
                    textBoxDepth.Hide();
                    textBoxType.Hide();
                    textBoxTypeOfCoating.Hide();
                    textBoxArea.Hide();
                    break;
                case 1: //Бассейн
                    label4.Text = "Глубина";
                    textBoxDepth.Show();
                    textBoxCapacity.Hide();
                    textBoxType.Hide();
                    textBoxTypeOfCoating.Hide();
                    textBoxArea.Hide();
                    break;
                case 2: //Корт
                    label4.Text = "Тип покрытия";
                    textBoxTypeOfCoating.Show();
                    textBoxCapacity.Hide();
                    textBoxDepth.Hide();
                    textBoxType.Hide();
                    textBoxArea.Hide();
                    break;
                case 3: //Спортзал
                    label4.Text = "Тип спортзала";
                    textBoxType.Show();
                    textBoxCapacity.Hide();
                    textBoxDepth.Hide();
                    textBoxTypeOfCoating.Hide();
                    textBoxArea.Hide();
                    break;
                case 4: //Манеж
                    label4.Text = "Площадь";
                    textBoxArea.Show();
                    textBoxCapacity.Hide();
                    textBoxDepth.Hide();
                    textBoxType.Hide();
                    textBoxTypeOfCoating.Hide();
                    break;
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Проверка корректности ввода кода сооружения
            if (textBoxCode.Text == null || textBoxCode.Text.Replace(".", "").Length != 11 || textBoxCode.Text[0] == '-')
            { 
                MessageBox.Show("Некорректное значение кода сооружения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка корректности ввода названия сооружения
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Некорректное значение названия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на существование сооружения с таким же названием
            if (facilities != null)
            {
                foreach (SportFacility sportfacility in facilities)
                {
                    if (textBoxName.Text == sportfacility.Name)
                    {
                        MessageBox.Show("Сооружение с таким названием уже есть в городе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }


            // Проверка корректности ввода года постройки
            if (!int.TryParse(textBoxYear.Text, out int year))
            {
               
                MessageBox.Show("Некорректное значение года постройки.", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (year > 2025 || year < 1860)
            {
                MessageBox.Show("Некорректное значение года постройки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            switch (comboBoxObjects.SelectedIndex)
            {
                case 0: // Если выбран стадион
                        // Проверка корректности ввода вместимости
                    if (!int.TryParse(textBoxCapacity.Text, out int capacity))
                    {
                        MessageBox.Show("Некорректное значение вместимости.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (capacity > 81000 || capacity < 10000) // Проверка на допустимые значения вместимости
                    {
                        MessageBox.Show("Некорректное значение вместимости.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        facility = new Stadium(textBoxCode.Text, capacity, textBoxName.Text, year); //Создаем новый объект
                        foreach (Competition competition in competitionsToAdd) facility.addCompetition(competition); //Добавляем выбранные пользователем соревнования
                        if (facilities != null) facilities.Add(facility); // Добавляем объект в список
                        else { facilities = new List<SportFacility>(); facilities.Add(facility); }
                        FacilitiesForm.SaveSportFacilitiesToJson(facilities); // Сохраняем изменения
                    }
                    break;
                case 1: // Если выбран бассейн
                        // Проверка корректности ввода глубины
                    if (!float.TryParse(textBoxDepth.Text, out float depth))
                    {
                        MessageBox.Show("Некорректное значение глубины.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (depth < 0.9f || depth > 42.15f) // Проверка на допустимые значения глубины
                    {
                        MessageBox.Show("Некорректное значение глубины.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        facility = new SwimmingPool(textBoxCode.Text, depth, textBoxName.Text, year);
                        foreach (Competition competition in competitionsToAdd) facility.addCompetition(competition);
                        if (facilities != null) facilities.Add(facility); // Добавляем объект в список
                        else { facilities = new List<SportFacility>(); facilities.Add(facility); }
                        FacilitiesForm.SaveSportFacilitiesToJson(facilities); // Сохраняем изменения
                    }
                    break;
                case 2: // Если выбран корт
                        // Проверка корректности ввода типа покрытия
                    if (string.IsNullOrWhiteSpace(textBoxTypeOfCoating.Text))
                    {
                        MessageBox.Show("Некорректное значение типа покрытия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        facility = new Court(textBoxCode.Text, textBoxTypeOfCoating.Text, textBoxName.Text, year);
                        foreach (Competition competition in competitionsToAdd) facility.addCompetition(competition);
                        if (facilities != null) facilities.Add(facility); // Добавляем объект в список
                        else { facilities = new List<SportFacility>(); facilities.Add(facility); }
                        FacilitiesForm.SaveSportFacilitiesToJson(facilities); // Сохраняем изменения
                    }
                    break;
                case 3: // Если выбран спортзал
                        // Проверка корректности ввода типа спортзала
                    if (string.IsNullOrWhiteSpace(textBoxType.Text))
                    {
                        MessageBox.Show("Некорректное значение типа спортзала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        facility = new Gym(textBoxType.Text, textBoxCode.Text, textBoxName.Text, year);
                        foreach (Competition competition in competitionsToAdd) facility.addCompetition(competition);
                        if (facilities != null) facilities.Add(facility); // Добавляем объект в список
                        else { facilities = new List<SportFacility>(); facilities.Add(facility); }
                        FacilitiesForm.SaveSportFacilitiesToJson(facilities); // Сохраняем изменения
                    }
                    break;
                case 4:  // Если выбрана арена
                         // Проверка корректности ввода площади
                    if (!int.TryParse(textBoxArea.Text, out int area))
                    {
                        MessageBox.Show("Некорректное значение вместимости.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (area > 8500 || area < 700) // Проверка на допустимые значения площади
                    {
                        MessageBox.Show("Некорректное значение вместимости.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        facility = new Arena(textBoxCode.Text, area, textBoxName.Text, year);
                        foreach (Competition competition in competitionsToAdd) facility.addCompetition(competition);
                        if (facilities != null) facilities.Add(facility); // Добавляем объект в список
                        else { facilities = new List<SportFacility>(); facilities.Add(facility); }
                        FacilitiesForm.SaveSportFacilitiesToJson(facilities); // Сохраняем изменения
                    }
                    break;
            }
            this.Close(); // Закрываем форму
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
