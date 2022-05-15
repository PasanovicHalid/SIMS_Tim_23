// File:    MedicineService.cs
// Author:  halid
// Created: Friday, 15 April 2022 20:54:06
// Purpose: Definition of Class MedicineService

using Model;
using System;
using System.Collections.Generic;
using Repository;

namespace Service
{
    public class MedicineService
    {
        private static MedicineService instance = null;

        public Boolean CreateMedicine(Model.Medication newMedicine)
        {
            return MedicineRepository.Instance.CreateMedicine(newMedicine);
        }

        public Boolean UpdateMedicine(Model.Medication medicine)
        {
            return MedicineRepository.Instance.UpdateMedicine(medicine);
        }

        public Boolean DeleteMedicine(int identificator)
        {
            return MedicineRepository.Instance.DeleteMedicine(identificator);
        }

        public Model.Medication ReadMedicine(int identificator)
        {
            return MedicineRepository.Instance.ReadMedicine(identificator);
        }

        public List<Medication> GetAllMedicine()
        {
            return MedicineRepository.Instance.GetAllMedicine();
        }

        public Boolean CreateMedicationType(MedicationType newMedicationType)
        {
            return MedicineRepository.Instance.CreateMedicationType(newMedicationType);
        }

        public Boolean UpdateMedicationType(MedicationType medicationType)
        {
            return MedicineRepository.Instance.UpdateMedicationType(medicationType);
        }

        public Boolean DeleteMedicationType(int id)
        {
            return MedicineRepository.Instance.DeleteMedicationType(id);
        }

        public MedicationType ReadMedicationType(int id)
        {
            return MedicineRepository.Instance.ReadMedicationType(id);
        }

        public List<MedicationType> GetAllMedicationType()
        {
            return MedicineRepository.Instance.GetAllMedicationType();
        }
        public static MedicineService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicineService();
                }
                return instance;
            }
        }
    }
}