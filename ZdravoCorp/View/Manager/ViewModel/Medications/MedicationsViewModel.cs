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
    public class MedicationsViewModel : ObservableObject, ViewModelInterface
    {

        private ObservableCollection<MedicationType> medicationTypes;
        private MedicineController controller;
        private MedicationType selectedType;

        public RelayCommand AddCommand { get; set; }

        public RelayCommand ViewCommand { get; set; }

        public RelayCommand RequestsCommand { get; set; }

        public MedicationType SelectedType
        {
            get => selectedType;
            set
            {
                if (value != selectedType)
                {
                    selectedType = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public ObservableCollection<MedicationType> MedicationTypes
        {
            get => medicationTypes;
            set
            {
                if (value != medicationTypes)
                {
                    medicationTypes = value;
                    OnPropertyChanged();
                }
            }
        }

        public MedicationsViewModel()
        {
            controller = new MedicineController();
            MedicationTypes = new ObservableCollection<MedicationType>(controller.GetAllMedicationType());

            ViewCommand = new RelayCommand(o =>
            {
                CurrentView = new ViewMedicine(new ViewMedicineViewModel(new MedicationType(SelectedType)));
            }, CheckIfSelected);

            AddCommand = new RelayCommand(o =>
            {
                CurrentView = new AddMedication(new AddMedicationViewModel());
            });

            RequestsCommand = new RelayCommand(o =>
            {
                CurrentView = new RequestsMedication(new RequestsMedicationViewModel());
            });
        }

        private bool CheckIfSelected(object obj)
        {
            return SelectedType != null;
        }

        public string GetTitle()
        {
            return "Medication Types";
        }

        public void Update()
        {

        }
    }
}
