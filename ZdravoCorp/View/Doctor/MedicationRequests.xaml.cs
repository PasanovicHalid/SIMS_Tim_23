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
    /// Interaction logic for MedicationRequests.xaml
    /// </summary>
    public partial class MedicationRequests : Window
    {
        NewMedicationRequestController newMedicationRequestController = new NewMedicationRequestController();
        public ObservableCollection<Model.NewMedicationRequest> requests
        {
            get;
            set;
        }
        public MedicationRequests()
        {
            InitializeComponent();
            this.DataContext = this;
            NewMedicationRequestController newMedicationRequestController = new NewMedicationRequestController();
            requests = new ObservableCollection<Model.NewMedicationRequest>();
            List<Model.NewMedicationRequest> listNewMedicationRequests = newMedicationRequestController.GetAllNewMedicationRequests();
            foreach(Model.NewMedicationRequest request in listNewMedicationRequests)
            {
                requests.Add(request);
            }
            MedicineGrid.DataContext = requests;
            rejectButton.IsEnabled = false;
        }

        private void textBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBlock.Text == "")
            {
                rejectButton.IsEnabled = false;
            }
            else
            {
                rejectButton.IsEnabled = true;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {
            String comment = textBlock.Text;
            Model.NewMedicationRequest newMedicationRequest = (Model.NewMedicationRequest)MedicineGrid.SelectedItem;
            newMedicationRequestController.RejectNewMedicationRequest(newMedicationRequest, comment);
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            Model.NewMedicationRequest newMedicationRequest = (Model.NewMedicationRequest)MedicineGrid.SelectedItem;
            if(newMedicationRequest.Status == Model.Status.REJECTED)
            {
                MessageBox.Show("This Medication is REJECTED!");
                return;
            }
            newMedicationRequestController.AcceptNewMedicationRequest(newMedicationRequest);
            requests = new ObservableCollection<Model.NewMedicationRequest>();
            List<Model.NewMedicationRequest> listNewMedicationRequests = newMedicationRequestController.GetAllNewMedicationRequests();
            foreach (Model.NewMedicationRequest request in listNewMedicationRequests)
            {
                requests.Add(request);
            }
            MedicineGrid.DataContext = requests;
        }
    }
}
