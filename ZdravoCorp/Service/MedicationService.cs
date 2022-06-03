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
    public class MedicationService : ICrud<Medication>
    {
        private static MedicationService instance = null;

        public void Create(Medication newMedicine)
        {
            MedicationRepository.Instance.Create(newMedicine);
        }

        public void Update(Medication medicine)
        {
            MedicationRepository.Instance.Update(medicine);
        }

        public void Delete(int id)
        {
            MedicationRepository.Instance.Delete(id);
        }

        public Medication Read(int id)
        {
            return MedicationRepository.Instance.Read(id);
        }

        public List<Medication> GetAll()
        {
            return MedicationRepository.Instance.GetAll();
        }

        public Boolean CreateMedicationType(MedicationType newMedicationType)
        {
            return MedicationRepository.Instance.CreateMedicationType(newMedicationType);
        }

        public Boolean UpdateMedicationType(MedicationType medicationType)
        {
            return MedicationRepository.Instance.UpdateMedicationType(medicationType);
        }

        public Boolean DeleteMedicationType(int id)
        {
            return MedicationRepository.Instance.DeleteMedicationType(id);
        }

        public MedicationType ReadMedicationType(int id)
        {
            return MedicationRepository.Instance.ReadMedicationType(id);
        }

        public List<MedicationType> GetAllMedicationType()
        {
            return MedicationRepository.Instance.GetAllMedicationType();
        }
        public static MedicationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicationService();
                }
                return instance;
            }
        }
    }
}