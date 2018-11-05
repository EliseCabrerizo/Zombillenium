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
    /// Logique d'interaction pour UCSuppA.xaml
    /// </summary>
    public partial class UCSuppA : UserControl
    {
        public UCSuppA()
        {
            InitializeComponent();
        }

        private void SupprimerA_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.MyVariables.P.TrouverAttraction(nomA.Text) != "")

            {
                MainWindow.MyVariables.P.SupprimerAttractionNom(nomA.Text, Convert.ToInt32(identifiantA.Text));
                MessageBox.Show("Attraction supprimée !");
            }
            else MessageBox.Show("Attraction introuvable !");
        }
    }
}
