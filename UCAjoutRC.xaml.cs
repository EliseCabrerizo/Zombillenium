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
    /// Logique d'interaction pour UCAjoutRC.xaml
    /// </summary>
    public partial class UCAjoutRC : UserControl
    {
        RollerCoaster rc = new RollerCoaster(false, 0, 0, "", "", 0, (TypeCategorie)Enum.Parse(typeof(TypeCategorie), "assise"), 1.0);
        public UCAjoutRC()
        {
            InitializeComponent();
        }

        private void BesoinSpeRC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)BesoinSpeRC.SelectedItem;
            rc.BesoinSpecifique = bool.Parse(temp.Content.ToString());
        }
        private void OuvertRC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)OuvertRC.SelectedItem;
            rc.Ouvert = bool.Parse(temp.Content.ToString());
        }
        private void MaintanceRC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)MaintanceRC.SelectedItem;
            rc.Maintenance = bool.Parse(temp.Content.ToString());
        }
        private void typeBesoinRC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)typeBesoinRC.SelectedItem;
            rc.TypeDeBesoin = temp.Content.ToString();
        }
        private void Categorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)Categorie.SelectedItem;
            rc.Categorie = (TypeCategorie)Enum.Parse(typeof(TypeCategorie), temp.Content.ToString());
        }
        private void AjoutRC_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(IdRc.Text, out m);
            rc.Identifiant = m;
            rc.Nom = NomRC.Text;
            m = 0;
            Int32.TryParse(NbMinRC.Text, out m);
            rc.NombreMinMonstre = m;
            rc.ModifierNatureMaintenance(TypeM.Text);
            m = 0;
            Int32.TryParse(AgeMinRc.Text, out m);
            rc.AgeMin = m;
            double mm = 0;
            Double.TryParse(TailleMin.Text, out mm);
            rc.TailleMin = mm;

            MainWindow.MyVariables.P.AjouterAttraction(rc);

            rc = new RollerCoaster(false, 0, 0, "", "", 0, (TypeCategorie)Enum.Parse(typeof(TypeCategorie), "assise"), 1.0);
            MessageBox.Show("Attraction ajoutée !");

        }
    }
}
