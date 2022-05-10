using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;
using ZdravoCorp.View.Manager.View;
using ZdravoCorp.View.ViewModel;

namespace ZdravoCorp.View.Manager.ViewModel
{
    public class EquipmentViewModel : ObservableObject, WindowInterface
    {
        private ObservableCollection<EquipmentTableVO> equipmentTable;
        private EquipmentController controller;
        private EquipmentTableVO selectedEquipment;
        private int selectedIndex;

        public RelayCommand AddEquipmentViewCommand { get; set; }

        public RelayCommand ViewEquipmentCommand { get; set; }

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

        public EquipmentViewModel()
        {
            SelectedIndex = -1;
            controller = new EquipmentController();

            updateViewModel();

            AddEquipmentViewCommand = new RelayCommand(o =>
            {
                CurrentView = new AddEquipment(new AddEquipmentViewModel());
            });

            ViewEquipmentCommand = new RelayCommand(o =>
            {
                if(SelectedIndex != -1)
                {
                    CurrentView = new ViewEquipment(new ViewEquipmentViewModel(SelectedEquipment, this));
                }
            });
        }

        public ObservableCollection<EquipmentTableVO> EquipmentTable 
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

        public EquipmentTableVO SelectedEquipment
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

        public string getTitle()
        {
            return "Equipment";
        }

        public void updateViewModel()
        {
            EquipmentTable = controller.GetAllEquipmentTableVO();
        }
    }
}
