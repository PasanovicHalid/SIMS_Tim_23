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
            roomController.DeleteRoom(Rooms.ElementAt(UpravnikTable.SelectedIndex).Identificator);
            Rooms = new ObservableCollection<Room>();
            List<Room> rooms = roomController.GetAllRooms();
            foreach (Room room in rooms)
            {
                Rooms.Add(room);
            }
            UpravnikTable.DataContext = Rooms;
            OnPropertyChanged("Rooms");
        }
    }
}
