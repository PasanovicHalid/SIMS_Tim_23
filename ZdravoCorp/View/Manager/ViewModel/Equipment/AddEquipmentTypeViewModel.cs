using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZdravoCorp.View.Core;
using ZdravoCorp.View.Manager.Model.Equipment;
using ZdravoCorp.View.Manager.View;
using ZdravoCorp.View.Manager.View.Equipment;

namespace ZdravoCorp.View.Manager.ViewModel.Equipment
{
    public class AddEquipmentTypeViewModel : ObservableObject, WindowInterface
    {
        private string _name;
        private string _description;
        private bool _disposable;
        private EquipmentController equipmentController;
        private AddEquipmentViewModel _parentViewModel;

        public RelayCommand AddViewCommand { get; set; }

        public AddEquipmentViewModel ParentViewModel { get => _parentViewModel; set => _parentViewModel = value; }

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

        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Disposable
        {
            get => _disposable;
            set
            {
                if (value != _disposable)
                {
                    _disposable = value;
                    OnPropertyChanged();
                }
            }
        }
        public AddEquipmentTypeViewModel(AddEquipmentViewModel parent)
        {
            equipmentController = new EquipmentController();
            ParentViewModel = parent;

            AddViewCommand = new RelayCommand(o =>
            {
                if (!equipmentController.CreateEquipmentType(new EquipmentTypeModel(Name, Description, Disposable)))
                {
                    MessageBox.Show("Nije uspesno dodat element", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    parent.UpdateViewModel();
                    CurrentView = new AddEquipment(parent);
                }
            });
        }

        public string getTitle()
        {
            return "Add Equipment Type";
        }
    }
}
