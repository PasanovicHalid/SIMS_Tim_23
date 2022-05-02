/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoCorp.View.ViewModel;

namespace Controller
{
    public class RoomController
    {
        RoomService roomService = new RoomService();
        
        public Boolean CreateRoom(Room newRoom)
        {
            return roomService.CreateRoom(newRoom);
        }

        public Room ReadRoom(String identifier)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateRoom(Room updatedRoom)
        {
            return roomService.UpdateRoom(updatedRoom);
        }

        public Boolean DeleteRoom(int identifier)
        {
            return roomService.DeleteRoom(identifier);
        }

        public Boolean RenovateRoom(int identifier, DateTime start, DateTime end)
        {
            return roomService.RenovateRoom(identifier, start, end);
        }

        public List<Room> GetAllRooms()
        {
            return roomService.GetAllRooms();
        }

        public ObservableCollection<RoomVO> GetAllRoomsVO()
        {
            List<Room> types = roomService.GetAllRooms();
            ObservableCollection<RoomVO> result = new ObservableCollection<RoomVO>();
            foreach (Room it in types)
            {
                result.Add(new RoomVO(it.Identifier, it.DesignationCode, it.SurfaceArea, it.Renovating, it.RenovatedUntil, it.RoomTypeString));
            }
            return result;
        }

        public Boolean CreateRoomType(RoomTypeVO newRoomType)
        {
            return RoomService.Instance.CreateRoomType(new RoomType(newRoomType));
        }

        public Boolean UpdateRoomType(Model.RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteRoomType(Model.RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public Model.RoomType ReadRoomType(Model.RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public List<RoomType> GetAllRoomType()
        {
            throw new NotImplementedException();
        }

        public int GetMaxCountForEquipment(int id_room, int id_equipment)
        {
            return RoomService.Instance.GetMaxCountForEquipment(id_room, id_equipment);
        }

        public ObservableCollection<RoomTypeVO> GetAllRoomTypeView()
        {
            return roomService.GetAllRoomTypeView();
        }
    }
}