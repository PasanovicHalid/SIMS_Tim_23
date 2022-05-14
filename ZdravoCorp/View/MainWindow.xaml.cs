using Controller;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using ZdravoCorp.Service;
using ZdravoCorp.View.Doctor;
using ZdravoCorp.View.Manager;
using ZdravoCorp.View.Patient;
using ZdravoCorp.View.Secretary;

namespace ZdravoCorp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TimerService timerService;
        private AutoResetEvent autoEvent;
        private bool anotherWindow = false;

        public ObservableCollection<Model.Doctor> DoctorCollection
        {
            get;
            set;
        }
        public MainWindow()
        {
            InitializeComponent();
            autoEvent = new AutoResetEvent(false);
            timerService = new TimerService(autoEvent);
            Thread timer = new Thread(new ThreadStart(timerService.initiate));
            timer.Start();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Drag_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            pb.Tag = (!string.IsNullOrEmpty(pb.Password)).ToString();
        }


        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!anotherWindow)
            {
                autoEvent.Set();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = User.Text;
            string password = PassBox.Password;

            if(LoginService.Instance.Login(username, password))
            {
                if (LoginService.Instance.IsPatient(username))
                {
                    Patient window = new Patient();
                    this.Close();
                    window.ShowDialog();
                }

                if (LoginService.Instance.IsManager(username))
                {
                    Manager window = new Manager(autoEvent);
                    anotherWindow = true;
                    this.Close();
                    window.ShowDialog();
                }

                if (LoginService.Instance.IsManager(username))
                {
                    Manager window = new Manager(autoEvent);
                    anotherWindow = true;
                    this.Close();
                    window.ShowDialog();
                }
                if (LoginService.Instance.IsDoctor(username))
                {
                    DoctorController doctorController = new DoctorController();
                    DoctorCollection = new ObservableCollection<Model.Doctor>();
                    List<Model.Doctor> doctorList = doctorController.GetAllDoctors();
                    foreach (Model.Doctor d in doctorList)
                    {
                        if (d.Username.Equals(username))
                        {
                            if (d.Password.Equals(password))
                            {
                                Appointments appointmentWindow = new Appointments(d);
                                this.Close();
                                appointmentWindow.ShowDialog();
                                return;
                            }
                        }
                    }
                    MessageBox.Show("Ne postoji ni jedan doktor");
                }
            }

        }
    }   
}
