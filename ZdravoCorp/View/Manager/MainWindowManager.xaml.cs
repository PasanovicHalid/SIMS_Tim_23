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
using System.Windows.Shapes;

namespace ZdravoCorp.View.Manager
{
    /// <summary>
    /// Interaction logic for MainWindowManager.xaml
    /// </summary>
    public partial class MainWindowManager : Window
    {
        public MainWindowManager()
        {
            InitializeComponent();
        }

        private void Rooms_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Manager.Rooms.Rooms rooms = new ZdravoCorp.View.Manager.Rooms.Rooms();
            rooms.ShowDialog();
        }
    }
}
