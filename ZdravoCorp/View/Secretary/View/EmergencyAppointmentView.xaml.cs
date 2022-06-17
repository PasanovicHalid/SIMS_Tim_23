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

namespace ZdravoCorp.View.Secretary.View
{
    /// <summary>
    /// Interaction logic for EmergencyAppointmentView.xaml
    /// </summary>
    public partial class EmergencyAppointmentView : Page
    {
        ObservableCollection<string> bloodTypes = new ObservableCollection<string>();
        ObservableCollection<string> rooms = new ObservableCollection<string>();
        ObservableCollection<string> doctors = new ObservableCollection<string>();
        public EmergencyAppointmentView(SecretaryMainPage smp, SecretaryMainWindow smw)
        {
            InitializeComponent();
            loadData();
            BloodTypes.DataContext = bloodTypes;
            BloodTypes.SelectedIndex = 0;
            Doctors.DataContext = doctors;
            Doctors.SelectedIndex = 0; 
            Rooms.DataContext = rooms;
            Rooms.SelectedIndex = 0;






            patients.Add("1234567890");
            patients.Add("Marko");
            patients.Add("Marković");
            patients.Add("1111122222");
            patients.Add("Luka");
            patients.Add("Lukić");
            patients.Add("3333333333");
            patients.Add("Lazar");
            patients.Add("Jović");


            this.smp = smp;
            this.smw = smw;

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
        private SecretaryMainWindow smw;
        private SecretaryMainPage smp;
        private List<String> patients = new List<String>();
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            smw.Content = smp;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;
            for (int i = 0; i < patients.Count; i++)
            {
                if (Id.Text.Equals(patients[i]))
                {
                    success = true;
                    Name.Text = patients[i + 1];
                    Surname.Text = patients[i + 2];
                    break;
                }
            }
            if (!success)
            {
                MessageBox.Show("Pacijent se ne nalazi u bazi. Molimo vas da unesete njegove podatke.", "Obaveštenje", MessageBoxButton.OK);
            }
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Uspešno obrađen hitan slučaj.", "Obaveštenje", MessageBoxButton.OK);
            Id.Text = "";
            Name.Text = "";
            Surname.Text = "";
            BloodTypes.SelectedIndex = 0;
            Doctors.SelectedIndex = 0;
            Rooms.SelectedIndex = 0;
        }

    }
}
