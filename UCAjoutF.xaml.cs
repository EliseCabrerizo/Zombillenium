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
    /// Logique d'interaction pour UCAjoutF.xaml
    /// </summary>
    public partial class UCAjoutF : UserControl
    {

        Fantome Fantome = new Fantome(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "");
        public UCAjoutF()
        {
            InitializeComponent();
        }
        private void SexeF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)SexeF.SelectedItem;
            Fantome.SEXE = (TypeSexe)Enum.Parse(typeof(TypeSexe), temp.Content.ToString());
        }
        private void AjoutF_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(MatriculeF.Text, out m);
            Fantome.MATRICULE = m;
            Fantome.NOM = NomF.Text;
            Fantome.PRENOM = PrenomF.Text;

            Fantome.FONCTION = fonctionF.Text;
            int c = 0;
            Int32.TryParse((cagnotteF.Text), out c);
            Fantome.CAGNOTTE = c;
            Fantome.AFFECTATION = affectationF.Text;
            c = 0;
            MainWindow.MyVariables.P.AjouterPersonnel(Fantome);
            Fantome = new Fantome(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "");
            MessageBox.Show("Personnel ajouté !");
        }
    }
}
