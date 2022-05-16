using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller;

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for MedicationsView.xaml
    /// </summary>
    public partial class MedicationsView : Window
    {
        private MedicineController medicineController;

        public ObservableCollection<Model.Medication> MedicineCollection
        {
            get;
            set;
        }

        public MedicationsView()
        {
            InitializeComponent();
            medicineController = new MedicineController();
            MedicineCollection = new ObservableCollection<Model.Medication>(medicineController.GetAllMedicine());

            MedicineGrid.DataContext = MedicineCollection;
        }
    }
}
