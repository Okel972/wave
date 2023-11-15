using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace Wave.View
{
    public partial class Acceuil : Window
    {
        public Acceuil()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Recherche du compte utilisateur dans la liste
            CompteUtilisateur user = App.comptesUtilisateurs.FirstOrDefault(u => u.NomUtilisateur == username && u.MotDePasse == password);

            if (user == null)
            {
                // Afficher un message d'erreur si les informations d'identification sont incorrectes
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur d'authentification", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Stocker l'utilisateur connecté dans la propriété statique "UtilisateurConnecte"
                App.UtilisateurConnecte = user;

                // Fermer la fenêtre de connexion actuelle
                this.Close();
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            if(App.UtilisateurConnecte == null)
            {
                // Afficher un message d'erreur si aucun utilisateur n'est connecté
                MessageBox.Show("Aucun utilisateur connecté.", "Erreur d'authentification", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                App.UtilisateurConnecte = null;

                // Fermer la fenêtre de connexion actuelle
                this.Close();
            }
        }
    }
}
