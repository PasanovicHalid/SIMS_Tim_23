// File:    MedicineService.cs
// Author:  halid
// Created: Friday, 15 April 2022 20:54:06
// Purpose: Definition of Class MedicineService

using Model;
using System;
using System.Collections.Generic;

namespace Service
{
    public class MedicineService
    {
        private MedicineService instance = null;

        public Boolean CreateMedicine(Model.Medication newMedicine)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateMedicine(Model.Medication medicine)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteMedicine(int identificator)
        {
            throw new NotImplementedException();
        }

        public Model.Medication ReadMedicine(int identificator)
        {
            throw new NotImplementedException();
        }

        public List<Medication> GetAllMedicine()
        {
            throw new NotImplementedException();
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