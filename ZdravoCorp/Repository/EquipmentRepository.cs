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
        private String dbPath;
        private String dbPath_EquipmentType_path;

        private static EquipmentRepository instance = null;

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
            throw new NotImplementedException();
        }

        public Boolean UpdateEquipmentType(EquipmentType equipmentType)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteEquipmentType(int id)
        {
            throw new NotImplementedException();
        }

        public EquipmentType ReadEquipmentType(int id)
        {
            throw new NotImplementedException();
        }

        public List<EquipmentType> GetAllEquipmentType()
        {
            throw new NotImplementedException();
        }

        public EquipmentRepository()
        {
            
        }

        public static EquipmentRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new EquipmentRepository();
                }
                return instance;
            }
        }

    }
}