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
    /// Logique d'interaction pour UCSuppP.xaml
    /// </summary>
    public partial class UCSuppP : UserControl
    {
        public UCSuppP()
        {
            InitializeComponent();
        }
        private void SupprimerP_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.MyVariables.P.TrouverPersonnel(nomP.Text, prenomP.Text) != "")
            {
                MainWindow.MyVariables.P.SupprimerPersonnelNom(nomP.Text, prenomP.Text);
                MessageBox.Show("Personnel supprimé !");
            }
            else MessageBox.Show("Personnel introuvable !");
        }
    }
}
