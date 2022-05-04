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
using ZdravoCorp.Controller;

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for MedicalRecords.xaml
    /// </summary>
    public partial class MedicalRecords : Window
    {
        private ZdravoCorp.Controller.CommentController commentsController;
        private MedicalRecordController medicalRecordController;
        private Model.Patient pomocnip;
        PatientController patientController;
        private Model.Doctor currentDoctor;
        private MedicineController medicineController;
        private PrescriptionController pc;

        public ObservableCollection<Model.Comments> comments
        {
            get;
            set;
        }

        public ObservableCollection<Model.Patient> PatientCollection
        {
            get;
            set;
        }

        public ObservableCollection<Model.Medication> MedicineCollection
        {
            get;
            set;
        }

        public ObservableCollection<Model.Prescription> PrescriptionCollection
        {
            get;
            set;
        }
        public MedicalRecords(Model.Doctor doc)
        {
            InitializeComponent();
            currentDoctor = doc;
            this.DataContext = this;
            commentsController = new ZdravoCorp.Controller.CommentController();
            comments = new ObservableCollection<Model.Comments>();
            patientController = new PatientController();
            PatientCollection = new ObservableCollection<Model.Patient>(patientController.GetAllPatients());
            PatientsCB.ItemsSource = PatientCollection;

            medicineController = new MedicineController();
            MedicineCollection = new ObservableCollection<Model.Medication>(medicineController.GetAllMedicine());

            pc = new PrescriptionController();

            //PrescriptionCollection = new ObservableCollection<Model.Prescription>(pc.GetAllPrescriptions());


            


        }

        private void PatientsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pomocnip = (Model.Patient)PatientsCB.SelectedItem;

            medicalRecordController = new MedicalRecordController();

            List<Model.MedicalRecord> med = medicalRecordController.GetAllRecords();

            PrescriptionCollection = new ObservableCollection<Model.Prescription>();

            foreach (Model.MedicalRecord pom in med)
            {
                if (pomocnip.Record.Id == pom.Id)
                {
                    textBox1.Text = pom.Id.ToString();
                    textBox2.Text = pom.Weight.ToString();

                    textBox3.Text = pom.Height.ToString();

                    textBox4.Text = pom.BloodType.ToString();

                    List<Model.Comments> commentsl = pom.Comments;

                    CommentsGrid.DataContext = commentsl;

                }
            }

            if(pomocnip.Prescription.Count > 0)
            {
                foreach(Model.Prescription p in pomocnip.Prescription)
                {
                    PrescriptionCollection.Add(p);
                }

                NoviGrid.DataContext = PrescriptionCollection;

            }

        }

        private void commentButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PatientsCB.Text))
            {
                MessageBox.Show("No Patient is Selected");
            }
            else
            {
                AddComment add = new AddComment(pomocnip, currentDoctor);
                this.Close();
                add.Show();

                //List<MedicalRecord> med = medicalRecordController.GetAllMedicalRecords();
                //foreach (MedicalRecord pom in med)
                //{
                //    if (pomocnip.MedicalRecord.Id == pom.Id)
                //    {
                //        textBox1.Text = pom.Id;
                //        textBox2.Text = pom.Weight.ToString();
                //
                //        textBox3.Text = pom.Height.ToString();
                //
                //        textBox4.Text = pom.BloodType.ToString();
                //
                //        List<Comments> commentsl = pom.Comments;
                //
                //        CommentsGrid.DataContext = commentsl;
                //
                //    }
                //}
            }
        }

        private void dodajTerapiju_Click(object sender, RoutedEventArgs e)
        {
            AddTherapy at = new AddTherapy();
            at.Show();
        }
    }
}
