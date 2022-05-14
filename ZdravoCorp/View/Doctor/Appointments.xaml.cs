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

        private Model.Doctor currentDoctor;

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
            txtIme.Text = currentDoctor.name + " " + currentDoctor.surname;

            List<Appointment> apps = appointmentController.GetAllAppointments();
            foreach (Appointment temp in apps)
            {
                if (temp.doctor.Id == dd.Id)
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Not deleted!");
                }
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment add = new AddAppointment();
            add.ShowDialog();

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

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateAppointment upd = new UpdateAppointment((Appointment)AppointmentGrid.SelectedItem);
            upd.ShowDialog();

            this.DataContext = this;
            appointmentController = new AppointmentController();
            appointments = new ObservableCollection<Appointment>();

            List<Appointment> apps = appointmentController.GetAllAppointments();
            foreach (Appointment temp in apps)
            {
                if(temp.DoctorID == currentDoctor.Id)
                {
                    appointments.Add(temp);
                }
            }
            AppointmentGrid.DataContext = appointments;
        }

        private void kartoniButton_Click(object sender, RoutedEventArgs e)
        {
            MedicalRecords meds = new MedicalRecords(currentDoctor);
            meds.Show();
        }
    }
}
