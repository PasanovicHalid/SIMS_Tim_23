// File:    PatientService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:41:52
// Purpose: Definition of Class PatientService

using Model;
using System;
using Repository;
using System.Collections.Generic;
using ZdravoCorp.Service.Interfaces;

namespace Service
{
    public class PatientService : ICrud<Patient> , IPatientService
    {
        
        private static PatientService instance = null;

        public void Create(Patient newPatient)
        {
            PatientRepository.Instance.Create(newPatient);
        }

        public void Update(Patient patient)
        {
            PatientRepository.Instance.Update(patient);
        }

        public void Delete(int id)
        {
            PatientRepository.Instance.Delete(id);
        }

        public Patient Read(int id)
        {
            return PatientRepository.Instance.Read(id);
        }

        public Patient ReadPatientByJmbg(string jmbg)
        {
            return PatientRepository.Instance.FindPatientByJMBG(jmbg);
        }

        public List<Patient> GetAll()
        {
            return PatientRepository.Instance.GetAll();
        }

        public Boolean AddPrescription(Patient patient, Prescription newPrescription)
        {
            return PatientRepository.Instance.AddPrescription(patient, newPrescription);
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
                    Update(patient);
                }
            }
        }


    }
}