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
    public class ActionRepository : Repository<Model.Action>
    {
        private static ActionRepository instance = null;
        public ActionRepository()
        {
            dbPath = "..\\..\\Data\\actionsDB.csv";
            InstantiateIDSet(GetAll());
        }

        public override Model.Action Read(int id)
        {
            lock (key)
            {
                CheckIfIDExists(id);
                List<Model.Action> actions = GetAll();
                return FindActionByID(id, actions);
            }
        }

        public override void Create(Model.Action element)
        {
            lock (key)
            {
                element.Id = GenerateID();
                List<Model.Action> actions = GetAll();
                AddAction(element, actions);
                SaveChanges(actions);
                idMap.Add(element.Id);
            }
        }

        public override void Update(Model.Action element)
        {
            lock (key)
            {
                List<Model.Action> actions = GetAll();
                SwapActions(element, actions);
                SortActionsAscendingAndSaveChanges(actions);
            }
        }

        public override void Delete(int id)
        {
            lock (key)
            {
                List<Model.Action> actions = GetAll();
                RemoveActionByID(id, actions);
                SaveChanges(actions);
                idMap.Remove(id);
            }
        }

        public void SaveActions(List<Model.Action> actions)
        {
            lock (key)
            {
                SaveChanges(actions);
            }
        }

        protected override void InstantiateIDSet(List<Model.Action> elements)
        {
            lock (key)
            {
                foreach (Model.Action element in elements)
                {
                    idMap.Add(element.Id);
                }
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

        private void CheckIfIDExists(int id)
        {
            if (!idMap.Contains(id))
                throw new LocalisedException("ActionDoesntExist");
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

        private void SortActionsAscendingAndSaveChanges(List<Model.Action> actions)
        {
            serializer.ToCSV(dbPath, actions.OrderBy(a => a.ExecutionDate).ToList());
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