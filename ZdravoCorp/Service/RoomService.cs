/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class RoomService
    {
        private static RoomService instance = null;
        private static readonly object key = new object();
        public Boolean CreateRoom(Room newRoom)
        {
            return RoomRepository.Instance.CreateRoom(newRoom);
        }

        public Room ReadRoom(String identifier)
        {
            return RoomRepository.Instance.ReadRoom(identifier);
        }

        public Boolean UpdateRoom(Room updatedRoom)
        {
            return RoomRepository.Instance.UpdateRoom(updatedRoom);
        }

        public Boolean DeleteRoom(int identifier)
        {
            return RoomRepository.Instance.DeleteRoom(identifier);
        }

        public List<Room> GetRoomsByInternalID(HashSet<int> identifiers)
        {
            return RoomRepository.Instance.GetRoomsByInternalID(identifiers);
        }

        public List<Room> GetAllRooms()
        {
            return RoomRepository.Instance.GetAllRooms();
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

        public RoomService()
        {
            
        }
        public static RoomService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new RoomService();
                        }
                    }
                }
                return instance;
            }
        }

        
    }
}