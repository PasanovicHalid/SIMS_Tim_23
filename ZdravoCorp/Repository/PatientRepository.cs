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
                newPatient.Id = patients.Count + 1;
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
            foreach(Patient p in patients)
            {
                if (patient.Id.Equals(p.Id))
                {
                    success = true;
                    patients.Remove(p);
                    break;
                }
            }
            if (success)
            {
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
            return serializerPatient.FromCSV(dbPath);
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