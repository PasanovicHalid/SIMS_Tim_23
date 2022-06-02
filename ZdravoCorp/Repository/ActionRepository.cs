// File:    ActionRepository.cs
// Author:  halid
// Created: Sunday, 24 April 2022 22:59:45
// Purpose: Definition of Class ActionRepository

using System;
using System.Collections.Generic;
using ZdravoCorp.Utility;
using System.Linq;
using ZdravoCorp.Exceptions;

namespace Repository
{
    //Sequencial Data Base
    public class ActionRepository
    {
        private String dbPath = "..\\..\\Data\\actionsDB.csv";
        private Serializer<Model.Action> serializerAction = new Serializer<Model.Action>();
        private HashSet<int> idMap;

        private static ActionRepository instance = null;

        private static readonly object key = new object();

        public ActionRepository()
        {
            idMap = new HashSet<int>();
            List<Model.Action> actions = serializerAction.FromCSV(dbPath);
            foreach (Model.Action action in actions)
            {
                idMap.Add(action.Id);
            }
        }

        public void CreateAction(Model.Action newAction)
        {
            lock (key)
            {
                newAction.Id = GenerateID();
                List<Model.Action> actions = serializerAction.FromCSV(dbPath);
                AddAction(newAction, actions);
                serializerAction.ToCSV(dbPath, actions);
                idMap.Add(newAction.Id);
            }
        }

        private void SwapActions(Model.Action action, List<Model.Action> actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                if (actions[i].Id == action.Id)
                {
                    actions[i] = action;
                    return;
                }
            }
            throw new LocalisedException("ActionDoesntExist");
        }

        public void UpdateAction(Model.Action action)
        {
            lock (key)
            {
                List<Model.Action> actions = serializerAction.FromCSV(dbPath);
                SwapActions(action, actions);
                SortActionsAscending(actions);
            }
        }

        public void DeleteAction(int id)
        {
            lock (key)
            {
                List<Model.Action> actions = serializerAction.FromCSV(dbPath);
                RemoveActionByID(id, actions);
                serializerAction.ToCSV(dbPath, actions);
                idMap.Remove(id);
            }
        }

        public void SaveActions(List<Model.Action> actions)
        {
            lock (key)
            {
                serializerAction.ToCSV(dbPath, actions);
            }
        }

        public Model.Action ReadAction(int id)
        {
            lock (key)
            {
                if (!idMap.Contains(id))
                {
                    throw new LocalisedException("ActionDoesntExist");
                }
                List<Model.Action> actions = serializerAction.FromCSV(dbPath);
                return FindActionByID(id, actions);
            }
        }

        public List<Model.Action> GetAllActions()
        {
            lock (key)
            {
                return serializerAction.FromCSV(dbPath);
            }
        }

        private int GenerateID()
        {
            Random random = new Random();
            int id;
            do
            {
                id = random.Next();
            }
            while (idMap.Contains(id));
            idMap.Add(id);
            return id;
        }

        /*
         * Add action sorted by excecution date ascending
        */
        private void AddAction(Model.Action newAction, List<Model.Action> actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                if (DateManipulator.checkIfLaterDate(actions[i].ExecutionDate, newAction.ExecutionDate))
                {
                    actions.Insert(i, newAction);
                    return;
                }
            }
            actions.Add(newAction);
        }

        private void SortActionsAscending(List<Model.Action> actions)
        {
            serializerAction.ToCSV(dbPath, actions.OrderBy(a => a.ExecutionDate).ToList());
        }

        private Model.Action FindActionByID(int id, List<Model.Action> actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                if (actions[i].Id == id)
                {
                    return actions[i];
                }
            }
            throw new LocalisedException("ActionDoesntExist");
        }

        private void RemoveActionByID(int id, List<Model.Action> actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                if (actions[i].Id == id)
                {
                    actions.RemoveAt(i);
                    return;
                }
            }
            throw new LocalisedException("ActionDoesntExist");
        }

        public static ActionRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new ActionRepository();
                        }
                    }
                }
                return instance;
            }
        }

    }
}