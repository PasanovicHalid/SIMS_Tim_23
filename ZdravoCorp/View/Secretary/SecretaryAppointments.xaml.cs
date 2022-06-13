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
using Model;
using Controller;

namespace ZdravoCorp.View.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryAppointments.xaml
    /// </summary>
    public partial class SecretaryAppointments : Page
    {
        private SecretaryMainWindow secretaryMainWindow;
        private SecretaryMainPage secretaryMainPage;
        public SecretaryAppointments(SecretaryMainPage smp, SecretaryMainWindow secretaryMainWindow)
        {
            InitializeComponent();
            this.secretaryMainPage = smp;
            this.secretaryMainWindow = secretaryMainWindow;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            
            secretaryMainWindow.Content = secretaryMainPage;

        }
    }
}
