// File:    EquipmentController.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:34:26
// Purpose: Definition of Class EquipmentController

using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoCorp.View.Manager.Model.Equipments;
using ZdravoCorp.View.Manager.Model.Rooms;

namespace Controller
{
    public class EquipmentController
    {
        public Boolean CreateEquipment(EquipmentTypeModel type, int count, RoomModel room)
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

        public void CreateEquipmentType(EquipmentTypeModel newEquipmentType)
        {
            EquipmentType result = new EquipmentType(newEquipmentType);
            EquipmentService.Instance.CreateEquipmentType(result);
        }

        public void UpdateEquipmentType(EquipmentType equipmentType)
        {
            EquipmentService.Instance.UpdateEquipmentType(equipmentType);
        }

        public void DeleteEquipmentType(int id)
        {
            EquipmentService.Instance.DeleteEquipmentType(id);
        }

        public EquipmentType ReadEquipmentType(int id)
        {
            throw new NotImplementedException();
        }

        public void ChangePositionOfEquipment(DateTime excecutionDate,int id_from_room,int id_to_room, int id_equipment, int count)
        {
            EquipmentService.Instance.ChangePositionOfEquipment(excecutionDate, id_from_room, id_to_room, id_equipment, count);
        }

        public ObservableCollection<EquipmentTypeModel> GetAllEquipmentType()
        {
            return EquipmentService.Instance.GetAllEquipmentType(); ;
        }

        public ObservableCollection<EquipmentModel> GetAllEquipmentTableVO()
        {
            return EquipmentService.Instance.GetAllEquipmentTableVO();
        }
    }
}