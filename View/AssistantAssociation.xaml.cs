using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Wave.View
{
    public class chansonMusicGroup
    {
        public string? IdChanson { get; set; }
        public string? IdMusicGroup { get; set; }
        public string? NomGroupe { get; set; }
        public string? NomChanson { get; set; }
        public string? ArtisteChanson { get; set; }
        public string? AlbumChanson { get; set; }
        public string? MembresMusicGroup { get; set; }
        public int? TimeChanson { get; set; }
    }
    public partial class AssistantAssociation : Window
    {
        public AssistantAssociation()
        {
            InitializeComponent();

            // Charger les données dans les listes
            ChansonList.ItemsSource = App.oeuvres;
            ListMusicGroup.ItemsSource = App.musicGroup;

            // Lier la ListView à la liste de chansons
            listView.ItemsSource = App.ChansonMusicGroups;
        }

        private void ChansonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Chanson chs = (Chanson)ChansonList.SelectedItem;

            if (chs != null)
            {
                SongChoice.Text = chs.IdentifiantUnique;
            }
        }

        private void ListMusicGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MusicGroup mg = (MusicGroup)ListMusicGroup.SelectedItem;

            if (mg != null)
            {
                MusicGroupChoice.Text = mg.IdGroupe;
            }
        }

        private void OnAssocierButtonClicked(object sender, RoutedEventArgs e)
        {
            MusicGroup selectedGroup = App.musicGroup.FirstOrDefault(x => x.IdGroupe == MusicGroupChoice.Text);
            Chanson selectedSong = App.oeuvres.FirstOrDefault(x => x.IdentifiantUnique == SongChoice.Text);

            if (selectedGroup != null && selectedSong != null)
            {
                // Vérifier si une association existe déjà pour l'ID de chanson sélectionné
                bool associationExists = App.ChansonMusicGroups.Any(x => x.IdChanson == selectedSong.IdentifiantUnique);

                if (associationExists)
                {
                    MessageBox.Show("Cette chanson est déjà associée à un groupe.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Créer une nouvelle instance de l'objet chansonMusicGroup
                    chansonMusicGroup association = new chansonMusicGroup
                    {
                        IdChanson = selectedSong.IdentifiantUnique,
                        IdMusicGroup = selectedGroup.IdGroupe,
                        NomGroupe = selectedGroup.NameGroup,
                        NomChanson = selectedSong.Titre,
                        ArtisteChanson = selectedSong.Artiste,
                        AlbumChanson = selectedSong.Album,
                        TimeChanson = selectedSong.DureeEnSecondes,
                        MembresMusicGroup = selectedGroup.Membres
                    };

                    // Ajouter la nouvelle association à la liste d'associations
                    App.ChansonMusicGroups.Add(association);
                }
            }

            listView.ItemsSource = null;
            listView.ItemsSource = App.ChansonMusicGroups;
        }

    }
}
