using System;
using System.Windows;
using System.Windows.Input;
using Wave.View;

namespace Wave
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void bntClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bntMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void bntMax_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void Acceuil_Click(object sender, RoutedEventArgs e)
        {
            Acceuil home = new();
            home.ShowDialog();
        }

        private void GestionDesOeuvres_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier le rôle de l'utilisateur actuel
            if(App.UtilisateurConnecte == null || App.UtilisateurConnecte.Role == null || App.UtilisateurConnecte.Role != Role.Admin)
            {
                // Afficher un message d'erreur si l'utilisateur n'a pas les droits suffisants
                MessageBox.Show("Vous n'êtes pas autorisé à accéder à cette fonctionnalité.", "Accès refusé", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Ouvrir la fenêtre "GestionDesOeuvres"
                GestionDesOeuvres song = new();
                song.ShowDialog();
            }
        }

        private void GestionDesGroupesDeMusique_Click(object sender, RoutedEventArgs e)
        {

            // Vérifier le rôle de l'utilisateur actuel
            if (App.UtilisateurConnecte == null || App.UtilisateurConnecte.Role == null || App.UtilisateurConnecte.Role != Role.Admin)
            {
                // Afficher un message d'erreur si l'utilisateur n'a pas les droits suffisants
                MessageBox.Show("Vous n'êtes pas autorisé à accéder à cette fonctionnalité.", "Accès refusé", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Ouvrir la fenêtre "GestionDesGroupesDeMusique"
                GestionDesGroupesDeMusique musicGroup = new();
                musicGroup.ShowDialog();
            }
        }

        private void GestionDesConcerts_Click(object sender, RoutedEventArgs e)
        {

            // Vérifier le rôle de l'utilisateur actuel
            if (App.UtilisateurConnecte == null || App.UtilisateurConnecte.Role == null || App.UtilisateurConnecte.Role != Role.Admin)
            {
                // Afficher un message d'erreur si l'utilisateur n'a pas les droits suffisants
                MessageBox.Show("Vous n'êtes pas autorisé à accéder à cette fonctionnalité.", "Accès refusé", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Ouvrir la fenêtre "GestionDesConcerts"
                GestionDesConcerts gestionDesConcerts = new();
                gestionDesConcerts.ShowDialog();
            }
        }

        private void GestionsDesComptes_Click(object sender, RoutedEventArgs e)
        {

            // Vérifier le rôle de l'utilisateur actuel
            if (App.UtilisateurConnecte == null || App.UtilisateurConnecte.Role == null || App.UtilisateurConnecte.Role != Role.Admin)
            {
                // Afficher un message d'erreur si l'utilisateur n'a pas les droits suffisants
                MessageBox.Show("Vous n'êtes pas autorisé à accéder à cette fonctionnalité.", "Accès refusé", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Ouvrir la fenêtre "GestionDesComptes"
                GestionDesComptes gestionDesComptes = new();
                gestionDesComptes.ShowDialog();
            }
        }
    }
}
