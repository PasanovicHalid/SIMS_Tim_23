using Controller;
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

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for AddTherapy.xaml
    /// </summary>
    public partial class AddTherapy : Window
    {

        private MedicineController medicineController;

        public ObservableCollection<Model.Medication> MedicineCollection
        {
            get;
            set;
        }

        public AddTherapy()
        {
            InitializeComponent();

            medicineController = new MedicineController();
            MedicineCollection = new ObservableCollection<Model.Medication>(medicineController.GetAllMedicine());

            MedicineGrid.DataContext = MedicineCollection;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
