using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Coursework
{
    public partial class AddChangeForm2 : Form
    {
        string whatToDo;  //Что сделать - добавить или редактировать 
        string objectType; //С каким объектом производить действия - спортсменами или тренерами
        List<Sportsman> sportsmenInTown = SportsmenForm.LoadSportsmenFromJson(); // Загружаем  из файла
        List<Competition> competitionsInTown = CompetitionsForm.LoadCompetitionsFromJson(); 
        List<Club> clubsInTown = ClubsForm.LoadClubsFromJson();
        List<Coach> coachesInTown = CoachesForm.LoadCoachesFromJson(); 
        List<Sport> sportsInTown = SportsForm.LoadSportFromJson();
        List<Sport> sports = new List<Sport>(); //Выбранные пользователем виды спорта
        List<Sportsman> sportsmen = new List<Sportsman>(); //Выбранные пользователем спортсмены
        List<Competition> participationInCompetitions = new List<Competition>(); //Выбранные пользователем соревнования
        
        public AddChangeForm2(string whatToDo, string objectType)
        {
            InitializeComponent();
            this.whatToDo = whatToDo;
            this.objectType = objectType;
            checkedListBox.Hide();
            checkedListBoxCompetitions.Hide();
            checkedListBoxSports.Hide();
           
            foreach (Competition competition in competitionsInTown) checkedListBoxCompetitions.Items.Add(competition.Name);
            foreach (Sport sport in sportsInTown) checkedListBoxSports.Items.Add(sport.Name);
            
            
            switch (objectType)
            {
                case "Sportsmen": //Если объект - спортсмен
                    foreach (Coach coach in coachesInTown) checkedListBox.Items.Add($"{coach.SecondName} {coach.Name} {coach.Patronymic}");
                    foreach (Club club in clubsInTown) comboBoxClub.Items.Add(club.Name);
                    label5.Text = "Код:";
                    label4.Text = "Клуб:";
                    comboBoxClub.Show();
                    comboBoxSports.Hide();
                    buttonCompetition.Show();
                    buttonSport.Show();
                    textBoxTitle.Hide();
                    textBoxCode.Show();
                    switch (whatToDo)
                    {

                        case "Add": //Если добавляем новый объект
                            this.Text = "Добавление спортсмена";
                            label1.Text = "Введите характеристики объекта";
                            comboBoxObject.Hide();
                            button2.Text = "Добавить";
                            buttonCompetition.Text = "Добавить соревнования";
                            button.Text = "Добавить тренеров";
                            buttonSport.Text = "Добавить виды спорта";
                            break;

                        case "Change": //Если изменяем объект
                            this.Text = "Редактирование спортсмена";
                            foreach (Sportsman sportsman in sportsmenInTown) comboBoxObject.Items.Add($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}");
                            label1.Text = "Выберите объект для редактирования";
                            button2.Text = "Изменить";
                            buttonCompetition.Text = "Изменить соревнования";
                            button.Text = "Изменить тренеров";
                            buttonSport.Text = "Изменить виды спорта";
                            button2.Text = "Изменить";
                            checkedListBox.Show();
                            comboBoxObject.Show();
                            break;
                    }
                    break;

                case "Coaches": //Если объект - тренер
                    foreach (Sportsman sportsman in sportsmenInTown) checkedListBox.Items.Add($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}");
                    checkedListBox.Show();
                    label10.Text = "";
                    label5.Text = "Звание:";
                    label4.Text = "Спорт:";
                    comboBoxClub.Hide();
                    comboBoxSports.Show();
                    buttonCompetition.Hide();
                    buttonSport.Hide();
                    textBoxTitle.Show();
                    textBoxCode.Hide();
                    foreach (Sport sport in sportsInTown) comboBoxSports.Items.Add($"{sport.Name}");

                    switch (whatToDo)
                    {

                        case "Add": //Если добавляем новый объект
                            this.Text = "Добавление тренера"; 
                            label1.Text = "Введите характеристики объекта";
                            comboBoxObject.Hide();
                            checkedListBox.Hide();
                            button2.Text = "Добавить";
                            button.Text = "Добавить спортсменов";
                            break;

                        case "Change": //Если изменяем объект
                            this.Text = "Редактирование тренера";
                            foreach (Coach coach in coachesInTown) comboBoxObject.Items.Add($"{coach.SecondName} {coach.Name} {coach.Patronymic}");
                            label1.Text = "Выберите объект для редактирования";
                            button2.Text = "Изменить";
                            button.Text = "Изменить спортсменов";
                            checkedListBox.Hide();
                            comboBoxObject.Show();
                            break;
                    }
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (objectType) { 
                case "Sportsmen": //Если объект - спортсмен
                if (!int.TryParse(textBoxCode.Text, out int code)) //Обработка неверного ввода кода
                {
                   MessageBox.Show("Некорректное значение кода.", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;

                }

                if (string.IsNullOrWhiteSpace(textBoxName.Text)) //Обработка неверного ввода имени
                {
                    MessageBox.Show("Некорректное значение имени", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxSecondName.Text)) //Обработка неверного ввода фамилии
                        {
                    MessageBox.Show("Некорректное значение фамилии", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Club selectedClub = GetSelectedClub(); //Выбранный пользователем клуб
                Sportsman newsportsman = new Sportsman(textBoxName.Text, textBoxSecondName.Text, textBoxPatronymic.Text, code, selectedClub); //Новый объект

                foreach (var item in checkedListBoxSports.CheckedItems) //Проходим по выбранным элементам checkedListBox
                {
                    var filteredSports = (sportsInTown.Where(p => p.Name == item.ToString())).ToList();
                    sports.AddRange(filteredSports); //Добавляем их в список
                }

                for (int i = 0;i<sports.Count;i++) newsportsman.AddSport(sports[i],(SportsCategory)i); //Добавляем виды спорта и разряд по каждому к новому объекту спортсмен
                
              
                foreach (var item in checkedListBoxCompetitions.CheckedItems) //Проходим по выбранным элементам checkedListBox
                {
                   var filteredCompetitions = (competitionsInTown.Where(p => p.Name == item.ToString())).ToList();
                   participationInCompetitions.AddRange(filteredCompetitions);
                }

                foreach (Competition competition in participationInCompetitions) newsportsman.AddCompetition(competition);  //Добавляем соревнования к новому объекту спортсмен


                foreach (var item in checkedListBox.CheckedItems) // Проходим по выбранным элементам checkedListBox
                {
                    var filteredCoaches = coachesInTown.Where(coach => $"{coach.SecondName} {coach.Name} {coach.Patronymic}".Equals(item.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
                    foreach (Coach coach in filteredCoaches)
                    {
                        foreach (SportInfo sport in newsportsman.SportInfoList)
                        {
                            if (sport.GetSport().Name.Equals(coach.Sport.Name, StringComparison.OrdinalIgnoreCase)) //Если спортсмен занимается спортом тренера
                             {
                                newsportsman.AddCoach(coach.Sport, coach); //Добавляем тренера
                             }
                        }
                    }
                }

                //Если объект редактируется, удаляем из списка спортсменов редактируемого спортсмена
                if (whatToDo == "Change") sportsmenInTown.RemoveAll(sportsman => $"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}" == comboBoxObject.Text);
                sportsmenInTown.Add(newsportsman); //Добавляем нового спортсмена
                SportsmenForm.SaveSportsmenToJson(sportsmenInTown);
                break;


            //Если объект - тренер
            case "Coaches":
                    if (string.IsNullOrWhiteSpace(textBoxName.Text)) //Проверка ввода имени
                    {
                        MessageBox.Show("Некорректное значение имени", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Проверка ввода фамилии
                    if (string.IsNullOrWhiteSpace(textBoxSecondName.Text))
                    {
                        MessageBox.Show("Некорректное значение фамилии", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //Выбранный пользователем спорт
                    Sport selectedSport = GetSelectedSport();
                    //Создание нового объекта тренер
                    Coach newCoach = new Coach(textBoxName.Text, textBoxSecondName.Text, textBoxPatronymic.Text, textBoxTitle.Text, selectedSport);

                    //Проходим по выбранным элементам checkedListBox и добавляем спортсменов в список
                    foreach (var item in checkedListBox.CheckedItems)
                    {
                        var filteredSportsmen = (sportsmenInTown.Where(sportsman => $"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}" == item.ToString())).ToList();
                        sportsmen.AddRange(filteredSportsmen);
                    }

                    //Добавляем спортсменов тренеру
                    foreach (Sportsman sportsman in sportsmen) newCoach.AddSportsman(sportsman);
                 
                    //Если объект редактируется, удаляем из списка тренеров редактируемого тренера
                    if (whatToDo == "Change") coachesInTown.RemoveAll(coach =>$"{coach.SecondName} {coach.Name} {coach.Patronymic}" == comboBoxObject.Text); 
                    coachesInTown.Add(newCoach);    //Добавляем новый объект
                    CoachesForm.SaveCoachesToJson(coachesInTown); //Сохраняем в файл 
                    break;
            
            }
            this.Close();
           
        }
        private Sport GetSelectedSport()
        {
            // Метод для получения выбранного вида спорта из ComboBox
            foreach (Sport sport in sportsInTown)
            {
                // Перебираем все виды спорта
                if (sport.Name == comboBoxSports.Text)
                {
                    // Если имя вида спорта совпадает с выбранным в ComboBox, возвращаем этот вид спорта
                    return sport;
                }
            }
            // Если вид спорта не найден, возвращаем новый объект Sport
            return new Sport();
        }
        private Club GetSelectedClub()
        {
            // Метод для получения выбранного клуба из ComboBox
            foreach (Club club in clubsInTown)
            {
                // Перебираем все клубы
                if (club.Name == comboBoxClub.Text)
                {
                    // Если имя клуба совпадает с выбранным в ComboBox, возвращаем этот клуб
                    return club;
                }
            }
            // Если клуб не найден, возвращаем новый объект Club
            return new Club();
        }

        private void comboBoxObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (objectType) {

                case "Sportsmen":
                Sportsman selectedSportsman = new Sportsman();
                foreach (Sportsman sportsman in sportsmenInTown) if ($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}" == comboBoxObject.Text) //Перебираем всех спортсменов. 
                        selectedSportsman = sportsman; //Выбранный пользователем спортсмен 

                // Заполняем текстовые поля данными спортсмена
                textBoxCode.Text = selectedSportsman.Code.ToString();
                textBoxName.Text = selectedSportsman.Name;
                textBoxSecondName.Text = selectedSportsman.SecondName;
                textBoxPatronymic.Text = selectedSportsman.Patronymic;
                comboBoxClub.Text = selectedSportsman.ParticipationInClub?.Name;
                break;


                case "Coaches":
                Coach selectedCoach = new Coach();
                foreach (Coach coach in coachesInTown) if ($"{coach.SecondName} {coach.Name} {coach.Patronymic}" == comboBoxObject.Text) //Перебираем тренеров
                        selectedCoach = coach; //Выбранный пользователем тренер 
               
                // Заполняем текстовые поля данными тренера
                textBoxName.Text = selectedCoach.Name;
                textBoxSecondName.Text = selectedCoach.SecondName;
                textBoxPatronymic.Text = selectedCoach.Patronymic;
                textBoxTitle.Text = selectedCoach.Title;
                comboBoxSports.Text = selectedCoach.Sport?.Name;
                break;
            }

        }
        private void buttonCoach_Click(object sender, EventArgs e)
        {
            
            switch (objectType)
            {
                case "Sportsmen":
                    checkedListBox.Show();
                    checkedListBoxCompetitions.Hide();
                    checkedListBoxSports.Hide();
                    
                    break;
                case "Coaches":
                    checkedListBox.Show();
                    checkedListBoxCompetitions.Hide();
                    checkedListBoxSports.Hide();
                    break;

            }
        }
        private void buttonCompetition_Click(object sender, EventArgs e)
        {
            checkedListBox.Hide();
            checkedListBoxCompetitions.Show();
            checkedListBoxSports.Hide();
        }
        private void buttonSport_Click(object sender, EventArgs e)
        {
            checkedListBox.Hide();
            checkedListBoxCompetitions.Hide();
            checkedListBoxSports.Show();
        }}}

