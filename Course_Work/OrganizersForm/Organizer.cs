using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Coursework
{
    public partial class Organizer //Организатор
    {
        private string type; // Тип
        private string name; //Название
        private List<Competition> heldCompetitions = new List<Competition>(); //Проведенные соревнования
        public Organizer() //Конструктор по умолчанию
        {
            type = "Организация";
            name = "Федерация баскетбола";
        }
        public Organizer(string type, string name) //Конструктор с параметрами
        {
            if (type != null || type != "") this.type = type;
            else throw new Exception("Некорректное значение");
            if (name != null || name != "") this.name = name;
            else throw new Exception("Некорректное значение");
        }
        //Свойства
        public string Name
        {
            get { return name; }
            set
            { if (value != null || value != "") name = value; else throw new Exception("Некорректное значение"); }
        }
        public string Type
        {
            get
            { return type; }
            set
            { if (value != null || value != "") type = value; else throw new Exception("Некорректное значение"); }
        }
        public List<Competition> HeldCompetitions
        {
            get => heldCompetitions;
            set => heldCompetitions = value ?? new List<Competition>();
        }
        //Добавить проведенное соревнование
        public void AddCompetititon(Competition competition)
        {
            if (!heldCompetitions.Contains(competition))
            {
                heldCompetitions.Add(competition);
            }
            else
            {
                MessageBox.Show("Соревнование уже добавлено.","Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public List<Competition> GetCompetitions()  //Получить список соревнованиий,проведенных данным организатором
        {return heldCompetitions; }
       
  
}
}
