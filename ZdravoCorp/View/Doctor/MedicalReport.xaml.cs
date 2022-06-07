using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Model;
using Controller;
using System.Globalization;
using System;

namespace ZdravoCorp.View.Doctor
{
    /// <summary>
    /// Interaction logic for MedicalReport.xaml
    /// </summary>
    public partial class MedicalReport : Window
    {
        Model.Patient currentPatient;
        Model.Doctor currentDoctor;
        AppointmentController appointmentController = new AppointmentController();
        ReportController reportController = new ReportController();
        MedicalRecordController medicalRecordController = new MedicalRecordController();
        MedicationController medicationController = new MedicationController();
        PatientController patientController = new PatientController();
        DoctorController doctorController = new DoctorController();
        RoomController roomController = new RoomController();

        public MedicalReport(Model.Patient tempPatient, Model.Doctor tempDoctor, int index)
        {
            InitializeComponent();

            currentPatient = new Model.Patient(tempPatient);
            currentDoctor = tempDoctor;
            List<Appointment> list = new List<Appointment>();
            foreach (Appointment app in appointmentController.GetAll())
            {
                if (app.Patient.Id == currentPatient.Id && app.doctor.Id == currentDoctor.Id)
                {
                    list.Add(app);
                }
            }
            AppointmentCB.ItemsSource = list;
            probaCB.ItemsSource = medicationController.GetAll();
            PatientsCB.ItemsSource = patientController.GetAll();
            PatientsCB.SelectedIndex = 1;
            DoctorsCB.ItemsSource = doctorController.GetAll();
            RoomsCB.ItemsSource = roomController.GetAll();
            PatientsCB.SelectedIndex = index;
        }

        private void medicationsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            string komentar = textBpx1.Text;
            Appointment appointment = (Appointment)AppointmentCB.SelectedItem;
            Report report = new Report(appointment, komentar, currentDoctor);
            reportController.Create(report);
            currentPatient.Record.MedicalReports.Add(report);
            medicalRecordController.Update(currentPatient.Record);
            patientController.Update(currentPatient);
            this.Close();
        }

        private void addAppointmentToDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Doctor tempDoctor = (Model.Doctor)DoctorsCB.SelectedItem;
            Model.Room tempRoom = (Model.Room)RoomsCB.SelectedItem;
            DateTime startDate = (DateTime)datePicker.SelectedDate;
            DateTime endDate = (DateTime)datePicker.SelectedDate;
            startDate.AddHours(int.Parse(startTimeHours.Text));
            startDate.AddMinutes(int.Parse(startTimeHours.Text));
            endDate.AddMinutes(startDate.Minute + int.Parse(endTimeMinutes.Text));
            endDate.AddHours(startDate.Hour + int.Parse(endTimeHours.Text));
            bool isEmergency = (bool)CheckBox1.IsChecked;
            appointmentController.Create(new Appointment(startDate, endDate, tempDoctor, tempRoom, currentPatient));
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

        private void medsButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void vacationRequestButton_Click(object sender, RoutedEventArgs e)
        {
            VacationRequest vacationRequest = new VacationRequest(currentDoctor);
            this.Close();
            vacationRequest.Show();
        }

        private void kartoniButton_Click(object sender, RoutedEventArgs e)
        {
            MedicalRecords medicalRecord = new MedicalRecords(currentDoctor);
            this.Close();
            medicalRecord.Show();
        }
    }
}
