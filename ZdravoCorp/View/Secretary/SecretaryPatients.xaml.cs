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
using Model;
using Controller;

namespace ZdravoCorp.View.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryPatients.xaml
    /// </summary>
    public partial class SecretaryPatients : Page
    {
        public ObservableCollection<Model.Patient> PatientCollection { get; set; }
        
        public PatientController patientController;
        
        Model.Patient patient;

        private Model.Secretary secretary;

        public ObservableCollection<Model.Guest> GuestCollection { get; set; }
        public GuestController guestController;
        private SecretaryMainWindow secretaryMainWindow;
        private SecretaryMainPage secretaryMainPage;
        public SecretaryPatients(SecretaryMainPage smp, SecretaryMainWindow smw)
        {
            this.secretaryMainWindow = smw;
            this.secretaryMainPage = smp;
            InitializeComponent();
            PatientCollection = new ObservableCollection<Model.Patient>();
            patientController = new PatientController();

            

            GuestCollection = new ObservableCollection<Model.Guest>();
            guestController = new GuestController();

            UpdateTable();
            UpdateGuestTable();
        }
        private void UpdateTable()
        {
            PatientCollection = new ObservableCollection<Model.Patient>();
            List<Model.Patient> patients = patientController.GetAll();
            foreach (Model.Patient pat in patients)
            {
                PatientCollection.Add(pat);
            }
            PatientTable.DataContext = PatientCollection;
        }
        private void UpdateGuestTable()
        {
            GuestCollection = new ObservableCollection<Model.Guest>();
            List<Model.Guest> guests = guestController.GetAll();
            foreach (Model.Guest guest in guests)
            {
                GuestCollection.Add(guest);
            }
            GuestTable.DataContext = GuestCollection;
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            AddPatient window = new AddPatient();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
            UpdateTable();
        }

        private void DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            if (PatientTable.SelectedIndex == -1)
            {
                return;
            }
            patientController.Delete(PatientCollection.ElementAt(PatientTable.SelectedIndex).Id);
            UpdateTable();
        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            if (PatientTable.SelectedIndex == -1)
            {
                return;
            }
            ChangePatient change = new ChangePatient(PatientCollection.ElementAt(PatientTable.SelectedIndex));
            change.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            change.ShowDialog();
            UpdateTable();
        }
        private void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            AddGuest window = new AddGuest();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
            UpdateGuestTable();
        }

        private void DeleteGuest_Click(object sender, RoutedEventArgs e)
        {
            if (GuestTable.SelectedIndex == -1)
            {
                return;
            }
            guestController.Delete(GuestCollection.ElementAt(GuestTable.SelectedIndex).Id);
            UpdateGuestTable();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            secretaryMainWindow.Content = secretaryMainPage;
        }
    }
}
