// File:    EquipmentController.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:34:26
// Purpose: Definition of Class EquipmentController

using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoCorp.View.ViewModel;

namespace Controller
{
    public class EquipmentController
    {
        public Boolean CreateEquipment(EquipmentTypeVO type, int count, RoomVO room)
        {
            return EquipmentService.Instance.CreateEquipment(type, count, room);
        }

        public Boolean UpdateEquipment(Equipment equipment)
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

        public Boolean CreateEquipmentType(EquipmentTypeVO newEquipmentType)
        {
            EquipmentType result = new EquipmentType(newEquipmentType);
            return EquipmentService.Instance.CreateEquipmentType(result);
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

        public ObservableCollection<EquipmentTypeVO> GetAllEquipmentType()
        {
            return EquipmentService.Instance.GetAllEquipmentType(); ;
        }

        public ObservableCollection<EquipmentTableVO> GetAllEquipmentTableVO()
        {
            return EquipmentService.Instance.GetAllEquipmentTableVO();
        }
    }
}