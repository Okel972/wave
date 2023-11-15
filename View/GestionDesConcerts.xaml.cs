using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Wave.View
{
    public class Concert
    {
        public string? Date { get; set; }
        public string? Heure { get; set; }
        public string? Lieu { get; set; }
        public string? ConcertName { get; set; }

        public Concert (string date, string time, string place, string concertName)
        {
            Date = date;
            Heure = time;
            Lieu = place;
            ConcertName = concertName;
        }
    }
    public partial class GestionDesConcerts : Window
    {
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(InputDate.Text) ||
                string.IsNullOrEmpty(InputTime.Text) ||
                string.IsNullOrEmpty(InputPlace.Text) ||
                string.IsNullOrEmpty(InputConcertName.Text))
            {
                return false;
            }
            return true;
        }
        public GestionDesConcerts()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // Accédez à la liste statique de groupes de musique dans la classe App
            List<concertChansonMusicGroup> newConcert = App.ConcertChansonsMusicGroups;

            // Utilisez la liste pour remplir le contrôle ListView avec les groupes de musique
            ListConcertShow.ItemsSource = newConcert;
        }

        private void ClickPlanif_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs() == false) // Vérifiez si la fonction ValidateInputs retourne false
            {
                // Afficher un message d'erreur
                MessageBox.Show("Veuillez remplir tous les champs avant de planifier un concert.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var itm = new Concert(InputDate.Text, InputTime.Text, InputPlace.Text, InputConcertName.Text);
            App.concert.Add(itm);

            ListConcertShow.ItemsSource = null;
            ListConcertShow.ItemsSource = App.ConcertChansonsMusicGroups;

            this.ListConcertDetails.Items.Clear(); // Vider la ListView

            foreach (var child in ListAdd.Children)
            {
                if (child is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }

            this.LabelShowConcert.Text = "";
        }

        private void ClickModifPlanif_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputConcertName.Text))
            {
                MessageBox.Show("Veuillez entrer le nom d'un concert.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Vérifier si le groupe n'existe pas
            bool concertNoExists = App.concert.Any(group => group.ConcertName.Equals(InputConcertName.Text, System.StringComparison.InvariantCultureIgnoreCase));

            if (!concertNoExists)
            {
                MessageBox.Show("Ce concert avec ce nom n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ValidateInputs() == false) // Vérifiez si la fonction ValidateInputs retourne false
            {
                // Afficher un message d'erreur
                MessageBox.Show("Veuillez remplir tous les champs avant de modifier un concert.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Trouver l'élément correspondant à InputConcertName
            var concertToUpdate = App.concert.First(group => group.ConcertName.Equals(InputConcertName.Text, System.StringComparison.InvariantCultureIgnoreCase));

            // Demander à l'utilisateur s'il veut modifier le nom du concert
            MessageBoxResult result = MessageBox.Show($"Voulez-vous modifier le nom du concert \"{concertToUpdate.ConcertName}\" ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Demander à l'utilisateur de saisir le nouveau nom de concert
                string newConcertName = Microsoft.VisualBasic.Interaction.InputBox("Entrez le nouveau nom du concert:", "Nouveau nom de concert", "");

                if (string.IsNullOrEmpty(newConcertName))
                {
                    MessageBox.Show("Veuillez entrer un nouveau nom de concert valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Mettre à jour le nom de l'élément
                string oldConcertName = concertToUpdate.ConcertName; // sauvegarder l'ancien nom pour le message box
                concertToUpdate.ConcertName = newConcertName;

                // Afficher un message avec le nouveau nom de concert
                MessageBox.Show($"Le nom du concert \"{oldConcertName}\" a été modifié en \"{newConcertName}\".", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Mettre à jour les informations de l'élément
            concertToUpdate.Date = InputDate.Text;
            concertToUpdate.Heure = InputTime.Text;
            concertToUpdate.Lieu = InputPlace.Text;

            ListConcertShow.ItemsSource = null;

            // Supprimer l'élément existant de la liste
            this.ListConcertShow.Items.Remove(concertToUpdate);

            ListConcertShow.ItemsSource = App.ConcertChansonsMusicGroups;

            this.ListConcertDetails.Items.Clear(); // Vider la ListView

            // Vider les champs de saisie
            InputDate.Text = "";
            InputTime.Text = "";
            InputPlace.Text = "";
            InputConcertName.Text = "";
            this.LabelShowConcert.Text = "";
        }

        private void ClickDeletePlanif_Click(object sender, RoutedEventArgs e)
        {
            // Rechercher le groupe de musique correspondante dans la liste
            var concertToRemove = App.concert.FirstOrDefault(x => x.ConcertName == InputConcertName.Text);

            if (concertToRemove == null)
            {
                MessageBox.Show("Ce concert avec ce nom n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Demander à l'utilisateur de confirmer la suppression
            var result = MessageBox.Show("Voulez-vous vraiment supprimer ce concert ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Si l'utilisateur clique sur "Oui", supprimer la chanson de la liste
            if (result == MessageBoxResult.Yes)
            {
                App.concert.Remove(concertToRemove);

                ListConcertShow.ItemsSource = null;
                ListConcertShow.ItemsSource = App.ConcertChansonsMusicGroups;

                this.InputConcertName.Text = "";

                MessageBox.Show("Le concert a été supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.ListConcertDetails.Items.Clear(); // Vider la ListView

            foreach (var child in ListAdd.Children)
            {
                if (child is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }

            this.LabelShowConcert.Text = "";
        }

        private void ListConcertShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            concertChansonMusicGroup? crt = (concertChansonMusicGroup)ListConcertShow.SelectedItem;

            if(crt != null)
            {
                LabelShowConcert.Text = crt.NameConcert;
                InputDate.Text = crt.DateConcert;
                InputTime.Text = crt.DateConcert;
                InputPlace.Text = crt.PlaceToBeConcert;
                InputConcertName.Text = crt.NameConcert;
            }
        }

        private void ClickShowConcert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LabelShowConcert.Text))
            {
                MessageBox.Show("Veuillez entrer le nom d'un concert.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Recherche du groupe de musique
            concertChansonMusicGroup selectedConcert = App.ConcertChansonsMusicGroups.FirstOrDefault(x => x.NameConcert == LabelShowConcert.Text);

            if (selectedConcert != null)
            {
                this.ListConcertDetails.Items.Clear(); // Vider la ListView avant d'ajouter le groupe de musique sélectionné
                this.ListConcertDetails.Items.Add(selectedConcert); // Ajouter le groupe de musique sélectionné
            }
            else
            {
                MessageBox.Show("Le groupe de musique n'a pas été trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClickClearDetails_Click(object sender, RoutedEventArgs e)
        {
            this.ListConcertDetails.Items.Clear(); // Vider la ListView
        }

        private void GroupsToConcerts_Click(object sender, RoutedEventArgs e)
        {
            // Ouvrir la fenêtre "AssistantAssociation2"
            AssistantAssociation2 childWindow = new();
            childWindow.Closed += ChildWindow_Closed;
            childWindow.Show();
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            // Rafraîchir la source de données de la ListView sur le thread de l'interface utilisateur
            this.Dispatcher.Invoke(() =>
            {
                RefreshListViewData();
            });
        }

        public void RefreshListViewData()
        {
            // Mettre à jour la source de données de la ListView ici
            ListConcertShow.ItemsSource = null;
            // Réaffecter la source de données à la ListView
            ListConcertShow.ItemsSource = App.ConcertChansonsMusicGroups;
        }

    }
}
