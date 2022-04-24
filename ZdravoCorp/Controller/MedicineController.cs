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
            throw new NotImplementedException();
        }

        public Boolean UpdateMedicationType(MedicationType medicationType)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteMedicationType(int id)
        {
            throw new NotImplementedException();
        }

        public MedicationType ReadMedicationType(int id)
        {
            throw new NotImplementedException();
        }

        public List<MedicationType> GetAllMedicationType()
        {
            throw new NotImplementedException();
        }

    }
}