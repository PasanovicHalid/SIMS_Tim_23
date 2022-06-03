// File:    PatientRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:43
// Purpose: Definition of Class PatientRepository

using Model;
using System;
using System.Collections.Generic;
using ZdravoCorp.Exceptions;

namespace Repository
{
    public class PatientRepository : UserRepository<Patient>
    {
        private static PatientRepository instance = null;

        public PatientRepository()
        {
            dbPath = "..\\..\\Data\\patientsDB.csv";
            InstantiateHashSets(GetAll());
        }

        private void InstantiateHashSets(List<Patient> secretaries)
        {
            InstantiateIDSet(secretaries);
            InstantiateUserSet(secretaries);
        }

        public new List<Patient> GetAll()
        {

            List<Patient> patients = base.GetAll();
            foreach (Patient patient in patients)
            {
                patient.Appointment = AppointmentRepository.Instance
                    .GetAppointmentsById(GetIdsOfAppointments(patient));
                patient.Record = MedicalRecordRepository.Instance
                    .ReadMedicalRecord(patient.Record.Id);
            }
            return patients;
        }

        public Boolean AddPrescription(Model.Patient patient, Model.Prescription newPrescription)
        {
            List<Patient> patients = GetAll();
            foreach (Patient temp in patients)
            {
                if(temp.Id == patient.Id)
                {
                    patient.AddPrescription(newPrescription);
                    Update(patient);
                    return true;
                }
            }
            return false;
        }

        public Dictionary<string, Patient> GetUsernameHashSet()
        {
            return Users;
        }

        public Patient ReadByJMBG(string jmbg)
        {
            lock (key)
            {
                List<Patient> patients = GetAll();
                CheckIfJMBGExists(patients, jmbg);
                return FindPatientByJMBG(patients, jmbg);
            }
        }

        public override Patient Read(int id)
        {
            lock (key)
            {
                CheckIfIDExists(id);
                return FindPatientByID(GetAll(), id);
            }
        }

        public override void Create(Patient element)
        {
            lock (key)
            {
                List<Patient> elements = GetAll();
                CheckIfUsernameExists(element.Username);
                CheckIfJMBGExists(elements, element.Jmbg);
                element.Id = GenerateID();
                Users.Add(element.Username, element);
                idMap.Add(element.Id);
                AppendToDB(element);
            }
        }

        public override void Update(Patient element)
        {
            lock (key)
            {
                CheckIfIDExists(element.Id);
                CheckIfUsernameExists(element.Username);
                List<Patient> elements = GetAll();
                SwapPatientByID(elements, element);
                SaveChanges(elements);
            }
        }

        public override void Delete(int id)
        {
            lock (key)
            {
                CheckIfIDExists(id);
                List<Patient> elements = GetAll();
                DeletePatientByID(elements, id);
                SaveChanges(elements);
            }
        }

        protected override void InstantiateIDSet(List<Patient> elements)
        {
            lock (key)
            {
                foreach (Patient element in elements)
                {
                    idMap.Add(element.Id);
                }
            }
        }

        private void CheckIfJMBGExists(List<Patient> patients, string jmbg)
        {
            foreach (Patient it in patients)
            {
                if (it.Jmbg.Equals(jmbg))
                {
                    throw new LocalisedException("UserExists");
                }
            }
        }

        private void CheckIfIDExists(int id)
        {
            if (idMap.Contains(id))
                throw new LocalisedException("UserDoesntExist");
        }

        private void CheckIfUsernameExists(string username)
        {
            if (Users.ContainsKey(username))
                throw new LocalisedException("UserExists");
        }

        private Patient FindPatientByID(List<Patient> patients, int id)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == id)
                {
                    return patients[i];
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private Patient FindPatientByJMBG(List<Patient> patients, string jmbg)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Jmbg.Equals(jmbg))
                {
                    return patients[i];
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private void DeletePatientByID(List<Patient> patients, int id)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == id)
                {
                    idMap.Remove(id);
                    Users.Remove(patients[i].Username);
                    patients.RemoveAt(i);
                    return;
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private void SwapPatientByID(List<Patient> patients, Patient patient)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == patient.Id)
                {
                    patients[i] = patient;
                    return;
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private List<int> GetIdsOfAppointments(Patient patient)
        {
            List<int> ids = new List<int>();
            foreach (Appointment it in patient.Appointment)
            {
                ids.Add(it.Id);
            }
            return ids;
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