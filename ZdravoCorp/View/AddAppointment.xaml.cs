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

namespace ZdravoCorp.View
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        public AddAppointment()
        {
            InitializeComponent();
        }

        private void dodaj_appointment_Click(object sender, RoutedEventArgs e)
        {
            Controller.AppointmentController con = new Controller.AppointmentController();
            con.CreateAppointment(new Model.Appointment(textBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text,TextBox6.Text));
            this.Close();
        }
    }
}
