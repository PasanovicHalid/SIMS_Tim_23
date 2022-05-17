using Controller;
using Model;
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

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {

        private AppointmentController appointmentController;
        Model.Doctor currentDoctor;

        public ObservableCollection<Appointment> appointments
        {
            get;
            set;
        }
        public Appointments(Model.Doctor dd)
        {
            InitializeComponent();
            this.DataContext = this;
            appointmentController = new AppointmentController();
            appointments = new ObservableCollection<Appointment>();

            currentDoctor = dd;

            List<Appointment> apps = appointmentController.GetAllAppointments();
            foreach (Appointment temp in apps)
            {
                if (temp.doctor.Id == currentDoctor.Id)
                {
                    appointments.Add(temp);
                }
            }
            AppointmentGrid.DataContext = appointments;
        }

        public Appointments()
        {
            InitializeComponent();
            this.DataContext = this;
            appointmentController = new AppointmentController();
            appointments = new ObservableCollection<Appointment>();

            List<Appointment> apps = appointmentController.GetAllAppointments();
            foreach (Appointment temp in apps)
            {
                appointments.Add(temp);
            }
            AppointmentGrid.DataContext = appointments;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            appointmentController = new AppointmentController();

            Appointment temp = (Appointment)AppointmentGrid.SelectedItem;

            if (temp == null)
            {
                MessageBox.Show("Appointment must be checked!");
            }
            else
            {
                if (appointmentController.DeleteAppointment(temp.Id))
                {
                    MessageBox.Show("Deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Not deleted!");
                }
            }
            List<Appointment> apps = appointmentController.GetAllAppointments();
            foreach (Appointment app in apps)
            {
                if (app.doctor.Id == currentDoctor.Id)
                {
                    appointments.Add(app);
                }
            }
            AppointmentGrid.DataContext = appointments;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment add = new AddAppointment(currentDoctor);
            add.ShowDialog();

            this.DataContext = this;
            appointmentController = new AppointmentController();
            appointments = new ObservableCollection<Appointment>();


            List<Appointment> apps = appointmentController.GetAllAppointments();
            foreach (Appointment temp in apps)
            {
                if (temp.doctor.Id == currentDoctor.Id)
                {
                    appointments.Add(temp);
                }
            }
            AppointmentGrid.DataContext = appointments;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if(AppointmentGrid.SelectedItem == null)
            {
                MessageBox.Show("Nije oznacen ni jedan appointment!");
            }
            else
            {
                UpdateAppointment upd = new UpdateAppointment((Appointment)AppointmentGrid.SelectedItem);
                upd.ShowDialog();

                this.DataContext = this;
                appointmentController = new AppointmentController();
                appointments = new ObservableCollection<Appointment>();

                List<Appointment> apps = appointmentController.GetAllAppointments();
                foreach (Appointment temp in apps)
                {
                    if (temp.DoctorID == currentDoctor.Id)
                    {
                        appointments.Add(temp);
                    }
                }
                AppointmentGrid.DataContext = appointments;

            }
            
        }

        private void kartoniButton_Click(object sender, RoutedEventArgs e)
        {
            MedicalRecords meds = new MedicalRecords(currentDoctor);
            this.Close();
            meds.Show();
        }

        private void requestsButton_Click(object sender, RoutedEventArgs e)
        {
            MedicationRequests medicationRequests = new MedicationRequests(currentDoctor);
            this.Close();
            medicationRequests.Show();
        }

        private void vacationRequestButton_Click(object sender, RoutedEventArgs e)
        {
            VacationRequest vacationRequest = new VacationRequest(currentDoctor);
            this.Close();
            vacationRequest.Show();
        }

        private void medsButton_Click(object sender, RoutedEventArgs e)
        {
            MedicationsView medicationsView = new MedicationsView(currentDoctor);
            this.Close();
            medicationsView.Show();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserWindow user = new UserWindow(currentDoctor);
            user.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
