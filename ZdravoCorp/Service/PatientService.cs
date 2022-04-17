// File:    PatientService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:41:52
// Purpose: Definition of Class PatientService

using Model;
using System;

namespace Service
{
    public class PatientService
    {
        private static PatientService instance = null;

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

        public PatientService()
        {
            
        }

        public static PatientService Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new PatientService();
                }
                return instance ;
            }
        }
    }
}