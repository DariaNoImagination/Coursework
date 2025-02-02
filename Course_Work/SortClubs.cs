using Coursework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Coursework
{
    public partial class SortClubs : Form
    {
        // Поле для хранения объекта клуба, значения которого нужно отсортировать
        private Club clubSort = new Club();

        // Поле для хранения списка отсортированных спортсменов
        private List<Sportsman> sortedClubMembers = new List<Sportsman>();

        
        public SortClubs(Club clubSort)
        {
            InitializeComponent(); 
            this.clubSort = clubSort; // Присваиваем переданный объект клуба полю класса
        }

        
        // Обработчик события нажатия кнопки сортировки
        private void buttonSort_Click(object sender, EventArgs e)
        {
            // Проверка на корректность ввода даты 
            if (!DateTime.TryParse(textBoxBegin.Text, out DateTime begin))
            {
                MessageBox.Show("Некорректное значение даты начала.", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error); // Выводим сообщение об ошибке, если преобразование не удалось
                return; 
            }

            //Проверка на корректность ввода даты 
            if (!DateTime.TryParse(textBoxEnd.Text, out DateTime end))
            {
                MessageBox.Show("Некорректное значение даты окончания.", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error); // Выводим сообщение об ошибке, если преобразование не удалось
                return; 
            }

            // Проверяем, чтобы начальная дата не была больше конечной даты
            if (begin > end)
            {
                MessageBox.Show("Окончание не может быть раньше начала", "Ошибка ввода", MessageBoxButtons.OK,MessageBoxIcon.Error); // Выводим сообщение об ошибке
                return; 
            }

          

            // Перебираем всех спортсменов клуба
            foreach (Sportsman clubMember in clubSort.GetMembers())
            {
                
                // Фильтруем соревнования спортсмена, оставляя только те, которые находятся между введенными датами
                var sortedCompetitions = clubMember.GetCompetitions().Where(competition => competition.Begin >= begin && competition.End <= end);
               
                // Проверяем, есть ли у спортсмена соревнования в заданном периоде
                if (sortedCompetitions.Count() != 0)
                {
                    
                    sortedClubMembers.Add(clubMember); // Добавляем спортсмена в список отсортированных, если есть соревнования в заданном периоде
                }
            }
            this.Close();
            
        }


        // Метод для получения списка отсортированных спортсменов
        public List<Sportsman> GetSortMembers()
        {
            return sortedClubMembers;
        }

    }
}
