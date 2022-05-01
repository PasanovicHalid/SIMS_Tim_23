// File:    EquipmentService.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:33:08
// Purpose: Definition of Class EquipmentService

using Model;
using Repository;
using System;
using System.Collections.Generic;
using ZdravoCorp.View.ViewModel;

namespace Service
{
    public class EquipmentService
    {
        private static EquipmentService instance = null;

        public Boolean CreateEquipment(EquipmentTypeVO type, int count, RoomVO room)
        {
            Equipment equipment = new Equipment(count, FindEquipmentTypeByName(type.Name));
            return RoomService.Instance.AddEquipment(equipment, room.Identifier);
        }

        public Boolean UpdateEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteEquipment(String identificator)
        {
            throw new NotImplementedException();
        }

        public Equipment ReadEquipment(String identificator)
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetAllEquipment()
        {
            throw new NotImplementedException();
        }

        public Boolean CreateEquipmentType(EquipmentType newEquipmentType)
        {
            return EquipmentRepository.Instance.CreateEquipmentType(newEquipmentType);
        }

        public Boolean UpdateEquipmentType(EquipmentType equipmentType)
        {
            return EquipmentRepository.Instance.UpdateEquipmentType(equipmentType);
        }

        public Boolean DeleteEquipmentType(int id)
        {
            return EquipmentRepository.Instance.DeleteEquipmentType(id);
        }

        public EquipmentType ReadEquipmentType(int id)
        {
            throw new NotImplementedException();
        }

        public EquipmentType FindEquipmentTypeByName(String name)
        {
            return EquipmentRepository.Instance.FindEquipmentTypeByName(name);
        }

        public List<EquipmentType> GetAllEquipmentType()
        {
            return EquipmentRepository.Instance.GetAllEquipmentType();
        }

        public EquipmentService()
        {
            
        }

        public static EquipmentService Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new EquipmentService();
                }
                return instance ;
            }
        }
    }
}