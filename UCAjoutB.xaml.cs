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
    /// Logique d'interaction pour UCAjoutB.xaml
    /// </summary>
    public partial class UCAjoutB : UserControl
    {
        Boutique b = new Boutique(false, 0, 0, "", "", (TypeBoutique)Enum.Parse(typeof(TypeBoutique), "nourriture"));
        
        public UCAjoutB()
        {
            InitializeComponent();
        }
        private void BesoinSpeB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)BesoinSpeB.SelectedItem;
            b.BesoinSpecifique = bool.Parse(temp.Content.ToString());
        }
        private void OuvertB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)OuvertB.SelectedItem;
            b.Ouvert = bool.Parse(temp.Content.ToString());
        }
        private void MaintanceB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)MaintanceB.SelectedItem;
            b.Maintenance = bool.Parse(temp.Content.ToString());
        }
        private void typeBesoinB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)typeBesoinB.SelectedItem;
            b.TypeDeBesoin = temp.Content.ToString();
        }
        private void TypeB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)TypeB.SelectedItem;
            b.Type = (TypeBoutique)Enum.Parse(typeof(TypeBoutique), temp.Content.ToString());
        }
        private void AjoutB_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(IdB.Text, out m);
            b.Identifiant = m;
            b.Nom = NomB.Text;
            b.ModifierNatureMaintenance(TypeM.Text);
            m = 0;
            Int32.TryParse(NbMinB.Text, out m);
            b.NombreMinMonstre = m;
            m = 0;

            MainWindow.MyVariables.P.AjouterAttraction(b);

            b = new Boutique(false, 0, 0, "", "", (TypeBoutique)Enum.Parse(typeof(TypeBoutique), "nourriture"));
            MessageBox.Show("Attraction ajoutée !");

        }
    }
}
