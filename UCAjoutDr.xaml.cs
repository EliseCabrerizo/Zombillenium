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
    /// Logique d'interaction pour UCAjoutDr.xaml
    /// </summary>
    public partial class UCAjoutDr : UserControl
    {
        DarkRide Dr = new DarkRide(false, 0, 0, "", "", TimeSpan.Parse("0"), false);
        public UCAjoutDr()
        {
            InitializeComponent();
        }
        private void BesoinSpeDr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)BesoinSpeDr.SelectedItem;
            Dr.BesoinSpecifique = bool.Parse(temp.Content.ToString());
        }
        private void OuvertDR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)OuvertDR.SelectedItem;
            Dr.Ouvert = bool.Parse(temp.Content.ToString());
        }
        private void MaintanceDR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)MaintanceDR.SelectedItem;
            Dr.Maintenance = bool.Parse(temp.Content.ToString());
        }
        private void typeBesoinDR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)typeBesoinDR.SelectedItem;
            Dr.TypeDeBesoin = temp.Content.ToString();
        }
        private void BesoinVehDR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)BesoinVehDR.SelectedItem;
            Dr.Vehicule = bool.Parse(temp.Content.ToString());
        }
        private void AjoutDR_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(IdDR.Text, out m);
            Dr.Identifiant = m;
            Dr.Nom = NomDR.Text;
            Dr.Duree = TimeSpan.Parse(DureeDR.Text);
            Dr.ModifierNatureMaintenance(TypeM.Text);
            m = 0;
            Int32.TryParse(NbMinDR.Text, out m);
            Dr.NombreMinMonstre = m;
            string[] liste = HorairesDR.Text.Split(';');
            List<DateTime> listetemp = new List<DateTime>();
            for (int i = 0; i < liste.Length; i++)
                listetemp.Add(Convert.ToDateTime(liste[i]));

            MainWindow.MyVariables.P.AjouterAttraction(Dr);

            Dr = new DarkRide(false, 0, 0, "", "", TimeSpan.Parse("0"), false);
            MessageBox.Show("Attraction ajoutée !");
        }
    }
}
