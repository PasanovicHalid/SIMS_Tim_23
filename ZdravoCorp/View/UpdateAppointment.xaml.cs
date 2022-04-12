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

namespace ZdravoCorp.View
{
    /// <summary>
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        Model.Appointment appointment;

        public ObservableCollection<Model.Appointment> apoc
        {
            get;
            set;
        }
        public UpdateAppointment(Model.Appointment ap)
        {
            InitializeComponent();
            appointment = ap;
            textBox1.Text = appointment.StartDate.ToString();
            TextBox2.Text = appointment.EndDate.ToString();
            TextBox3.Text = appointment.AppointmentID.ToString();
            TextBox4.Text = appointment.DoctorID.ToString();
            TextBox5.Text = appointment.PatientID.ToString();
            TextBox6.Text = appointment.RoomID.ToString();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            Model.Appointment drugi = new Model.Appointment(textBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text);
            if (drugi.getAppointmentID() != appointment.getAppointmentID())
            {
                MessageBox.Show("ID can not be changed!");
                var s = new View.ViewAppointments();
                s.Show();
                this.Close();   
            }
            else
            {
                Controller.AppointmentController apc = new Controller.AppointmentController();
                if (apc.UpdateAppointment(drugi))
                {
                    MessageBox.Show("Updated successfully!");
                    var s = new View.ViewAppointments();
                    s.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Not Updated!");
                    var s = new View.ViewAppointments();
                    s.Show();
                    this.Close();

                }
            }
        }
    }
}
