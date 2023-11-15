using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Wave.View
{
    public class concertChansonMusicGroup
    {
        public string? NameConcert { get; set; }
        public string? DateConcert { get; set; }
        public string? TimeConcert { get; set; }
        public string? PlaceToBeConcert { get; set; }
        public string? IdChansonMusicGroup { get; set; }
        public string? GroupNameChansonMusicGroup { get; set; }
        public string? MembresChansonMusicGroup { get; set; }
        public string? NameChansonMusicGroup { get; set; }
        public string? ArtistChansonMusicGroup { get; set; }
        public int? TimeChansonMusicGroup { get; set; }
    }
    public partial class AssistantAssociation2 : Window
    {
        public AssistantAssociation2()
        {
            InitializeComponent();

            // Charger les données dans les listes
            ConcertList.ItemsSource = App.concert;
            ListChansonMusicGroup.ItemsSource = App.ChansonMusicGroups;

            // Lier la ListView à la liste de chansons
            listView.ItemsSource = App.ConcertChansonsMusicGroups;
        }

        private void ListChansonMusicGroup_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            chansonMusicGroup cmg = (chansonMusicGroup)ListChansonMusicGroup.SelectedItem;

            if (cmg != null)
            {
                ChansonMusicGroupChoice.Text = cmg.IdMusicGroup;
            }
        }

        private void ConcertList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Concert crt = (Concert)ConcertList.SelectedItem;

            if (crt != null)
            {
                ConcertChoice.Text = crt.ConcertName;
            }
        }

        private void OnAssocierButtonClicked(object sender, RoutedEventArgs e)
        {
            chansonMusicGroup selectedGroupCM = App.ChansonMusicGroups.FirstOrDefault(x => x.IdMusicGroup == ChansonMusicGroupChoice.Text);
            List<Concert> selectedConcerts = App.concert.Where(x => ConcertChoice.Text.Contains(x.ConcertName)).ToList();

            if (selectedGroupCM != null && selectedConcerts.Any())
            {
                foreach (Concert selectedConcert in selectedConcerts)
                {
                    // Vérifier si une association existe déjà pour l'ID de chanson sélectionné
                    bool associationExists = App.ConcertChansonsMusicGroups.Any(x => x.IdChansonMusicGroup == selectedGroupCM.IdMusicGroup && x.NameConcert == selectedConcert.ConcertName);

                    if (associationExists)
                    {
                        MessageBox.Show($"Le groupe \"{selectedGroupCM.NomGroupe}\" est déjà associé au concert \"{selectedConcert.ConcertName}\".", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        // Créer une nouvelle instance de l'objet chansonMusicGroup
                        concertChansonMusicGroup association2 = new concertChansonMusicGroup
                        {
                            NameConcert = selectedConcert.ConcertName,
                            DateConcert = selectedConcert.Date,
                            TimeConcert = selectedConcert.Heure,
                            PlaceToBeConcert = selectedConcert.Lieu,
                            IdChansonMusicGroup = selectedGroupCM.IdMusicGroup,
                            GroupNameChansonMusicGroup = selectedGroupCM.NomGroupe,
                            MembresChansonMusicGroup = selectedGroupCM.MembresMusicGroup,
                            NameChansonMusicGroup = selectedGroupCM.NomChanson,
                            ArtistChansonMusicGroup = selectedGroupCM.ArtisteChanson,
                            TimeChansonMusicGroup = selectedGroupCM.TimeChanson
                        };

                        // Ajouter la nouvelle association à la liste d'associations
                        App.ConcertChansonsMusicGroups.Add(association2);
                    }
                }

                listView.ItemsSource = null;
                listView.ItemsSource = App.ConcertChansonsMusicGroups;
            }
        }
    }
}
