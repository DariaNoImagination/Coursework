using Coursework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Delete : Form
    {
        // Загрузка списков данных из JSON-файлов
        List<SportFacility> sportFacilitiesinTown = FacilitiesForm.LoadSportFacilitiesFromJson();
        List<Competition> competitionsInTown = CompetitionsForm.LoadCompetitionsFromJson();
        List<Club> clubsInTown = ClubsForm.LoadClubsFromJson();
        List<Sportsman> sportsmenInTown = SportsmenForm.LoadSportsmenFromJson();
        List<Coach> coachesInTown = CoachesForm.LoadCoachesFromJson();
        List<Organizer> organizersInTown = OrganizersForm.LoadOrganizersFromJson();
        string whatToDelete; // Поле для хранения типа объекта, который нужно удалить

        public Delete(string whatToDelete)
        {
            InitializeComponent();
            this.whatToDelete = whatToDelete;
            this.Text = "Удаление";
            // В зависимости от типа объекта, который нужно удалить
            switch (whatToDelete)
            {
                case "SportFacility":
                    // Заполняем CheckedListBox названиями спортивных сооружений
                    PopulateCheckedListBox(sportFacilitiesinTown.Select(sf => sf.Name).ToList(), "Нет доступных спортивных сооружений для отображения.");
                    break;

                case "Competition":
                    // Заполняем CheckedListBox названиями соревнований
                    PopulateCheckedListBox(competitionsInTown.Select(c => c.Name).ToList(), "Нет доступных соревнований для отображения.");
                    break;

                case "Club":
                    // Заполняем CheckedListBox названиями клубов
                    PopulateCheckedListBox(clubsInTown.Select(c => c.Name).ToList(), "Нет доступных клубов для отображения.");
                    break;

                case "Sportsmen":
                    // Заполняем CheckedListBox именами спортсменов
                    var sportsmanNames = sportsmenInTown.Select(s => $"{s.SecondName} {s.Name} {s.Patronymic}").ToList();
                    PopulateCheckedListBox(sportsmanNames, "Нет доступных спортсменов для отображения.");
                    break;

                case "Coaches":
                    // Заполняем CheckedListBox именами тренеров
                    var coachNames = coachesInTown.Select(c => $"{c.SecondName} {c.Name} {c.Patronymic}").ToList();
                    PopulateCheckedListBox(coachNames, "Нет доступных тренеров для отображения.");
                    break;

                case "Organizers":
                    // Заполняем CheckedListBox именами организаторов
                    var organizerNames = organizersInTown.Select(o => o.Name).ToList();
                    PopulateCheckedListBox(organizerNames, "Нет доступных организаторов для отображения.");
                    break;
            }
        }


        private void PopulateCheckedListBox(List<string> items, string emptyMessage)
        {
            // Если список элементов пуст
            if (items.Count == 0)
            {
                checkedListBoxToDelete.Items.Add(emptyMessage); // Добавляем сообщение об отсутствии элементов
            }
            else
            {
                // Если список не пуст
                foreach (var item in items)
                {
                    checkedListBoxToDelete.Items.Add(item); // Добавляем элементы в CheckedListBox
                }
            }
        }
       
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            List<string> itemsToRemove = new List<string>();

            // Собираем имена отмеченных элементов
            foreach (var item in checkedListBoxToDelete.CheckedItems)
            {
                itemsToRemove.Add(item.ToString());
            }

            switch (whatToDelete)
            {
                case "SportFacility":

                    // Удаляем элементы из sportFacilitiesinTown
                    sportFacilitiesinTown.RemoveAll(sportFacility => itemsToRemove.Contains(sportFacility.Name));
                    
                    //Удаляем соревнования, которые проходили в удаленных спортивных сооружениях
                    competitionsInTown.RemoveAll(competition => itemsToRemove.Contains(competition.Location.Name));
                    CompetitionsForm.SaveCompetitionsToJson(competitionsInTown);
                    FacilitiesForm.SaveSportFacilitiesToJson(sportFacilitiesinTown);
                    break;

                case "Competition":

                    // Удаляем элементы из competitionsInTown
                    competitionsInTown.RemoveAll(competitionToRemove => itemsToRemove.Contains(competitionToRemove.Name));
                    
                    //Удаляем соревнования из списка соревнований спортивных сооружений
                    foreach (var sportFacility in sportFacilitiesinTown)
                    {
                        sportFacility.getCompetitions().RemoveAll(competition => competition.Name == checkedListBoxToDelete.Text);
                    }
                    CompetitionsForm.SaveCompetitionsToJson(competitionsInTown);
                    FacilitiesForm.SaveSportFacilitiesToJson(sportFacilitiesinTown);

                    break;

                case "Club":

                    //Удаляем клуб
                    clubsInTown.RemoveAll(clubToRemove => itemsToRemove.Contains(clubToRemove.Name));
                    
                    //Удаляем участие в клубе у спортсменов данного клуба
                    foreach (var sportsman in sportsmenInTown)
                    {
                        if (sportsman.ParticipationInClub.Name == checkedListBoxToDelete.Text) sportsman.ParticipationInClub = null;
                    }
                    ClubsForm.SaveClubsToJson(clubsInTown);
                    SportsmenForm.SaveSportsmenToJson(sportsmenInTown);
                    break;


                case "Sportsmen":
                    //Удаляем спортсменов
                    sportsmenInTown.RemoveAll(sportsman => itemsToRemove.Contains($"{sportsman.SecondName} {sportsman.Name} {sportsman.Patronymic}"));
                    SportsmenForm.SaveSportsmenToJson(sportsmenInTown);
                    break;


                case "Organizers": 
                    //Удаляем организаторов
                    organizersInTown.RemoveAll(organizer => itemsToRemove.Contains(organizer.Name));

                    // Если у организаторов есть связанные соревнования, удаляем их
                    competitionsInTown.RemoveAll(competition => itemsToRemove.Contains(competition.Organizer.Name));
                    OrganizersForm.SaveOrganizersToJson(organizersInTown);
                    CompetitionsForm.SaveCompetitionsToJson(competitionsInTown);
                    break;

                case "Coaches":

                    //Удаляем тренеров
                    coachesInTown.RemoveAll(coach => itemsToRemove.Contains($"{coach.SecondName} {coach.Name} {coach.Patronymic}"));

                    // Проходим по каждому спортсмену в списке sportsmenInTown
                    foreach (var sportsman in sportsmenInTown)
                    {
                        // Проходим по каждому объекту SportInfo спортсмена
                        foreach (var sportInfo in sportsman.SportInfoList)
                        {
                            // Удаляем тренеров, которые были удалены из coachesInTown
                            foreach (var coach in coachesInTown)
                            {
                                if (itemsToRemove.Contains($"{coach.SecondName} {coach.Name} {coach.Patronymic}"))
                                {
                                    sportInfo.RemoveCoach(coach); // Удаляем тренера из SportInfo
                                }
                            }
                        }
                    }
                    CoachesForm.SaveCoachesToJson(coachesInTown);
                    SportsmenForm.SaveSportsmenToJson(sportsmenInTown);
                    break;

            }
            this.Close();
        }
    }
}

    
    