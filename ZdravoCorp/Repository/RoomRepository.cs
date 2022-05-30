/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using ZdravoCorp.Exceptions;

namespace Repository
{
    public class RoomRepository
    {
        private String dbPath = "..\\..\\Data\\roomsDB.csv";
        private String dbRoomTypePath = "..\\..\\Data\\roomTypesDB.csv";
        private Serializer<Room> serializerRoom = new Serializer<Room>();
        private Serializer<RoomType> serializerRoomType = new Serializer<RoomType>();
        private HashSet<int> idMap;
        private static readonly object key = new object();
        private static RoomRepository instance = null;  

        public void CreateRoom(Room newRoom)
        {
            lock (key)
            {
                newRoom.Identifier = GenerateId();
                List<Room> rooms = serializerRoom.FromCSV(dbPath);
                CheckIfDesignationCodeExists(newRoom.DesignationCode, rooms);
                serializerRoom.ToCSVAppend(dbPath, new List<Room> { newRoom });
                idMap.Add(newRoom.Identifier);
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
            lock (key)
            {
                Dictionary<int, Room> rooms = serializerRoom.FromCSV(dbPath).ToDictionary(keySelector: m => m.Identifier, elementSelector: m => m);
                Dictionary<int, EquipmentType> types = EquipmentRepository.Instance.GetAllEquipmentType().ToDictionary(keySelector: m => m.Identifier, elementSelector: m => m);
                Dictionary<int, Appointment> appointments = AppointmentRepository.Instance.GetAllAppointments().ToDictionary(keySelector: m => m.Id, elementSelector: m => m);
                if (!rooms.ContainsKey(identifier))
                {
                    throw new LocalisedException("RoomIdDoesntExist");
                }
                Room room = rooms[identifier];
                LoadEquipmentTypesForRoom(room, types);
                LoadAppointmentsForRoom(room, appointments);
                return room;
            }
        }

        public void UpdateRoom(Room updatedRoom)
        {
            lock (key)
            {
                List<Room> rooms = serializerRoom.FromCSV(dbPath);
                CheckIfChangedDesignationCodeExists(updatedRoom, rooms);
                ReplaceRoomByID(rooms, updatedRoom);
                serializerRoom.ToCSV(dbPath, rooms);
            }
        }

        private void AddEquipmentToRoom(Room room, Equipment equipment)
        {
            bool exists = false;
            for (int i = 0; i < room.Equipment.Count; i++)
            {
                if (room.Equipment[i].Identifier == equipment.Identifier)
                {
                    room.Equipment[i].Count += equipment.Count;
                    room.Equipment[i].Actual_count += equipment.Actual_count;
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                room.Equipment.Add(equipment);
            }
        }

        public void AddEquipment(Equipment equipment, int room_id)
        {
            lock (key)
            {
                bool found = false;
                List<Room> rooms = serializerRoom.FromCSV(dbPath);
                Room room = FindRoomByID(room_id, rooms);
                AddEquipmentToRoom(room, equipment);
                serializerRoom.ToCSV(dbPath, rooms);
            }
        }

        public List<Room> GetAllRooms()
        {
            lock (key)
            {
                List<Room> result = serializerRoom.FromCSV(dbPath);
                Dictionary<int, EquipmentType> types = EquipmentRepository.Instance.GetAllEquipmentType().ToDictionary(keySelector: m => m.Identifier, elementSelector: m => m);
                Dictionary<int, Appointment> appointments = AppointmentRepository.Instance.GetAllAppointments().ToDictionary(keySelector: m => m.Id, elementSelector: m => m);
                foreach(Room room in result)
                {
                    LoadEquipmentTypesForRoom(room, types);
                    LoadAppointmentsForRoom(room, appointments);
                }
                return result;
            }
        }

        public void CombineRooms(Room combineInto, Room selectedRoom)
        {
            MoveEquipment(combineInto, selectedRoom);
            MoveAppointements(combineInto, selectedRoom);
            MoveMedications(combineInto, selectedRoom);
            combineInto.SurfaceArea += selectedRoom.SurfaceArea;
            DeleteRoom(selectedRoom.Identifier);
            UpdateRoom(combineInto);
        }

        public void CreateRoomType(Model.RoomType newRoomType)
        {
            lock (key)
            {

                List<RoomType> types = serializerRoomType.FromCSV(dbRoomTypePath);
                if(CheckIfRoomTypeExists(types, newRoomType))
                {
                    throw new LocalisedException("RoomTypeAlreadyExists");
                }
                types.Add(newRoomType);
                serializerRoomType.ToCSV(dbRoomTypePath, types);
            }
        }

        private void SwapRoomTypes(RoomType swappedInto, RoomType type)
        {

        }

        //Ova funckija ima logicku gresku ne koristiti
        //Greska je to sto roomType samo sadryi izmenjeno ime
        //a ne mozemo da nadjemo prethodno ime u bazi jer nemamo taj podatak
        public Boolean UpdateRoomType(Model.RoomType roomType)
        {
            throw new NotImplementedException();
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

        public void DeleteRoomType(Model.RoomType roomType)
        {
            lock (key)
            {
                List<RoomType> rooms = serializerRoomType.FromCSV(dbRoomTypePath);
                RemoveType(rooms, roomType);
                serializerRoomType.ToCSV(dbRoomTypePath, rooms);
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

        public void ChangeActualCountOfEquipment(int id_from_room, int id_equipment, int count)
        {
            lock (key)
            {
                List<Room> rooms = GetAllRooms();
                Room room = FindRoomByID(id_from_room, rooms);
                ChangeActualCountInRoom(room, count, id_equipment);
            }
        }

        public List<RoomType> GetAllRoomType()
        {
            lock (key)
            {
                return serializerRoomType.FromCSV(dbRoomTypePath);
            }
        }

        private void CheckIfChangedDesignationCodeExists(Room updatedRoom, List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                if (updatedRoom.DesignationCode.Equals(room.DesignationCode) && room.Identifier != updatedRoom.Identifier)
                {
                    throw new LocalisedException("RoomDesignationExists");
                }
            }
        }

        private void ReplaceRoomByID(List<Room> rooms, Room room)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (room.Identifier == rooms[i].Identifier)
                {
                    rooms[i] = room;
                    return;
                }
            }
            throw new LocalisedException("RoomIdDoesntExist");
        }

        private void LoadEquipmentTypesForRoom(Room room, Dictionary<int, EquipmentType> types)
        {
            for (int i = 0; i < room.Equipment.Count; i++)
            {
                if (types.ContainsKey(room.Equipment[i].Identifier))
                {
                    room.Equipment[i].EquipmentType = types[room.Equipment[i].Identifier];
                }
            }
        }

        private void LoadAppointmentsForRoom(Room room, Dictionary<int, Appointment> appointments)
        {
            for (int i = 0; i < room.Appointment.Count; i++)
            {
                if (appointments.ContainsKey(room.Appointment[i].Id))
                {
                    room.Appointment[i] = appointments[room.Appointment[i].Id];
                }
            }
        }

        private int GenerateId()
        {
            Random random = new Random();
            int id;
            do
            {
                id = random.Next();
            }
            while (idMap.Contains(id));
            return id;
        }

        private void CheckIfDesignationCodeExists(string designation, List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                if (room.DesignationCode.Equals(designation))
                {
                    throw new LocalisedException("RoomDesignationExists");
                }
            }
        }

        private void FindAndDeleteRoomByID(int id, List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                if (id == room.Identifier)
                {
                    rooms.Remove(room);
                    return;
                }
            }
            throw new LocalisedException("RoomIdDoesntExist");
        }

        public void DeleteRoom(int id)
        {
            lock (key)
            {
                List<Room> rooms = serializerRoom.FromCSV(dbPath);
                FindAndDeleteRoomByID(id, rooms);
                serializerRoom.ToCSV(dbPath, rooms);
                idMap.Remove(id);
            }
        }

        private Room FindRoomByID(int id, List<Room> rooms)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (id == rooms[i].Identifier)
                {
                    return rooms[i];
                }
            }
            throw new LocalisedException("RoomIdDoesntExist");
        }

        private void MoveEquipment(Room into, Room from)
        {
            foreach (Equipment equipment in from.Equipment)
            {
                into.Equipment.Add(equipment);
            }
        }

        private void MoveAppointements(Room into, Room from)
        {
            foreach (Appointment appointment in from.Appointment)
            {
                into.Appointment.Add(appointment);
            }
        }

        private void MoveMedications(Room into, Room from)
        {
            foreach (Medication medication in from.Medication)
            {
                into.Medication.Add(medication);
            }
        }

        private bool CheckIfRoomTypeExists(List<RoomType> types, RoomType type)
        {
            foreach (RoomType it in types)
            {
                if (it.Name.Equals(type.Name))
                {
                    return true;
                }
            }
            return false;
        }

        private void RemoveType(List<RoomType> types, RoomType roomType)
        {
            foreach (RoomType type in types)
            {
                if (roomType.Name.Equals(type.Name))
                {
                    types.Remove(type);
                    return;
                }
            }
            throw new LocalisedException("RoomTypeDoesntExists");
        }

        private void ChangeActualCountInRoom(Room room, int count, int id_equipment)
        {
            for (int i = 0; i < room.Equipment.Count; i++)
            {
                if (room.Equipment[i].Identifier.Equals(id_equipment))
                {
                    room.Equipment[i].Actual_count += count;
                    return;
                }
            }
            throw new LocalisedException("EquipmentDoesntExist");
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