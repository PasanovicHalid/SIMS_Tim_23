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
namespace ZdravoCorp.View.Patient.MedicalRecord
{
    /// <summary>
    /// Interaction logic for Anamnesis.xaml
    /// </summary>
    public partial class Anamnesis : Window
    {
        private Model.Anamnesis anamnesis;
        private AnamnesisController anamnesisController = new AnamnesisController();
        private PatientController patientController = new PatientController();
        private DoctorController doctorController = new DoctorController();
        public Anamnesis(Model.Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            anamnesis = anamnesisController.FindAnamnesisByAppointmentId(appointment.Id);
            Patient.Content = patientController.ReadPatient(appointment.Patient.Id).Name;
            Doctor.Content = doctorController.ReadDoctor(appointment.Doctor.Id).nameSurname;
            Date.Content = appointment.startDate.Date.ToString();
            DoctorType.Content = doctorController.ReadDoctor(appointment.Doctor.Id).DoctorType.ToString();
            AppointmentType.Content = anamnesis.AppointmentType;
            Diagnosis.Content = anamnesis.Diagnosis;
            Presciption.Content = anamnesis.Prescription.ToString();
        }
    }
}
