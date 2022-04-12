/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class RoomController
    {
        public Service.RoomService roomService;

        public RoomController()
        {
            roomService = new Service.RoomService();
        }

        public Boolean CreateRoom(Model.Room newRoom)
        {
            return roomService.CreateRoom(newRoom);
        }
      
        public Model.Room ReadRoom(String identifier)
        {
            return roomService.ReadRoom(identifier);
        }
      
        public Boolean UpdateRoom(Model.Room updatedRoom)
        {
            return roomService.UpdateRoom(updatedRoom);
        }
      
        public Boolean DeleteRoom(String identifier)
        {
            return roomService.DeleteRoom(identifier);
        }
      
        public List<Room> GetAllRooms()
        {
            return roomService.GetAllRooms();
        }
      
    }
}