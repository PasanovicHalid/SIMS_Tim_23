// File:    MedicineController.cs
// Author:  halid
// Created: Friday, 15 April 2022 20:28:45
// Purpose: Definition of Class MedicineController

using Model;
using System;
using System.Collections.Generic;
using Service;

namespace Controller
{
    public class MedicineController
    {
        public Boolean CreateMedicine(Model.Medication newMedicine)
        {
            return MedicineService.Instance.CreateMedicine(newMedicine);
        }

        public Boolean UpdateMedicine(Model.Medication medicine)
        {
            return MedicineService.Instance.UpdateMedicine(medicine);
        }

        public Boolean DeleteMedicine(int identificator)
        {
            return MedicineService.Instance.DeleteMedicine(identificator);
        }

        public Model.Medication ReadMedicine(int identificator)
        {
            return MedicineService.Instance.ReadMedicine(identificator);
        }

        public List<Medication> GetAllMedicine()
        {
            return MedicineService.Instance.GetAllMedicine();
        }

        public Boolean CreateMedicationType(MedicationType newMedicationType)
        {
            return MedicineService.Instance.CreateMedicationType(newMedicationType);
        }

        public Boolean UpdateMedicationType(MedicationType medicationType)
        {
            return MedicineService.Instance.UpdateMedicationType(medicationType);
        }

        public Boolean DeleteMedicationType(int id)
        {
            return MedicineService.Instance.DeleteMedicationType(id);
        }

        public MedicationType ReadMedicationType(int id)
        {
            return MedicineService.Instance.ReadMedicationType(id);
        }

        public List<MedicationType> GetAllMedicationType()
        {
            return MedicineService.Instance.GetAllMedicationType();
        }

    }
}