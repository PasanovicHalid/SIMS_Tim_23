using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        PatientController patientController;
        RoomController roomController;
        AppointmentController appointmentController;
        DoctorController doctorController;
        Model.Doctor currentDoctor;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Model.Room> RoomCollection
        {
            get;
            set;
        }
        public ObservableCollection<Model.Patient> PatientCollection
        {
            get;
            set;
        }
        public AddAppointment(Model.Doctor temp)
        {
            InitializeComponent();
            DataContext = this;
            patientController = new PatientController();
            roomController = new RoomController();
            doctorController = new DoctorController();
            appointmentController = new AppointmentController();


            PatientCollection = new ObservableCollection<Model.Patient>(patientController.GetAllPatients());
            RoomCollection = new ObservableCollection<Model.Room>(roomController.GetAllRooms());
            PatientsCB.ItemsSource = PatientCollection;
            RoomsCB.ItemsSource = RoomCollection;
            this.currentDoctor = temp;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo dateTimeFormat = new CultureInfo("en-GB");
            DateTime date = DateTime.Parse(textBox1.Text,dateTimeFormat);
            DateTime date2 = DateTime.Parse(textBox2.Text,dateTimeFormat);
            Model.Patient newPatient = patientController.ReadPatient(PatientsCB.SelectedIndex);
            Model.Room newRoom = roomController.ReadRoom(RoomsCB.SelectedIndex);

            Model.Appointment newAppointment = new Model.Appointment(date, date2, currentDoctor, newRoom, newPatient);
            appointmentController.CreateAppointment(newAppointment);
            this.Close();

        }

        private void OdustaniButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
