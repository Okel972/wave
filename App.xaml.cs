using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wave.View;

namespace Wave
{
    public partial class App : Application
    {
        public static List<Chanson>? oeuvres { get; set; }

        public static List<MusicGroup>? musicGroup { get; set; }

        public static List<Concert>? concert { get; set; }

        public static List<chansonMusicGroup>? ChansonMusicGroups { get; set; }

        public static List<concertChansonMusicGroup>? ConcertChansonsMusicGroups { get; set; }

        public static List<CompteUtilisateur>? comptesUtilisateurs { get; set; }

        public static CompteUtilisateur? UtilisateurConnecte { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialiser la propriété UtilisateurConnecte avec une valeur par défaut
            UtilisateurConnecte = null;
        }

        public App()
        {
            concert = new List<Concert>();

            musicGroup = new List<MusicGroup>();

            oeuvres = new List<Chanson>();

            ChansonMusicGroups = new List<chansonMusicGroup>();

            ConcertChansonsMusicGroups = new List<concertChansonMusicGroup>();

            comptesUtilisateurs = new List<CompteUtilisateur>();

            // Listes des Utilisateurs___________________________________________

            CompteUtilisateur User1 = new CompteUtilisateur("admin", "admin", (Role)Enum.Parse(typeof(Role), "Admin"));
            comptesUtilisateurs.Add(User1);

            // Listes des concerts_______________________________________________

            Concert concert1 = new Concert("17/06/2024", "17h - 23h", "Place Longwy bas", "Concert 1");
            concert.Add(concert1);
            //this.ListConcertShow.Items.Add(concert1);

            Concert concert2 = new Concert("17/07/2024", "17h - 23h", "Place d'arche Longwy haut", "Concert 2");
            concert.Add(concert2);

            Concert concert3 = new Concert("21/11/2023", "17h - 23h", "Place de Longuyon", "Concert 3");
            concert.Add(concert3);

            // Listes des chansons_______________________________________________

            Chanson chanson = new Chanson("Au bord de la route", "Gisèle", "Auto chant", 2020, 211, "ID123");
            oeuvres.Add(chanson);
            //this.ChansonList.Items.Add(chanson);

            Chanson chanson1 = new Chanson("Jardin d'Eden", "Les Citronniers", "Aube Citron", 2018, 265, "ID001");
            oeuvres.Add(chanson1);

            Chanson chanson2 = new Chanson("La Danse du Soleil", "Les Citronniers", "Aube Citron", 2018, 189, "ID002");
            oeuvres.Add(chanson2);

            Chanson chanson3 = new Chanson("L'Ombre et la Lumière", "Les Citronniers", "Aube Citron", 2018, 312, "ID003");
            oeuvres.Add(chanson3);

            Chanson chanson4 = new Chanson("L'Appel de la Nuit", "Les Fantômes de la Nuit", "Nuit Fantôme", 2022, 176, "ID006");
            oeuvres.Add(chanson4);

            Chanson chanson5 = new Chanson("Le Rêve de la Lune", "Les Fantômes de la Nuit", "Nuit Fantôme", 2022, 211, "ID007");
            oeuvres.Add(chanson5);

            Chanson chanson6 = new Chanson("La Morsure de l'Ombre", "Les Fantômes de la Nuit", "Nuit Fantôme", 2022, 187, "ID008");
            oeuvres.Add(chanson6);

            Chanson chanson7 = new Chanson("Les Flammes du Destin", "Les Feux Follets", "Feux Follets", 2015, 224, "ID011");
            oeuvres.Add(chanson7);

            Chanson chanson8 = new Chanson("Le Souffle de la Vie", "Les Feux Follets", "Feux Follets", 2015, 187, "ID012");
            oeuvres.Add(chanson8);

            Chanson chanson9 = new Chanson("La Lueur de l'Espoir", "Les Feux Follets", "Feux Follets", 2015, 253, "ID013");
            oeuvres.Add(chanson9);

            Chanson chanson10 = new Chanson("Le Souffle du Vent", "Les Échos du Désert", "Désert d'Échos", 2019, 192, "ID016");
            oeuvres.Add(chanson10);

            Chanson chanson11 = new Chanson("La Voix de l'Oasis", "Les Échos du Désert", "Désert d'Échos", 2019, 227, "ID017");
            oeuvres.Add(chanson11);

            Chanson chanson12 = new Chanson("Le Souffle du Vent", "Les Échos du Désert", "Désert d'Échos", 2019, 192, "ID016");
            oeuvres.Add(chanson12);

            Chanson chanson13 = new Chanson("La Voix de l'Oasis", "Les Échos du Désert", "Désert d'Échos", 2019, 227, "ID017");
            oeuvres.Add(chanson13);

            Chanson chanson14 = new Chanson("Les Sables de l'Infini", "Les Échos du Désert", "Désert d'Échos", 2019, 213, "ID018");
            oeuvres.Add(chanson14);

            Chanson chanson15 = new Chanson("Premiers Rayons", "Les Voix de l'Aube", "L'Aube se lève", 2022, 180, "ID019");
            oeuvres.Add(chanson15);

            Chanson chanson16 = new Chanson("Le Souffle du Vent", "Les Voix de l'Aube", "Esprit Libre", 2020, 210, "ID020");
            oeuvres.Add(chanson16);

            Chanson chanson17 = new Chanson("Sous les Étoiles", "Les Voix de l'Aube", "Nuit Blanche", 2021, 195, "ID021");
            oeuvres.Add(chanson17);

            // Listes des groupes de musiques_______________________________________________

            MusicGroup citronniers = new MusicGroup("001", "Les Citronniers", "Sarah (chanteuse), Tom (guitariste), Ben (bassiste), Alex (batteur)", "Formé en 2015 à Londres, le groupe a commencé à jouer dans des petits clubs et a gagné une certaine notoriété grâce à leur mélange unique de rock indépendant et de musique électronique. Ils ont sorti leur premier album 'Sour' en 2018 et ont depuis tourné à travers le Royaume-Uni et l'Europe.", "Rock indépendant, musique électronique", "Radiohead, The xx, Daft Punk");
            musicGroup.Add(citronniers);
            //this.ListMusicGroup.Items.Add(citronniers);

            MusicGroup fantomes = new MusicGroup("002", "Les Fantômes de la Nuit", "Max (chanteur), Lily (guitariste), Eric (bassiste), Mark (batteur)", "Formé en 2008 à Los Angeles, le groupe s'est rapidement fait remarquer pour leur son rock sombre et leur énergie sur scène. Ils ont sorti leur premier album Nocturnes en 2010 et ont tourné avec des groupes tels que The Black Keys et Arctic Monkeys.", "Rock alternatif, rock gothique", "The Cure, Joy Division, Interpol");
            musicGroup.Add(fantomes);

            MusicGroup feuxFollets = new MusicGroup("003", "Les Feux Follets", "Lucie (chanteuse), Antoine (guitariste), Jules (bassiste), Marie (claviériste), Étienne (batteur)", "Formé en 2012 à Paris, le groupe est devenu célèbre pour leur musique pop énergique et leurs paroles engagées. Ils ont sorti leur premier album Enflammé en 2015 et ont tourné en France et en Belgique.", "Pop, rock", "Arcade Fire, Florence + The Machine, Phoenix");
            musicGroup.Add(feuxFollets);

            MusicGroup echosDesert = new MusicGroup("004", "Les Échos du Désert", "Omar (chanteur), Ahmed (oud), Fatima (violon), Hassan (percussions), Khaled (claviers)", "Formé en 2010 à Tunis, le groupe a mélangé les sons de la musique traditionnelle tunisienne avec des éléments de jazz et de rock pour créer un son unique. Ils ont sorti leur premier album Sahara Blues en 2012 et ont tourné en Afrique du Nord et en Europe.", "World music, jazz, rock", "Tinariwen, Yusef Lateef, Pink Floyd");
            musicGroup.Add(echosDesert);

            MusicGroup voixAube = new MusicGroup("005", "Les Voix de l'Aube", "Marie (chanteuse), Thomas (guitariste), Charlotte (pianiste), Simon (bassiste), Éric (batteur)", "Formé en 2014 à Montréal, le groupe s'est rapidement fait remarquer pour leur harmonie vocale unique et leurs chansons poétiques. Ils ont sorti leur premier album Aube en 2016 et ont tourné à travers le Canada et les États-Unis.", "Folk, pop", "Fleet Foxes, Bon Iver, Simon & Garfunkel");
            musicGroup.Add(voixAube);
        }
    }
}
