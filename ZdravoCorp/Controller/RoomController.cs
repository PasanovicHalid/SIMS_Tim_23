/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using Service;
using System;
using System.Collections.Generic;

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

        public Boolean UpdateRoom(Room updatedRoom)
        {
            return roomService.UpdateRoom(updatedRoom);
        }

        public Boolean DeleteRoom(int identifier)
        {
            return roomService.DeleteRoom(identifier);
        }

        public List<Room> GetAllRooms()
        {
            return roomService.GetAllRooms();
        }

        public Boolean CreateRoomType(Model.RoomType newRoomType)
        {
            throw new NotImplementedException();
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
        public Room findFreeRoom(DateTime start, DateTime end)
        {
            return RoomService.Instance.findFreeRoom(start, end);
        }
    }
}