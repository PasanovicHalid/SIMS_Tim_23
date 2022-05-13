using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ZdravoCorp.View.Core;
using ZdravoCorp.View.Manager.Model.Equipments;
using ZdravoCorp.View.Manager.View;
using ZdravoCorp.View.Manager.View.Equipments;

namespace ZdravoCorp.View.Manager.ViewModel.Equipments
{
    public class EquipmentViewModel : ObservableObject, ViewModelInterface
    {
        private ObservableCollection<EquipmentModel> equipmentTable;
        private EquipmentController controller;
        private EquipmentModel selectedEquipment;
        private int selectedIndex;

        public RelayCommand AddEquipmentViewCommand { get; set; }

        public RelayCommand ViewEquipmentTypeCommand { get; set; }

        public RelayCommand ViewEquipmentCommand { get; set; }

        public RelayCommand ChangePositionCommand { get; set; }

        public RelayCommand ReservedCommand { get; set; }

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

        public EquipmentViewModel()
        {
            SelectedIndex = -1;
            controller = new EquipmentController();

            Update();

            AddEquipmentViewCommand = new RelayCommand(o =>
            {
                CurrentView = new AddEquipment(new AddEquipmentViewModel());
            });

            ViewEquipmentCommand = new RelayCommand(o =>
            {
                CurrentView = new ViewEquipment(new ViewEquipmentViewModel(SelectedEquipment, this));
            }, checkIfTableRowSelected);

            ViewEquipmentTypeCommand = new RelayCommand(o =>
            {
                CurrentView = new ViewEquipment(new ViewEquipmentViewModel(SelectedEquipment, this));
            }, checkIfTableRowSelected);

            ChangePositionCommand = new RelayCommand(o =>
            {
                CurrentView = new ChangeEquipmentPosition(new ChangeEquipmentPositionViewModel(SelectedEquipment));
            }, checkIfTableRowSelected);

            ReservedCommand = new RelayCommand(o =>
            {
                CurrentView = new ReservedEquipment(new ReservedEquipmentViewModel());
            });
        }

        private bool checkIfTableRowSelected(object arg)
        {
            return SelectedIndex != -1;
        }

        public ObservableCollection<EquipmentModel> EquipmentTable
        {
            get => equipmentTable;
            set
            {
                if (value != equipmentTable)
                {
                    equipmentTable = value;
                    OnPropertyChanged();
                }
            }
        }

        public EquipmentModel SelectedEquipment
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

        public string GetTitle()
        {
            return "Equipment";
        }

        public void Update()
        {
            EquipmentTable = controller.GetAllEquipmentTableVO();
        }
    }
}
