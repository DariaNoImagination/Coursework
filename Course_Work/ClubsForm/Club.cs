using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Coursework
{public partial class Club //Клуб
    {
        private string name; //Название
        private Sport sport; //Спорт
        private List<Sportsman> members = new List<Sportsman>(); //Список участников клуба
        public Club() //Конструктор по умолчанию
        {
            name = "Чемпионы";
            sport = new Sport();}
        public Club(string name, Sport sport) //Конструктор с параметрами
        {
            if (name != null || name != "") this.name = name;
            else throw new Exception("Некорректное значение");
            if (sport != null) this.sport = sport;
            else sport = new Sport();
        }
        //Свойства
        public string Name
        {
            get { return name; }
            set
            { if (value != null || value != "") name = value; else throw new Exception("Некорректное значение"); }
        }
        public Sport Sport
        {
            get
            { return sport; }
            set
            { if (value != null) sport = value; else throw new Exception("Некорректное значение"); }
        }
        public List<Sportsman> Members
        {
            get => members;
            set => members = value ?? new List<Sportsman>();
        }
        public void addMember(Sportsman member) //Добавление нового участника в клуб
        {
            if (!members.Contains(member))
            {
                members.Add(member);
            }
            else
            {
                MessageBox.Show("Спорстмен уже является участником клуба.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<Sportsman> GetMembers() //Получить участников клуба
        {return members;}
    }
}


