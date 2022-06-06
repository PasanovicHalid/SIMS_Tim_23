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
using Model;
using Controller;

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for MedicalReport.xaml
    /// </summary>
    public partial class MedicalReport : Window
    {
        Model.Patient currentPatient;
        AppointmentController ac = new AppointmentController();
        ReportController cc = new ReportController();
        MedicalRecordController mcc = new MedicalRecordController();
        PatientController pc = new PatientController();
        Model.Doctor currentDoctor;

        public MedicalReport(Model.Patient pomocnip, Model.Doctor doc)
        {
            InitializeComponent();

            currentPatient = new Model.Patient(pomocnip);
            currentDoctor = doc;
            List<Model.Appointment> lista = ac.GetAll();
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
    }
}
