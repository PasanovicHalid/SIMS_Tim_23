using Controller;
using Model;
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

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for AddComment.xaml
    /// </summary>
    public partial class AddComment : Window
    {
        Model.Patient currentPatient;
        AppointmentController ac = new AppointmentController();
        Controller.ReportController cc = new Controller.ReportController();
        MedicalRecordController mcc = new MedicalRecordController();
        PatientController pc = new PatientController();
        Model.Doctor currentDoctor;

        public AddComment(Model.Patient pomocnip, Model.Doctor doc)
        {
            InitializeComponent();

            currentPatient = new Model.Patient(pomocnip);
            currentDoctor = doc;
            List<Model.Appointment> lista = ac.GetAllAppointments();
            List<Model.Appointment> pomocna = new List<Model.Appointment>();
            foreach (Appointment app in lista)
            {
                if (app.Patient.Id == currentPatient.Id && app.doctor.Id == currentDoctor.Id)
                {
                    pomocna.Add(app);
                }
            }
            AppointmentCB.ItemsSource = pomocna;

        }

        private void odustaniButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            string komentar = textBpx1.Text;
            Appointment apo = (Appointment)AppointmentCB.SelectedItem;
            Report c = new Report(apo, komentar, currentDoctor);
            cc.CreateComment(c);
            currentPatient.Record.MedicalReports.Add(c);
            mcc.UpdateMedicalRecord(currentPatient.Record);
            pc.UpdatePatient(currentPatient);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddAppointmentToDoctor addAppointmentToDoctorWindow = new AddAppointmentToDoctor(currentPatient, currentDoctor);
            addAppointmentToDoctorWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddTherapy addTherapy = new AddTherapy(currentPatient);
            addTherapy.ShowDialog();
        }
    }
}
