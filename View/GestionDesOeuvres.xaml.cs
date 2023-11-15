using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Wave.View
{
    public class Chanson
    {
        public string? Titre { get; set; }
        public string? Artiste { get; set; }
        public string? Album { get; set; }
        public int? AnneeDeSortie { get; set; }
        public int? DureeEnSecondes { get; set; }
        public string? IdentifiantUnique { get; set; }

        public Chanson(string titre, string artiste, string album, int anneeSortie, int duree, string id)
        {
            Titre = titre;
            Artiste = artiste;
            Album = album;
            AnneeDeSortie = anneeSortie;
            DureeEnSecondes = duree;
            IdentifiantUnique = id;
        }
    }

    public partial class GestionDesOeuvres : Window
    {
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(InputTitle.Text) ||
                string.IsNullOrEmpty(InputArtist.Text) ||
                string.IsNullOrEmpty(InputAlbum.Text) ||
                string.IsNullOrEmpty(InputOut.Text) ||
                string.IsNullOrEmpty(InputTime.Text) ||
                string.IsNullOrEmpty(InputId.Text))
            {                
                return false;
            }
            return true;
        }

        public GestionDesOeuvres()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            List<Chanson>? newChanson = App.oeuvres;

            ChansonList.ItemsSource = newChanson;

        }

        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs() == false) // Vérifiez si la fonction ValidateInputs retourne false
            {
                // Afficher un message d'erreur
                MessageBox.Show("Veuillez remplir tous les champs avant d'ajouter une chanson.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int annee, duree;

            if (!int.TryParse(InputOut.Text, out annee) || !int.TryParse(InputTime.Text, out duree))
            {
                // Afficher un message d'erreur
                MessageBox.Show("Veuillez entrer des nombres entiers pour l'année de sortie et la durée.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var itm = new Chanson (InputTitle.Text, InputArtist.Text, InputAlbum.Text, annee, duree,InputId.Text);
            App.oeuvres.Add(itm);

            ChansonList.ItemsSource = null;
            ChansonList.ItemsSource = App.oeuvres;

            foreach (var child in ListAdd.Children)
            {
                if (child is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }
        }

        private void ModifySong_Click(object sender, RoutedEventArgs e)
        {
            string id = InputId.Text;

            // Vérifier si l'identifiant unique est vide
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Veuillez entrer un identifiant unique pour la chanson à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Trouver la chanson avec l'identifiant unique donné
            var index = App.oeuvres.FindIndex(c => c.IdentifiantUnique == id);

            // Vérifier si la chanson existe
            if (index == -1)
            {
                MessageBox.Show("Aucune chanson avec l'identifiant unique donné n'a été trouvée.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!ValidateInputs())
            {
                MessageBox.Show("Veuillez remplir tous les champs avant de modifier la chanson.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Modifier la chanson
            App.oeuvres[index].Titre = InputTitle.Text;
            App.oeuvres[index].Artiste = InputArtist.Text;
            App.oeuvres[index].Album = InputAlbum.Text;
            App.oeuvres[index].AnneeDeSortie = int.Parse(InputOut.Text);
            App.oeuvres[index].DureeEnSecondes = int.Parse(InputTime.Text);
            App.oeuvres[index].IdentifiantUnique = InputId.Text;

            // Rafraîchir la liste affichée dans l'interface utilisateur
            this.ChansonList.Items.Refresh();

            foreach (var child in ListAdd.Children)
            {
                if (child is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }
        }

        private void DeleteSong_Click(object sender, RoutedEventArgs e)
        {
            // Rechercher la chanson correspondante dans la liste
            var songToRemove = App.oeuvres.FirstOrDefault(x => x.IdentifiantUnique == InputId.Text);

            // Si la chanson n'existe pas, afficher un message d'erreur
            if (songToRemove == null)
            {
                MessageBox.Show("La chanson avec cet identifiant n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Demander à l'utilisateur de confirmer la suppression
            var result = MessageBox.Show("Voulez-vous vraiment supprimer cette chanson ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Si l'utilisateur clique sur "Oui", supprimer la chanson de la liste
            if (result == MessageBoxResult.Yes)
            {
                App.oeuvres.Remove(songToRemove);

                ChansonList.ItemsSource = null;
                ChansonList.ItemsSource = App.oeuvres;

                // Effacer les valeurs des TextBox après la suppression
                foreach (var child in ListAdd.Children)
                {
                    if (child is TextBox textBox)
                    {
                        textBox.Text = "";
                    }
                }

                MessageBox.Show("La chanson a été supprimée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ChansonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Chanson? chs = (Chanson)ChansonList.SelectedItem;

            if (chs != null)
            {
                InputTitle.Text = chs.Titre;
                InputArtist.Text = chs.Artiste;
                InputAlbum.Text = chs.Album;
                InputOut.Text = chs.AnneeDeSortie.ToString();
                InputTime.Text = chs.DureeEnSecondes.ToString();
                InputId.Text = chs.IdentifiantUnique;
            }
        }

        private void ClearClick_Click(object sender, RoutedEventArgs e)
        {
            // Effacer les valeurs des TextBox après la suppression
            foreach (var child in ListAdd.Children)
            {
                if (child is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }
        }

        private void SongsToGroups_Click(object sender, RoutedEventArgs e)
        {
            // Ouvrir la fenêtre de l'assistant d'association ChansonMusicGroup
            AssistantAssociation assistantAssociation = new();
            assistantAssociation.ShowDialog();
        }
    }
}
