// File:    MedicineRepository.cs
// Author:  halid
// Created: Friday, 15 April 2022 20:54:21
// Purpose: Definition of Class MedicineRepository

using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MedicineRepository
    {
        private String dbPath = "..\\..\\Data\\medicationDB.csv";
        private String dbPathTypes = "..\\..\\Data\\medicationTypeDB.csv";
        private Serializer<Medication> serializerMedication = new Serializer<Medication>();
        private Serializer<MedicationType> serializerType = new Serializer<MedicationType>();

        private static MedicineRepository instance = null;

        private HashSet<int> typeIdMap = new HashSet<int>();
        private HashSet<string> typeNameMap = new HashSet<string>();

        public MedicineRepository()
        {
            List<MedicationType> typeList = GetAllMedicationType();
            InstantiateTypeHashSets(typeList);
        }

        private void InstantiateTypeHashSets(List<MedicationType> medicationTypes)
        {
            foreach (MedicationType type in medicationTypes)
            {
                typeIdMap.Add(type.Id);
                typeNameMap.Add(type.Name);
            }
        }
        public List<int> GetAllMedicationIds()
        {
            List<Medication> medicine = GetAllMedicine();
            List<int> ids = new List<int>();
            foreach (Medication medication in medicine)
            {
                ids.Add(medication.Id);
            }
            return ids;
        }
        public void GenerateId(Medication newMedication)
        {
            List<int> allMedicationIds = GetAllMedicationIds();
            Random random = new Random();
            do
            {
                newMedication.Id = random.Next();
            }
            while (allMedicationIds.Contains(newMedication.Id));
        }

        public Boolean CreateMedicine(Model.Medication newMedicine)
        {
            List<Medication> medicines = GetAllMedicine();
            GenerateId(newMedicine);
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

        private int GenerateTypeID()
        {
            int id;
            Random random = new Random();
            do
            {
                id = random.Next();
            }
            while (typeIdMap.Contains(id));
            typeIdMap.Add(id);
            return id;
        }

        public bool CheckIfNameExists(string username)
        {
            return typeNameMap.Contains(username);
        }

        private bool CheckIfTypeIDExists(int id)
        {
            return typeIdMap.Contains(id);
        }

        public Boolean CreateMedicationType(MedicationType newMedicationType)
        {
            if (!CheckIfNameExists(newMedicationType.Name))
            {
                newMedicationType.Id = GenerateTypeID();
                typeNameMap.Add(newMedicationType.Name);
                serializerType.ToCSVAppend(dbPathTypes, new List<MedicationType>() { newMedicationType });
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SwapTypesByID(List<MedicationType> types, MedicationType type)
        {
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].Id == type.Id)
                {
                    types[i] = type;
                    break;
                }
            }
        }

        public Boolean UpdateMedicationType(MedicationType medicationType)
        {
            if (CheckIfTypeIDExists(medicationType.Id))
            {
                List<MedicationType> types = GetAllMedicationType();
                SwapTypesByID(types, medicationType);
                serializerType.ToCSV(dbPathTypes, types);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DeleteTypeByID(List<MedicationType> types, int id)
        {
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].Id == id)
                {
                    types.RemoveAt(i);
                    break;
                }
            }
        }

        public Boolean DeleteMedicationType(int id)
        {
            if (CheckIfTypeIDExists(id))
            {
                List<MedicationType> types = GetAllMedicationType();
                DeleteTypeByID(types, id);
                serializerType.ToCSV(dbPathTypes, types);
                return true;
            }
            else
            {
                return false;
            }
        }

        private MedicationType FindTypeByID(List<MedicationType> types, int id)
        {
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].Id == id)
                {
                    return types[i];
                }
            }
            return null;
        }



        public MedicationType ReadMedicationType(int id)
        {
            if (CheckIfTypeIDExists(id))
            {
                List<MedicationType> types = GetAllMedicationType();
                return FindTypeByID(types, id);
            }
            else
            {
                return null;
            }
        }

        private void InstantiateReplacements(Dictionary<int, MedicationType> types)
        {
            foreach (MedicationType type in types.Values)
            {
                for(int i = 0; i < type.Replacement.Count; i++)
                {
                    if (types.ContainsKey(type.Replacement[i].Id))
                    {
                        type.Replacement[i] = types[type.Replacement[i].Id];
                    }
                }
            }
        }

        public List<MedicationType> GetAllMedicationType()
        {
            Dictionary<int, MedicationType> types = serializerType.FromCSV(dbPathTypes).ToDictionary(keySelector: m => m.Id, elementSelector: m => m);
            InstantiateReplacements(types);
            return types.Values.ToList();
        }
        public static MedicineRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicineRepository();
                }
                return instance;
            }
        }

    }
}