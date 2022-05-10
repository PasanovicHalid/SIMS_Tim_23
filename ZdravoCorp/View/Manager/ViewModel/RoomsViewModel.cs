using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;
using ZdravoCorp.View.Manager.View;

namespace ZdravoCorp.View.Manager.ViewModel
{
    public class RoomsViewModel : ObservableObject, WindowInterface
    {
        public RoomController roomController;

        public ObservableCollection<Room> RoomsCollection
        {
            get;
            set;
        }

        public RelayCommand AddViewCommand { get; set; }

        public WindowInterface CurrentView
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

        public RoomsViewModel()
        {
            roomController = new RoomController();
            RoomsCollection = new ObservableCollection<Room>();

            AddViewCommand = new RelayCommand(o =>
            {
                CurrentView = new ViewRoom();
            });

            UpdateTable();
        }

        public string getTitle()
        {
            return "Rooms";
        }

        private void UpdateTable()
        {
            RoomsCollection = new ObservableCollection<Room>();
            List<Room> rooms = roomController.GetAllRooms();
            foreach (Room room in rooms)
            {
                RoomsCollection.Add(room);
            }
        }
    }
}
