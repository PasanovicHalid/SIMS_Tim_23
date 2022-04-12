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
using Model;

namespace ZdravoCorp.View
{
    /// <summary>
    /// Interaction logic for ViewAppointments.xaml
    /// </summary>
    public partial class ViewAppointments : Window
    {
        private Controller.AppointmentController appointmentController;
        public ObservableCollection<Appointment> appointments
        {
            get;
            set;
        }

        public ViewAppointments()
        {
            InitializeComponent();
            this.DataContext = this;
            appointmentController = new Controller.AppointmentController();
            appointments = new ObservableCollection<Appointment>();

            List<Appointment> apps = appointmentController.GetAllAppointments();
            foreach (Appointment temp in apps)
            {
                appointments.Add(temp);
            }
            AppointmentGrid.DataContext = appointments;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            appointmentController = new Controller.AppointmentController();

            Appointment temp = (Appointment)AppointmentGrid.SelectedItem;

            if(temp == null)
            {
                MessageBox.Show("Appointment must be checked!");
            }
            else
            {
                var s = new View.UpdateAppointment(temp);
                s.Show();
                this.Close();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            appointmentController = new Controller.AppointmentController();

            Appointment temp = (Appointment)AppointmentGrid.SelectedItem;

            if (temp == null)
            {
                MessageBox.Show("Appointment must be checked!");
            }
            else
            {
                if(appointmentController.DeleteAppointment(temp.getAppointmentID()))
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
    }
}
