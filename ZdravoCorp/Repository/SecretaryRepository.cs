// File:    SecretaryRepository.cs
// Author:  halid
// Created: Saturday, 16 April 2022 01:44:41
// Purpose: Definition of Class SecretaryRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class SecretaryRepository
    {
        private String dbPath = "..\\..\\Data\\secretariesDB.csv";
        private Serializer<Secretary> serializer = new Serializer<Secretary>();
        private static readonly object key = new object();
        private static SecretaryRepository instance = null;

        private HashSet<int> idMap = new HashSet<int>();
        private Dictionary<string, string> userMap = new Dictionary<string, string>();

        public SecretaryRepository()
        {
            List<Secretary> secretaryList = GetAllSecretaries();
            InstantiateHashSets(secretaryList);
        }

        private void InstantiateHashSets(List<Secretary> secretaries)
        {
            foreach (Secretary secretary in secretaries)
            {
                idMap.Add(secretary.Id);
                userMap.Add(secretary.Username, secretary.Password);
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

        public Boolean CreateSecretary(Secretary newSecretary)
        {
            if (!CheckIfUsernameExists(newSecretary.Username))
            {
                newSecretary.Id = GenerateID();
                userMap.Add(newSecretary.Username, newSecretary.Password);
                serializer.ToCSVAppend(dbPath, new List<Secretary>() { newSecretary });
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SwapSecretaryByID(List<Secretary> secretaries, Secretary secretary)
        {
            for (int i = 0; i < secretaries.Count; i++)
            {
                if (secretaries[i].Id == secretary.Id)
                {
                    secretaries[i] = secretary;
                    break;
                }
            }
        }

        public Boolean UpdateSecretary(Secretary secretary)
        {
            if (CheckIfIDExists(secretary.Id))
            {
                List<Secretary> secretaries = GetAllSecretaries();
                SwapSecretaryByID(secretaries, secretary);
                serializer.ToCSV(dbPath, secretaries);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DeleteSecretaryByID(List<Secretary> secretaries, int id)
        {
            for (int i = 0; i < secretaries.Count; i++)
            {
                if (secretaries[i].Id == id)
                {
                    secretaries.RemoveAt(i);
                    break;
                }
            }
        }

        public Boolean DeleteSecretary(int id)
        {
            if (CheckIfIDExists(id))
            {
                List<Secretary> secretaries = GetAllSecretaries();
                DeleteSecretaryByID(secretaries, id);
                serializer.ToCSV(dbPath, secretaries);
                return true;
            }
            else
            {
                return false;
            }
        }

        private Secretary FindSecretaryByID(List<Secretary> secretaries, int id)
        {
            for (int i = 0; i < secretaries.Count; i++)
            {
                if (secretaries[i].Id == id)
                {
                    return secretaries[i];
                }
            }
            return null;
        }

        public Secretary ReadSecretary(int id)
        {
            if (CheckIfIDExists(id))
            {
                List<Secretary> secretaries = GetAllSecretaries();
                return FindSecretaryByID(secretaries, id);
            }
            else
            {
                return null;
            }
        }

        public List<Secretary> GetAllSecretaries()
        {
            return serializer.FromCSV(dbPath);
        }

        public Dictionary<string, string> GetUsernameHashSet()
        {
            return userMap;
        }

        public static SecretaryRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new SecretaryRepository();
                        }
                    }
                }
                return instance;
            }
        }

    }
}