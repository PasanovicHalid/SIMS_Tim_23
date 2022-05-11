using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.View.Core;
using ZdravoCorp.View.Manager.Model.Equipment;

namespace ZdravoCorp.View.Manager.ViewModel.Equipment
{
    public class ViewEquipmentViewModel : ObservableObject
    {
        private EquipmentModel equipment;
        private EquipmentViewModel _parent;

        public EquipmentModel Equipment { get => equipment; set => equipment = value; }

        public RelayCommand ChangeViewCommand { get; set; }

        public RelayCommand MoveCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

        public string Equipment_Type
        {
            get => Equipment.Name;
            set
            {
                if (value != Equipment.Name)
                {
                    Equipment.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => Equipment.Description;
            set
            {
                if (value != Equipment.Description)
                {
                    Equipment.Description = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Disposable
        {
            get => Equipment.Disposable;
            set
            {
                if (value != Equipment.Disposable)
                {
                    Equipment.Disposable = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Count
        {
            get => Equipment.Count;
            set
            {
                if (value != Equipment.Count)
                {
                    Equipment.Count = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Designation_Code
        {
            get => Equipment.DesignationCode;
            set
            {
                if (value != Equipment.DesignationCode)
                {
                    Equipment.DesignationCode = value;
                    OnPropertyChanged();
                }
            }
        }


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
        public ViewEquipmentViewModel(EquipmentModel selected, EquipmentViewModel parent)
        {
            _parent = parent;
            Equipment = selected;
        }
    }
}
