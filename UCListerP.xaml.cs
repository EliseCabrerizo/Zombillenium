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
    /// Logique d'interaction pour UCListerP.xaml
    /// </summary>
    public partial class UCListerP : UserControl
    {
        public UCListerP()
        {
            InitializeComponent();

            for (int i = 0; i < MainWindow.MyVariables.P.Personnels.Count; i++)
                listBox1.Items.Add(MainWindow.MyVariables.P.Personnels[i].ToString());
        }
    }
}
