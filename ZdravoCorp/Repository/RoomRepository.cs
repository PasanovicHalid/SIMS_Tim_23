/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Model.Room ReadRoomByIndex(int index)
        {
            lock (key)
            {
                List<Room> rooms = serializerRoom.FromCSV(dbPath);
                int i = 0;

                foreach (Room room in rooms)
                {
                    if (i == index)
                    {
                        return room;
                    }
                    i++;
                }
                return null;
            }
        }

        public int GetRoomIndex(Model.Room room)
        {
            lock (key)
            {
                List<Room> rooms = serializerRoom.FromCSV(dbPath);
                int i = 0;

                foreach (Room rom in rooms)
                {
                    if (room.Identifier == rom.Identifier)
                    {
                        return i;
                    }
                    i++;
                }
                return -1;
            }
        }

        public Model.Room ReadRoom(int identifier)
        {
            List<Room> rooms = serializerRoom.FromCSV(dbPath);

            Dictionary<int, EquipmentType> types = EquipmentRepository.Instance.GetAllEquipmentType().ToDictionary(keySelector: m => m.Identifier, elementSelector: m => m);
            List<Appointment> appointments = new List<Appointment>();
            foreach (Room room in rooms)
            {
                if (identifier ==(room.Identifier))
                {
                    foreach (Equipment equipment in room.Equipment)
                    {
                        if (types.ContainsKey(equipment.Identifier))
                        {
                            equipment.EquipmentType = types[equipment.Identifier];
                        }
                    }
                    foreach (Appointment app in room.Appointment)
                    {
                        appointments.Add(AppointmentRepository.Instance.ReadAppointment(app.Id));
                    }
                    room.Appointment = appointments;
                    return room;
                }
            }
            return null;
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
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (updatedRoom.Identifier == rooms[i].Identifier)
                        {
                            rooms[i] = updatedRoom;
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        //Publishing changes to DB
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
                        for(int j = 0; j < rooms[i].Equipment.Count; j++)
                        {
                            if(rooms[i].Equipment[j].Identifier == equipment.Identifier)
                            {
                                rooms[i].Equipment[j].Count += equipment.Count;
                                rooms[i].Equipment[j].Actual_count += equipment.Actual_count;
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
                List<Room> result = serializerRoom.FromCSV(dbPath);

                Dictionary<int, EquipmentType> types = EquipmentRepository.Instance.GetAllEquipmentType().ToDictionary(keySelector: m => m.Identifier, elementSelector: m => m);
                List<Appointment> appointments = new List<Appointment>();
                foreach(Room room in result)
                {
                    foreach(Equipment equipment in room.Equipment)
                    {
                        if (types.ContainsKey(equipment.Identifier))
                        {
                            equipment.EquipmentType = types[equipment.Identifier];
                            
                        }
                    }
                    foreach(Appointment app in room.Appointment)
                    {
                        appointments.Add(AppointmentRepository.Instance.ReadAppointment(app.Id));
                    }
                    room.Appointment = appointments;
                    appointments = new List<Appointment>();
                }
                return result;
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

        public int GetMaxCountForEquipment(int id_room, int id_equipment)
        {
            Room room = ReadRoom(id_room);
            foreach(Equipment it in room.Equipment)
            {
                if (it.Identifier.Equals(id_equipment))
                {
                    return it.Actual_count;
                }
            }
            return 0;
        }

        public Boolean ChangeActualCountOfEquipment(int id_from_room, int id_equipment, int count)
        {
            List<Room> room =GetAllRooms();
            bool found = false;
            bool added = false;
            for (int i = 0; i < room.Count; i++)
            {
                if (room[i].Identifier.Equals(id_from_room))
                {
                    found = true;
                    for (int j = 0; j < room[i].Equipment.Count; j++)
                    {
                        if (room[i].Equipment[j].Identifier.Equals(id_equipment))
                        {
                            added = true;
                            room[i].Equipment[j].Actual_count += count;
                            break;
                        }
                    }
                    if (added)
                    {
                        break;
                    }
                }
            }
            if (!found || !added)
            {
                return false;
            }
            else
            {
                serializerRoom.ToCSV(dbPath, room);
                return true;
            }
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