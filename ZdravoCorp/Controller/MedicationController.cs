// File:    MedicineController.cs
// Author:  halid
// Created: Friday, 15 April 2022 20:28:45
// Purpose: Definition of Class MedicineController

using Model;
using System;
using System.Collections.Generic;
using Service;
using Repository;

namespace Controller
{
    public class MedicationController : ICrud<Medication>
    {
        public void Create(Model.Medication newMedicine)
        {
            MedicationService.Instance.Create(newMedicine);
        }

        public void Update(Model.Medication medicine)
        {
            MedicationService.Instance.Update(medicine);
        }

        public void Delete(int identificator)
        {
            MedicationService.Instance.Delete(identificator);
        }

        public Model.Medication Read(int identificator)
        {
            return MedicationService.Instance.Read(identificator);
        }

        public List<Medication> GetAll()
        {
            return MedicationService.Instance.GetAll();
        }

        public void CreateMedicationType(MedicationType newMedicationType)
        {
            MedicationService.Instance.CreateMedicationType(newMedicationType);
        }

        public void UpdateMedicationType(MedicationType medicationType)
        {
            MedicationService.Instance.UpdateMedicationType(medicationType);
        }

        public void DeleteMedicationType(int id)
        {
            MedicationService.Instance.DeleteMedicationType(id);
        }

        public MedicationType ReadMedicationType(int id)
        {
            return MedicationService.Instance.ReadMedicationType(id);
        }

        public List<MedicationType> GetAllMedicationType()
        {
            return MedicationService.Instance.GetAllMedicationType();
        }

    }
}