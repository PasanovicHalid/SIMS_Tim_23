// File:    PatientController.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:19:13
// Purpose: Definition of Class PatientController

using Model;
using System;
using Service;
using Repository;
using System.Collections.Generic;

namespace Controller
{
    public class PatientController : ICrud<Patient>
    {
        public void Create(Patient newPatient)
        {
            PatientService.Instance.Create(newPatient);
        }

        public void Update(Patient patient)
        {
            PatientService.Instance.Update(patient);
        }

        public void Delete(int patient)
        {
            PatientService.Instance.Delete(patient);
        }

        public Patient Read(int patient)
        {
            return PatientService.Instance.Read(patient);
        }

        public Patient ReadPatientByJmbg(string jmbg)
        {
            return PatientService.Instance.ReadPatientByJmbg(jmbg);
        }

        public List<Patient> GetAll()
        {
            return PatientService.Instance.GetAll();
        }

        public Boolean AddPrescription(Model.Patient patient,Model.Prescription newPrescription)
        {
            return PatientService.Instance.AddPrescription(patient,newPrescription);
        }

        public void RemoveFromChangedOrCanceledList(Patient patient)
        {
            PatientService.Instance.RemoveFromChangedOrCanceledList(patient);
        }
    }
}