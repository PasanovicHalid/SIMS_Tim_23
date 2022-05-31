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
        Model.Patient patient;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Appointment> AppointmentsCollection
        {
            get;
            set;
        }
        public ObservableCollection<Model.Doctor> DoctorsCollection
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
        public AddAppointment(Model.Patient logedPatient)
        {
            InitializeComponent();
            DataContext = this;
            doctorController = new DoctorController();
            appointmentController = new AppointmentController();
            patient = logedPatient;
            SuggestionsCollection = new ObservableCollection<Suggestion>(suggestions);
            Suggestion suggestion;
            AppointmentsCollection = new ObservableCollection<Appointment>();
            DoctorsCollection = new ObservableCollection<Model.Doctor>(doctorController.GetAllDoctors());
            DoctorsCB.ItemsSource = DoctorsCollection;
        }


        private void Search_Click(object sender, RoutedEventArgs e)

        {

            DataContext = this;
            Model.Doctor d = (Model.Doctor)DoctorsCB.SelectedItem;
            Model.Doctor doctor = doctorController.ReadDoctor(d.Id);
            DateTime date = (DateTime)datePicker.SelectedDate;
            Appointment app;
            List<Appointment> apps = new List<Appointment>();
            date.AddHours((int)doctor.WorkStartTime.Hour);
            date.AddMinutes((int)doctor.WorkStartTime.Minute);
            date.AddSeconds((int)doctor.WorkStartTime.Second);
            if (DateRB.IsChecked == true)
            {
                apps = appointmentController.sugAppointment(new WantedAppointment(doctor, date, date.AddMinutes(45), false, true, patient)); //SuggestAppointments(doctor, date, date.AddMinutes(45), false, true, patient);
            }
            else
            {
                apps = appointmentController.sugAppointment(new WantedAppointment(doctor, date, date.AddMinutes(45), true, true, patient));
               // apps = appointmentController.SuggestAppointments(doctor, date, date.AddMinutes(45), true, true, patient);

            }

            AppointmentsCollection = new ObservableCollection<Appointment>(apps);
            TableForSuggestedApp.DataContext = AppointmentsCollection;

        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (TableForSuggestedApp.SelectedIndex == -1)
            {
                return;
            }
            app = AppointmentsCollection.ElementAt(TableForSuggestedApp.SelectedIndex);
            PatientController pc = new PatientController();

            RoomController rc = new RoomController();

            appointmentController.CreateAppointment(app);
            Room r = app.Room;
            r.AddAppointment(app);
            rc.UpdateRoom(r);
            Model.Doctor d = app.doctor;
            d.AddAppointment(app);
            doctorController.UpdateDoctor(d);
            Model.Patient p = app.Patient;
            p.AddAppointment(app);
            pc.UpdatePatient(p);
            this.Close();
        }

    

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
