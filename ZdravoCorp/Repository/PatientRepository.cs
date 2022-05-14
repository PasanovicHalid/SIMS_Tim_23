// File:    PatientRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:43
// Purpose: Definition of Class PatientRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class PatientRepository
    {
        private String dbPath = "..\\..\\Data\\patientsDB.csv";
        private Serializer<Patient> serializerPatient = new Serializer<Patient>();

        private static PatientRepository instance = null;
        public List<int> GetAllPatientIds()
        {
            List<Patient> patients = GetAllPatients();
            List<int> ids = new List<int>();
            foreach (Patient patient in patients)
            {
                ids.Add(patient.Id);
            }
            return ids;
        }
        public void GenerateId(Patient newPatient)
        {
            List<int> allPatientsIds = GetAllPatientIds();
            Random random = new Random();
            do
            {
                newPatient.Id = random.Next();
            }
            while (allPatientsIds.Contains(newPatient.Id));
        }
        public Boolean CreatePatient(Patient newPatient)
        {
            List<Patient> patients = GetAllPatients();
            bool exists = false;
            
            foreach (Patient d in patients)
            {
                if (d.Jmbg.Equals(newPatient.Jmbg))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                GenerateId(newPatient);
                patients.Add(newPatient);
                serializerPatient.ToCSV(dbPath, patients);
                return true;
            }
            return false;

        }

        public Boolean UpdatePatient(Patient patient)
        {
            Boolean success = false;
            List<Patient> patients = GetAllPatients();

            for (int i = 0; i < patients.Count; i++)

            {
                if (patient.Id == patients[i].Id)
                {
                    success = true;
                    DeletePatient(patient.Id);
                    break;
                }
            }
            if (success)
            {
                patients = GetAllPatients();
                patients.Add(patient);
                serializerPatient.ToCSV(dbPath, patients);

            }
            return success;
        }

        public Boolean DeletePatient(int id)
        {
            Boolean success = false;
            List<Patient> patients = GetAllPatients();
            foreach(Patient p in patients)
            {
                if(id == p.Id)
                {
                    success = true;
                    patients.Remove(p);
                    serializerPatient.ToCSV(dbPath, patients);
                    break;
                }
            }
            return success;
        }

        public Patient ReadPatient(int id)
        {
            List<Patient> patients = GetAllPatients();
            foreach(Patient p in patients)
            {
                if(id == p.Id)
                {
                    return p;
                }
            }
            return null;
        }

        public List<Patient> GetAllPatients()
        {

            List<Patient> patients = serializerPatient.FromCSV(dbPath);
            foreach (Patient d in patients)
            {
                List<int> ids = new List<int>();
                foreach (Appointment a in d.Appointment)
                {
                    ids.Add(a.Id);
                }
                d.Appointment = AppointmentRepository.Instance.GetAppointmentsById(ids);
                d.Record = MedicalRecordRepository.Instance.ReadMedicalRecord(d.Record.Id);

            }
            return patients;
        }

        public Boolean AddPrescription(Model.Patient patient, Model.Prescription newPrescription)
        {
            List<Patient> patients = GetAllPatients();
            foreach (Patient temp in patients)
            {
                if(temp.Id == patient.Id)
                {
                    patient.AddPrescription(newPrescription);
                    UpdatePatient(patient);
                    return true;
                }
            }
            return false;
        }

        public PatientRepository()
        {
            
        }

        public static PatientRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new PatientRepository();
                }
                return instance ;
            }
        }
        
    }
}