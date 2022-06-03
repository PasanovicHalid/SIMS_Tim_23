// File:    ManagerRepository.cs
// Author:  halid
// Created: Saturday, 16 April 2022 01:42:18
// Purpose: Definition of Class ManagerRepository

using Model;
using System;
using System.Collections.Generic;
using ZdravoCorp.Exceptions;

namespace Repository
{
    public class ManagerRepository : UserRepository<Manager>
    {
        private static ManagerRepository instance = null;

        public ManagerRepository()
        {
            dbPath = "..\\..\\Data\\managersDB.csv";
            InstantiateHashSets(GetAll());
        }

        public Dictionary<string, Manager> GetUsernameHashSet()
        {
            return Users;
        }

        public override Manager Read(int id)
        {
            lock (key)
            {
                CheckIfIDExists(id);
                List<Manager> managers = GetAll();
                return FindManagerByID(managers, id);
            }
        }

        public override void Create(Manager element)
        {
            lock (key)
            {
                CheckIfUsernameExists(element.Username);
                element.Id = GenerateID();
                AppendToDB(element);
                Users.Add(element.Username, element);
                idMap.Add(element.Id);
            }
        }

        public override void Update(Manager element)
        {
            lock (key)
            {
                CheckIfIDExists(element.Id);
                CheckIfUsernameExists(element.Username);
                List<Manager> elements = GetAll();
                SwapManagerByID(elements, element);
                SaveChanges(elements);
            }
        }

        public override void Delete(int id)
        {
            lock (key)
            {
                CheckIfIDExists(id);
                List<Manager> managers = GetAll();
                DeleteManagerByID(managers, id);
                SaveChanges(managers);
            }
        }

        protected override void InstantiateIDSet(List<Manager> elements)
        {
            lock (key)
            {
                foreach (Manager element in elements)
                {
                    idMap.Add(element.Id);
                }
            }
        }

        private void InstantiateHashSets(List<Manager> managers)
        {
            InstantiateIDSet(managers);
            InstantiateUserSet(managers);
        }

        private void CheckIfUsernameExists(string username)
        {
            if (Users.ContainsKey(username))
                throw new LocalisedException("UserExists");
        }

        private void CheckIfIDExists(int id)
        {
            if (idMap.Contains(id))
                throw new LocalisedException("UserDoesntExist");
        }

        private Manager FindManagerByID(List<Manager> managers, int id)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id == id)
                {
                    return managers[i];
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private void SwapManagerByID(List<Manager> managers, Manager manager)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id == manager.Id)
                {
                    managers[i] = manager;
                    return;
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private void DeleteManagerByID(List<Manager> managers, int id)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id == id)
                {
                    idMap.Remove(id);
                    Users.Remove(managers[i].Username);
                    managers.RemoveAt(i);
                    return;
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        public static ManagerRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new ManagerRepository();
                        }
                    }
                }
                return instance;
            }
        }
    }
}