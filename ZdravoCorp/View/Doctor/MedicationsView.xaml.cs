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

        Model.Doctor currentDoctor;

        public ObservableCollection<Model.Medication> MedicineCollection
        {
            get;
            set;
        }

        public MedicationsView(Model.Doctor temp)
        {
            InitializeComponent();
            medicineController = new MedicineController();
            MedicineCollection = new ObservableCollection<Model.Medication>(medicineController.GetAllMedicine());

            MedicineGrid.DataContext = MedicineCollection;
            this.currentDoctor = temp;
        }

        private void appointmentsButton_Click(object sender, RoutedEventArgs e)
        {
            Appointments appointments = new Appointments(currentDoctor);
            this.Close();
            appointments.Show();
        }

        private void requestsButton_Click(object sender, RoutedEventArgs e)
        {
            MedicationRequests medicationRequests = new MedicationRequests(currentDoctor);
            this.Close();
            medicationRequests.Show();
        }

        private void vacationRequestButton_Click(object sender, RoutedEventArgs e)
        {
            VacationRequest vacationRequest = new VacationRequest(currentDoctor);
            this.Close();
            vacationRequest.Show();
        }

        private void kartoniButton_Click(object sender, RoutedEventArgs e)
        {
            MedicalRecords meds = new MedicalRecords(currentDoctor);
            this.Close();
            meds.Show();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserWindow user = new UserWindow(currentDoctor);
            user.ShowDialog();
        }

        private void medsButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
