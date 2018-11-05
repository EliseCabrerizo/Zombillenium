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
    /// Logique d'interaction pour UCAjoutS.xaml
    /// </summary>
    public partial class UCAjoutS : UserControl
    {
        public UCAjoutS()
        {
            InitializeComponent();
        }
        Sorcier S = new Sorcier(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", (Grade)Enum.Parse(typeof(Grade), "novice"));

        private void SexeS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp = (ComboBoxItem)SexeS.SelectedItem;
            S.SEXE = (TypeSexe)Enum.Parse(typeof(TypeSexe), temp.Content.ToString());
        }
        private void AjoutS_Click(object sender, RoutedEventArgs e)
        {
            int m = 0;
            Int32.TryParse(MatriculeS.Text, out m);
            S.MATRICULE = m;
            S.NOM = NomS.Text;
            S.PRENOM = PrenomS.Text;
            S.FONCTION = fonctionS.Text;
            string[] liste = listePouvoirS.Text.Split(';');
            for (int i = 0; i < liste.Length; i++)
                S.AjouterPouvoir(liste[i]);
            MainWindow.MyVariables.P.AjouterPersonnel(S);
            S = new Sorcier(0, "", "", (TypeSexe)Enum.Parse(typeof(TypeSexe), "male"), "", (Grade)Enum.Parse(typeof(Grade), "novice"));
            MessageBox.Show("Personnel ajouté !");

        }
    }
}
