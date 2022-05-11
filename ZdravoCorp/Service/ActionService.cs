// File:    ActionService.cs
// Author:  halid
// Created: Sunday, 24 April 2022 22:50:44
// Purpose: Definition of Class ActionService

using Repository;
using System;
using System.Collections.Generic;
using Model;
using ZdravoCorp.Utility;
using System.Threading;
using System.Collections.ObjectModel;
using ZdravoCorp.View.Manager.Model.Equipment;
using ZdravoCorp.View.Manager.Model.Room;

namespace Service
{

    public class ActionService
    {
        public void CheckActions(Object stateInfo)
        {
            Console.WriteLine("{0} Timer activated", DateTime.Now.ToString("h:mm:ss.fff"));

            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            List<Model.Action> actions = GetAllActions();
            List<Model.Action> removed = new List<Model.Action>();

            DateTime now = DateTime.Now;
            for (int i = 0; i < actions.Count; i++)
            {
                if (DateManipulator.checkIfLaterDate(now, actions[i].ExecutionDate))
                {
                    switch (actions[i].Type)
                    {
                        case ActionType.changePosition:
                            removed.Add(actions[i]);
                            if (!executeChangePosition((ChangeRoomAction)actions[i].Object))
                            {
                                removeExecutedActions(removed);
                                Console.WriteLine("\nError when executing ChangePosition Action\nShuting down Thread\n");
                                autoEvent.Set();
                                return;
                            }
                            break;
                        case ActionType.renovation:
                            removed.Add(actions[i]);
                            if (!executeRenovation((RenovationAction)actions[i].Object))
                            {
                                removeExecutedActions(removed);
                                Console.WriteLine("\nError when executing Renovation Action\nShuting down Thread\n");
                                autoEvent.Set();
                                return;
                            }
                            break;
                    }
                }
                else
                {
                    if(removed.Count != 0)
                        removeExecutedActions(removed);
                    break;
                }
            }
            if (removed.Count != 0)
                removeExecutedActions(removed);
        }
        public Boolean CreateAction(Model.Action newAction)
        {
            return ActionRepository.Instance.CreateAction(newAction);
        }

        public Boolean UpdateAction(Model.Action action)
        {
            return ActionRepository.Instance.UpdateAction(action);
        }

        public Boolean UpdateRenovationAction(RenovationActionModel action)
        {
            Model.Action temp = ReadAction(action.Id);

            temp.ExecutionDate = action.ExecutionDate;
            RenovationAction renovationAction = new RenovationAction(action.ExpirationDate, action.Id_room, action.Renovation);
            temp.Object = renovationAction;


            return ActionRepository.Instance.UpdateAction(temp);
        }

        public Boolean UpdateChangeAction(ChangeActionModel action, int count)
        {
            Model.Action temp = ReadAction(action.Id);
            temp.ExecutionDate = action.ExecutionDate;
            ChangeRoomAction renovationAction = new ChangeRoomAction(action.Id_incoming_room, action.Id_outgoing_room, action.Id_equipment, action.Count);
            temp.Object = renovationAction;

            Room room = RoomService.Instance.ReadRoom(action.Id_outgoing_room);
            for (int i = 0; i < room.Equipment.Count; i++)
            {
                if (room.Equipment[i].Identifier == action.Id_equipment)
                {
                    room.Equipment[i].Actual_count += count;
                    break;
                }
            }

            if (!ActionRepository.Instance.UpdateAction(temp))
            {
                return false;
            }
            else
            {
                return RoomService.Instance.UpdateRoom(room);
            }
        }

        public Boolean DeleteRenovationAction(RenovationActionModel action)
        {
            if (!DeleteAction(action.Id))
            {
                return false;
            }
            else
            {
                Room room = RoomService.Instance.ReadRoom(action.Id_room);
                room.Renovating = false;
                return RoomService.Instance.UpdateRoom(room);
            }
        }

        public Boolean DeleteChangeAction(ChangeActionModel action)
        {
            if(!DeleteAction(action.Id))
            {
                return false;
            }
            else
            {
                Room room = RoomService.Instance.ReadRoom(action.Id_outgoing_room);
                for (int i = 0; i < room.Equipment.Count; i++) 
                { 
                    if(room.Equipment[i].Identifier == action.Id_equipment)
                    {
                        room.Equipment[i].Actual_count += action.Count;
                        break;
                    }
                }
                return RoomService.Instance.UpdateRoom(room);
            }
        }

        public Boolean DeleteAction(int identificator)
        {
            return ActionRepository.Instance.DeleteAction(identificator);
        }

        public Model.Action ReadAction(int identificator)
        {
            return ActionRepository.Instance.ReadAction(identificator);
        }

        public List<Model.Action> GetAllActions()
        {
            return ActionRepository.Instance.GetAllActions();
        }

        public ObservableCollection<RenovationActionModel> GetAllRenovationActions()
        {
            List<Model.Action> actions = GetAllActions();
            ObservableCollection<RenovationActionModel> result = new ObservableCollection<RenovationActionModel>();
            RenovationAction renovation;
            foreach (Model.Action action in actions)
            {
                if(action.Type == ActionType.renovation)
                {
                    renovation = (RenovationAction)action.Object;
                    result.Add(new RenovationActionModel(action.Id, action.ExecutionDate, renovation.ExpirationDate, RoomService.Instance.ReadRoom(renovation.Id_room).DesignationCode,renovation.Id_room, renovation.Renovation));
                }
            }
            return result;
        }

        public ObservableCollection<ChangeActionModel> GetAllChangeRoomActions()
        {
            List<Model.Action> actions = GetAllActions();
            ObservableCollection<ChangeActionModel> result = new ObservableCollection<ChangeActionModel>();
            ChangeRoomAction changeRoomAction;
            foreach(Model.Action action in actions)
            {
                if(action.Type == ActionType.changePosition)
                {
                    changeRoomAction = (ChangeRoomAction) action.Object;
                    result.Add(new ChangeActionModel(action.Id, action.ExecutionDate, changeRoomAction.Id_incoming_room, changeRoomAction.Id_outgoing_room, changeRoomAction.Id_equipment, changeRoomAction.Count, RoomService.Instance.ReadRoom(changeRoomAction.Id_incoming_room).DesignationCode, RoomService.Instance.ReadRoom(changeRoomAction.Id_outgoing_room).DesignationCode, EquipmentService.Instance.ReadEquipmentType(changeRoomAction.Id_equipment).Name));
                }
            }

            return result;
        }

        public void SaveActions(List<Model.Action> actions)
        {
            ActionRepository.Instance.SaveActions(actions);
        }

        private Boolean executeChangePosition(ChangeRoomAction action)
        {
            HashSet<int> getter = new HashSet<int>();
            getter.Add(action.Id_incoming_room);
            getter.Add(action.Id_outgoing_room);

            //Get 2 rooms
            List<Room> rooms = RoomService.Instance.GetRoomsByInternalID(getter);

            if(rooms.Count != 2)
            {
                return false;
            }

            Room incoming_room;
            Room outgoing_room;

            //Set variables
            if (rooms[0].Identifier == action.Id_incoming_room)
            {
                incoming_room = rooms[0];
                outgoing_room = rooms[1];
            }
            else
            {
                incoming_room = rooms[1];
                outgoing_room = rooms[0];
            }

            //Changing outgoing room
            foreach(Equipment it in outgoing_room.Equipment)
            {
                if(it.Identifier == action.Id_equipment)
                {
                    if(it.Count > action.Count)
                    {
                        it.Count -= action.Count;
                        outgoing_room.EditEquipment(it);
                        break;
                    }
                    else
                    {
                        outgoing_room.RemoveEquipment(it);
                        break;
                    }
                }
            }
            //Changing incoming room
            //Bool for if equipmentType doesnt exist
            bool found = false;
            foreach(Equipment it in incoming_room.Equipment)
            {
                if(it.Identifier == action.Id_equipment)
                {
                    found = true;
                    it.Count += action.Count;
                    it.Actual_count += action.Count;
                    incoming_room.EditEquipment(it);
                    break;
                }
            }
            if (!found)
            {
                incoming_room.AddEquipment(new Equipment(action.Count, action.Count, EquipmentService.Instance.ReadEquipmentType(action.Id_equipment)));
            }

            if (!RoomService.Instance.UpdateRoom(incoming_room))
            {
                return false;
            }
            if (!RoomService.Instance.UpdateRoom(outgoing_room))
            {
                return false;
            }
            return true;
        }

        private Boolean executeRenovation(RenovationAction action)
        {
            HashSet<int> getter = new HashSet<int>();
            getter.Add(action.Id_room);

            List<Room> rooms = RoomService.Instance.GetRoomsByInternalID(getter);

            if(rooms.Count != 1)
            {
                return false;
            }

            if(action.Renovation == true)
            {
                rooms[0].Renovating = true;
                rooms[0].RenovatedUntil = action.ExpirationDate;
                if (!RoomService.Instance.UpdateRoom(rooms[0]))
                {
                    return false;
                }
                return CreateAction(new Model.Action(ActionType.renovation, action.ExpirationDate, new RenovationAction(new DateTime(), action.Id_room, false)));
            }
            else
            {
                rooms[0].Renovating = false;
                return RoomService.Instance.UpdateRoom(rooms[0]);
            }
        }

        private void removeExecutedActions(List<Model.Action> removed)
        {
            List<Model.Action> actions = GetAllActions();
            foreach (Model.Action it in removed)
            {
                foreach(Model.Action action in actions)
                {
                    if(it.Id == action.Id)
                    {
                        actions.Remove(action);
                        break;
                    }
                }
            }
            SaveActions(actions);
        }
    }
}