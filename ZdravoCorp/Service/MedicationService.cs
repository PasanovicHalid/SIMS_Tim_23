// File:    MedicineService.cs
// Author:  halid
// Created: Friday, 15 April 2022 20:54:06
// Purpose: Definition of Class MedicineService

using Model;
using System;
using System.Collections.Generic;
using Repository;
using ZdravoCorp.Service.Interfaces;

namespace Service
{
    public class MedicationService : ICrud<Medication> , IMedicationService
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

        public void CreateMedicationType(MedicationType newMedicationType)
        {
            MedicationTypeRepository.Instance.Create(newMedicationType);
        }

        public void UpdateMedicationType(MedicationType medicationType)
        {
            MedicationTypeRepository.Instance.Update(medicationType);
        }

        public void DeleteMedicationType(int id)
        {
            MedicationTypeRepository.Instance.Delete(id);
        }

        public MedicationType ReadMedicationType(int id)
        {
            return MedicationTypeRepository.Instance.Read(id);
        }

        public List<MedicationType> GetAllMedicationType()
        {
            return MedicationTypeRepository.Instance.GetAll();
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