// File:    PatientRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:43
// Purpose: Definition of Class PatientRepository

using Model;
using System;

namespace Repository
{
    public class PatientRepository
    {
        private String dbPath;

        private static PatientRepository instance = null;

        public Boolean CreatePatient(Patient newPatient)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Boolean DeletePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Patient ReadPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Array GetAllPatients()
        {
            throw new NotImplementedException();
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