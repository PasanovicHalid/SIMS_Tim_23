// File:    ManagerRepository.cs
// Author:  halid
// Created: Saturday, 16 April 2022 01:42:18
// Purpose: Definition of Class ManagerRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class ManagerRepository
    {
        private String dbPath = "..\\..\\Data\\managersDB.csv";
        private Serializer<Manager> serializer = new Serializer<Manager>();
        private static readonly object key = new object();
        private static ManagerRepository instance = null;

        private HashSet<int> idMap = new HashSet<int>();
        private Dictionary<string, string> userMap = new Dictionary<string, string>();

        public ManagerRepository()
        {
            List<Manager> list = GetAllManagers();
            InstantiateHashSets(list);
        }

        private void InstantiateHashSets(List<Manager> managers)
        {
            foreach (Manager manager in managers)
            {
                idMap.Add(manager.Id);
                userMap.Add(manager.Username, manager.Password);
            }
        }

        public bool CheckIfUsernameExists(string username)
        {
            return userMap.ContainsKey(username);
        }

        private bool CheckIfIDExists(int id)
        {
            return idMap.Contains(id);
        }
        
        private int GenerateID()
        {
            int id;
            Random random = new Random();
            do
            {
                id = random.Next();
            }
            while (idMap.Contains(id));
            idMap.Add(id);
            return id;
        }

        public Boolean CreateManager(Manager newManager)
        {
            if (!CheckIfUsernameExists(newManager.Username))
            {
                newManager.Id = GenerateID();
                userMap.Add(newManager.Username, newManager.Password);
                serializer.ToCSVAppend(dbPath, new List<Manager>() { newManager });
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SwapManagerByID(List<Manager> managers, Manager manager)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id == manager.Id)
                {
                    managers[i] = manager;
                    break;
                }
            }
        }

        public Boolean UpdateManager(Manager manager)
        {
            if (CheckIfIDExists(manager.Id))
            {
                List<Manager> managers = GetAllManagers();
                SwapManagerByID(managers, manager);
                serializer.ToCSV(dbPath, managers);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DeleteManagerByID(List<Manager> managers, int id)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id == id)
                {
                    managers.RemoveAt(i);
                    break;
                }
            }
        }

        public Boolean DeleteManager(int id)
        {
            if (CheckIfIDExists(id))
            {
                List<Manager> managers = GetAllManagers();
                DeleteManagerByID(managers, id);
                serializer.ToCSV(dbPath, managers);
                return true;
            }
            else
            {
                return false;
            }
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
            return null;
        }

        public Manager ReadManager(int id)
        {
            if (CheckIfIDExists(id))
            {
                List<Manager> managers = GetAllManagers();
                return FindManagerByID(managers, id);
            }
            else
            {
                return null;
            }
        }

        public List<Manager> GetAllManagers()
        {
            return serializer.FromCSV(dbPath);
        }

        public Dictionary<string, string> GetUsernameHashSet()
        {
            return userMap;
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