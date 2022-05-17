﻿using System;
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
using System.ComponentModel;
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
        public ObservableCollection<Model.Appointment> AppointmentsCollection { get; set; }
        public PatientController patientController;
        public AppointmentController appointmentController;
        Model.Patient patient;

        private Model.Secretary secretary;

        public ObservableCollection<Model.Guest> GuestCollection { get; set; }
        public GuestController guestController;
        

        public Secretary(Model.Secretary logedSecretary)
        {
            InitializeComponent();
            PatientCollection = new ObservableCollection<Model.Patient>();
            patientController = new PatientController();

            secretary = logedSecretary;

            GuestCollection = new ObservableCollection<Model.Guest>();
            guestController = new GuestController();

            UpdateTable();
            UpdateGuestTable();
            UpdateAppointmentTable();
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

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            if (PatientTable.SelectedIndex == -1)
            {
                return;
            }
            AddRecord add = new AddRecord(PatientCollection.ElementAt(PatientTable.SelectedIndex));
            add.ShowDialog();
            UpdateTable();
        }

        private void EditRecord_Click(object sender, RoutedEventArgs e)
        {
            if (PatientTable.SelectedIndex == -1)
            {
                return;
            }
            
            
            MedicalRecordController mr = new MedicalRecordController();
            MedicalRecord record = mr.ReadMedicalRecord(PatientCollection.ElementAt(PatientTable.SelectedIndex).Record.Id);
            ChangeRecord change = new ChangeRecord(record);
            change.ShowDialog();
            UpdateTable();
            
            
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (PatientTable.SelectedIndex == -1)
            {
                return;
            }
            MedicalRecordController mr = new MedicalRecordController();
            PatientController pc = new PatientController();
            Model.Patient pat = pc.ReadPatient(PatientCollection.ElementAt(PatientTable.SelectedIndex).Id);

            mr.DeleteMedicalRecord(pat.Record.Id);
            pat.Record.Id = -1;
            UpdateTable();
        }

        private void UpdateGuestTable()
        {
            GuestCollection = new ObservableCollection<Model.Guest>();
            List<Model.Guest> guests = guestController.GetAllGuests();
            foreach (Model.Guest guest in guests)
            {
                GuestCollection.Add(guest);
            }
            GuestTable.DataContext = GuestCollection;
        }

        private void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            AddGuest window = new AddGuest();
            window.ShowDialog();
            UpdateGuestTable();
        }

        private void DeleteGuest_Click(object sender, RoutedEventArgs e)
        {
            if (GuestTable.SelectedIndex == -1)
            {
                return;
            }
            if (!guestController.DeleteGuest(GuestCollection.ElementAt(GuestTable.SelectedIndex).Id))
            {
                MessageBox.Show("Element ne postoji u bazi podataka", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UpdateGuestTable();
        }

        private void UpdateAppointmentTable()
        {
            DoctorController doctorController = new DoctorController();
            AppointmentController appointmentController = new AppointmentController();
            RoomController roomController = new RoomController();
            patientController = new PatientController();

            List<Appointment> appointments = appointmentController.GetAllAppointments();
            
            AppointmentsCollection = new ObservableCollection<Appointment>(appointments);
            foreach (Appointment a in appointments)
            {
                a.doctor = doctorController.ReadDoctor(a.doctor.Id);
                a.room = roomController.ReadRoom(a.room.Identifier);
                a.Patient = patientController.ReadPatient(a.Patient.Id);
            }
            AppointmentTable.DataContext = AppointmentsCollection;
        }


        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment window = new AddAppointment();
            window.ShowDialog();
            UpdateAppointmentTable();
        }

        private void DeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (AppointmentTable.SelectedIndex == -1)
            {
                return;
            }
            Appointment appointment = (Appointment) AppointmentTable.SelectedItem;
            appointmentController = new AppointmentController();
            if (!appointmentController.DeleteAppointment(appointment.Id))
            {
                MessageBox.Show("Element ne postoji u bazi podataka", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DoctorController doctorController = new DoctorController();
            Model.Doctor doctor = doctorController.ReadDoctor(appointment.Doctor.Id);
            doctor.RemoveAppointment(appointment);
            doctorController.UpdateDoctor(doctor);
            RoomController roomController = new RoomController();
            Model.Room room = roomController.ReadRoom(appointment.Room.Identifier);
            room.RemoveAppointment(appointment);
            roomController.UpdateRoom(room);
            Model.Patient patient = patientController.ReadPatient(appointment.Patient.Id);
            patient.RemoveAppointment(appointment);
            patientController.UpdatePatient(patient);
            
            UpdateAppointmentTable();
        }

        private void EditAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (AppointmentTable.SelectedIndex == -1)
            {
                return;
            }
            ChangeAppointment window = new ChangeAppointment(AppointmentsCollection.ElementAt(AppointmentTable.SelectedIndex));
            window.ShowDialog();
            UpdateAppointmentTable();
        }
    }
}
