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
using System.Collections.ObjectModel;

namespace ZdravoCorp.View.Secretary
{
    /// <summary>
    /// Interaction logic for EmergencyAppointment.xaml
    /// </summary>
    public partial class EmergencyAppointment : Page
    {
        ObservableCollection<string> bloodTypes = new ObservableCollection<string>();
        ObservableCollection<string> rooms = new ObservableCollection<string>();
        ObservableCollection<string> doctors = new ObservableCollection<string>();
        private SecretaryMainWindow secretaryMainWindow;
        private SecretaryMainPage secretaryMainPage;
        public EmergencyAppointment(SecretaryMainPage smp, SecretaryMainWindow smw)
        {
            this.secretaryMainPage = smp;
            this.secretaryMainWindow = smw;
            InitializeComponent();
            loadData();
            BloodTypes.ItemsSource = bloodTypes;
            Doctors.ItemsSource = doctors;
            Rooms.ItemsSource = rooms;
        }

        public void loadData() 
        {
            bloodTypes.Add("aPlus");
            bloodTypes.Add("aMinus");
            bloodTypes.Add("bPlus");
            bloodTypes.Add("bMinus");
            bloodTypes.Add("aBPlus");
            bloodTypes.Add("aBMinus");
            bloodTypes.Add("oPlus");
            bloodTypes.Add("oMinus");

            rooms.Add("RS110");
            rooms.Add("RS111");
            rooms.Add("RS201");
            rooms.Add("RS202");
            rooms.Add("RS301");

            doctors.Add("Duško Dušković");
            doctors.Add("Mina Minić");
            doctors.Add("Luka Kostić");
            doctors.Add("Lazar Petković");
        }
    }
}
