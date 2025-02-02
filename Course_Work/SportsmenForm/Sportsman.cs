using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Coursework
{
    public enum SportsCategory //Спортивные категории
    {
        CandidateMasterOfSport = 0,
        FirstSportsRank = 1,
        SecondSportsRank = 2,
        ThirdSportsRank = 3,
        FirstYouthSportsRank = 4,
        SecondYouthSportsRank = 5,
        ThirdYouthSportsRank = 6
    }
    public partial class Sportsman //Спортсмен
    {
        private string name; //Имя
        private string secondName; //Фамилия
        string patronymic; //Отчество
        private int code; //Код
        private List<Competition> partcipationInCompetition = new List<Competition>(); //Участие в соревнованиях
        private List<SportInfo> sportInfoList = new List<SportInfo>(); //Список видов спорта и информации о них
        private Club partcipationInClub; //Участие в клубе

        public Sportsman() //Конструктор по умолчанию
        {
            name = "Иван";
            secondName = "Иванов";
            patronymic = "Иванович";
            code = 34;
            partcipationInClub = new Club();

        }
        public Sportsman(string name, string secondName, string patronymic, int code, Club partcipationInClub) //Конструктор с параметрами
        {
            if (name != null || name != "") this.name = name;
            else throw new Exception("Некорректное значение");
            if (secondName != null || secondName != "") this.secondName = secondName;
            else throw new Exception("Некорректное значение");
            this.patronymic = patronymic;
            if (code > 0) this.code = code;
            else throw new Exception("Некорректное значение");
            if (partcipationInClub != null) this.partcipationInClub = partcipationInClub;
            else throw new Exception("Некорректное значение");
        }


        //Свойства
        public string Name
        {
            get { return name; }
            set
            { if (value != null || value != "") name = value; else throw new Exception("Некорректное значение"); }
        }
        public string SecondName
        {
            get
            { return secondName; }
            set
            { if (value != null || value != "") secondName = value; else throw new Exception("Некорректное значение"); }
        }
        public string Patronymic
        {
            get
            { return patronymic; }
            set
            { if (value != null || value != "") patronymic = value; else throw new Exception("Некорректное значение"); }
        }
        public int Code
        {
            get { return code; }
            set
            { if (value > 0) code = value; else throw new Exception("Некорректное значение"); }
        }
        public Club ParticipationInClub
        {
            get { return partcipationInClub; }
            set { if (value != null) partcipationInClub = value; }
        }
        public List<SportInfo> SportInfoList
        {
            get => sportInfoList;
            set => sportInfoList = value ?? new List<SportInfo>();
        }
        public List<Competition> ParticipationInCompetition
        {
            get => partcipationInCompetition;
            set => partcipationInCompetition = value ?? new List<Competition>();
        }

        //Добавление спорта
        public void AddSport(Sport sport, SportsCategory category)
        {
            // Проверяем, существует ли уже данный спорт в списке
            if (!sportInfoList.Any(info => info.Sport == sport))
            {
                sportInfoList.Add(new SportInfo { Sport = sport, Category = category, Coaches = new List<Coach>() });
            }
            else
            {
                MessageBox.Show("Вид спорта уже был добавлен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public SportsCategory? GetCategoryBySport(Sport sport) // Получить разряд спортсмена по определенному виду спорта
        {
            var sportInfo = sportInfoList.FirstOrDefault(info => info.Sport.Name == sport.Name);
            if (sportInfo != null)
            {
                return sportInfo.Category;
            }
            else
            {
                MessageBox.Show("Спорт не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public void AddCoach(Sport sport, Coach coach)
        {
            if (coach == null) throw new ArgumentNullException(nameof(coach));

            // Ищем информацию о спорте
            var sportInfo = sportInfoList.FirstOrDefault(info => info.Sport.Equals(sport));


            if (sportInfo == null)
            {
                return;
            }

            // Проверяем, есть ли уже тренер в списке
            if (!sportInfo.Coaches.Contains(coach))
            {
                sportInfo.Coaches.Add(coach); // Добавляем тренера в список
            }
            else
            {
                MessageBox.Show("Тренер уже был добавлен для данного вида спорта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void AddCompetition(Competition competition) //Добавление соревнования
        {
            if (!partcipationInCompetition.Contains(competition))
            {
                partcipationInCompetition.Add(competition);
            }
            else
            {
                MessageBox.Show("Соревнование уже добавлено для этого спортсмена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        public List<Competition> GetCompetitions() //Получить список соревнований,в которых учавствовал спортсмен
        {
            return partcipationInCompetition;
        }



   
    }

public class SportInfo //Вспомогательный класс, хранящия информацию о видах спорта, которыми занимается спортсмен
{
    // Свойства
    public Sport Sport { get; set; } //Вид спорта
    public SportsCategory? Category { get; set; } //Спортивный разряд по данному виду спорта
    private List<Coach> coaches; //Список тренеров по данному виду спорта
    public List<Coach> Coaches
    {
        get => coaches;
        set => coaches = value ?? new List<Coach>();
    }

    // Конструктор по умолчанию
    public SportInfo()
    {
        Coaches = new List<Coach>();
    }

    // Конструктор с параметрами
    public SportInfo(Sport sport, SportsCategory category)
    {
        Sport = sport;
        Category = category;
        Coaches = new List<Coach>();
    }




    // Метод для удаления тренера
    public void RemoveCoach(Coach coach)
    {
        if (coach == null) throw new ArgumentNullException(nameof(coach));

        if (Coaches.Contains(coach))
        {
            Coaches.Remove(coach);
        }
        else
        {
            MessageBox.Show("Тренер не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public Sport GetSport()
    {
        return Sport;
    }

    // Метод для получения списка тренеров
    public List<Coach> GetCoaches()
    {
        return Coaches;
    }
}
}