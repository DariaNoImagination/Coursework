using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework
{

    public partial class SortCompetitions2 : Form
    {
        //Загрузка данных из файлов
        List<Competition> competitions = CompetitionsForm.LoadCompetitionsFromJson();
        List<Organizer> organizers = OrganizersForm.LoadOrganizersFromJson();
        List<Competition> sortCompetitions;
        string comboBoxText; // По какому фактору сортировать соревнования
        public SortCompetitions2(string comboBoxText)
        {
            InitializeComponent();
            this.Text = "Сортировка";
            this.comboBoxText = comboBoxText;
            
                switch (comboBoxText)
                {
                case "По дате":
                    labelSort.Text = "Введите период в течение";
                    label1.Text = "которого проходили соревнования";
                    textBoxBegin.Show();
                    textBoxEnd.Show();
                    label2.Show();
                    label3.Show();
                    comboBoxOrganizers.Hide();
                    break;
                case "Проведенные организатором":
                
                    foreach (Organizer organizer in organizers)comboBoxOrganizers.Items.Add(organizer.Name);
                    labelSort.Text = "Выберите организатора";
                    label1.Text = "";
                    label2.Hide();
                    label3.Hide();
                    textBoxBegin.Hide();
                    textBoxEnd.Hide();
                    comboBoxOrganizers.Show();
                    break;
                default:
                    foreach (Organizer organizer in organizers) comboBoxOrganizers.Items.Add(organizer.Name);
                    labelSort.Text = "Введите параметры сортировки";
                    label1.Text = "";
                    label2.Show();
                    label3.Show();
                    textBoxBegin.Show();
                    textBoxEnd.Show();
                    comboBoxOrganizers.Show();
                    break;
                }
        }


      

        private void buttonSort_Click(object sender, EventArgs e)
        {

            switch (comboBoxText)
            {
                case "По дате":

                    // Если выбрана сортировка "По дате"
                    // Проверяем корректность ввода начальной даты
                    if (!DateTime.TryParse(textBoxBegin.Text, out DateTime begin))
                    {
                        // Если начальная дата введена некорректно, выводим сообщение об ошибке и выходим из метода
                        MessageBox.Show("Некорректное значение даты", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Проверяем корректность ввода конечной даты
                    if (!DateTime.TryParse(textBoxEnd.Text, out DateTime end))
                    {
                        // Если конечная дата введена некорректно, выводим сообщение об ошибке и выходим из метода
                        MessageBox.Show("Некорректное значение даты", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Проверяем, что начальная дата не позже конечной
                    if (begin > end)
                    {
                        // Если начальная дата позже конечной, выводим сообщение об ошибке и выходим из метода
                        MessageBox.Show("Некорректное значение даты.Конец не может быть раньше начала", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Фильтруем соревнования по дате
                    var selectedCompetitions = competitions.Where(competitionSort => competitionSort.Begin >= begin && competitionSort.End <= end);
                    sortCompetitions = selectedCompetitions.ToList(); // Сохраняем отсортированный список
                    break;



                case "Проведенные организатором":

                    // Если выбрана сортировка "Проведенные организатором"
                    // Фильтруем соревнования по организатору
                    selectedCompetitions = competitions.Where(competitionSort => competitionSort.Organizer.Name == comboBoxOrganizers.Text);
                    sortCompetitions = selectedCompetitions.ToList(); // Сохраняем отсортированный список
                    break;
                default:

                    // Если выбрана сортировка "По дате и организатору"
                    // Проверяем корректность ввода начальной даты
                    if (!DateTime.TryParse(textBoxBegin.Text, out begin))
                    {
                        // Если начальная дата введена некорректно, выводим сообщение об ошибке и выходим из метода
                        MessageBox.Show("Некорректное значение даты", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Проверяем корректность ввода конечной даты
                    if (!DateTime.TryParse(textBoxEnd.Text, out end))
                    {
                        // Если конечная дата введена некорректно, выводим сообщение об ошибке и выходим из метода
                        MessageBox.Show("Некорректное значение даты", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Фильтруем соревнования по дате и организатору
                    selectedCompetitions = competitions.Where(competitionSort => competitionSort.Begin >= begin && competitionSort.End <= end && competitionSort.Organizer.Name == comboBoxOrganizers.Text);
                    sortCompetitions = selectedCompetitions.ToList(); // Сохраняем отсортированный список
                    break;
            }
            this.Close(); 
        }

        public List<Competition> getSortCompetitions()
        {
            return sortCompetitions; // Возвращает отсортированный список соревнований
        }
    }
}

  