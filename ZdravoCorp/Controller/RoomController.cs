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
        public Boolean CreateRoom(Room newRoom)
        {
            return RoomService.Instance.CreateRoom(newRoom);
        }

        public Room ReadRoom(String identifier)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateRoom(Room updatedRoom)
        {
            return RoomService.Instance.UpdateRoom(updatedRoom);
        }

        public Boolean DeleteRoom(int identifier)
        {
            return RoomService.Instance.DeleteRoom(identifier);
        }

        public List<Room> GetAllRooms()
        {
            return RoomService.Instance.GetAllRooms();
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
    }
}