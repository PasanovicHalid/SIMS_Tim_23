/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using System;
using System.Collections.Generic;

namespace Service
{
   public class RoomService
   {
        public Repository.RoomRepository roomRepository;

        public RoomService()
        {
            roomRepository = new Repository.RoomRepository();
        }

        public Boolean CreateRoom(Model.Room newRoom)
        {
            return roomRepository.CreateRoom(newRoom);
        }
      
        public Model.Room ReadRoom(String identifier)
        {
            return roomRepository.ReadRoom(identifier);
        }
      
        public Boolean UpdateRoom(Model.Room updatedRoom)
        {
            return roomRepository.UpdateRoom(updatedRoom);
        }
      
        public Boolean DeleteRoom(String identifier)
        {
            return roomRepository.DeleteRoom(identifier);
        }
      
        public List<Room> GetAllRooms()
        {
           return roomRepository.GetAllRooms();
        }
      
   }
}