using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;
using ZdravoCorp.View.ViewModel;

namespace ZdravoCorp.View.Manager.ViewModel
{
    public class EquipmentViewModel : ObservableObject
    {
        private ObservableCollection<EquipmentTableVO> equipmentTable;
        private EquipmentController controller;


        public RelayCommand AddEquipmentViewCommand { get; set; }

        public AddEquipmentViewModel AddEquipmentVM { get; set; }

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

        public EquipmentViewModel()
        {
            controller = new EquipmentController();

            AddEquipmentViewCommand = new RelayCommand(o =>
            {
                AddEquipmentVM = new AddEquipmentViewModel();
                CurrentView = AddEquipmentVM;
            });
            EquipmentTable = controller.GetAllEquipmentTableVO();
            updateControl();
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
        public void updateControl()
        {
            //EquipmentTable = controller.GetAllEquipmentTableVO();
        }
    }
}
