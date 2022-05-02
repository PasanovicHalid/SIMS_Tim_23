using Controller;
using Model;
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

namespace ZdravoCorp.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        public RoomController roomController;

        public ObservableCollection<Room> RoomsCollection
        {
            get;
            set;
        }

        public Rooms()
        {
            InitializeComponent();
            roomController = new RoomController();
            RoomsCollection = new ObservableCollection<Room>();
            UpdateTable();
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoom addRoom = new AddRoom();
            addRoom.ShowDialog(); RoomsCollection = new ObservableCollection<Room>();
            UpdateTable();
        }

        private void ChangeRoom_Click(object sender, RoutedEventArgs e)
        {
            if (RoomTable.SelectedIndex == -1)
            {
                return;
            }

            ChangeRoom change = new ChangeRoom(RoomsCollection.ElementAt(RoomTable.SelectedIndex));
            change.ShowDialog();
            UpdateTable();
        }

        private void UpdateTable()
        {
            RoomsCollection = new ObservableCollection<Room>();
            List<Room> rooms = roomController.GetAllRooms();
            foreach (Room room in rooms)
            {
                RoomsCollection.Add(room);
            }
            RoomTable.DataContext = RoomsCollection;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (RoomTable.SelectedIndex == -1)
            {
                return;
            }
            if (!roomController.DeleteRoom(RoomsCollection.ElementAt(RoomTable.SelectedIndex).Identifier))
            {
                MessageBox.Show("Element ne postoji u bazi podataka", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateTable();
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

        private void RenovateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (RoomTable.SelectedIndex == -1)
            {
                return;
            }
            RenovateRoom window = new RenovateRoom(RoomsCollection.ElementAt(RoomTable.SelectedIndex));
            window.ShowDialog();
            UpdateTable();
        }
    }
}
