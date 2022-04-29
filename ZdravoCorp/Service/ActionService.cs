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

namespace Service
{
    public class ActionService
    {
        public void CheckActions(Object stateInfo)
        {
            Console.WriteLine("{0} Timer activated", DateTime.Now.ToString("h:mm:ss.fff"));

            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            List<Model.Action> actions = GetAllActions();
            List<int> removed = new List<int> ();

            DateTime now = DateTime.Now;
            for (int i = 0; i < actions.Count; i++)
            {
                if (DateManipulator.checkIfLaterDate(now, actions[i].ExecutionDate))
                {
                    switch (actions[i].Type)
                    {
                        case ActionType.changePosition:
                            removed.Add(i);
                            if (!executeChangePosition((ChangeRoomAction)actions[i].Object))
                            {
                                autoEvent.Set();
                                removeExecutedActions(actions, removed);
                                Console.WriteLine("\nError when executing ChangePosition Action\nShuting down Thread\n");
                                return;
                            }
                            break;
                        case ActionType.renovation:
                            removed.Add(i);
                            if (!executeRenovation((RenovationAction)actions[i].Object))
                            {
                                autoEvent.Set();
                                removeExecutedActions(actions, removed);
                                Console.WriteLine("\nError when executing Renovation Action\nShuting down Thread\n");
                                return;
                            }
                            break;
                    }
                }
                else
                {
                    removeExecutedActions(actions, removed);
                    break;
                }
            }
        }
        public Boolean CreateAction(Model.Action newAction)
        {
            return ActionRepository.Instance.CreateAction(newAction);
        }

        public Boolean UpdateAction(Model.Action action)
        {
            return ActionRepository.Instance.UpdateAction(action);
        }

        public Boolean DeleteAction(int identificator)
        {
            return ActionRepository.Instance.DeleteAction(identificator);
        }

        public Model.Action ReadAction(int identificator)
        {
            throw new NotImplementedException();
        }

        public List<Model.Action> GetAllActions()
        {
            return ActionRepository.Instance.GetAllActions();
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
                    incoming_room.EditEquipment(it);
                    break;
                }
            }
            if (!found)
            {
                incoming_room.AddEquipment(new Equipment(action.Count, EquipmentRepository.Instance.ReadEquipmentType(action.Id_equipment)));
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
            return true;
        }

        private void removeExecutedActions(List<Model.Action> actions, List<int> removed)
        {
            foreach(int id in removed)
            {
                actions.RemoveAt(id);
            }
            SaveActions(actions);
        }
    }
}