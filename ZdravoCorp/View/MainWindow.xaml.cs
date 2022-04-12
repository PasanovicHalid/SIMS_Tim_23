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

namespace ZdravoCorp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Probaj_lekar_Click(object sender, RoutedEventArgs e)
        {
            var s =new View.AddAppointment();
            s.ShowDialog();
        }

        private void ispisi_appointmente_Click(object sender, RoutedEventArgs e)
        {
            var s = new View.ViewAppointments();
            s.ShowDialog();
        }

        private void Read_Button_Click(object sender, RoutedEventArgs e)
        {
            var s = new View.ReadAppointment();
            s.ShowDialog();
        }
    }
}
