using Controller;
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
    public class RenovatingRoomsViewModel : ObservableObject, ViewModelInterface
    {
        private ObservableCollection<RenovationActionModel> actionTable;
        private ActionController controller;
        private RenovationActionModel selectedAction;
       

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

        public RenovationActionModel SelectedAction
        {
            get { return selectedAction; }
            set
            {
                if (value != selectedAction)
                {
                    selectedAction = value;
                    OnPropertyChanged();
                }
            }
        }


        public ObservableCollection<RenovationActionModel> ActionTable { get => actionTable; set => actionTable = value; }

        public RelayCommand ViewCommand { get; set; }

        public RenovatingRoomsViewModel()
        {
            controller = new ActionController();
            Update();

            ViewCommand = new RelayCommand(o =>
            {
                if (SelectedAction.Renovation)
                {
                    CurrentView = new ViewRenovationTrue(new ViewRenovationTrueViewModel(selectedAction));
                }
                else
                {
                    CurrentView = new ViewRenovationFalse(new ViewRenovationFalseViewModel(selectedAction));
                }
            }, checkIfReady);
        }

        private bool checkIfReady(object arg)
        {
            return SelectedAction != null;
        }

        public string GetTitle()
        {
            return "Renovations";
        }

        public void Update()
        {
            ActionTable = controller.GetAllRenovationActions();
        }
    }
}
