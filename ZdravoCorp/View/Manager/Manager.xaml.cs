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
using System.Windows.Shapes;
using ZdravoCorp.View.Manager.ViewModel;

namespace ZdravoCorp.View.Manager
{
    /// <summary>
    /// Interaction logic for MainWindowManager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private AutoResetEvent autoEvent;
        private bool changed;
        private string currentLanguage;

        public string CurrentLanguage
        {
            get { return currentLanguage; }
            set
            {
                currentLanguage = value;
            }
        }
        public Manager(AutoResetEvent autoEvent)
        {
            InitializeComponent();
            this.CurrentLanguage = "en";
            this.DataContext = ContentViewModel.Instance;
            this.autoEvent = autoEvent;
            changed = false;
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

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CloseManager(object sender, System.ComponentModel.CancelEventArgs e)
        {
            autoEvent.Set();
        }

        private void Employess_Click(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            if (CurrentLanguage.Equals("en"))
            {
                CurrentLanguage = "sr";
            }
            else
            {
                CurrentLanguage = "en";
            }
            app.ChangeLanguage(CurrentLanguage);
        }
    }
}
