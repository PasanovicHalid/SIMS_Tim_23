using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZdravoCorp.View.Secretary.View
{
    /// <summary>
    /// Interaction logic for HolidayRequests.xaml
    /// </summary>
    public partial class HolidayRequestsView : Page
    {
        
        public HolidayRequestsView(SecretaryMainPage smp, SecretaryMainWindow secretaryMainWindow)
        {
            InitializeComponent();
            HolidaysTable.DataContext = new ViewModel.HolidayRequestViewModel(smp, secretaryMainWindow);























            this.smw = secretaryMainWindow;
            this.smp = smp;
            
        }
        private SecretaryMainWindow smw;
        private SecretaryMainPage smp;  

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            smw.Content = smp;
        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = (MessageBoxResult)System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da odbijete zahtev za odsustvo?", "Upozorenje", MessageBoxButtons.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                //do something
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                //do something else
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = (MessageBoxResult)System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da odobrite zahtev za odsustvo?", "Upozorenje", MessageBoxButtons.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                //do something
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                //do something else
            }
        }
    }
}
