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
using Controller;

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for AddTherapy.xaml
    /// </summary>
    public partial class AddTherapy : Window
    {

        private MedicationController medicineController;
        private PatientController patientController;

        private Model.Patient tempPatient;

        public ObservableCollection<Model.Medication> MedicineCollection
        {
            get;
            set;
        }

        public AddTherapy(Model.Patient temp)
        {
            InitializeComponent();

            medicineController = new MedicationController();
            MedicineCollection = new ObservableCollection<Model.Medication>(medicineController.GetAll());

            MedicineGrid.DataContext = MedicineCollection;
            tempPatient = temp;
        }

        private void MedicineGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            textBox1.Text = ((Model.Medication)MedicineGrid.SelectedItem).Id.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
