// File:    EquipmentService.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:33:08
// Purpose: Definition of Class EquipmentService

using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoCorp.View.Manager.Model.Equipments;
using ZdravoCorp.View.Manager.Model.Rooms;

namespace Service
{
    public class EquipmentService
    {
        private static EquipmentService instance = null;
        private ActionService actionService;

        public Boolean CreateEquipment(EquipmentTypeModel type, int count, RoomModel room)
        {
            Equipment equipment = new Equipment(count, count,FindEquipmentTypeByName(type.Name));
            RoomService.Instance.AddEquipment(equipment, room.Identifier);
            return true;
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

        public void CreateEquipmentType(EquipmentType newEquipmentType)
        {
            EquipmentRepository.Instance.CreateEquipmentType(newEquipmentType);
        }

        public void UpdateEquipmentType(EquipmentType equipmentType)
        {
            EquipmentRepository.Instance.UpdateEquipmentType(equipmentType);
        }

        public void DeleteEquipmentType(int id)
        {
            EquipmentRepository.Instance.DeleteEquipmentType(id);
        }

        public EquipmentType ReadEquipmentType(int id)
        {
             return EquipmentRepository.Instance.ReadEquipmentType(id);
        }

        public EquipmentType FindEquipmentTypeByName(String name)
        {
            return EquipmentRepository.Instance.FindEquipmentTypeByName(name);
        }

        public void ChangePositionOfEquipment(DateTime excecutionDate, int id_from_room, int id_to_room, int id_equipment, int count)
        {
            actionService.CreateAction(new Model.Action(ActionType.changePosition, 
                excecutionDate, new ChangeRoomAction(id_to_room, id_from_room, id_equipment, count)));
            RoomService.Instance.ChangeActualCountOfEquipment(id_from_room, id_equipment, -count);
        }

        public ObservableCollection<EquipmentTypeModel> GetAllEquipmentType()
        {
            List<EquipmentType> types = EquipmentRepository.Instance.GetAllEquipmentType();
            ObservableCollection<EquipmentTypeModel> result = new ObservableCollection<EquipmentTypeModel>();
            foreach(EquipmentType it in types)
            {
                result.Add(new EquipmentTypeModel(it.Name, it.Description, it.Disposable));
            }
            return result;
        }

        public ObservableCollection<EquipmentModel> GetAllEquipmentTableVO()
        {
            ObservableCollection<EquipmentModel> result = new ObservableCollection<EquipmentModel>();
            List<Room> rooms = RoomService.Instance.GetAllRooms();
            foreach(Room room in rooms)
            {
                foreach(Equipment it in room.Equipment)
                {
                    result.Add(new EquipmentModel(it.Count, it.Actual_count,it.EquipmentType.Name, 
                        room.DesignationCode, it.EquipmentType.Description, it.EquipmentType.Disposable, 
                        room.Identifier, it.Identifier));
                }
                
            }

            return result;
        }

        public EquipmentService()
        {
            actionService = new ActionService();
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