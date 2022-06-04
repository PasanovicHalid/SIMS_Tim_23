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
using ZdravoCorp.View.Manager.View.Medications;

namespace ZdravoCorp.View.Manager.ViewModel.Medications
{
    public class RequestsMedicationViewModel : ObservableObject, ViewModelInterface
    {
        private ObservableCollection<NewMedicationRequest> medicationRequests;
        private NewMedicationRequestController controller;
        private NewMedicationRequest selectedRequest;

        public RelayCommand ViewCommand { get; set; }

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

        public ObservableCollection<NewMedicationRequest> MedicationRequests
        {
            get => medicationRequests;
            set
            {
                if (value != medicationRequests)
                {
                    medicationRequests = value;
                    OnPropertyChanged();
                }
            }
        }

        public NewMedicationRequest SelectedRequest
        {
            get => selectedRequest;
            set
            {
                if (value != selectedRequest)
                {
                    selectedRequest = value;
                    OnPropertyChanged();
                }
            }
        }

        public RequestsMedicationViewModel()
        {
            controller = new NewMedicationRequestController();
            MedicationRequests = new ObservableCollection<NewMedicationRequest>(controller.GetAll());

            ViewCommand = new RelayCommand(o =>
            {
                if(SelectedRequest.Status == Status.PENDING)
                {
                    CurrentView = new ViewPending(new ViewPendingViewModel(new NewMedicationRequest(SelectedRequest)));
                }
                else if(SelectedRequest.Status == Status.REJECTED) 
                {
                    CurrentView = new ViewRejected(new ViewRejectedViewModel(new NewMedicationRequest(SelectedRequest)));
                }
            }, CheckIfSelected);

        }

        private bool CheckIfSelected(object obj)
        {
            return SelectedRequest != null;
        }

        public string GetTitle()
        {
            return "Requests";
        }

        public void Update()
        {
            MedicationRequests = new ObservableCollection<NewMedicationRequest>(controller.GetAll());
        }
    }
}
