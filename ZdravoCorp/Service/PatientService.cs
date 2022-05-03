// File:    PatientService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:41:52
// Purpose: Definition of Class PatientService

using Model;
using System;
using Repository;
using System.Collections.Generic;

namespace Service
{
    public class PatientService
    {
        
        private static PatientService instance = null;

        public Boolean CreatePatient(Patient newPatient)
        {
            return PatientRepository.Instance.CreatePatient(newPatient);
        }

        public Boolean UpdatePatient(Patient patient)
        {
            return PatientRepository.Instance.UpdatePatient(patient);
        }

        public Boolean DeletePatient(int patient)
        {
            return PatientRepository.Instance.DeletePatient(patient);
        }

        public Patient ReadPatient(int patient)
        {
            return PatientRepository.Instance.ReadPatient(patient);
        }

        public List<Patient> GetAllPatients()
        {
            return PatientRepository.Instance.GetAllPatients();
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