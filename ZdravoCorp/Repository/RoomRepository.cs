/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class RoomRepository
    {
        private String dbPath = "..\\..\\Data\\roomsDB.csv";
        private String dbRoomTypePath = "..\\..\\Data\\roomTypesDB.csv";
        private Serializer<Room> serializerRoom = new Serializer<Room>();
        private Serializer<RoomType> serializerRoomType = new Serializer<RoomType>();

        private static RoomRepository instance = null;

        public Boolean CreateRoom(Room newRoom)
        {
            List<Room> rooms = serializerRoom.FromCSV(dbPath);

            //Checking if the Designation Code of the new Room exists
            bool exists = false;
            foreach (Room room in rooms)
            {
                if (newRoom.DesignationCode.Equals(room.DesignationCode))
                {
                    if (newRoom.Identifier != room.Identifier)
                    {
                        exists = true;
                        break;
                    }
                }
            }

            if (!exists)
            {
                //Checking if the Identificator of the new Room exists 
                bool found = false;
                foreach (Room room in rooms)
                {
                    if (newRoom.Identifier == room.Identifier)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    //Publishing changes to DB
                    rooms.Add(newRoom);
                    serializerRoom.ToCSV(dbPath, rooms);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Model.Room ReadRoom(String identifier)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateRoom(Room updatedRoom)
        {
            List<Room> rooms = serializerRoom.FromCSV(dbPath);

            //Checking if Designation Code of the changed Room exists
            bool exists = false;
            foreach (Room room in rooms)
            {
                if (updatedRoom.DesignationCode.Equals(room.DesignationCode))
                {
                    if(updatedRoom.Identifier != room.Identifier)
                    {
                        exists = true;
                        break;
                    }
                }
            }

            if (!exists)
            {
                //Finding the Room in the list and removing it from the list
                bool found = false;
                foreach (Room room in rooms)
                {
                    if (updatedRoom.Identifier == room.Identifier)
                    {
                        rooms.Remove(room);
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    //Publishing changes to DB
                    rooms.Add(updatedRoom);
                    serializerRoom.ToCSV(dbPath, rooms);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Boolean DeleteRoom(int identifier)
        {
            bool deleted = false;
            List<Room> rooms = serializerRoom.FromCSV(dbPath);
            foreach (Room room in rooms)
            {
                if (identifier == room.Identifier)
                {
                    rooms.Remove(room);
                    deleted = true;
                    break;
                }
            }
            if (deleted)
            {
                serializerRoom.ToCSV(dbPath, rooms);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Room> GetAllRooms()
        {
            return serializerRoom.FromCSV(dbPath);
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

        public RoomRepository()
        {
            
        }

        public static RoomRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new RoomRepository();
                }
                return instance ;
            }
        }

    }
}