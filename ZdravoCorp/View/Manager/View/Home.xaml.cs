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
using ZdravoCorp.View.Core;
using ZdravoCorp.View.Manager.ViewModel;

namespace ZdravoCorp.View.Manager.View
{
    /// <summary>
    /// Interaction logic for ManagerMain.xaml
    /// </summary>
    public partial class Home : UserControl, WindowInterface
    {
        private MainViewModel viewModel;
        public Home(MainViewModel model)
        {
            InitializeComponent();
            this.viewModel = model;
            this.DataContext = viewModel;
        }

        private void Rooms_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Manager.Rooms.Rooms rooms = new ZdravoCorp.View.Manager.Rooms.Rooms();
            rooms.ShowDialog();
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Manager.Equipments.Equipments window = new ZdravoCorp.View.Manager.Equipments.Equipments();
            window.ShowDialog();
        }

        public string getTitle()
        {
            return "Main";
        }
    }
}
