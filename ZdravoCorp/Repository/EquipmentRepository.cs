// File:    EquipmentRepository.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:26:08
// Purpose: Definition of Class EquipmentRepository

using Controller;
using Model;
using System;
using System.Collections.Generic;

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

        public Boolean CreateEquipmentType(EquipmentType newEquipmentType)
        {
            lock (key)
            {
                Random random = new Random();
                do
                {
                    newEquipmentType.Identifier = random.Next();
                }
                while (idMap.Contains(newEquipmentType.Identifier));

                List<EquipmentType> equipmentTypes = serializer.FromCSV(dbPath);

                //Checking if Name of EquipmentType already exists
                bool exists = false;
                foreach (EquipmentType type in equipmentTypes)
                {
                    if (newEquipmentType.Name.Equals(type.Name))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    equipmentTypes.Add(newEquipmentType);
                    serializer.ToCSV(dbPath, equipmentTypes);
                    idMap.Add(newEquipmentType.Identifier);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean UpdateEquipmentType(EquipmentType equipmentType)
        {
            lock (key)
            {
                List<EquipmentType> equipmentTypes = serializer.FromCSV(dbPath);

                //Checking if Name of EquipmentType already exists
                bool exists = false;
                foreach (EquipmentType type in equipmentTypes)
                {
                    if (equipmentType.Name.Equals(type.Name) && equipmentType.Identifier != type.Identifier)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    bool found = false;
                    foreach (EquipmentType type in equipmentTypes)
                    {
                        if (type.Identifier == equipmentType.Identifier)
                        {
                            equipmentTypes.Remove(type);
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        //Publishing changes to DB
                        equipmentTypes.Add(equipmentType);
                        serializer.ToCSV(dbPath, equipmentTypes);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean DeleteEquipmentType(int id)
        {
            lock (key)
            {
                List<EquipmentType> equipmentTypes = serializer.FromCSV(dbPath);

                bool deleted = false;
                foreach (EquipmentType type in equipmentTypes)
                {
                    if (type.Identifier == id)
                    {
                        equipmentTypes.Remove(type);
                        deleted = true;
                        break;
                    }
                }

                if (!deleted)
                {
                    serializer.ToCSVAppend(dbPath, equipmentTypes);
                    idMap.Remove(id);
                    return true;
                }
                else
                {
                    return false;
                }
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
                return null;
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
                return null;
            }
        }

        public List<EquipmentType> GetAllEquipmentType()
        {
            lock (key)
            {
                return serializer.FromCSV(dbPath);
            }
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