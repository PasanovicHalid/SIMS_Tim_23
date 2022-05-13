// File:    PatientController.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:19:13
// Purpose: Definition of Class PatientController

using Model;
using System;
using Service;
using System.Collections.Generic;

namespace Controller
{
    public class PatientController
    {
        public Boolean CreatePatient(Patient newPatient)
        {
            return PatientService.Instance.CreatePatient(newPatient);
        }

        public Boolean UpdatePatient(Patient patient)
        {
            return PatientService.Instance.UpdatePatient(patient);
        }

        public Boolean DeletePatient(int patient)
        {
            return PatientService.Instance.DeletePatient(patient);
        }

        public Patient ReadPatient(int patient)
        {
            return PatientService.Instance.ReadPatient(patient);
        }

        public List<Patient> GetAllPatients()
        {
            return PatientService.Instance.GetAllPatients();
        }

        public Boolean AddPrescription(Model.Patient patient,Model.Prescription newPrescription)
        {
            return PatientService.Instance.AddPrescription(patient,newPrescription);
        }
    }
}