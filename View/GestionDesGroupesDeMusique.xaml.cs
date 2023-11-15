using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Wave.View
{
    public class GroupName
    {
        public string? NameGroup { get; set; }

        public GroupName (string nameGroup)
        {
            NameGroup = nameGroup;
        }
    }

    public class MusicGroup : GroupName
    {
        public string? IdGroupe { get; set; }
        public string? Membres { get; set; }
        public string? Histoire { get; set; }
        public string? Style { get; set; }
        public string? Influences { get; set; }

        public MusicGroup (string nameGroup, string membres, string histoire, string style, string influences) : base(nameGroup)
        {
            Membres = membres;
            Histoire = histoire;
            Style = style;
            Influences = influences;
        }

        public MusicGroup(string id, string nameGroup, string membres, string histoire, string style, string influences) : base(nameGroup)
        {
            IdGroupe = id;
            Membres = membres;
            Histoire = histoire;
            Style = style;
            Influences = influences;
        }

    }
    public partial class GestionDesGroupesDeMusique : Window
    {
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(InputId.Text) || 
                string.IsNullOrEmpty(InputMembers.Text) ||
                string.IsNullOrEmpty(InputStory.Text) ||
                string.IsNullOrEmpty(InputMusicStyle.Text) ||
                string.IsNullOrEmpty(InputInfluences.Text))
            {
                return false;
            }
            return true;
        }

        public GestionDesGroupesDeMusique()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // Accédez à la liste statique de groupes de musique dans la classe App
            List<MusicGroup> groupes = App.musicGroup;

            // Utilisez la liste pour remplir le contrôle ListView avec les groupes de musique
            ListMusicGroup.ItemsSource = groupes;
        }

        private void AddMusicGroup_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DefMusicGroup.Text))
            {
                MessageBox.Show("Veuillez entrer le nom d'un groupe.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Vérifier si le groupe existe déjà
            bool groupExists = App.musicGroup.Any(group => group.NameGroup.Equals(DefMusicGroup.Text, StringComparison.InvariantCultureIgnoreCase));

            if (groupExists)
            {
                MessageBox.Show("Un groupe avec ce nom existe déjà.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var itm = new MusicGroup(InputId.Text, DefMusicGroup.Text, InputMembers.Text, InputStory.Text, InputMusicStyle.Text, InputInfluences.Text);
            App.musicGroup.Add(itm);

            // Mettre à jour la source de données de la liste
            ListMusicGroup.ItemsSource = null; // D'abord vider la source de données actuelle
            ListMusicGroup.ItemsSource = App.musicGroup; // Puis lier la liste à la nouvelle source de données

            this.DefMusicGroup.Text = "";

            foreach (var child in ListAdd.Children)
            {
                if (child is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }
        }

        private void SelectMusicGroup_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DefMusicGroup.Text))
            {
                MessageBox.Show("Veuillez entrer le nom d'un groupe.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Recherche du groupe de musique
            MusicGroup selectedGroup = App.musicGroup.FirstOrDefault(x => x.NameGroup == DefMusicGroup.Text);

            if (selectedGroup != null)
            {
                this.ListInfoGroupMusic.Items.Clear(); // Vider la ListView avant d'ajouter le groupe de musique sélectionné
                this.ListInfoGroupMusic.Items.Add(selectedGroup); // Ajouter le groupe de musique sélectionné
            }
            else
            {
                MessageBox.Show("Le groupe de musique n'a pas été trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ModifyMusicGroup_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DefMusicGroup.Text))
            {
                MessageBox.Show("Veuillez entrer le nom d'un groupe.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Vérifier si le groupe n'existe pas
            bool groupNoExists = App.musicGroup.Any(group => group.NameGroup.Equals(DefMusicGroup.Text, StringComparison.InvariantCultureIgnoreCase));

            if (!groupNoExists)
            {
                MessageBox.Show("Ce groupe avec ce nom n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!ValidateInputs())
            {
                MessageBox.Show("Veuillez remplir tous les champs avant de modifier les éléments du groupe.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Trouver l'index du groupe de musique que l'on souhaite modifier
            int groupIndex = App.musicGroup.FindIndex(group => group.NameGroup.Equals(DefMusicGroup.Text, StringComparison.InvariantCultureIgnoreCase));

            // Modifier le groupe de musique
            App.musicGroup[groupIndex].NameGroup = DefMusicGroup.Text;
            App.musicGroup[groupIndex].IdGroupe = InputId.Text;
            App.musicGroup[groupIndex].Membres = InputMembers.Text;
            App.musicGroup[groupIndex].Histoire = InputStory.Text;
            App.musicGroup[groupIndex].Style = InputMusicStyle.Text;
            App.musicGroup[groupIndex].Influences = InputInfluences.Text;

            // Rafraîchir la liste des groupes de musique
            this.ListMusicGroup.Items.Refresh();
            this.ListInfoGroupMusic.Items.Refresh();

            MusicGroup selectedGroup = App.musicGroup.FirstOrDefault(x => x.NameGroup == DefMusicGroup.Text);

            if (selectedGroup != null)
            {
                this.ListInfoGroupMusic.Items.Clear(); // Vider la ListView avant d'ajouter le groupe de musique sélectionné
                this.ListInfoGroupMusic.Items.Add(selectedGroup); // Ajouter le groupe de musique sélectionné
            }

            this.DefMusicGroup.Text = "";

            foreach (var child in ListAdd.Children)
            {
                if (child is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }
        }

        private void Clearbtn_Click(object sender, RoutedEventArgs e)
        {
            this.ListInfoGroupMusic.Items.Clear();
        }

        private void ListMusicGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MusicGroup? mg = (MusicGroup)ListMusicGroup.SelectedItem;
            
            if (mg != null)
            {
                DefMusicGroup.Text = mg.NameGroup;
            }
        }

        private void DeleteMusicGroup_Click(object sender, RoutedEventArgs e)
        {
            // Rechercher le groupe de musique correspondante dans la liste
            var groupToRemove = App.musicGroup.FirstOrDefault(x => x.NameGroup == DefMusicGroup.Text);

            if (groupToRemove == null)
            {
                MessageBox.Show("Le groupe de musique avec ce nom n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Demander à l'utilisateur de confirmer la suppression
            var result = MessageBox.Show("Voulez-vous vraiment supprimer ce groupe ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Si l'utilisateur clique sur "Oui", supprimer la chanson de la liste
            if (result == MessageBoxResult.Yes)
            {
                App.musicGroup.Remove(groupToRemove);

                // Mettre à jour la source de données de la liste
                ListMusicGroup.ItemsSource = null; // D'abord vider la source de données actuelle
                ListMusicGroup.ItemsSource = App.musicGroup; // Puis lier la liste à la nouvelle source de données

                this.DefMusicGroup.Text = "";

                MessageBox.Show("Le groupe a été supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
