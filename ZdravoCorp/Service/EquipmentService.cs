// File:    EquipmentService.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:33:08
// Purpose: Definition of Class EquipmentService

using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoCorp.View.ViewModel;

namespace Service
{
    public class EquipmentService
    {
        private static EquipmentService instance = null;
        private ActionService actionService;

        public Boolean CreateEquipment(EquipmentTypeVO type, int count, RoomVO room)
        {
            Equipment equipment = new Equipment(count, count,FindEquipmentTypeByName(type.Name));
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
             return EquipmentRepository.Instance.ReadEquipmentType(id);
        }

        public EquipmentType FindEquipmentTypeByName(String name)
        {
            return EquipmentRepository.Instance.FindEquipmentTypeByName(name);
        }

        public Boolean ChangePositionOfEquipment(DateTime excecutionDate, int id_from_room, int id_to_room, int id_equipment, int count)
        {
            if(!actionService.CreateAction(new Model.Action(ActionType.changePosition, excecutionDate, new ChangeRoomAction(id_to_room, id_from_room, id_equipment, count))))
            {
                return false;
            }
            
            return RoomService.Instance.ChangeActualCountOfEquipment(id_from_room, id_equipment, -count);
        }

        public ObservableCollection<EquipmentTypeVO> GetAllEquipmentType()
        {
            List<EquipmentType> types = EquipmentRepository.Instance.GetAllEquipmentType();
            ObservableCollection<EquipmentTypeVO> result = new ObservableCollection<EquipmentTypeVO>();
            foreach(EquipmentType it in types)
            {
                result.Add(new EquipmentTypeVO(it.Name, it.Description, it.Disposable));
            }
            return result;
        }

        public ObservableCollection<EquipmentTableVO> GetAllEquipmentTableVO()
        {
            ObservableCollection<EquipmentTableVO> result = new ObservableCollection<EquipmentTableVO>();
            List<Room> rooms = RoomService.Instance.GetAllRooms();
            foreach(Room room in rooms)
            {
                foreach(Equipment it in room.Equipment)
                {
                    result.Add(new EquipmentTableVO(it.Count, it.Actual_count,it.EquipmentType.Name, room.DesignationCode, it.EquipmentType.Disposable ,room.Identifier, it.Identifier));
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