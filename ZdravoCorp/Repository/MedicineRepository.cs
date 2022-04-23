// File:    MedicineRepository.cs
// Author:  halid
// Created: Friday, 15 April 2022 20:54:21
// Purpose: Definition of Class MedicineRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class MedicineRepository
    {
        private String dbPath = "..\\..\\Data\\medicineDB.csv";
        private Serializer<Medication> serializerMedication = new Serializer<Medication>();

        private MedicineRepository instance = null;

        public Boolean CreateMedicine(Model.Medication newMedicine)
        {
            List<Medication> medicines = GetAllMedicine();
            
            newMedicine.Id = medicines.Count + 1;
            medicines.Add(newMedicine);
            serializerMedication.ToCSV(dbPath, medicines);
            return true ;
        }

        public Boolean UpdateMedicine(Model.Medication medicine)
        {
            Boolean success = false;
            List<Medication> medicines = GetAllMedicine();
            foreach(Medication m in medicines)
            {
                if(medicine.Id == m.Id)
                {
                    success = true;
                    medicines.Remove(m);
                    break;
                }
            }
            if (success)
            {
                medicines.Add(medicine);
                serializerMedication.ToCSV(dbPath, medicines);
            }   
            return success;

        }

        public Boolean DeleteMedicine(int identificator)
        {
            Boolean success = false;
            List<Medication> medicines = GetAllMedicine();
            foreach (Medication m in medicines)
            {
                if (identificator == m.Id)
                {
                    success = true;
                    medicines.Remove(m);
                    serializerMedication.ToCSV(dbPath, medicines);
                    break;
                }
            }
            return success;
        }

        public Model.Medication ReadMedicine(int identificator)
        {
            List<Medication> medicines = GetAllMedicine();
            foreach(Medication m in medicines)
            {
                if(identificator == m.Id)
                {
                    return m;
                }
            }
            return null;
        }

        public List<Medication> GetAllMedicine()
        {
            return serializerMedication.FromCSV(dbPath);
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