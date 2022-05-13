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
using ZdravoCorp.View.Manager.Model.Rooms;

namespace Controller
{
    public class RoomController
    {
        RoomService roomService = new RoomService();

        public Boolean CreateRoom(Room newRoom)
        {
            return roomService.CreateRoom(newRoom);
        }

        public Room ReadRoom(int identifier)
        {
            return roomService.ReadRoom(identifier);
        }

        public Room ReadRoomByIndex(int index)
        {
            return roomService.ReadRoomByIndex(index);
        }

        public int GetRoomIndex(Model.Room room)
        {
            return RoomService.Instance.GetRoomIndex(room);
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

        public ObservableCollection<RoomModel> GetAllRoomsVO()
        {
            List<Room> types = roomService.GetAllRooms();
            ObservableCollection<RoomModel> result = new ObservableCollection<RoomModel>();
            foreach (Room it in types)
            {
                result.Add(new RoomModel(it.Identifier, it.DesignationCode, it.SurfaceArea, it.Renovating, it.RenovatedUntil, it.RoomTypeString));
            }
            return result;
        }

        public Boolean CreateRoomType(RoomTypeModel newRoomType)
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

        public ObservableCollection<RoomTypeModel> GetAllRoomTypeView()
        {
            return roomService.GetAllRoomTypeView();

        }
        public Room findFreeRoom(DateTime start, DateTime end)
        {
            return RoomService.Instance.findFreeRoom(start, end);

        }
    }
}