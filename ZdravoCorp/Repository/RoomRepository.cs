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
        private Serializer<Appointment> serializer1;

        public RoomRepository()
        {
            dbPath = "Resourses\\roomsCSV.csv";
            serializer = new Serializer<Room>();
            serializer1 = new Serializer<Appointment>();
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
                List<Appointment> appoint = serializer1.FromCSV("Resourses\\appointmentCSV.csv");
                foreach (Appointment appointment in appoint)
                {
                    if (appointment.RoomID.Equals(identificator))
                    {
                        appointment.RoomID = updatedRoom.Identificator;
                    }
                }
                serializer1.ToCSV("Resourses\\appointmentCSV.csv", appoint);

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
                List<Appointment> appoint = serializer1.FromCSV("Resourses\\appointmentCSV.csv");
                List<int> ids = new List<int>();
                for (int i = 0; i < appoint.Count; i++)
                {
                    if (appoint[i].RoomID.Equals(identifier))
                    {
                        ids.Add(i);
                    }
                }
                for (int i = 0; i < ids.Count; i++)
                {
                    appoint.RemoveAt(ids[i]);
                }
                if(ids.Count > 0)
                {
                    serializer1.ToCSV("Resourses\\appointmentCSV.csv", appoint);
                }
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