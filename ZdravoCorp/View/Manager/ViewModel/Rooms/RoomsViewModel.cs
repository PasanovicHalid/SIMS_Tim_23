using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ZdravoCorp.View.Core;
using ZdravoCorp.View.Manager.View;
using ZdravoCorp.View.Manager.View.Rooms;

namespace ZdravoCorp.View.Manager.ViewModel.Rooms
{
    public class RoomsViewModel : ObservableObject, ViewModelInterface
    {
        public RoomController roomController;
        private Room selectedRoom;
        private int selectedIndex;

        public ObservableCollection<Room> RoomsCollection
        {
            get;
            set;
        }

        public RelayCommand ViewRoomCommand { get; set; }

        public RelayCommand AddRoomCommand { get; set; }

        public RelayCommand RenovationsCommand { get; set; }

        public UserControl CurrentView
        {
            get => ContentViewModel.Instance.CurrentView;
            set
            {
                if (value != ContentViewModel.Instance.CurrentView)
                {
                    ContentViewModel.Instance.WindowBrowser.AddWindow(value);
                    ContentViewModel.Instance.CurrentView = value;
                    OnPropertyChanged();
                }
            }
        }

        public Room SelectedRoom
        {
            get => selectedRoom;
            set
            {
                if (value != selectedRoom)
                {
                    selectedRoom = value;
                    OnPropertyChanged();
                }
            }

        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (value != selectedIndex)
                {
                    selectedIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public RoomsViewModel()
        {
            roomController = new RoomController();
            RoomsCollection = new ObservableCollection<Room>();

            ViewRoomCommand = new RelayCommand(o =>
            {
                CurrentView = new ViewRoom(new ViewRoomViewModel(SelectedRoom));
            }, checkIfTableRowSelected);

            AddRoomCommand = new RelayCommand(o =>
            {
                CurrentView = new AddRoom(new AddRoomViewModel());
            });

            RenovationsCommand = new RelayCommand(o =>
            {
                CurrentView = new RenovatingRooms(new RenovatingRoomsViewModel());
            });

            Update();
        }

        private bool checkIfTableRowSelected(object arg)
        {
            return SelectedIndex != -1;
        }

        public string GetTitle()
        {
            return "Rooms";
        }

        public void Update()
        {
            List<Room> rooms = roomController.GetAllRooms();
            RoomsCollection = new ObservableCollection<Room>(rooms);
        }
    }
}
