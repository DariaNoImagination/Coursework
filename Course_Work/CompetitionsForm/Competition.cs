using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Competition //Соревнование
    {
        private string name;//Название
        private string code;//Код соревнования
        private DateTime begin;//Дата начала
        private DateTime end;//Дата конца
        private Sport type;//Вид спорта
        private Organizer organizer;//Организатор
        private SportFacility location;//Место проведения
        private List <Winner> winners = new List<Winner>();//Список призеров
        public Competition()//Конструктор по умолчанию
        {
            name = "Кубок по баскетболу";
            code = "0140012611Я";
            begin = new DateTime(2023, 1, 17);
            end = new DateTime(2023, 3, 17);
            type = new Sport();
            organizer = new Organizer();
            location = new Stadium();

        }
        public Competition(string name, string code, DateTime begin, DateTime end, Sport type, Organizer organizer, SportFacility location) //Конструктор с параметрами
        {
            if (name != null && name != "") this.name = name;
            else throw new Exception("Некорректное значение");
            if (code != null && code != "") this.code = code;
            else throw new Exception("Некорректное значение");
            if (begin != null) this.begin = begin;
            else throw new Exception("Некорректное значение");
            if (end != null) this.end = end;
            else throw new Exception("Некорректное значение");
            if (type != null) this.type = type;
            else throw new Exception("Некорректное значение");
            if (type != null) this.organizer = organizer;
            else throw new Exception("Некорректное значение");
            if (location != null) this.location = location;
            else location = new Stadium();

        }
        //Свойства
        public string Name
        {
            get { return name; }
            set
            { if (value != null || value != "") name = value; else throw new Exception("Некорректное значение"); }
        }
        public string Code
        {
            get { return code; }
            set
            { if (value != null || value != "") code = value; else throw new Exception("Некорректное значение"); }
        }
        public DateTime Begin
        {
            get { return begin; }
            set
            {
                if (value != null) begin = value; else throw new Exception("Некорректное значение");
            }
        }
        public DateTime End
        {
            get { return end; }
            set
            {
                if (value != null) end = value; else throw new Exception("Некорректное значение");
            }
        }
        public Sport Type
        {
            get { return type; }
            set
            {
                if (value != null) type = value; else throw new Exception("Некорректное значение");
            }
        }
        public Organizer Organizer
        {
            get { return organizer; }
            set
            {
                if (value != null) organizer = value; else throw new Exception("Некорректное значение");
            }
        }
        public SportFacility Location
        {
            get { return location; }
            set
            {
                if (value != null) location = value; else location = new Stadium();
            }
        }
        public List<Winner> Winners
        {
            get => winners;
            set => winners = value ?? new List<Winner>(); // Защита от установки null
        }

        //Добавить спортсмена
        public void AddWinner(Sportsman sportsman, int place)
        {
            // Проверка на null для sportsman
            if (sportsman == null)
            {
                MessageBox.Show("Некорректное значение спортсмена.", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            // Инициализация списка winners, если он еще не инициализирован
            if (winners == null)
            {
                winners = new List<Winner>();
            }

            // Проверка на существование спортсмена в списке победителей
            if (!winners.Any(w => w.Sportsman == sportsman))
            {
                winners.Add(new Winner(sportsman, place));
            }
        }

        public int GetPlaceBySportsman(Sportsman sportsman) // Получить место, которое занял определенный спортсмен в данном соревновании
        {
            var winner = winners.FirstOrDefault(w => w.Sportsman == sportsman);
            if (winner != null)
            {
                return winner.Place;
            }
            else
            {
                MessageBox.Show("Спорстмен не найден.", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }

        public List<Sportsman> GetWinners() // Получить список победителей
        {
            List<Sportsman> sportsmen = new List<Sportsman> ();
            if (winners.Count != 0)
                return winners.Select(w => w.Sportsman).ToList();
            
            else return sportsmen;
           
        }

        public override string ToString()
        {
            return $"Название {Name} Код: {Code} Дата начала: {Begin.Date.ToShortDateString()} Дата конца: {End.Date.ToShortDateString()} Вид спорта: {Type.Name} Организатор: {Organizer.Name} Место проведения: {Location.Name}";
        }
    }
    public class Winner //Победитель
    {
        private Sportsman sportsman; //Спортсмен
        private int place; //Место
        public Sportsman Sportsman { get; set; }
        public int Place { get; set; }
        public Winner(Sportsman sportsman, int place) 
        {
            if (sportsman == null)
            {
                MessageBox.Show("Некорректное значение спортсмена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (place <= 0) 
            {
                MessageBox.Show("Место должжно быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Sportsman = sportsman;
            Place = place;
        }
    }
}



    

