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
using System.ComponentModel;
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
        private Appointment app;
        public Model.Doctor doctor { get; set; }
        private DoctorController dc;
        public String NameSurname { get => NameSurname; set => NameSurname = value; }
        public Patient()
        {
            InitializeComponent();
            appointmentController = new AppointmentController();
            dc = new DoctorController();
            AppointmentsCollection = new ObservableCollection<Appointment>();
            DoctorCollection = new ObservableCollection<Model.Doctor>();
            RoomCollection = new ObservableCollection<Room>();
            UpdateTable();

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        public String Doctorr
        {
            get { return app.doctor.nameSurname; }
            set
            {
                if (value != app.doctor.nameSurname)
                {
                    app.doctor.nameSurname = value;
                    OnPropertyChanged("Doctorr");
                }
            }
        }
        public String Room
        {
            get { return app.Room.DesignationCode; }
            set
            {
                if (value != app.Room.DesignationCode)
                {
                    app.Room.DesignationCode = value;
                    OnPropertyChanged("Room");
                }
            }
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

        public ObservableCollection<Room> RoomCollection
        {
            get;
            set;
        }
        public ObservableCollection<Model.Doctor> DoctorCollection
        {
            get;
            set;
        }

        private void UpdateTable()
        {
            
            List<Appointment> appointments = appointmentController.GetAllAppointments();

            AppointmentsCollection = new ObservableCollection<Appointment>(appointments);
            List<Model.Doctor> doctors = new List<Model.Doctor>();
            foreach(Appointment a in appointments)
            {
                doctors.Add(a.doctor);
            }
            DoctorCollection = new ObservableCollection<Model.Doctor>();
            PatientAppointmentTable.DataContext = AppointmentsCollection;
        }
        private void Add_Appointment(object sender, RoutedEventArgs e)
        {
            AddAppointment window = new AddAppointment();
            window.Owner = this;
            window.ShowDialog();
            UpdateTable();
        }

        private void Change_Appointment(object sender, RoutedEventArgs e)
        {
            if (PatientAppointmentTable.SelectedIndex == -1)
            {
                return;
            }

            ChangeAppointment change = new ChangeAppointment(AppointmentsCollection.ElementAt(PatientAppointmentTable.SelectedIndex));
            change.ShowDialog();
            UpdateTable();

        }

        private void Delete_Appointment(object sender, RoutedEventArgs e)
        {
            if (PatientAppointmentTable.SelectedIndex == -1)
            {
                return;
            }
            if (!appointmentController.DeleteAppointment(AppointmentsCollection.ElementAt(PatientAppointmentTable.SelectedIndex).Id))
            {
                MessageBox.Show("Element ne postoji u bazi podataka", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            UpdateTable();
        }
    }
}
