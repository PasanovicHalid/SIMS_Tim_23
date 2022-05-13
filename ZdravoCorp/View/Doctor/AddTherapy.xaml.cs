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

        private MedicineController medicineController;
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

            medicineController = new MedicineController();
            MedicineCollection = new ObservableCollection<Model.Medication>(medicineController.GetAllMedicine());

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
            patientController = new PatientController();
            Controller.PrescriptionController prescriptionController = new Controller.PrescriptionController();
            int newId = prescriptionController.CreatePrescription(new Model.Prescription(((Model.Medication)MedicineGrid.SelectedItem).Id,Int32.Parse(textBox2.Text),Int32.Parse(textBox3.Text),textBlock.Text));
            Model.Medication tempMedication = (Model.Medication)MedicineGrid.SelectedItem;
            if((Int32.Parse(textBox2.Text)) * (Int32.Parse(textBox3.Text)) > tempMedication.Count)
            {
                MessageBox.Show("U magacinu ne postoje tolike kolicine leka!");
                this.Close();
            }
            patientController.AddPrescription(tempPatient, prescriptionController.ReadPrescription(newId));
            tempMedication.Count = tempMedication.Count - (Int32.Parse(textBox2.Text)) * (Int32.Parse(textBox3.Text));
            medicineController.UpdateMedicine(tempMedication);
            this.Close();
        }
    }
}
