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
                    result.Add(new EquipmentTableVO(it.Count, it.EquipmentType.Name, room.DesignationCode, room.Identifier, it.Identifier));
                }
                
            }

            return result;
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