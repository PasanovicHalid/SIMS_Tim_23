using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ZdravoCorp.View.Patient.ViewModel.Allergies
{
    public class AllergiesViewModel
    {
        public ObservableCollection<String> MedicationAllergies { get; set; }
        public ObservableCollection<String> OtherAllergies { get; set; }
        public ObservableCollection<String> Note { get; set; }


    }
}
