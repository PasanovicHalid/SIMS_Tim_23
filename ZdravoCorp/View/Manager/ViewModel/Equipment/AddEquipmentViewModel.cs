using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZdravoCorp.View.Core;
using ZdravoCorp.View.Manager.Model.Equipment;
using ZdravoCorp.View.Manager.Model.Room;
using ZdravoCorp.View.Manager.View;
using ZdravoCorp.View.Manager.View.Equipment;

namespace ZdravoCorp.View.Manager.ViewModel.Equipment
{
    public class AddEquipmentViewModel : ObservableObject, WindowInterface
    {
        private ObservableCollection<EquipmentTypeModel> equipmentList;
        private ObservableCollection<RoomModel> roomsList;
        private EquipmentController equipmentController;
        private RoomController roomController;
        private int count;
        private int selectedEquipment = -1;
        private int selectedRoom = -1;

        public RelayCommand AddViewCommand { get; set; }

        public RelayCommand AddEquipmentTypeViewCommand { get; set; }


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

        public int Count
        {
            get => count;
            set
            {
                if (value != count)
                {
                    count = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SelectedEquipment
        {
            get => selectedEquipment;
            set
            {
                if (value != selectedEquipment)
                {
                    selectedEquipment = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SelectedRoom
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

        public AddEquipmentViewModel()
        {
            equipmentController = new EquipmentController();
            roomController = new RoomController();

            AddViewCommand = new RelayCommand(o =>
            {
                if (!equipmentController.CreateEquipment(equipmentList.ElementAt(SelectedEquipment), count, roomsList.ElementAt(SelectedRoom)))
                {
                    MessageBox.Show("Nije uspesno dodat element", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    CurrentView = new View.Equipment.Equipment(new EquipmentViewModel());
                }
            });

            AddEquipmentTypeViewCommand = new RelayCommand(o =>
            {
                CurrentView = new AddEquipmentType(new AddEquipmentTypeViewModel(this));
            });

            UpdateViewModel();
        }

        public ObservableCollection<EquipmentTypeModel> EquipmentList
        {
            get => equipmentList;
            set
            {
                if (value != equipmentList)
                {
                    equipmentList = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<RoomModel> RoomsList
        {
            get => roomsList;
            set
            {
                if (value != roomsList)
                {
                    roomsList = value;
                    OnPropertyChanged();
                }
            }
        }

        public void UpdateViewModel()
        {
            EquipmentList = equipmentController.GetAllEquipmentType();
            RoomsList = roomController.GetAllRoomsVO();
        }

        public string getTitle()
        {
            return "Add Equipment";
        }
    }
}
