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
namespace ZdravoCorp.View.Patient.Appointments
{
    /// <summary>
    /// Interaction logic for ChangeAppointment.xaml
    /// </summary>
    public partial class ChangeAppointment : Window
    {
        public DateTime selectedDate { get; set; }
        public DateTime exDate;
        public Appointment app;
        public Appointment exApp;
        public Doctor doctor { get; set; }
        public DoctorController doctorController;
        public AppointmentController appointmentController;
        public int selectedIndex {get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
        public Doctor SelectedDoctor { get; set; }
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
        public ChangeAppointment(Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            appointmentController = new AppointmentController();
            doctorController = new DoctorController();
            this.app = appointment;
            exApp = appointment;
            DoctorsCollection = new ObservableCollection<Doctor>(doctorController.GetAllDoctors());
            DoctorsCB.ItemsSource = DoctorsCollection;
            doctor = doctorController.ReadDoctor(appointment.doctor.Id);
            selectedIndex = doctor.Id;
            DoctorsCB.SelectedIndex = selectedIndex;
            selectedDate = appointment.startDate;
            this.exDate = appointment.StartDate;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            Doctor doctor = (Doctor)DoctorsCB.SelectedValue;
            DateTime date = (DateTime)datePicker.SelectedDate;
            List<Appointment> apps = new List<Appointment>();
            TimeSpan lessDays = new TimeSpan(-1, 0, 0, 0);
            TimeSpan moreDays = new TimeSpan(2, 0, 0, 0);
            DateTime less = exDate.Date + lessDays;
            DateTime more = exDate.Date + moreDays;
            if (date < less)
            {
                MessageBox.Show("Prvobitan datum mozete pomeriti najvise 1 dan uznazad.\nPrvobitan datum :\t" + exDate.ToString(), "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (date > more)
            {
                MessageBox.Show("Prvobitan datum mozete pomeriti najvise 2 dana unapred.\nPrvobitan datum :\t" + exDate.ToString(), "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (DateRB.IsChecked == true)
                {
                    apps = appointmentController.SuggestAppointments(doctor, date, date.AddMinutes(45), false, true);
                }
                else
                {
                    apps = appointmentController.SuggestAppointments(doctor, date, date.AddMinutes(45), true, true);

                }
                AppointmentsCollection = new ObservableCollection<Appointment>(apps);
                TableForSuggestedApp.DataContext = AppointmentsCollection;
            }
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
            app.Id = exApp.Id;
            appointmentController.UpdateAppointment(app);
            Room r = app.Room;
            r.RemoveAppointment(exApp);
            r.AddAppointment(app);
            rc.UpdateRoom(r);
            Doctor d = app.doctor;
            d.RemoveAppointment(exApp);
            d.AddAppointment(app);
            doctorController.UpdateDoctor(d);
            Model.Patient p = app.Patient;
            p.RemoveAppointment(exApp);
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
