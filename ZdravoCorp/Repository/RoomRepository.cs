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
        private static readonly object key = new object();

        private HashSet<int> idMap;

        private static RoomRepository instance = null;

        public Boolean CreateRoom(Room newRoom)
        {
            lock (key) 
            {
                Random random = new Random();
                do
                {
                    newRoom.Identifier = random.Next();
                }
                while (idMap.Contains(newRoom.Identifier));

                List<Room> rooms = serializerRoom.FromCSV(dbPath);

                //Checking if the Designation Code of the new Room exists
                bool exists = false;
                foreach (Room room in rooms)
                {
                    if (newRoom.DesignationCode.Equals(room.DesignationCode))
                    {
                         exists = true;
                         break;
                    }
                }

                if (!exists)
                {
                    rooms.Add(newRoom);
                    serializerRoom.ToCSV(dbPath, rooms);
                    idMap.Add(newRoom.Identifier);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Gets Rooms by internal ID
        //Returns List of rooms if found
        //Returns empty List if not found
        public List<Room> GetRoomsByInternalID(HashSet<int> identifiers)
        {
            lock (key)
            {
                List<Room> rooms = serializerRoom.FromCSV(dbPath);
                List<Room> result = new List<Room>();

                foreach (Room room in rooms)
                {
                    if (identifiers.Contains(room.Identifier))
                    {
                        result.Add(room);
                    }
                }
                return result;
            }
        }

        public Model.Room ReadRoom(String identifier)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateRoom(Room updatedRoom)
        {
            lock (key)
            {
                List<Room> rooms = serializerRoom.FromCSV(dbPath);

                //Checking if Designation Code of the changed Room exists
                bool exists = false;
                foreach (Room room in rooms)
                {
                    if (updatedRoom.DesignationCode.Equals(room.DesignationCode) && room.Identifier != updatedRoom.Identifier)
                    {
                        exists = true;
                        break;
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
        }


        public Boolean DeleteRoom(int identifier)
        {
            lock (key)
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
                    idMap.Remove(identifier);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean AddEquipment(Equipment equipment, int id)
        {
            lock (key)
            {
                bool found = false;
                List<Room> rooms = serializerRoom.FromCSV(dbPath);
                for(int i = 0; i < rooms.Count; i++)
                {
                    if (id == rooms[i].Identifier)
                    {
                        found = true;
                        bool exists = false;
                        for(int j = 0; i < rooms[i].Equipment.Count; j++)
                        {
                            if(rooms[i].Equipment[j].Identifier == equipment.Identifier)
                            {
                                rooms[i].Equipment[j].Count += equipment.Count;
                                exists = true;
                                break;
                            }
                        }
                        if (!exists)
                        {
                            rooms[i].Equipment.Add(equipment);
                        }
                        break;
                    }
                }
                if (found)
                {
                    serializerRoom.ToCSV(dbPath, rooms);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Room> GetAllRooms()
        {
            lock (key)
            {
                return serializerRoom.FromCSV(dbPath);
            }
        }

        public Boolean CreateRoomType(Model.RoomType newRoomType)
        {
            lock (key)
            {

                List<RoomType> rooms = serializerRoomType.FromCSV(dbRoomTypePath);

                bool exists = false;
                foreach (RoomType room in rooms)
                {
                    if (newRoomType.Name.Equals(room.Name))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    rooms.Add(newRoomType);
                    serializerRoomType.ToCSV(dbRoomTypePath, rooms);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean UpdateRoomType(Model.RoomType roomType)
        {
            lock (key)
            {

                List<RoomType> rooms = serializerRoomType.FromCSV(dbRoomTypePath);

                bool exists = false;
                for (int i = 0; i < rooms.Count ; i++)
                {
                    if (roomType.Name.Equals(rooms[i].Name))
                    {
                        rooms[i] = roomType;
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    rooms.Add(roomType);
                    serializerRoomType.ToCSV(dbRoomTypePath, rooms);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean DeleteRoomType(Model.RoomType roomType)
        {
            lock (key)
            {

                List<RoomType> rooms = serializerRoomType.FromCSV(dbRoomTypePath);

                bool exists = false;
                foreach (RoomType room in rooms)
                {
                    if (roomType.Name.Equals(room.Name))
                    {
                        rooms.Remove(room);
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    serializerRoomType.ToCSV(dbRoomTypePath, rooms);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Model.RoomType ReadRoomType(Model.RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public List<RoomType> GetAllRoomType()
        {
            lock (key)
            {
                return serializerRoomType.FromCSV(dbRoomTypePath);
            }
        }

        public RoomRepository()
        {
            idMap = new HashSet<int>();
            List<Room> rooms = serializerRoom.FromCSV(dbPath);

            foreach(Room room in rooms)
            {
                idMap.Add(room.Identifier);
            }
        }

        public static RoomRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (key)
                        {
                            if (instance == null)
                            {
                                instance = new RoomRepository();
                            }
                        }
                }
                return instance;
            }
        }

    }
}