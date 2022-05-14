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

        public Boolean DeletePatient(int id)
        {
            return PatientRepository.Instance.DeletePatient(id);
        }

        public Patient ReadPatient(int id)
        {
            return PatientRepository.Instance.ReadPatient(id);
        }

        public List<Patient> GetAllPatients()
        {
            return PatientRepository.Instance.GetAllPatients();
        }

        public Boolean AddPrescription(Model.Patient patient,Model.Prescription newPrescription)
        {
            return PatientRepository.Instance.AddPrescription(patient,newPrescription);
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
        public void RemoveFromChangedOrCanceledList(Patient patient)
        {
            if(patient.ChangedOrCanceledAppointmentsDates == null)
            {
                patient.ChangedOrCanceledAppointmentsDates = new List<DateTime>();
            }
            foreach (DateTime date in patient.ChangedOrCanceledAppointmentsDates)
            {
                if (date < DateTime.Now.AddMonths(-1))
                {
                    patient.ChangedOrCanceledAppointmentsDates.Remove(date);
                    UpdatePatient(patient);
                }
            }
        }


    }
}