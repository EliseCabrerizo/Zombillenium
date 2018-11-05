using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Zombillenium
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //On utilise cette classe pour faire des variables globales
        public static class MyVariables
        {
            public static Parc P = new Parc();
            public static bool click = false;
        }
        static void Peuplement(Parc P)
        {
            Zombie Z1 = new Zombie(48, "Grave", "Chase", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "neant", 58, "523", 4, (CouleurZ)Enum.Parse(typeof(CouleurZ), "bleuatre"));
            Zombie Z2 = new Zombie(489, "Debault", "Blaine", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "neant", 148, "428", 9, (CouleurZ)Enum.Parse(typeof(CouleurZ), "bleuatre"));
            Zombie Z3 = new Zombie(487, "Moore", "Liv", (TypeSexe)Enum.Parse(typeof(TypeSexe), "femelle"), "neant", 189, "623", 1, (CouleurZ)Enum.Parse(typeof(CouleurZ), "grisatre"));
            Zombie Z4 = new Zombie(4988, "Babineaux", "Dale", (TypeSexe)Enum.Parse(typeof(TypeSexe), "femelle"), "neant", 239, "112", 3, (CouleurZ)Enum.Parse(typeof(CouleurZ), "grisatre"));
            P.AjouterPersonnel(Z1);
            P.AjouterPersonnel(Z2);
            P.AjouterPersonnel(Z3);
            P.AjouterPersonnel(Z4);

            Vampire V1 = new Vampire(751, "Cullen", "Edward", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "neant", 489, "623", 0.8);
            Vampire V2 = new Vampire(759, "Cullen", "Bella", (TypeSexe)Enum.Parse(typeof(TypeSexe), "femelle"), "neant", 51, "428", 0.3);
            P.AjouterPersonnel(V1);
            P.AjouterPersonnel(V2);

            Demon D1 = new Demon(6666, "Hell", "belzebuth", (TypeSexe)Enum.Parse(typeof(TypeSexe), "autre"), "neant", 588, "parc", 5);
            Demon D2 = new Demon(6667, "Hell", "Lucifer", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "neant", 22, "684", 1);
            P.AjouterPersonnel(D1);
            P.AjouterPersonnel(D2);

            LoupGarou LG1 = new LoupGarou(7896, "black", "jacob", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "neant", 555, "684", 5);
            LoupGarou LG2 = new LoupGarou(7896, "White", "Seth", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "neant", 499, "parc", 4);
            P.AjouterPersonnel(LG1);
            P.AjouterPersonnel(LG2);

            Fantome F1 = new Fantome(1, "XIV", "louis", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "neant", 1200, "parc");
            Fantome F2 = new Fantome(88999, "hallyday", "johnny", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "neant", 2, "684");
            P.AjouterPersonnel(F1);
            P.AjouterPersonnel(F2);

            List<string> P1 = new List<string>();
            P1.Add("maitrise des elements");
            P1.Add("parle aux animaux");
            Sorcier S1 = new Sorcier(789, "apprentie", "Sabrina", (TypeSexe)Enum.Parse(typeof(TypeSexe), "femelle"), "neant", (Grade)Enum.Parse(typeof(Grade), "giga"), P1);
            P.AjouterPersonnel(S1);

            DarkRide DR1 = new DarkRide(true, 125, 3, "Immeuble hanté", "fantome", TimeSpan.Parse("12"), true);
            DarkRide DR2 = new DarkRide(true, 12465, 3, "camping hanté", "zombie", TimeSpan.Parse("12"), true);
            P.AjouterAttraction(DR1);
            P.AjouterAttraction(DR2);

            RollerCoaster R1 = new RollerCoaster(true, 36987, 4, "super hulk", "zombie", 12, (TypeCategorie)Enum.Parse(typeof(TypeCategorie), "assise"), 128);
            RollerCoaster R2 = new RollerCoaster(false, 387, 3, "Space mountain", "neant", 9, (TypeCategorie)Enum.Parse(typeof(TypeCategorie), "bobsleigh"), 111);
            P.AjouterAttraction(R1);
            P.AjouterAttraction(R2);

            Boutique B1 = new Boutique(false, 48, 1, "souvenirs effrayants", "neant", (TypeBoutique)Enum.Parse(typeof(TypeBoutique), "souvenir"));
            Boutique B2 = new Boutique(false, 498, 2, "miam miam", "neant", (TypeBoutique)Enum.Parse(typeof(TypeBoutique), "nourriture"));
            P.AjouterAttraction(B1);
            P.AjouterAttraction(B2);

            List<DateTime> listeTemp = new List<DateTime>();
            listeTemp.Add(Convert.ToDateTime("10:15"));
            listeTemp.Add(Convert.ToDateTime("15:15"));
            Spectacle Sp1 = new Spectacle(true, 789456, 4, "vampires sanglants", "vampire", listeTemp, 200, "bloddy room");
            List<DateTime> listeTemp2 = new List<DateTime>();
            listeTemp2.Add(Convert.ToDateTime("12:15"));
            listeTemp2.Add(Convert.ToDateTime("16:15"));
            Spectacle Sp2 = new Spectacle(true, 789456, 8, "Zombie degoutants", "zombie", listeTemp2, 245, "cimetiere");
            P.AjouterAttraction(Sp1);
            P.AjouterAttraction(Sp2);

        }
        //Creation de la vue et peuplement
        public MainWindow()
        {
            InitializeComponent();
            MyVariables.P.LectureFichier("listing.csv");
            Peuplement(MyVariables.P);
            for(int i=0;i<MyVariables.P.Personnels.Count;i++)
            {
                if (MyVariables.P.Personnels[i] is Monstre)
                    MyVariables.P.GererCagnotte(MyVariables.P.Personnels[i] as Monstre);
            }
            mafenetre.ShowDialog();

        }
        //Action de chaque bouton
        //On nettoie à chaque fois la partie bleue claire avant de rouvrir le UserControl correspondant
        private void Zombie_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutZ temp = new UCAjoutZ();
            ZoneEcriture.Children.Add(temp);
        }

        private void LG_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutLG temp = new UCAjoutLG();
            ZoneEcriture.Children.Add(temp);
        }
        
        private void Vamp_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutV temp = new UCAjoutV();
            ZoneEcriture.Children.Add(temp);
        }
        private void Fant_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutF temp = new UCAjoutF();
            ZoneEcriture.Children.Add(temp);
        }
        private void Sorcier_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutS temp = new UCAjoutS();
            ZoneEcriture.Children.Add(temp);
        }
        private void Demon_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutD temp = new UCAjoutD();
            ZoneEcriture.Children.Add(temp);
        }

        private void ListingP_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            MyVariables.P.Ecriture(true, "ListerPersonnel.csv", "Personnel", "");
            MessageBox.Show("C'est fait ! Rendez-vous dans le debug");
        }
        private void ListingA_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            MyVariables.P.Ecriture(true, "ListerAttraction.csv", "Attraction", "");
            MessageBox.Show("C'est fait ! Rendez-vous dans le debug");
        }

        private void ListerP_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCListerP temp = new UCListerP();
            ZoneEcriture.Children.Add(temp);
        }
        private void ListerA_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCListerA temp = new UCListerA();
            ZoneEcriture.Children.Add(temp);
        }
        private void DarkRide_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutDr temp = new UCAjoutDr();
            ZoneEcriture.Children.Add(temp);
        }
        private void Spectacle_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutSpe temp = new UCAjoutSpe();
            ZoneEcriture.Children.Add(temp);

        }
        private void RollerCoaster_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutRC temp = new UCAjoutRC();
            ZoneEcriture.Children.Add(temp);
        }
        private void Boutique_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCAjoutB temp = new UCAjoutB();
            ZoneEcriture.Children.Add(temp);
        }
        private void SupprimerP_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCSuppP temp = new UCSuppP();
            ZoneEcriture.Children.Add(temp);
        }
        private void SupprimerA_Click(object sender, RoutedEventArgs e)
        {
            ZoneEcriture.Children.Clear();
            UCSuppA temp = new UCSuppA();
            ZoneEcriture.Children.Add(temp);
        }



    }
}
