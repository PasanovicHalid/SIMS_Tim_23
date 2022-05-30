/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoCorp.View.Manager.Model.Rooms;

namespace Service
{
    public class RoomService
    {
        private static RoomService instance = null;
        private ActionService actionService;
        private static readonly object key = new object();
        public void CreateRoom(Room newRoom)
        {
            RoomRepository.Instance.CreateRoom(newRoom);
        }

        public Room ReadRoom(int identifier)
        {
            return RoomRepository.Instance.ReadRoom(identifier);
        }

        public Room ReadRoomByIndex(int index)
        {
            return RoomRepository.Instance.ReadRoomByIndex(index);
        }

        public void UpdateRoom(Room updatedRoom)
        {
            RoomRepository.Instance.UpdateRoom(updatedRoom);
        }

        public void DeleteRoom(int identifier)
        {
            RoomRepository.Instance.DeleteRoom(identifier);
        }

        public void RenovateRoom(int identifier, DateTime start, DateTime end)
        {
            actionService.CreateAction(new Model.Action(ActionType.renovation, start, new RenovationAction(end, identifier, true)));
        }

        public void CombineRooms(Room combineInto, Room selectedRoom)
        {
            RoomRepository.Instance.CombineRooms(combineInto, selectedRoom);
        }

        public List<Room> GetRoomsByInternalID(HashSet<int> identifiers)
        {
            return RoomRepository.Instance.GetRoomsByInternalID(identifiers);
        }

        public List<Room> GetAllRooms()
        {
            return RoomRepository.Instance.GetAllRooms();
        }

        public void CreateRoomType(Model.RoomType newRoomType)
        {
            RoomRepository.Instance.CreateRoomType(newRoomType);
        }

        public void UpdateRoomType(Model.RoomType roomType)
        {
            RoomRepository.Instance.UpdateRoomType(roomType);
        }

        public void DeleteRoomType(Model.RoomType roomType)
        {
            RoomRepository.Instance.DeleteRoomType(roomType);
        }

        public int GetMaxCountForEquipment(int id_room, int id_equipment)
        {
            return RoomRepository.Instance.GetMaxCountForEquipment(id_room, id_equipment);
        }

        public void ChangeActualCountOfEquipment(int id_from_room, int id_equipment,int count)
        {
            RoomRepository.Instance.ChangeActualCountOfEquipment(id_from_room, id_equipment, count);
        }

        public Model.RoomType ReadRoomType(Model.RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public List<RoomType> GetAllRoomType()
        {
            return RoomRepository.Instance.GetAllRoomType();
        }


        public ObservableCollection<RoomTypeModel> GetAllRoomTypeView()
        {
            List<RoomType> types = RoomRepository.Instance.GetAllRoomType();
            ObservableCollection<RoomTypeModel> result = new ObservableCollection<RoomTypeModel>();
            foreach(RoomType roomType in types)
            {
                result.Add(new RoomTypeModel(roomType.Name));
            }
            return result;
        }

        public void AddEquipment(Equipment equipment, int id)
        {
            RoomRepository.Instance.AddEquipment(equipment, id);
        }

        public int GetRoomIndex(Model.Room room)
        {
            return RoomRepository.Instance.GetRoomIndex(room);
        }

        public RoomService()
        {
            actionService = new ActionService();
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
        public Room findFreeRoom(DateTime start, DateTime end) 
        {
            Room freeRoom = null;

            
            List<Room> rooms = GetAllRooms();
            foreach (Room room in rooms)
            {
                List<DateTime> datesStart = new List<DateTime>();
                List<DateTime> datesEnd = new List<DateTime>();

                Boolean appOk = false;
                Boolean renovationOk = false;
                foreach (Appointment a in room.Appointment)
                {
                    //if ((start < a.StartDate) && (end < a.StartDate))
                    //{
                    //    freeRoom = room;
                    //    appOk = true;
                    //    break;
                    //}
                    //else if ((start > a.EndDate))
                    //{
                    //    freeRoom = room;
                    //    appOk = true;
                    //    break;
                    //}
                    datesStart.Add(a.StartDate);
                    datesEnd.Add(a.endDate);
                }
                if(!(datesStart.Contains(start) || datesEnd.Contains(end)))
                {
                    appOk = true;
                }
                if (!room.Renovating)
                {
                    renovationOk = true;
                }
                if(appOk && renovationOk)
                {
                    freeRoom = room;
                }
            }
            
            return freeRoom;
        }
        
    }
}