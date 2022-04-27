using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Controller;
using Model;
namespace ZdravoCorp.View.Patient.Appointments
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {
        public AppointmentController appointmentController;

        public ObservableCollection<Appointment> AppointmentsCollection
        {
            get;
            set;
        }
        public Appointments()
        {
            InitializeComponent();
            appointmentController = new AppointmentController();
            AppointmentsCollection = new ObservableCollection<Appointment>();
            UpdateTable();
        }
        private void UpdateTable() 
        {
            AppointmentsCollection = new ObservableCollection<Appointment>();
            List<Appointment> appointments = appointmentController.GetAllAppointments();
            foreach(Appointment app in appointments)
            {
                AppointmentsCollection.Add(app);
            }
            PatientAppointmentTable.DataContext = AppointmentsCollection;
        }
        private void Add_Appointment(object sender, RoutedEventArgs e)
        {

        }

        private void Change_Appointment(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Appointment(object sender, RoutedEventArgs e)
        {

        }
    }
}
