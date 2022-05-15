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

namespace ZdravoCorp.View.Manager.ViewModel.Medications
{
    public class MedicationsViewModel : ObservableObject, ViewModelInterface
    {

        private ObservableCollection<MedicationType> medicationTypes;
        private MedicineController controller;

        public RelayCommand AddCommand { get; set; }

        public RelayCommand RequestsCommand { get; set; }

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
