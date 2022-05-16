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
    public partial class Patient : Window, INotifyPropertyChanged
    {
        private Appointment app;
        private Model.Patient patient;
        public  Model.Doctor doctor { get; set; }
        private DoctorController dc;
        public String NameSurname { get => NameSurname; set => NameSurname = value; }
        private String password;
        private String username;
        private String name;
        private String surname;
        private String jmbg;
        private String email;
        private String address;
        private String phoneNumber;
        private Gender gender;
        private DateTime dateOfBirth;

        public String Username
        {
            get { return username; }
            set
            {
                if (value != username)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public String Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public String Namee
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Namee");
                }
            }
        }

        public String Surname
        {
            get { return surname; }
            set
            {
                if (value != surname)
                {
                    surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }

        public String Jmbg
        {
            get { return jmbg; }
            set
            {
                if (value != jmbg)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }

        public String Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public String Address
        {
            get { return address; }
            set
            {
                if (value != address)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public String PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public Gender Gender
        {
            get { return gender; }
            set
            {
                if (value != gender)
                {
                    if (MaleButton.IsChecked == true)
                    {
                        gender = Gender.Male;
                    }
                    else
                    {
                        gender = Gender.Female;
                    }
                    OnPropertyChanged("Gender");
                }

            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value != dateOfBirth)
                {
                    dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        public Patient(Model.Patient logedPatient)
        {
            InitializeComponent();
            patient = logedPatient;
            appointmentController = new AppointmentController();
            dc = new DoctorController();
            FutureAppointmentsCollection = new ObservableCollection<Appointment>();
            PastAppointmentsCollection = new ObservableCollection<Appointment>();
            DoctorCollection = new ObservableCollection<Model.Doctor>();
            RoomCollection = new ObservableCollection<Room>();
            SetPatientInfo(patient);
            UpdateTable();
            PastAppointments();

        }
        public void SetPatientInfo(Model.Patient patient)
        {
            NameTextBox.Text = patient.Name;
            SurnameTextBox.Text = patient.Surname;
            BirthTextBox.Text = patient.DateOfBirth.ToLongDateString();
            PhoneTextBox.Text = patient.PhoneNumber;
            EmailTextBox.Text = patient.Email;
            JMBGTextBox.Text = patient.Jmbg;
            if (patient.Gender == Gender.Male)
            {
                MaleButton.IsChecked = true;
            }
            else
            {
                FemaleButton.IsChecked = true;
            }
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

        public ObservableCollection<Appointment> FutureAppointmentsCollection
        {
            get;
            set;
        }
        public ObservableCollection<Appointment> PastAppointmentsCollection
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
            
            List<Appointment> appointments = appointmentController.GetFutureAppointmentsForPatient(patient);
            RoomController roomController = new RoomController();
            FutureAppointmentsCollection = new ObservableCollection<Appointment>(appointments);
            foreach(Appointment a in appointments)
            {
                a.doctor = dc.ReadDoctor(a.doctor.Id);
                a.room = roomController.ReadRoom(a.room.Identifier);
            }
            PatientAppointmentTable.DataContext = FutureAppointmentsCollection;
        }
        private void Add_Appointment(object sender, RoutedEventArgs e)
        {
            AddAppointment window = new AddAppointment(patient);
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
            Appointment appointment = (Appointment)PatientAppointmentTable.SelectedItem;
            PatientController patientController = new PatientController();
            //Model.Patient patient = patientController.ReadPatient(appointment.Patient.Id);
            patientController.RemoveFromChangedOrCanceledList(patient);
            if (appointmentController.IsTroll(appointment))
            {
                MessageBox.Show("Sad cete biti blokirani jer ste trol", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow window = new MainWindow();
                this.Close();
                window.ShowDialog();
            }
            ChangeAppointment change = new ChangeAppointment(appointment);
            change.ShowDialog();
            UpdateTable();

        }

        private void Delete_Appointment(object sender, RoutedEventArgs e)
        {
            if (PatientAppointmentTable.SelectedIndex == -1)
            {
                return;
            }
            Appointment appointment = (Appointment)PatientAppointmentTable.SelectedItem;
            PatientController patientController = new PatientController();
            //Model.Patient patient = patientController.ReadPatient(appointment.Patient.Id);
            patientController.RemoveFromChangedOrCanceledList(patient);
            if (appointmentController.IsTroll(appointment))
            {
                MessageBox.Show("Sad cete biti blokirani jer ste trol", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow window = new MainWindow();
                this.Close();
                window.ShowDialog();
                
            }
            if (!appointmentController.DeleteAppointment(appointment.Id))
            {
                MessageBox.Show("Element ne postoji u bazi podataka", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (patient.ChangedOrCanceledAppointmentsDates == null)
            {
                patient.ChangedOrCanceledAppointmentsDates = new List<DateTime>();
            }
            DoctorController doctorController = new DoctorController();
            Model.Doctor doctor = doctorController.ReadDoctor(appointment.Doctor.Id);
            doctor.RemoveAppointment(appointment);
            doctorController.UpdateDoctor(doctor);
            RoomController roomController = new RoomController();
            Model.Room room = roomController.ReadRoom(appointment.Room.Identifier);
            room.RemoveAppointment(appointment);
            roomController.UpdateRoom(room);
            patient.RemoveAppointment(appointment);
            patient.ChangedOrCanceledAppointmentsDates.Add(DateTime.Now);
            patientController.UpdatePatient(patient);
            UpdateTable();
        }

        private void AppointmentSurvey_Click(object sender, RoutedEventArgs e)
        {
            AppointmentSurveyController appointmentSurveyController = new AppointmentSurveyController();
            if (DoneAppointments.SelectedIndex == -1)
            {
                return;
            }
            else if (appointmentSurveyController.DoneSurvey(PastAppointmentsCollection.ElementAt(DoneAppointments.SelectedIndex)))
            {
                MessageBox.Show("Vec ste popunili anketu za ovaj pregled", "Pregled ocenjen", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            ZdravoCorp.View.Patient.View.Survey.AppointmentSurveyView window = new ZdravoCorp.View.Patient.View.Survey.AppointmentSurveyView(PastAppointmentsCollection.ElementAt(DoneAppointments.SelectedIndex));
            window.ShowDialog();
        }

        public void PastAppointments()
        {
            List<Appointment> appointments = appointmentController.GetPastAppointmentsForPatient(patient);
            RoomController roomController = new RoomController();
            PastAppointmentsCollection = new ObservableCollection<Appointment>(appointments);
            List<Model.Doctor> doctors = new List<Model.Doctor>();
            foreach (Appointment a in appointments)
            {
                a.doctor = dc.ReadDoctor(a.doctor.Id);
                a.room = roomController.ReadRoom(a.room.Identifier);
            }
            DoctorCollection = new ObservableCollection<Model.Doctor>();
            DoneAppointments.DataContext = PastAppointmentsCollection;
        }

        private void HospitalSurvey_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Patient.View.Survey.HospitalSurveyView window = new ZdravoCorp.View.Patient.View.Survey.HospitalSurveyView(patient);
            window.ShowDialog();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.ShowDialog();
           
        }
    }
}
