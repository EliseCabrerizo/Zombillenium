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
    /// Logique d'interaction pour UCListerA.xaml
    /// </summary>
    public partial class UCListerA : UserControl
    {
        public UCListerA()
        {
            InitializeComponent();

            for (int i = 0; i < MainWindow.MyVariables.P.Attractions.Count; i++)
                listBox1.Items.Add(MainWindow.MyVariables.P.Attractions[i].ToString());
        }
    }
}
