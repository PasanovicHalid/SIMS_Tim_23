using Service;
using System;
using System.Collections.Generic;
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
using ZdravoCorp.View.Manager;
using ZdravoCorp.View.Patient;

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

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            Manager window = new Manager(autoEvent);
            anotherWindow = true;
            this.Close();
            window.ShowDialog();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            pb.Tag = (!string.IsNullOrEmpty(pb.Password)).ToString();
        }

<<<<<<< HEAD
        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!anotherWindow)
            {
                autoEvent.Set();
            }
=======
        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            Patient window = new Patient();
            this.Close();
            window.ShowDialog();

>>>>>>> patient-add-appointment
        }
    }
}
