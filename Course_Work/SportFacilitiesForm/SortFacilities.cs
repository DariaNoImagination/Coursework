using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Coursework
{   public partial class SortFacilities : Form
    {
        char action = '='; // Переменная для хранения типа сравнения (=, >, <)
        SportFacility facility; // Спортивное сооружение для определения типа
        List<SportFacility> sportFacilitiesinTown = FacilitiesForm.LoadSportFacilitiesFromJson(); // Загрузка списка спортивных сооружений из JSON
        List<SportFacility> sportFacilitiesinTownSort; // Список отсортированных спортивных сооружений


        public SortFacilities(SportFacility facility, string typeOfFacility)
        {
            InitializeComponent();
            this.Text = "Сортировка";
            this.facility = facility; // Сохраняем переданное сооружение
                                      // Проверяем, относится ли сооружение к стадиону, бассейну или манежу
            if (facility.getSportFacilitywithType(new Stadium()) ||
                facility.getSportFacilitywithType(new SwimmingPool())  ||
                facility.getSportFacilitywithType(new Arena()))
            {
                label2.Text = typeOfFacility;
                label1.Text = "";
                comboBoxChooseAction.Show();
                textBoxcharacteristicsInput.Show();
                comboBoxCharacteristic.Hide();
                comboBoxChooseAction.Items.Add("Любая");
                comboBoxChooseAction.Items.Add("Более...");
                comboBoxChooseAction.Items.Add("Менее...");
            }
            else
            {
                // Для остальных типов сооружений
                comboBoxCharacteristic.Items.Add("Любой");
                label1.Text = typeOfFacility;
                label2.Text = "";
                comboBoxChooseAction.Hide();
                textBoxcharacteristicsInput.Hide();
                comboBoxCharacteristic.Show();
            }
        }


        private void comboBoxChooseAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Определяем тип сравнения в зависимости от выбранного 
            switch (comboBoxChooseAction.SelectedIndex)
            {
                case 0: // "Любая"
                    textBoxcharacteristicsInput.Hide(); 
                    comboBoxCharacteristic.Hide(); 
                    break;
                case 1: // "Более..."
                    textBoxcharacteristicsInput.Show();
                    action = '>'; 
                    break;
                case 2: // "Менее..."
                    textBoxcharacteristicsInput.Show();
                    action = '<';
                    break;
                default: // Другие случаи (по умолчанию)
                    action = '='; 
                    break;

            }
        }

        private void SortByProperties_Click(object sender, EventArgs e)
        {
           
            if (comboBoxChooseAction.SelectedIndex == 0 || comboBoxCharacteristic.Text == "Любой")
            {
                // Если выбрана сортировка без фильтрации по характеристикам
                var sportFacilitiesinTownWithCHaracteristics = sportFacilitiesinTown.Where(facilitySort => facilitySort.getSportFacilitywithType(facility));
                sportFacilitiesinTownSort = sportFacilitiesinTownWithCHaracteristics.ToList(); // Отбираем все сооружения данного типа
            }
            else if (comboBoxChooseAction.SelectedIndex != 0 &&
                       (facility.getSportFacilitywithType(new Stadium()) ||
                        facility.getSportFacilitywithType(new SwimmingPool())||
                        facility.getSportFacilitywithType(new Arena())))
            {
                // Если выбрана сортировка с фильтрацией по числовой характеристике
                var sportFacilitiesinTownWithCHaracteristics = sportFacilitiesinTown.Where(facilitySort =>
                    facilitySort.getSportFacilitywithType(facility) && // Отбираем сооружения данного типа
                    facilitySort.getSportFacilityWithCharacteristic(textBoxcharacteristicsInput.Text, action)); // И фильтруем по характеристике
                sportFacilitiesinTownSort = sportFacilitiesinTownWithCHaracteristics.ToList(); // Сохраняем отфильтрованные сооружения
            }
            else
            {
                // Если выбрана сортировка с фильтрацией по нечисловой характеристике
                var sportFacilitiesinTownWithCHaracteristics = sportFacilitiesinTown.Where(facilitySort =>
                   facilitySort.getSportFacilitywithType(facility) && // Отбираем сооружения данного типа
                   facilitySort.getSportFacilityWithCharacteristic(comboBoxCharacteristic.Text, action));  // И фильтруем по характеристике
                sportFacilitiesinTownSort = sportFacilitiesinTownWithCHaracteristics.ToList(); // Сохраняем отфильтрованные сооружения
            }
            this.Close(); // Скрываем текущую форму
        }

        public List<SportFacility> getSportFacilitiesinTownSort()
        {
            return sportFacilitiesinTownSort; // Возвращаем отсортированный список
        }
    }
}