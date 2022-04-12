using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using ZdravoCorp.View;

namespace ZdravoCorp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Controller.RoomController roomController;
        private Controller.AppointmentController appointmentControllerForPatients;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<Room> Rooms
        {
            get;
            set;
        }

        public ObservableCollection<Appointment> AppointmentsForPatients 
        {
            get;
            set;
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            roomController = new Controller.RoomController();
            Rooms = new ObservableCollection<Room>();
            List<Room> rooms = roomController.GetAllRooms();
            foreach (Room room in rooms)
            {
                Rooms.Add(room);
            }
            appointmentControllerForPatients = new Controller.AppointmentController();
            AppointmentsForPatients = new ObservableCollection<Appointment>();
            List<Appointment> appointmentsForPatients = appointmentControllerForPatients.GetAllAppointments();
            foreach (Appointment app in appointmentsForPatients)
            {
                AppointmentsForPatients.Add(app);
            }

            PatientTable.DataContext = AppointmentsForPatients;
            UpravnikTable.DataContext = Rooms;

            
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            var s = new View.AddRoom();
            s.ShowDialog();
            Rooms = new ObservableCollection<Room>();
            List<Room> rooms = roomController.GetAllRooms();
            foreach (Room room in rooms)
            {
                Rooms.Add(room);
            }
            UpravnikTable.DataContext = Rooms;
            OnPropertyChanged("Rooms");
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            if(UpravnikTable.SelectedIndex == -1)
            {
                return;
            }

            ChangeRoom change = new ChangeRoom(Rooms.ElementAt(UpravnikTable.SelectedIndex));
            change.ShowDialog();
            Rooms = new ObservableCollection<Room>();
            List<Room> rooms = roomController.GetAllRooms();
            foreach (Room room in rooms)
            {
                Rooms.Add(room);
            }
            UpravnikTable.DataContext = Rooms;
            OnPropertyChanged("Rooms");
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if (UpravnikTable.SelectedIndex == -1)
            {
                return;
            }
            if (!roomController.DeleteRoom(Rooms.ElementAt(UpravnikTable.SelectedIndex).Identificator))
            {
                MessageBox.Show("Element ne postoji u bazi podataka", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Rooms = new ObservableCollection<Room>();
            List<Room> rooms = roomController.GetAllRooms();
            foreach (Room room in rooms)
            {
                Rooms.Add(room);
            }
            UpravnikTable.DataContext = Rooms;
            OnPropertyChanged("Rooms");
        }


        private void AddAppointmentToPatient_Click(object sender, RoutedEventArgs e)
        {
            var s = new View.AddAppointmentToPatient();
            s.ShowDialog();
            AppointmentsForPatients = new ObservableCollection<Appointment>();
            List<Appointment> rooms = appointmentControllerForPatients.GetAllAppointments();
            foreach (Appointment room in rooms)
            {
                AppointmentsForPatients.Add(room);
            }
            PatientTable.DataContext = AppointmentsForPatients;
            OnPropertyChanged("AppointmentsForPatients");

        }

        private void EditPatientsAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (PatientTable.SelectedIndex == -1)
            {
                return;
            }
            OnPropertyChanged("AppointmentsForPatients");
        }
    

        private void DeletePatientsAppointment_Click(object sender, RoutedEventArgs e)
        {


        }
        private void Probaj_lekar_Click(object sender, RoutedEventArgs e)
        {
            var s =new View.AddAppointment();
            s.ShowDialog();
        }

        private void ispisi_appointmente_Click(object sender, RoutedEventArgs e)
        {
            var s = new View.ViewAppointments();
            s.ShowDialog();
        }

        private void Read_Button_Click(object sender, RoutedEventArgs e)
        {
            var s = new View.ReadAppointment();
            s.ShowDialog();

        }
    }
}
