using System;
using System.Collections.Generic;
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

namespace ZdravoCorp.View
{
    /// <summary>
    /// Interaction logic for AddAppointmentToPatient.xaml
    /// </summary>
    public partial class AddAppointmentToPatient : Window, INotifyPropertyChanged
    {
        private string doctorName;
        private string date;
        private string time;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public String DoctorID
        {
            get { return doctorName; }
            set
            {
                if (value != doctorName)
                {
                    doctorName = value;
                    OnPropertyChanged("DoctorID");
                }
            }
        }
        public string Date
        {
            get { return date; }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        public string Time
        {
            get { return time; }
            set
            {
                if (value != time)
                {
                    time = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }
        public AddAppointmentToPatient()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Controller.AppointmentController controller = new Controller.AppointmentController();
            //Random rand = new Random();
            //int i = rand.Next(123456);
            string s = new string("123456");
            if (!controller.CreateAppointment(new Model.Appointment(dateTime.Text, dateTime.Text, s, s + "1", s + "2", s + "3")))
            {
                MessageBox.Show("Nije uspesno dodat element", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                this.Close();
            }

        }
    }
}
