using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        PatientController patientController;
        RoomController roomController;
        AppointmentController appointmentController;
        DoctorController doctorController;

        int id;

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
        public ObservableCollection<DateTime> DateCollection
        {
            get;
            set;
        }
        public UpdateAppointment(Model.Appointment pomocna)
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

            textBox1.Text = pomocna.startDate.ToString();
            textBox2.Text = pomocna.endDate.ToString();
            PatientsCB.SelectedIndex = pomocna.DoctorID;
            int index = roomController.GetRoomIndex(pomocna.Room);
            RoomsCB.SelectedIndex = index;
            id = pomocna.Id;
        }

        private void OdustaniButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Parse(textBox1.Text);
            DateTime date2 = DateTime.Parse(textBox2.Text);
            Model.Patient newPatient = patientController.ReadPatient(PatientsCB.SelectedIndex);
            Model.Room newRoom = roomController.ReadRoomByIndex(RoomsCB.SelectedIndex);
            Model.Doctor newDoctor = doctorController.ReadDoctor(0);
            Model.Appointment newAppointment = new Model.Appointment(date, date2, id, newDoctor, newRoom, newPatient);
            appointmentController.UpdateAppointment(newAppointment);
            this.Close();
        }
    }
}
