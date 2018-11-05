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
    /// Logique d'interaction pour UCAjoutD.xaml
    /// </summary>
    public partial class UCAjoutD : UserControl
    {
        Demon Dem = new Demon(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "", 0);

        public IEnumerable<Control> Controls { get; private set; }

        public UCAjoutD()
        {
            InitializeComponent();
        }

        private void SexeD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)SexeD.SelectedItem;
            Dem.SEXE = (TypeSexe)Enum.Parse(typeof(TypeSexe), temp.Content.ToString());
        }
        private void AjoutD_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(MatriculeD.Text, out m);
            Dem.MATRICULE = m;
            Dem.NOM = NomD.Text;
            Dem.PRENOM = PrenomD.Text;
            Dem.FONCTION = fonctionD.Text;
            int c = 0;
            Int32.TryParse((cagnotteD.Text), out c);
            Dem.CAGNOTTE = c;
            Dem.AFFECTATION = affectationD.Text;
            c = 0;
            Int32.TryParse((ForceD.Text), out c);
            Dem.FORCE = c;
            MainWindow.MyVariables.P.AjouterPersonnel(Dem);
            Dem = new Demon(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", 0, "", 0);
            MessageBox.Show("Personnel ajouté !");

            
        }

    }
}
