using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZdravoCorp.View.Core;
using ZdravoCorp.View.ViewModel;

namespace ZdravoCorp.View.Manager.ViewModel
{
    public class AddEquipmentViewModel : ObservableObject
    {
        private ObservableCollection<EquipmentTypeVO> equipmentList;
        private ObservableCollection<RoomVO> roomsList;
        private EquipmentController equipmentController;
        private RoomController roomController;
        private int count;
        private int selectedEquipment = -1;
        private int selectedRoom = -1;

        public RelayCommand AddViewCommand { get; set; }


        public object CurrentView
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
                    CurrentView = new EquipmentViewModel();
                }
            });

            UpdateTable();
        }

        public ObservableCollection<EquipmentTypeVO> EquipmentList
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

        public ObservableCollection<RoomVO> RoomsList
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

        private void UpdateTable()
        {
            EquipmentList = equipmentController.GetAllEquipmentType();
            RoomsList = roomController.GetAllRoomsVO();
        }
    }
}
