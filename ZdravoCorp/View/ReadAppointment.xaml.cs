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
    /// Interaction logic for ReadAppointment.xaml
    /// </summary>
    public partial class ReadAppointment : Window
    {
        public ReadAppointment()
        {
            InitializeComponent();
        }

        public ObservableCollection<Model.Appointment> appointment
        {
            get;
            set;
        }

        private void prikazi_Click(object sender, RoutedEventArgs e)
        {
            Controller.AppointmentController ap = new Controller.AppointmentController();
            Model.Appointment temp = ap.ReadAppointment(textBoxR.Text);
            if (temp.getAppointmentID() == textBoxR.Text)
            {
                appointment = new ObservableCollection<Model.Appointment>();
                appointment.Add(temp);
                AppointmentGrid.DataContext = appointment; 
                //textBoxR.Text = "Postoji";
            }
            else
            {
                MessageBox.Show("Appointment with this ID does not exist!");
                AppointmentGrid.DataContext = null;
                textBoxR.Text = "";
            }
        }
    }
}
