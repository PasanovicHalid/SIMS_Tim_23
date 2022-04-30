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

using System.Collections.ObjectModel;
using Controller;
using Model;
using ZdravoCorp.View.Patient.Appointments;

namespace ZdravoCorp.View.Patient
{
    /// <summary>
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        public Patient()
        {
            InitializeComponent();
            appointmentController = new AppointmentController();
            AppointmentsCollection = new ObservableCollection<Appointment>();
            UpdateTable();

        }

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments.Appointments window = new Appointments.Appointments();
            this.Hide();
            window.ShowDialog();
            this.Show();

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PatientAppointmentTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public AppointmentController appointmentController;

        public ObservableCollection<Appointment> AppointmentsCollection
        {
            get;
            set;
        }
          
        
        private void UpdateTable()
        {
            AppointmentsCollection = new ObservableCollection<Appointment>();
            List<Appointment> appointments = appointmentController.GetAllAppointments();
            foreach (Appointment app in appointments)
            {
                AppointmentsCollection.Add(app);
            }
            PatientAppointmentTable.DataContext = AppointmentsCollection;
        }
        private void Add_Appointment(object sender, RoutedEventArgs e)
        {
            AddAppointment window = new AddAppointment();
            window.Owner = this;
            window.ShowDialog();
        }

        private void Change_Appointment(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Appointment(object sender, RoutedEventArgs e)
        {

        }
    }
}
