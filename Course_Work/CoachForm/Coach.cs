using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Coursework
{
    public partial class Coach //Тренер
    {
        private string name; //Имя
        private string secondName; //Фамилия
        private string patronymic; //Отчество
        private string title; //Спортивное звание
        private Sport sport; //Спорт
        private List<Sportsman> sportsmen = new List<Sportsman>(); //Спортсмены
        public Coach()
        {
            name = "Петр";
            secondName = "Петров";
            patronymic = "Петрович";
            title = "Заслуженный тренер России";
            sport = new Sport();
        }
        public Coach(string name, string secondName, string patronymic, string title, Sport sport)
        {
            this.name = name;
            this.secondName = secondName;
            this.patronymic = patronymic;
            this.title = title;
            this.sport = sport;
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
            { patronymic = value; }
        }
        public string Title
        {
            get
            { return title; }
            set
            { if (value != null || value != "") title = value; else throw new Exception("Некорректное значение"); }
        }
        public Sport Sport
        {
            get { return sport; }
            set
            {
                if (value != null) sport = value; else throw new Exception("Некорректное значение");
            }
        }
        public List<Sportsman> Sportsmen
        {
            get => sportsmen;
            set => sportsmen = value ?? new List<Sportsman>();
        }

        //Добавить спортсмена
        public void AddSportsman(Sportsman sportsman)
        {
            if (!sportsmen.Contains(sportsman))
            {
                sportsmen.Add(sportsman);
            }
            else
            {
                MessageBox.Show("Спорстмен уже добавлен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        public List<Sportsman> GetSportsmen() //Получить список спортсменов у тренера
        {
            return sportsmen;
        }
    }
}
