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

namespace ZdravoCorp.View.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryMainPage.xaml
    /// </summary>
    public partial class SecretaryMainPage : Page
    {
        private SecretaryMainWindow secretaryMainWindow;
        public SecretaryMainPage(SecretaryMainWindow smw)
        {
            InitializeComponent();
            this.secretaryMainWindow = smw;
        }

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
            
            SecretaryAppointments secretaryAppointments = new SecretaryAppointments(this, secretaryMainWindow);
            
            secretaryMainWindow.Content = secretaryAppointments;

              
        }

        private void Holidays_Click(object sender, RoutedEventArgs e)
        {
            View.HolidayRequestsView holidayRequestsView = new View.HolidayRequestsView();
            secretaryMainWindow.Content = holidayRequestsView;
        }
    }
}
