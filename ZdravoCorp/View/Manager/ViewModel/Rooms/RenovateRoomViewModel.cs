using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ZdravoCorp.View.Core;

namespace ZdravoCorp.View.Manager.ViewModel.Rooms
{
    public class RenovateRoomViewModel : ObservableObject, ViewModelInterface
    {
        private Room selectedRoom;
        private RoomController controller;
        private DateTime startDate;
        private DateTime endDate;

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

        public RelayCommand RenovateCommand { get; set; }

        public float Size
        {
            get { return selectedRoom.SurfaceArea; }
            set
            {
                if (value != selectedRoom.SurfaceArea)
                {
                    selectedRoom.SurfaceArea = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Floor
        {
            get { return selectedRoom.Floor; }
            set
            {
                if (value != selectedRoom.Floor)
                {
                    selectedRoom.Floor = value;
                    OnPropertyChanged();
                }
            }
        }

        public String Identifier
        {
            get { return selectedRoom.DesignationCode; }
            set
            {
                if (value != selectedRoom.DesignationCode)
                {
                    selectedRoom.DesignationCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value != startDate)
                {
                    startDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value != endDate)
                {
                    endDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public RenovateRoomViewModel(Room selected)
        {
            controller = new RoomController();
            selectedRoom = selected;

            RenovateCommand = new RelayCommand(o =>
            {
                if (!controller.RenovateRoom(selectedRoom.Identifier, StartDate, EndDate))
                {
                    MessageBox.Show("Nije uspesno izvrsen zadatak", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    CurrentView = new View.Rooms.Rooms(new RoomsViewModel());
                }
            });
        }


        public string GetTitle()
        {
            return "Renovate Room";
        }

        public void Update()
        {
            
        }
    }
}
