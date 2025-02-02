using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Coursework
{
    public abstract partial class SportFacility
    {
        private string sportFacilityCode;//Код сооружения
        private string name; //Название
        private int yearOfConstruction; //Год постройки
        protected List<Competition> competitionsHeld = new List<Competition>(); //Проведенные соревнования
        public SportFacility() //Конструктор по умолчанию
        {
            sportFacilityCode = "42.99.12.110.12";
            yearOfConstruction = 2017;
            name = "Спортивное сооружение";
        }
        public SportFacility(string code, string name, int yearofConstruction) //Конструктор с параметрами
        {
            if (code == null || code == "") throw new Exception("Некорректное значение");
            else sportFacilityCode = code;
            if (yearofConstruction > 1850 && yearOfConstruction < 2025) this.yearOfConstruction = yearofConstruction;
            else throw new Exception("Некорректное значение");
            if (name == null || name == "") throw new Exception("Некорректное значение"); else this.name = name;

        }

        public override string ToString() //Переопределенный метод, выводящий информацию об объекте
        {
            return $"Код сооружения: {sportFacilityCode} Название: {name} Год постройки: {yearOfConstruction}";
        }
        
        public override bool Equals(object obj) //Переопределение метода сравнения
        {
            if (obj is SportFacility other)
            {
                // Сравниваем свойства
                return this.sportFacilityCode == other.sportFacilityCode &&
                       this.name == other.name &&
                       this.yearOfConstruction == other.yearOfConstruction;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Используем хэш-коды свойств для формирования общего хэш-кода
            int hashCode = sportFacilityCode.GetHashCode();
            hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ yearOfConstruction.GetHashCode();
            return hashCode;
        }
        public void addCompetition(Competition competition) //Добавить проведенное соревнование
        {
            if (!competitionsHeld.Contains(competition))
            {
                competitionsHeld.Add(competition);
            }
            else
            {
                MessageBox.Show("Соревнование уже добавлено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<Competition> getCompetitions() //Получение соревнований,проведенных в данном спортивном сооружении
        {

            return competitionsHeld;
        }

        //Свойства
        public string SportFacilityCode
        {
            get { return sportFacilityCode; }
            set
            {
                if (value == null || value == "") throw new Exception("Некорректное значение");
                else sportFacilityCode = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "") throw new Exception("Некорректное значение");
                else name = value;
            }
        }

        public int YearOfConstruction
        {
            get { return yearOfConstruction; }
            set
            {
                if (value > 1850 && value < 2025) yearOfConstruction = value;
                else throw new Exception("Некорректное значение");
            }
        }
        public List<Competition> CompetitionsHeld
        {
            get => competitionsHeld;
            set => competitionsHeld = value ?? new List<Competition>();
        }
        public bool getSportFacilitywithType(object type) //Сооружения указанного типа
        {

            if (this.GetType() == type.GetType()) return true;
            else return false;
        }
        public abstract bool getSportFacilityWithCharacteristic(string characteristic, char operation); //Сооружения удовлетворяющие данным характеристикам
       


    }
    public partial class Stadium : SportFacility // Производный класс стадион
    {
        private int capacity; //Вместимость
        public Stadium() : base()
        {
            capacity = 500;
        }
        public Stadium(string code, int capacity, string name, int year) : base(code, name, year)
        {
            if (capacity > 0) this.capacity = capacity;
            else throw new Exception("Некорректное значение");

        }
        public int Capacity
        {
            get { return capacity; }
            set { if (value > 0) capacity = value; else throw new Exception("Некорректное значение"); }
        }
        public override string ToString()
        {
            ;
            return base.ToString() + $" Вместимость: {capacity} ";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Stadium other = (Stadium)obj;

            // Сравниваем поля базового класса и поле производного класса
            return base.Equals(other) && capacity == other.capacity;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + capacity.GetHashCode(); 
        }
        public override bool getSportFacilityWithCharacteristic(string characteristic, char operation)
        {
            if (!int.TryParse(characteristic, out int characteristicValue))
            {
                MessageBox.Show("Некорректное значение вместимости.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else
            {
                switch (operation)
                {
                    case '<':
                        return capacity <= characteristicValue;
                    case '>':
                        return capacity >= characteristicValue;
                    case '=':
                        return capacity == characteristicValue;
                    default:
                        MessageBox.Show("Некорректная операция", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }
            }

        }
        
    }
   
    public partial class Arena : SportFacility //Производный класс манеж
    {
        private int area; //Площадь
        public Arena(string code, int area, string name, int year) : base(code, name, year)
        {
            if (area > 0) this.area = area;
            else throw new Exception("Некорректное значение");
        }
        public Arena() : base() { area = 500; }
        public int Area
        {
            get { return area; }
            set
            {
                if (value > 0) area = value;else throw new Exception("Некорректное значение");
            }
        }
        public override string ToString()
        {
            return base.ToString() + $" Площадь: {area} ";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Arena other = (Arena)obj;

            // Сравниваем поля базового класса и поле производного класса
            return base.Equals(other) && area == other.area;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + area.GetHashCode();
        }
        public override bool getSportFacilityWithCharacteristic(string characteristic, char operation)
        {

            if (!int.TryParse(characteristic, out int characteristicValue))
            {
                MessageBox.Show("Некорректное значение площади.", "Ошибка ввода", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                switch (operation)
                {
                    case '<':
                        if (area > characteristicValue) return false;
                        else return true;
                    case '>':
                        if (area < characteristicValue) return false;
                        else return true;
                    case '=':
                        if (area == characteristicValue) return true;
                        else return false;
                    default:
                        MessageBox.Show("Некорректная операция", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }
            }
        }
       

        
    }
   
    public partial class Court : SportFacility //Производный класс корт
    {
        private string typeOfCoating; //Тип покрытия
        public Court(string code, string typeOfCoating, string name, int year) : base(code, name, year)
        {
            if (typeOfCoating != null) this.typeOfCoating = typeOfCoating;
            else throw new Exception("Некорректное значение");
        }
        public Court() : base() { typeOfCoating = "Искусственная трава"; }
        public string TypeOfCoating
        {
            get { return typeOfCoating; }
            set
            {
                if (value != null) typeOfCoating = value; else throw new Exception("Некорректное значение");
            }
        }
        public override string ToString()
        {
            return base.ToString() + $" Тип покрытия: {typeOfCoating} ";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Court other = (Court)obj;

            // Сравниваем поля базового класса и поле производного класса
            return base.Equals(other) && typeOfCoating == other.typeOfCoating;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + typeOfCoating.GetHashCode();
        }
        public override bool getSportFacilityWithCharacteristic(string characteristic, char operation)
        {
            if (characteristic == null || characteristic.GetType() != typeof(string)) 
            {
                MessageBox.Show("Некорректное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            switch (operation)
            {
                case '=':
                    if (typeOfCoating == (string)characteristic) return true; //Если тип покрытия равен заданному
                    else return false;
                default:
                    MessageBox.Show("Некорректная операция", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
        }
       
      
        }


    public partial class SwimmingPool : SportFacility //Производный класс бассейн
        {
            private float depth; //Глубина
            public SwimmingPool(string code, float depth, string name, int year) : base(code, name, year)
            {
                if (depth != 0) this.depth = depth;
                else throw new Exception("Некорректное значение");
            }
            public SwimmingPool() : base() { depth = 1.5f; }
            public float Depth
            {
                get { return depth; }
                set
                {
                    if (value != 0) depth = value; else throw new Exception("Некорректное значение");
                }
            }
            public override string ToString()
            {
                return base.ToString() + $" Глубина: {depth}";
            }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            SwimmingPool other = (SwimmingPool)obj;

            // Сравниваем поля базового класса и поле производного класса
            return base.Equals(other) && depth == other.depth;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + depth.GetHashCode();
        }
        public override bool getSportFacilityWithCharacteristic(string characteristic, char operation)
            {
                if (!float.TryParse(characteristic, out float characteristicValue))
                {
                MessageBox.Show("Некорректное значение глубины", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
                else
                {

                    switch (operation)
                    {
                        case '<':
                            if (depth > characteristicValue) return false;
                            else return true;
                        case '>':
                            if (depth < characteristicValue) return false;
                            else return true;
                        case '=':
                            if (depth == characteristicValue) return true;
                            else return false;
                        default:
                        MessageBox.Show("Некорректная операция", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }
                }
            }


        }
    public partial class Gym : SportFacility //Производный класс спортзал
        {
            private string type; //Тип спортзала
            public Gym(string type, string code, string name, int year) : base(code, name, year)
            {
                if (type != null) this.type = type;
                else throw new Exception("Некорректное значение");
            }
            public Gym() : base() { type = "Универсальный"; }
            public string Type
            {
                get { return type; }
                set
                {
                    if (value != null) type = value;else  throw new Exception("Некорректное значение типа спортзала.");
                }
            }
            public override string ToString()
            {
                return base.ToString() + $" Тип спортзала: {type}";
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Gym other = (Gym)obj;

                // Сравниваем поля базового класса и поле производного класса
                return base.Equals(other) && type == other.type;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode() + type.GetHashCode();
            }
        public override bool getSportFacilityWithCharacteristic(string characteristic, char operation)
            {
                if (characteristic == null)
                {
                MessageBox.Show("Некорректное значение типа спортзала", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            
                }
                switch (operation)
                {
                    case '=':
                        if (type == (string)characteristic) return true;
                        else return false;
                    default:
                    MessageBox.Show("Некорректная операция", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
           }
        }
    }


    


