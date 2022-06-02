// File:    EquipmentRepository.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:26:08
// Purpose: Definition of Class EquipmentRepository

using Controller;
using Model;
using System;
using System.Collections.Generic;
using ZdravoCorp.Exceptions;

namespace Repository
{
    public class EquipmentRepository
    {
        private String dbPath = "..\\..\\Data\\equipmentTypeDB.csv";
        private Serializer<EquipmentType> serializer = new Serializer<EquipmentType>();

        private static EquipmentRepository instance = null;
        private static readonly object key = new object();

        private HashSet<int> idMap;

        public Boolean CreateEquipment(Equipment newEquipment)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteEquipment(String identificator)
        {
            throw new NotImplementedException();
        }

        public Model.Equipment ReadEquipment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetEquipmentsById(List<int> id)
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetAllEquipment()
        {
            throw new NotImplementedException();
        }

        public void CreateEquipmentType(EquipmentType newEquipmentType)
        {
            lock (key)
            {
                List<EquipmentType> equipmentTypes = serializer.FromCSV(dbPath);
                newEquipmentType.Identifier = GenerateID();
                CheckIfEquipmentNameExists(newEquipmentType.Name, equipmentTypes);
                serializer.ToCSVAppend(dbPath,new List<EquipmentType> { newEquipmentType });
                idMap.Add(newEquipmentType.Identifier);
            }
        }

        public void UpdateEquipmentType(EquipmentType equipmentType)
        {
            lock (key)
            {
                List<EquipmentType> equipmentTypes = serializer.FromCSV(dbPath);
                CheckIfNameOfChangedEquipmentTypeExists(equipmentType, equipmentTypes);
                SwapEquipmentByID(equipmentType, equipmentTypes);
                equipmentTypes.Add(equipmentType);
                serializer.ToCSV(dbPath, equipmentTypes);
            }
        }

        public void DeleteEquipmentType(int id)
        {
            lock (key)
            {
                List<EquipmentType> equipmentTypes = serializer.FromCSV(dbPath);
                RemoveEquipmentType(id, equipmentTypes);
                serializer.ToCSV(dbPath, equipmentTypes);
                idMap.Remove(id);
            }
        }

        public EquipmentType ReadEquipmentType(int id)
        {
            lock (key)
            {
                List<EquipmentType> equipmentTypes = serializer.FromCSV(dbPath);
                foreach (EquipmentType type in equipmentTypes)
                {
                    if (type.Identifier == id)
                    {
                        return type;
                    }
                }
                throw new LocalisedException("EquipmentDoesntExists");
            }
        }

        public EquipmentType FindEquipmentTypeByName(String name)
        {
            lock (key)
            {
                List<EquipmentType> equipmentTypes = serializer.FromCSV(dbPath);
                foreach (EquipmentType type in equipmentTypes)
                {
                    if (type.Name == name)
                    {
                        return type;
                    }
                }
                throw new LocalisedException("EquipmentDoesntExists");
            }
        }

        public List<EquipmentType> GetAllEquipmentType()
        {
            lock (key)
            {
                return serializer.FromCSV(dbPath);
            }
        }

        private void RemoveEquipmentType(int id, List<EquipmentType> types)
        {
            foreach (EquipmentType type in types)
            {
                if (type.Identifier == id)
                {
                    types.Remove(type);
                    return;
                }
            }
            throw new LocalisedException("EquipmentDoesntExists");
        }

        private int GenerateID()
        {
            Random random = new Random();
            int id;
            do
            {
                id = random.Next();
            }
            while (idMap.Contains(id));
            idMap.Add(id);
            return id;
        }

        private void CheckIfEquipmentNameExists(string name, List<EquipmentType> types)
        {
            foreach (EquipmentType type in types)
            {
                if (type.Name == name)
                {
                    throw new LocalisedException("EquipmentNameExists");
                }
            }
        }

        private void CheckIfNameOfChangedEquipmentTypeExists(EquipmentType type, List<EquipmentType> types)
        {
            foreach (EquipmentType it in types)
            {
                if (type.Name.Equals(type.Name) && type.Identifier != type.Identifier)
                {
                    throw new LocalisedException("EquipmentNameExists");
                }
            }
        }

        private void SwapEquipmentByID(EquipmentType type, List<EquipmentType> types)
        {
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].Identifier == type.Identifier)
                {
                    types[i] = type;
                    return;
                }
            }
            throw new LocalisedException("EquipmentDoesntExists");
        }

        public EquipmentRepository()
        {
            idMap = new HashSet<int>();
            List<EquipmentType> rooms = serializer.FromCSV(dbPath);
            foreach (EquipmentType it in rooms)
            {
                idMap.Add(it.Identifier);
            }
        }

        public static EquipmentRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new EquipmentRepository();
                        }
                    }
                }
                return instance;
            }
        }

    }
}