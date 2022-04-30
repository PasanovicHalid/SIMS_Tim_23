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
using Controller;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;

using System.Collections.Generic;

namespace ZdravoCorp.View.Patient.Appointments
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window, INotifyPropertyChanged
    {
        public Appointment app;
        public DoctorController doctorController;
        public AppointmentController appointmentController;
        List<Model.Suggestion> suggestions = new List<Model.Suggestion>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Appointment> AppointmentsCollection
        {
            get;
            set;
        }
        public ObservableCollection<Doctor> DoctorsCollection
        {
            get;
            set;
        }
        public ObservableCollection<DateTime> DateCollection
        {
            get;
            set;
        }
        public ObservableCollection<Model.Suggestion> SuggestionsCollection
        {
            get;
            set;
        }
        public AddAppointment()
        {
            InitializeComponent();
            DataContext = this;
            doctorController = new DoctorController();
            appointmentController = new AppointmentController();
            
            SuggestionsCollection = new ObservableCollection<Suggestion>(suggestions);
            Suggestion suggestion;
            AppointmentsCollection = new ObservableCollection<Appointment>();
            DoctorsCollection = new ObservableCollection<Doctor>(doctorController.GetAllDoctors());
            DoctorsCB.ItemsSource = DoctorsCollection;
        }


        private void Search_Click(object sender, RoutedEventArgs e)

        {
            Suggestion suggestion;
            DataContext = this;
            Doctor doctor = doctorController.ReadDoctor(DoctorsCB.SelectedIndex);
            DateTime date = (DateTime) datePicker.SelectedDate;
            Appointment app ;
            List<Appointment> apps = new List<Appointment>();
            date.AddHours((int) doctor.WorkStartTime.Hour);
            date.AddMinutes((int)doctor.WorkStartTime.Minute);
            date.AddSeconds((int)doctor.WorkStartTime.Second);
            apps = appointmentController.SuggestAppointments(doctor, date, date.AddMinutes(45), DateRB.IsChecked == true);
            //for (int i = 0; i < 15; i++)
            //{
            //    if (DateRB.IsChecked == true)
            //    {
            //        app = appointmentController.SuggestAppointment(doctor, date, date.AddMinutes(45), false);
            //        date = date.AddMinutes(45);
                    
            //    }
            //    else 
            //    { 
            //        app = appointmentController.SuggestAppointment(doctor, date, date.AddMinutes(45), true);
            //        date = date.AddMinutes(45);
                    
            //    }
            //    apps.Add(app);
            //   // suggestions.Add(new Model.Suggestion(app.doctor, app.startDate, app.endDate, true, true));
            //}
            AppointmentsCollection = new ObservableCollection<Appointment>(apps);
            TableForSuggestedApp.DataContext = AppointmentsCollection;
            //SuggestionsCollection = new ObservableCollection<Model.Suggestion>(suggestions);

            //TableForSuggestedApp.DataContext = SuggestionsCollection;


        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            
            //SuggestionsCollection = new ObservableCollection<Model.Suggestion>();
            //Appointment appointment = new Appointment();

            if (TableForSuggestedApp.SelectedIndex == -1)
            {
                return;
            }
            app = AppointmentsCollection.ElementAt(TableForSuggestedApp.SelectedIndex);
            //Suggestion suggestion = SuggestionsCollection.ElementAt(TableForSuggestedApp.SelectedIndex);
            //appointment.doctor = doctorController.ReadDoctor(suggestion.Doctor.Id);
            //appointment.startDate = suggestion.StartInterval;
            //appointment.endDate = appointment.startDate.AddMinutes(45);
            PatientController pc = new PatientController();
            app.Patient = pc.ReadPatient(0);
            RoomController rc = new RoomController();
            app.Room = rc.ReadRoom(0);
            appointmentController.CreateAppointment(app);
            this.Close();
        }

        private void TableForSuggestedApp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AppointmentsCollection = new ObservableCollection<Appointment>();
            SuggestionsCollection = new ObservableCollection<Model.Suggestion>();
            Appointment appointment = new Appointment();

            if (TableForSuggestedApp.SelectedIndex == -1)
            {
                return;
            }
            Suggestion suggestion = SuggestionsCollection.ElementAt(TableForSuggestedApp.SelectedIndex);
            appointment.doctor = doctorController.ReadDoctor(suggestion.Doctor.Id);
            appointment.startDate = suggestion.StartInterval;
            appointment.endDate = appointment.startDate.AddMinutes(45);
            PatientController pc = new PatientController();
            appointment.Patient = pc.ReadPatient(0);
            RoomController rc = new RoomController();
            Room r = rc.findFreeRoom(appointment.startDate, appointment.endDate);
            appointment.Room = r;
            appointmentController.CreateAppointment(appointment);
        }
    }
}
