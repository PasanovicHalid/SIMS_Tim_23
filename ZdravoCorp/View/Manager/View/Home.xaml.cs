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

namespace ZdravoCorp.View.Manager.View
{
    /// <summary>
    /// Interaction logic for ManagerMain.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Rooms_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Manager.Rooms.Rooms rooms = new ZdravoCorp.View.Manager.Rooms.Rooms();
            rooms.ShowDialog();
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            Equipments.Equipments window = new Equipments.Equipments();
            window.ShowDialog();
        }
    }
}
