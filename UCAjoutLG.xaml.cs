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
    /// Logique d'interaction pour UCAjoutLG.xaml
    /// </summary>
    public partial class UCAjoutLG : UserControl
    {
        LoupGarou Loup = new LoupGarou(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "", 0);

        public UCAjoutLG()
        {
            InitializeComponent();
        }
        private void SexeLG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)SexeLG.SelectedItem;
            Loup.SEXE = (TypeSexe)Enum.Parse(typeof(TypeSexe), temp.Content.ToString());
        }
        private void AjoutLG_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(MatriculeLG.Text, out m);
            Loup.MATRICULE = m;
            Loup.NOM = NomLG.Text;
            Loup.PRENOM = PrenomLG.Text;
            Loup.FONCTION = fonctionLG.Text;
            int c = 0;
            Int32.TryParse((cagnotteLG.Text), out c);
            Loup.CAGNOTTE = c;
            Loup.AFFECTATION = affectationLG.Text;
            c = 0;
            Int32.TryParse((CruateLG.Text), out c);
            Loup.CRUAUTE = c;
            MainWindow.MyVariables.P.AjouterPersonnel(Loup);
            Loup = new LoupGarou(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "", 0);
            MessageBox.Show("Personnel ajouté !");
        }
    }
}
