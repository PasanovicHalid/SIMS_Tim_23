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
using ZdravoCorp.View.Manager.Model.Rooms;
using ZdravoCorp.View.Manager.View.Rooms;

namespace ZdravoCorp.View.Manager.ViewModel.Rooms
{
    public class ViewRoomViewModel : ObservableObject, ViewModelInterface
    {
        private RoomController roomController;
        private Room selectedRoom;
        private RoomTypeModel selectedRoomType;
        private ObservableCollection<RoomTypeModel> types;
        private ObservableCollection<Equipment> equipments;
        private ObservableCollection<Appointment> appointments;
        private ObservableCollection<Medication> medications;
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
            get { return selectedRoom; }
            set
            {
                if (value != selectedRoom)
                {
                    selectedRoom = value;
                    OnPropertyChanged();
                }
            }
        }

        public float Size
        {
            get { return SelectedRoom.SurfaceArea; }
            set
            {
                if (value != SelectedRoom.SurfaceArea)
                {
                    SelectedRoom.SurfaceArea = value;
                    OnPropertyChanged();
                }
            }
        }

        public String Identifier
        {
            get { return SelectedRoom.DesignationCode; }
            set
            {
                if (value != SelectedRoom.DesignationCode)
                {
                    SelectedRoom.DesignationCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public RoomTypeModel Type
        {
            get { return selectedRoomType; }
            set
            {
                if (value != selectedRoomType)
                {
                    selectedRoomType = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<RoomTypeModel> Types
        {
            get { return types; }
            set
            {
                if (value != types)
                {
                    types = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<Equipment> Equipments
        {
            get { return equipments; }
            set
            {
                if (value != equipments)
                {
                    equipments = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<Appointment> Appointments
        {
            get { return appointments; }
            set
            {
                if (value != appointments)
                {
                    appointments = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Medication> Medications
        {
            get { return medications; }
            set
            {
                if (value != medications)
                {
                    medications = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand RenovateCommand { get; set; }

        public ViewRoomViewModel(Room selectedRoom)
        {
            SelectedRoom = new Room(selectedRoom);
            roomController = new RoomController();

            Equipments = new ObservableCollection<Equipment>(SelectedRoom.Equipment);
            Appointments = new ObservableCollection<Appointment>(SelectedRoom.Appointment);
            Medications = new ObservableCollection<Medication>(SelectedRoom.Medication);

            Types = roomController.GetAllRoomTypeView();
            foreach(RoomTypeModel type in Types)
            {
                if (type.Name.Equals(SelectedRoom.RoomTypeString))
                {
                    Type = type;
                }
            }

            RenovateCommand = new RelayCommand(o =>
            {
                CurrentView = new RenovateRoom(new RenovateRoomViewModel(selectedRoom));
            });

        }

        public string GetTitle()
        {
            return "Room";
        }

        public void Update()
        {
            
        }
    }
}
