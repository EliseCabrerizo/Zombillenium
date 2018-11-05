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
    /// Logique d'interaction pour UCAjoutV.xaml
    /// </summary>
    public partial class UCAjoutV : UserControl
    {
        Vampire V = new Vampire(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "", 0);

        public UCAjoutV()
        {
            InitializeComponent();
        }
        private void SexeVamp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)SexeV.SelectedItem;
            V.SEXE = (TypeSexe)Enum.Parse(typeof(TypeSexe), temp.Content.ToString());
        }
        private void AjoutV_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(MatriculeV.Text, out m);
            V.MATRICULE = m;
            V.NOM = NomV.Text;
            V.PRENOM = PrenomV.Text;
            V.FONCTION = fonctionV.Text;
            int c = 0;
            Int32.TryParse((cagnotteV.Text), out c);
            V.CAGNOTTE = c;
            V.AFFECTATION = affectationV.Text;
            c = 0;
            Int32.TryParse((lumV.Text), out c);
            V.INDICELUMINOSITE = c;
            MainWindow.MyVariables.P.AjouterPersonnel(V);
            V = new Vampire(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "", 0);
            MessageBox.Show("Personnel ajouté !");
        }
    }
}
