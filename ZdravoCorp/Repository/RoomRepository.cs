/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;

namespace Repository
{
   public class RoomRepository
   {
        private String dbPath;
        private Serializer<Room> serializer;

        public RoomRepository()
        {
            dbPath = "Resourses\\roomsCSV.csv";
            serializer = new Serializer<Room>();
        }

        public Boolean CreateRoom(Model.Room newRoom)
        {
            List<Room> rooms = serializer.FromCSV(dbPath);
            bool found = false;
            foreach (Room room in rooms)
            {
                if (newRoom.Identificator.Equals(room.Identificator))
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                return false;
            }
            else
            {
                List<Room> temp = new List<Room> { newRoom };
                serializer.ToCSVAppend(dbPath, temp);
                return true;
            }
        }
      
        public Model.Room ReadRoom(String identifier)
        {
            List<Room> rooms = serializer.FromCSV(dbPath);
            foreach (Room room in rooms)
            {
                if (identifier.Equals(room.Identificator))
                {
                    return room;
                }
            }
            return null;
        }
      
        public Boolean UpdateRoom(Model.Room updatedRoom, string identificator)
        {
            List<Room> rooms = serializer.FromCSV(dbPath);

            bool found = false;
            foreach (Room room in rooms)
            {
                if (identificator.Equals(room.Identificator))
                {
                    rooms.Remove(room);
                    found = true;
                    break;
                }
            }
            bool exists = false;
            foreach (Room room in rooms)
            {
                if (updatedRoom.Identificator.Equals(room.Identificator))
                {
                    exists = true;
                    break;
                }
            }

            if (!found || exists)
            {
                return false;
            }
            else
            {
                rooms.Add(updatedRoom);
                serializer.ToCSV(dbPath, rooms);
                return true;
            }

        }
      
        public Boolean DeleteRoom(String identifier)
        {
            bool deleted = false;
            List<Room> rooms = serializer.FromCSV(dbPath);
            foreach (Room room in rooms)
            {
                if (identifier.Equals(room.Identificator))
                {
                    rooms.Remove(room);
                    deleted = true;
                    break;
                }
            }
            if (deleted)
            {
                serializer.ToCSV(dbPath, rooms);
                return true;
            }
            else
            {
                return false;
            }
        }
      
        public List<Room> GetAllRooms()
        {
            return serializer.FromCSV(dbPath);
        }
   
   }
}