using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Coursework
{
    public partial class AddChangeForm : Form
    {
        List<Club> clubs = ClubsForm.LoadClubsFromJson(); //Чтение из файлов
        List<Sport> sports = SportsForm.LoadSportFromJson();
        List<Sportsman> sportsmenInTown = SportsmenForm.LoadSportsmenFromJson();
        List<Competition> competitionsInTown = CompetitionsForm.LoadCompetitionsFromJson();
        List <Organizer> organizers = OrganizersForm.LoadOrganizersFromJson();
        List<Sportsman> sportsmenInClub = new List<Sportsman>(); //Список спортсменов, выбранных пользователем
        List<Competition> competitionsInOrganizer = new List<Competition>(); //Список соревнований, выбранных пользователем
        // Поле для хранения типа выполняемого действия (добавление или изменение)
        private string whatToDo;
        // Поле для хранения типа объекта, с которым работаем (клуб или организатор)
        private string objectType;

        public AddChangeForm(string whatToDo, string objectType)
        {
            InitializeComponent();
            
            this.whatToDo = whatToDo; // Сохраняем тип действия (добавить/изменить)
            this.objectType = objectType; // Сохраняем тип объекта (клуб/организатор)

            // В зависимости от типа объекта настраиваем интерфейс формы
            switch (objectType)
            {
                // Если работаем с клубами
                case "Clubs":
                    label2.Text = "Название клуба"; 
                    label3.Text = "Вид спорта"; 
                    comboBoxType.Hide(); 
                    comboBoxSport.Show(); 
                    // Заполняем comboBoxSport названиями видов спорта
                    foreach (Sport sport in sports) { comboBoxSport.Items.Add(sport.Name); }

                    // Заполняем checkedListBox1 именами всех спортсменов
                    foreach (Sportsman sportsman in sportsmenInTown) checkedListBox1.Items.Add($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}");

                    // В зависимости от действия (whatToDo) настраиваем форму
                    switch (whatToDo)
                    {
                        case "Add": // Если добавляем новый клуб
                            this.Text = "Добавление клуба";
                            label.Text = "Введите характеристики объекта"; 
                            comboBoxChooseObject.Hide(); 
                            checkedListBox1.Show(); 
                            label1.Text = "Спортсмены";
                            button.Text = "Добавить участников"; 
                            buttonAdd.Text = "Добавить";  
                            break;
                        case "Change":  //Если изменяем клуб
                            this.Text = "Редактирование клуба";
                            foreach (Club club in clubs) comboBoxChooseObject.Items.Add(club.Name);
                            label.Text = "Выберите объект для редактирования"; 
                            label1.Text = "Редактировать участников"; 
                            button.Text = "Изменить"; 
                            buttonAdd.Text = "Изменить"; 
                            checkedListBox1.Show();  
                            comboBoxChooseObject.Show();  
                            break;
                    }
                    break;


                // Если работаем с организаторами
                case "Organizers":
                    label2.Text = "Название";  
                    label3.Text = "Тип"; 
                    comboBoxType.Show(); 
                    comboBoxSport.Hide(); 
                    comboBoxType.Items.Add("Организатор"); comboBoxType.Items.Add("Организация"); 
                                                                                              
                    foreach (Competition competion in competitionsInTown) checkedListBox1.Items.Add(competion.Name);
                    

                    // В зависимости от действия (whatToDo) настраиваем форму
                    switch (whatToDo)
                    {
                        case "Add": // Если добавляем нового организатора
                            this.Text = "Добавление организатора";
                            label.Text = "Введите характеристики объекта"; 
                            comboBoxChooseObject.Hide(); 
                            checkedListBox1.Show(); 
                            label1.Text = "Соревнования"; 
                            button.Text = "Добавить соревнования"; 
                            buttonAdd.Text = "Добавить";  
                            break;

                        case "Change": // Если изменяем существующего организатора
                            this.Text = "Редактирование организатора";
                            foreach (Organizer organizer in organizers) comboBoxChooseObject.Items.Add(organizer.Name);
                            label.Text = "Выберите объект для редактирования";  
                            label1.Text = "Редактировать соревнования"; 
                            button.Text = "Изменить соревнования";   
                            buttonAdd.Text = "Изменить"; 
                            checkedListBox1.Show(); 
                            comboBoxChooseObject.Show();  
                            break;
                    }
                    break;}}

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Проверяем, поле на корректность
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Некорректное значение названия", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error); // Выводим сообщение об ошибке, если поле пустое
                return; // Выходим из метода
            }

            // В зависимости от типа объекта
            switch (objectType)
            {
                // Если работаем с клубами
                case "Clubs":
                    // Проверяем, нет ли уже клуба с таким названием в списке (если не изменяем объект)
                    foreach (Club clubInTown in clubs)
                    {
                        if (textBoxName.Text == clubInTown.Name && whatToDo != "Change")
                        {
                            MessageBox.Show("Клуб с таким названием уже есть в городе!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); // Выводим сообщение об ошибке, если клуб с таким названием уже есть
                            return;
                        }
                    }

                    Sport selectedSport = GetSelectedSport(); // Получаем выбранный вид спорта

                    Club club = new Club // Создаем новый объект клуба
                    {
                        Name = textBoxName.Text,
                        Sport = selectedSport,
                    };

                    foreach (Sportsman member in sportsmenInClub) club.addMember(member);  // Добавляем спортсменов в клуб
                    if (whatToDo == "Change") clubs.RemoveAll(clubRemove => clubRemove.Name == comboBoxChooseObject.Text); // Если режим изменения, удаляем клуб из списка
                    clubs.Add(club);  // Добавляем (новый или измененный) клуб в список
                    ClubsForm.SaveClubsToJson(clubs);
                    break;

                // Если работаем с организаторами
                case "Organizers":
                    // Проверяем, нет ли уже организатора с таким названием в списке (если не в режиме изменения)
                    foreach (Organizer organizerInTown in organizers)
                    {
                        if (textBoxName.Text == organizerInTown.Name && whatToDo != "Change")
                        {
                            MessageBox.Show("Организатор с таким названием уже существует!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); // Выводим сообщение об ошибке, если организатор с таким названием уже есть
                            return;
                        }
                    }

                    if (comboBoxType.SelectedItem == null) MessageBox.Show("Тип организатора не выбран!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Organizer organizer = new Organizer
                        {
                            Name = textBoxName.Text,
                            Type = comboBoxType.SelectedItem.ToString(),
                        };

                        foreach (Competition competition in competitionsInOrganizer) organizer.AddCompetititon(competition);
                        if (whatToDo == "Change") organizers.RemoveAll(organizerRemove => organizerRemove.Name == comboBoxChooseObject.Text);  // Если режим изменения, удаляем организатора из списка
                        organizers.Add(organizer); // Добавляем (новый или измененный) организатора в список
                        OrganizersForm.SaveOrganizersToJson(organizers);
                      
                    }
                    break;}
            this.Close(); }

        // Метод для получения выбранного вида спорта
        private Sport GetSelectedSport()
        {
            foreach (Sport sport in sports)
            {
                if (sport.Name == comboBoxSport.Text)
                {
                    return sport; // Возвращаем найденный спорт
                }
            }
            return new Sport();
        }
        private void button_Click(object sender, EventArgs e)
        {
            // Обработка выбора участников для клуба
            switch (objectType) {
                case "Clubs":
            
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    // Фильтруем спортсменов и преобразуем результат в список
                    var filteredSportsmen = sportsmenInTown
                        .Where(p => $"{p.SecondName} {p.Name} {p.Patronymic}" == item.ToString())
                        .ToList();

                    // Добавляем отфильтрованных спортсменов в sportsmenInClub
                    sportsmenInClub.AddRange(filteredSportsmen);

                }
                break;

                // Обработка выбора соревнований для организаторов
                case "Organizers":
            
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    var filteredOrganizers = (competitionsInTown.Where(c => c.Name == item.ToString())).ToList();
                    competitionsInOrganizer.AddRange(filteredOrganizers);
                }
                 break;
            }
        }

        private void comboBoxChooseObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChooseObject.SelectedIndex != -1)
            {
                int selectedIndex = comboBoxChooseObject.SelectedIndex;

                switch (objectType){

                    case "Clubs":

                    Club selectedClub = new Club();
                    foreach (Club club in clubs)if (club.Name == comboBoxChooseObject.Text)selectedClub = club; //Находим выбранный клуб
                    textBoxName.Text = selectedClub.Name;
                    comboBoxSport.Text = selectedClub.Sport.Name; // Выводим его характеристики
                    checkedListBox1.Items.Clear();
                    foreach (Sportsman sportsman in sportsmenInTown)
                    {
                        checkedListBox1.Items.Add($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}");
                    }

                        break;

                    // Обработка организаторов
                    case "Organizers":
                
                    Organizer selectedOrganizer = new Organizer();
                    foreach (Organizer organizer in organizers) if (organizer.Name == comboBoxChooseObject.Text) selectedOrganizer = organizer; //Находим выбранного организатора
                    textBoxName.Text = selectedOrganizer.Name; //Выводим его характеристики
                    comboBoxType.Text = selectedOrganizer.Type; 
                   
                    checkedListBox1.Items.Clear();
                    foreach (Competition competition in competitionsInTown)
                    {
                        checkedListBox1.Items.Add(competition.Name);
                    }
                        break;
                }
            }
        }
    }
}

