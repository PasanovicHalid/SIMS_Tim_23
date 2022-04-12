/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using System;

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
            throw new NotImplementedException();
        }
      
        public Model.Room ReadRoom(String identifier)
        {
            throw new NotImplementedException();
        }
      
        public Boolean UpdateRoom(Model.Room updatedRoom)
        {
            throw new NotImplementedException();
        }
      
        public Boolean DeleteRoom(String identifier)
        {
            throw new NotImplementedException();
        }
      
        public System.Collections.ArrayList GetAllRooms()
        {
            throw new NotImplementedException();
        }
      
   }
}