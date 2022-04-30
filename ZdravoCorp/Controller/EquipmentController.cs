// File:    EquipmentController.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:34:26
// Purpose: Definition of Class EquipmentController

using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class EquipmentController
    {
        public Boolean CreateEquipment(Model.Equipment newEquipment)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateEquipment(Model.Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteEquipment(String identificator)
        {
            throw new NotImplementedException();
        }

        public Model.Equipment ReadEquipment(String identificator)
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetAllEquipment()
        {
            throw new NotImplementedException();
        }

        public Boolean CreateEquipmentType(EquipmentType newEquipmentType)
        {
            return EquipmentService.Instance.CreateEquipmentType(newEquipmentType);
        }

        public Boolean UpdateEquipmentType(EquipmentType equipmentType)
        {
            return EquipmentService.Instance.UpdateEquipmentType(equipmentType);
        }

        public Boolean DeleteEquipmentType(int id)
        {
            return EquipmentService.Instance.DeleteEquipmentType(id);
        }

        public EquipmentType ReadEquipmentType(int id)
        {
            throw new NotImplementedException();
        }

        public List<EquipmentType> GetAllEquipmentType()
        {
            return EquipmentService.Instance.GetAllEquipmentType();
        }
    }
}