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
using Controller;
using Model;

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for AddAppointmentToDoctor.xaml
    /// </summary>
    public partial class AddAppointmentToDoctor : Window
    {

        PatientController patientController;
        RoomController roomController;
        AppointmentController appointmentController;
        DoctorController doctorController;
        Model.Patient tempPatient;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Model.Room> RoomCollection
        {
            get;
            set;
        }

        public ObservableCollection<Model.Doctor> DoctorCollection
        {
            get;
            set;
        }

        public AddAppointmentToDoctor(Model.Patient pomocnip, Model.Doctor doc)
        {
            InitializeComponent();
            DataContext = this;
            patientController = new PatientController();
            roomController = new RoomController();
            doctorController = new DoctorController();
            appointmentController = new AppointmentController();
            tempPatient = pomocnip;

            DoctorCollection = new ObservableCollection<Model.Doctor>(doctorController.GetAllDoctors());
            Model.Doctor pomocniDoctor = doctorController.ReadDoctor(doc.Id);
            RoomCollection = new ObservableCollection<Model.Room>(roomController.GetAllRooms());
            DoctorsCB.ItemsSource = DoctorCollection;
            RoomsCB.ItemsSource = RoomCollection;
            InitializeComponent();
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {   
            Model.Doctor tempDoctor = (Model.Doctor)DoctorsCB.SelectedItem;
            Model.Room tempRoom = (Model.Room)RoomsCB.SelectedItem;
            CultureInfo dateTimeFormat = new CultureInfo("en-GB");
            DateTime date = DateTime.Parse(textBox1.Text, dateTimeFormat);
            DateTime date2 = DateTime.Parse(textBox2.Text, dateTimeFormat);
            bool isEmergency = (bool)CheckBox1.IsChecked;
            Model.Appointment newAppointment = new Model.Appointment(date, date2, 0, tempDoctor, tempRoom, tempPatient);
            appointmentController.CreateAppointment(newAppointment);
            this.Close();
        }
    }
}
