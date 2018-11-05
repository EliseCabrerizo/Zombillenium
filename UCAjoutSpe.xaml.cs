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
    /// Logique d'interaction pour UCAjoutSpe.xaml
    /// </summary>
    public partial class UCAjoutSpe : UserControl
    {
        static List<DateTime> ListeDate()
        {
            List<DateTime> listeTemp = new List<DateTime>();
            listeTemp.Add(Convert.ToDateTime("00:00"));
            listeTemp.Add(Convert.ToDateTime("00:00"));
            return listeTemp;
        }
        Spectacle Spe = new Spectacle(false, 0, 0, "", "", ListeDate(), 0, "");
        public UCAjoutSpe()
        {
            InitializeComponent();
        }

        private void BesoinSpeSpe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)BesoinSpeSpe.SelectedItem;
            Spe.BesoinSpecifique = bool.Parse(temp.Content.ToString());
        }
        private void OuvertSPE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)OuvertSpe.SelectedItem;
            Spe.Ouvert = bool.Parse(temp.Content.ToString());
        }
        private void MaintanceSPE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)MaintanceSpe.SelectedItem;
            Spe.Maintenance = bool.Parse(temp.Content.ToString());
        }
        private void typeBesoinSPE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)typeBesoinSpe.SelectedItem;
            Spe.TypeDeBesoin = temp.Content.ToString();
        }

        private void AjoutSPE_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(IdSPE.Text, out m);
            Spe.Identifiant = m;
            Spe.Nom = NomSpe.Text;
            m = 0;
            Spe.ModifierNatureMaintenance(TypeM.Text);
            Int32.TryParse(NbMinSpe.Text, out m);
            Spe.NombreMinMonstre = m;

            MainWindow.MyVariables.P.AjouterAttraction(Spe);

            Spe = new Spectacle(false, 0, 0, "", "", ListeDate(), 0, "");
            MessageBox.Show("Attraction ajoutée !");
        }
    }
}
