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
    /// Logique d'interaction pour UCAjoutZ.xaml
    /// </summary>
    public partial class UCAjoutZ : UserControl
    {
        Zombie Z = new Zombie(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "", 0, (CouleurZ)Enum.Parse(typeof(CouleurZ), "grisatre"));

        public UCAjoutZ()
        {
            InitializeComponent();
        }
        private void SexeZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)SexeZ.SelectedItem;
            Z.SEXE = (TypeSexe)Enum.Parse(typeof(TypeSexe), temp.Content.ToString());
        }
        private void CouleurZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)CouleurZ.SelectedItem;
            Z.TEINT = (CouleurZ)Enum.Parse(typeof(CouleurZ), temp.Content.ToString());
        }
        private void AjoutZ_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(MatriculeZ.Text, out m);
            Z.MATRICULE = m;
            Z.NOM = NomZ.Text;
            Z.PRENOM = PrenomZ.Text;

            Z.FONCTION = fonctionZ.Text;
            int c = 0;
            Int32.TryParse((cagnotteZ.Text), out c);
            Z.CAGNOTTE = c;
            Z.AFFECTATION = affectationZ.Text;
            int d = 0;
            Int32.TryParse((DegreeZ.Text), out d);
            Z.DEGREDECOMPOSITION = d;
            MainWindow.MyVariables.P.AjouterPersonnel(Z);
            Z = new Zombie(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "", 0, (CouleurZ)Enum.Parse(typeof(CouleurZ), "grisatre"));
            MessageBox.Show("Personnel ajouté !");

        }
    }
}
