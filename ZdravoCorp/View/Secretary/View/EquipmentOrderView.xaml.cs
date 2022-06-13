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

namespace ZdravoCorp.View.Secretary.View
{
    /// <summary>
    /// Interaction logic for EquipmentOrderView.xaml
    /// </summary>
    public partial class EquipmentOrderView : Page
    {
        public EquipmentOrderView(SecretaryMainPage smp, SecretaryMainWindow smw)
        {
            InitializeComponent();
            OrderEquipmentTable.DataContext = new ViewModel.EquipmentToOrderViewModel();


















            this.smw = smw;
            this.smp = smp; 
        }
        SecretaryMainWindow smw;
        SecretaryMainPage smp;
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            smw.Content = smp;
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Uspešno izvršena porudžbina.", "Obaveštenje", MessageBoxButton.OK);
        }
    }
}
