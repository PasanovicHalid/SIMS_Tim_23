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
using ZdravoCorp.View.ViewModel;

namespace Service
{
    public class RoomService
    {
        private static RoomService instance = null;
        private ActionService actionService;
        private static readonly object key = new object();
        public Boolean CreateRoom(Room newRoom)
        {
            return RoomRepository.Instance.CreateRoom(newRoom);
        }

        public Room ReadRoom(String identifier)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateRoom(Room updatedRoom)
        {
            return RoomRepository.Instance.UpdateRoom(updatedRoom);
        }

        public Boolean DeleteRoom(int identifier)
        {
            return RoomRepository.Instance.DeleteRoom(identifier);
        }

        public Boolean RenovateRoom(int identifier, DateTime start, DateTime end)
        {
            return actionService.CreateAction(new Model.Action(ActionType.renovation, start, new RenovationAction(end, identifier, true)));
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
            return RoomRepository.Instance.CreateRoomType(newRoomType);
        }

        public Boolean UpdateRoomType(Model.RoomType roomType)
        {
            return RoomRepository.Instance.UpdateRoomType(roomType);
        }

        public Boolean DeleteRoomType(Model.RoomType roomType)
        {
            return RoomRepository.Instance.DeleteRoomType(roomType);
        }

        public Model.RoomType ReadRoomType(Model.RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public List<RoomType> GetAllRoomType()
        {
            return RoomRepository.Instance.GetAllRoomType();
        }

        public ObservableCollection<RoomTypeVO> GetAllRoomTypeView()
        {
            List<RoomType> types = RoomRepository.Instance.GetAllRoomType();
            ObservableCollection<RoomTypeVO> result = new ObservableCollection<RoomTypeVO>();
            foreach(RoomType roomType in types)
            {
                result.Add(new RoomTypeVO(roomType.Name));
            }
            return result;
        }

        public Boolean AddEquipment(Equipment equipment, int id)
        {
            return RoomRepository.Instance.AddEquipment(equipment, id);
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

        
    }
}