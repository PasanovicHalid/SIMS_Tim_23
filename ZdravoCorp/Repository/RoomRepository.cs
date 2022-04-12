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
            dbPath = "Resourses\\roomsCSV.txt";
            serializer = new Serializer<Room>();
        }

        public Boolean CreateRoom(Model.Room newRoom)
        {
            List<Room> temp = new List<Room>();
            temp.Add(newRoom);
            serializer.ToCSVAppend(dbPath, temp);
            return true;
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
      
        public Boolean UpdateRoom(Model.Room updatedRoom)
        {
            List<Room> rooms = serializer.FromCSV(dbPath);
            foreach (Room room in rooms)
            {
                if (updatedRoom.Identificator.Equals(room.Identificator))
                {
                    rooms.Remove(room);
                    break;
                }
            }
            rooms.Add(updatedRoom);
            serializer.ToCSV(dbPath, rooms);
            return true;
        }
      
        public Boolean DeleteRoom(String identifier)
        {
            List<Room> rooms = serializer.FromCSV(dbPath);
            foreach (Room room in rooms)
            {
                if (identifier.Equals(room.Identificator))
                {
                    rooms.Remove(room);
                    break;
                }
            }
            serializer.ToCSV(dbPath, rooms);
            return true;
        }
      
        public List<Room> GetAllRooms()
        {
            return serializer.FromCSV(dbPath);
        }
   
   }
}