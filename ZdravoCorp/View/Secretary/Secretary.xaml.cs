using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using Model;
using Controller;

namespace ZdravoCorp.View.Secretary
{
    /// <summary>
    /// Interaction logic for Secretary.xaml
    /// </summary>
    public partial class Secretary : Window
    {
        public ObservableCollection<Model.Patient> PatientCollection { get; set; }
        public PatientController patientController;


        public Secretary()
        {
            InitializeComponent();
            PatientCollection = new ObservableCollection<Model.Patient>();
            patientController = new PatientController();            
            UpdateTable();
        }

        private void UpdateTable()
        {
            PatientCollection = new ObservableCollection<Model.Patient>();
            List<Model.Patient> patients = patientController.GetAllPatients();
            foreach (Model.Patient pat in patients)
            {
                PatientCollection.Add(pat);
            }
            PatientTable.DataContext = PatientCollection;
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            AddPatient window = new AddPatient();
            window.ShowDialog();
            UpdateTable();
        }

        private void DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            if (PatientTable.SelectedIndex == -1)
            {
                return;
            }
            if (!patientController.DeletePatient(PatientCollection.ElementAt(PatientTable.SelectedIndex).Id))
            {
                MessageBox.Show("Element ne postoji u bazi podataka", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateTable();
        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            if(PatientTable.SelectedIndex == -1)
            {
                return;
            }
            ChangePatient change = new ChangePatient(PatientCollection.ElementAt(PatientTable.SelectedIndex));
            change.ShowDialog();
            UpdateTable();
        }
    }
}
