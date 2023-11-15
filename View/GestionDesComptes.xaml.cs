using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Wave.View
{
    public enum Role
    {
        Admin,
        User,
        Organisateur,
        Acheteurs
    }
    public class CompteUtilisateur
    {
        public string? NomUtilisateur { get; set; }
        public string? MotDePasse { get; set; }
        public Role? Role { get; set; }

        public CompteUtilisateur(string nomUtilisateur, string motDePasse, Role role)
        {
            NomUtilisateur = nomUtilisateur;
            MotDePasse = motDePasse;
            Role = role;
        }
    }
    public partial class GestionDesComptes : Window
    {
        public GestionDesComptes()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            cmbRole.Items.Add(Role.Admin);
            cmbRole.Items.Add(Role.User);
            cmbRole.Items.Add(Role.Organisateur);
            cmbRole.Items.Add(Role.Acheteurs);

            List<CompteUtilisateur>? newComptesUtilisateurs = App.comptesUtilisateurs;

            cmbComptesUtilisateurs.ItemsSource = newComptesUtilisateurs;
            cmbComptesUtilisateurs.SelectedItem = newComptesUtilisateurs[0]; // ou tout autre élément de la liste

            // Vider les champs de texte
            txtNomUtilisateur.Clear();
            txtMotDePasse.Clear();
            cmbRole.SelectedItem = null;
        }

        private void btnCreerCompte_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomUtilisateur.Text) || string.IsNullOrEmpty(txtMotDePasse.Password))
            {
                MessageBox.Show("Veuillez entrer un nom d'utilisateur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un rôle.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CompteUtilisateur nouveauCompte = new CompteUtilisateur
            (
                txtNomUtilisateur.Text,
                txtMotDePasse.Password,
                (Role)cmbRole.SelectedItem
            );

            App.comptesUtilisateurs.Add(nouveauCompte);

            ActualiserListeComptesUtilisateurs();

            // Vider les champs de texte
            txtNomUtilisateur.Clear();
            txtMotDePasse.Clear();
            cmbRole.SelectedItem = null;
        }

        private void cmbComptesUtilisateurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CompteUtilisateur compteSelectionne = cmbComptesUtilisateurs.SelectedItem as CompteUtilisateur;
            if (compteSelectionne != null)
            {
                // afficher les informations du compte sélectionné
                txtNomUtilisateur.Text = compteSelectionne.NomUtilisateur;
                txtMotDePasse.Password = compteSelectionne.MotDePasse;
                cmbRole.SelectedItem = compteSelectionne.Role;
            }
        }

        private void btnModifierCompte_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomUtilisateur.Text) || string.IsNullOrEmpty(txtMotDePasse.Password))
            {
                MessageBox.Show("Veuillez entrer un nom d'utilisateur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un rôle.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CompteUtilisateur compteSelectionne = cmbComptesUtilisateurs.SelectedItem as CompteUtilisateur;
            if (compteSelectionne != null)
            {
                compteSelectionne.NomUtilisateur = txtNomUtilisateur.Text;
                compteSelectionne.MotDePasse = txtMotDePasse.Password;
                compteSelectionne.Role = (Role)cmbRole.SelectedItem;
            }

            ActualiserListeComptesUtilisateurs();

            // Vider les champs de texte
            txtNomUtilisateur.Text = "";
            txtMotDePasse.Password = "";
            cmbRole.SelectedItem = null;
        }

        private void btnSupprimerCompte_Click(object sender, RoutedEventArgs e)
        {
            CompteUtilisateur compteSelectionne = cmbComptesUtilisateurs.SelectedItem as CompteUtilisateur;
            if (compteSelectionne != null)
            {
                App.comptesUtilisateurs.Remove(compteSelectionne);
            }

            ActualiserListeComptesUtilisateurs();

            // Vider les champs de texte
            txtNomUtilisateur.Text = "";
            txtMotDePasse.Password = "";
            cmbRole.SelectedItem = null;
        }

        private void ActualiserListeComptesUtilisateurs()
        {
            cmbComptesUtilisateurs.ItemsSource = null;
            cmbComptesUtilisateurs.ItemsSource = App.comptesUtilisateurs;
        }

        private void ClearClick_Click(object sender, RoutedEventArgs e)
        {
            // Vider les champs de texte
            txtNomUtilisateur.Clear();
            txtMotDePasse.Clear();
            cmbRole.SelectedItem = null;
            cmbComptesUtilisateurs.SelectedItem = null;
        }
    }
}
