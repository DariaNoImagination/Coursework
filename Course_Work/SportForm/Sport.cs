using System;
namespace Coursework
{
    public partial class Sport //Спорт 
    {
        private string code; //Код вида спорта
        private string name; //Название вида спорта
        public Sport(string name, string code) //Конструктор с параметрами
        {
            if (code != null) this.code = code;
            else throw new Exception("Некорректное значение");
            if (name != null) this.name = name;
            else throw new Exception("Некорректное значение");
        }
        public Sport() { code = "0140002611Я"; name = "Баскетбол"; } //Конструктор по умолчанию
        //Свойства
        public string Code
        {
            get { return code; }
            set
            {
                if (value != null) code = value; else throw new Exception("Некорректное значение");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null) name = value; else throw new Exception("Некорректное значение");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Sport otherSport)
            {
                return this.Name == otherSport.Name && this.Code == otherSport.Code; // Сравниваем по имени и коду
            }
            return false;
        }
        public override int GetHashCode()
        {
            // Используем простую комбинацию хэш-кодов для имени и кода
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashCode = Code == null ? 0 : Code.GetHashCode();

            return hashName ^ hashCode; // XOR для комбинирования хэш-кодов
        }
    }
}