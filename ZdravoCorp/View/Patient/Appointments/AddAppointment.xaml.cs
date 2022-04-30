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
        DoctorController doctorController;
        AppointmentController appointmentController;
        List<Model.Suggestions> suggestions = new List<Model.Suggestions>();

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
        public ObservableCollection<Model.Suggestions> SuggestionsCollection
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

            
            
            AppointmentsCollection = new ObservableCollection<Appointment>();
            DoctorsCollection = new ObservableCollection<Doctor>(doctorController.GetAllDoctors());
            DoctorsCB.ItemsSource = DoctorsCollection;
        }


        private void Search_Click(object sender, RoutedEventArgs e)

        {
            DataContext = this;
            Doctor doctor = doctorController.ReadDoctor(DoctorsCB.SelectedIndex);
            DateTime date = (DateTime) datePicker.SelectedDate;
            Appointment app = new Appointment();
            List<Appointment> apps = new List<Appointment>();
            date.AddHours( doctor.WorkStartTime.Hour);
            date.AddMinutes(doctor.WorkStartTime.Minute);
            date.AddSeconds(doctor.WorkStartTime.Second);

            for (int i = 0; i < 15; i++)
            {
                if (DateRB.IsChecked == true)
                {
                    app = appointmentController.SuggestAppointment(doctor, date, date.AddMinutes(45), false);
                    date = date.AddMinutes(45);
                    
                }
                else 
                { 
                    app = appointmentController.SuggestAppointment(doctor, date, date.AddMinutes(45), true);
                    date = date.AddMinutes(45);
                }
                apps.Add(app);
                //suggestions.Add(new Model.Suggestions(app.doctor.Id, app.startDate, app.endDate, true, true));
            }
            AppointmentsCollection = new ObservableCollection<Appointment>(apps);
            TableForSuggestedApp.DataContext = AppointmentsCollection;
            //SuggestionsCollection = new ObservableCollection<Model.Suggestions>(suggestions);

            //TableForSuggestedApp.DataContext= SuggestionsCollection;


        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            //AppointmentsCollection = new ObservableCollection<Appointment>();
            //Appointment appointment = new Appointment();

            //if(TableForSuggestedApp.SelectedIndex == -1)
            //{
            //    return;
            //}
            //Model.Suggestions s = SuggestionsCollection.ElementAt(TableForSuggestedApp.SelectedIndex);
            //appointment.doctor = doctorController.ReadDoctor(s.DoctorID);
            //appointment.startDate = s.StartInterval;
            //appointment.endDate = appointment.startDate.AddMinutes(45);
            //PatientController pc = new PatientController();
            //appointment.Patient = pc.ReadPatient(0);
            //RoomController rc = new RoomController();
            //appointment.Room = rc.ReadRoom("0");
            //appointmentController.CreateAppointment(appointment);
            //this.Close();
        }
    }
}
