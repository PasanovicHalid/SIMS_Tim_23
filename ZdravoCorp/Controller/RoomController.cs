/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using Service;
using System;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoCorp.View.Manager.Model.Rooms;

namespace Controller
{
    public class RoomController : ICrud<Room>
    {

        public void Create(Room newRoom)
        {
            RoomService.Instance.Create(newRoom);
        }

        public Room Read(int identifier)
        {
            return RoomService.Instance.Read(identifier);
        }

        public void Update(Room updatedRoom)
        {
            RoomService.Instance.Update(updatedRoom);
        }

        public void Delete(int identifier)
        {
            RoomService.Instance.Delete(identifier);
        }

        public void RenovateRoom(int identifier, DateTime start, DateTime end)
        {
            RoomService.Instance.RenovateRoom(identifier, start, end);
        }

        public void CombineRooms(Room combineInto, Room selectedRoom)
        {
            RoomService.Instance.CombineRooms(combineInto, selectedRoom);
        }

        public List<Room> GetAll()
        {
            return RoomService.Instance.GetAll();
        }

        public ObservableCollection<RoomModel> GetAllRoomsVO()
        {
            List<Room> types = RoomService.Instance.GetAll();
            ObservableCollection<RoomModel> result = new ObservableCollection<RoomModel>();
            foreach (Room it in types)
            {
                result.Add(new RoomModel(it.Identifier, it.DesignationCode, it.Floor, it.SurfaceArea, it.Renovating, it.RenovatedUntil, it.RoomTypeString));
            }
            return result;
        }

        public void CreateRoomType(RoomTypeModel newRoomType)
        {
            RoomService.Instance.CreateRoomType(new RoomType(newRoomType));
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

        public int GetActualCountForEquipment(int idRoom, int idEquipment)
        {
            return RoomService.Instance.GetActualCountForEquipment(idRoom, idEquipment);
        }

        public ObservableCollection<RoomTypeModel> GetAllRoomTypeView()
        {
            return RoomService.Instance.GetAllRoomTypeView();

        }
        public Room findFreeRoom(DateTime start, DateTime end)
        {
            return RoomService.Instance.findFreeRoom(start, end);

        }
    }
}