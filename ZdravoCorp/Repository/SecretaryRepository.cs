// File:    SecretaryRepository.cs
// Author:  halid
// Created: Saturday, 16 April 2022 01:44:41
// Purpose: Definition of Class SecretaryRepository

using Model;
using System;
using System.Collections.Generic;
using ZdravoCorp.Exceptions;

namespace Repository
{
    public class SecretaryRepository : UserRepository<Secretary>
    {
        private static SecretaryRepository instance = null;
        public SecretaryRepository()
        {
            dbPath = "..\\..\\Data\\secretariesDB.csv";
            InstantiateHashSets(GetAll());
        }

        public Dictionary<string, Secretary> GetUsernameHashSet()
        {
            return Users;
        }

        public override Secretary Read(int id)
        {
            lock (key)
            {
                CheckIfIDExists(id);
                return FindSecretaryByID(GetAll(), id);
            }
        }

        public override void Create(Secretary element)
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

        public override void Update(Secretary element)
        {
            lock (key)
            {
                CheckIfIDExists(element.Id);
                CheckIfUsernameExists(element.Username);
                List<Secretary> secretaries = GetAll();
                SwapSecretaryByID(secretaries, element);
                SaveChanges(secretaries);
            }
        }

        public override void Delete(int id)
        {
            lock (key)
            {
                CheckIfIDExists(id);
                List<Secretary> secretaries = GetAll();
                DeleteSecretaryByID(secretaries, id);
                SaveChanges(secretaries);
            }
        }

        protected override void InstantiateIDSet(List<Secretary> elements)
        {
            lock (key)
            {
                foreach (Secretary element in elements)
                {
                    idMap.Add(element.Id);
                }
            }
        }

        private void InstantiateHashSets(List<Secretary> secretaries)
        {
            InstantiateIDSet(secretaries);
            InstantiateUserSet(secretaries);
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

        private void SwapSecretaryByID(List<Secretary> secretaries, Secretary secretary)
        {
            for (int i = 0; i < secretaries.Count; i++)
            {
                if (secretaries[i].Id == secretary.Id)
                {
                    secretaries[i] = secretary;
                    return;
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private void DeleteSecretaryByID(List<Secretary> secretaries, int id)
        {
            for (int i = 0; i < secretaries.Count; i++)
            {
                if (secretaries[i].Id == id)
                {
                    idMap.Remove(id);
                    Users.Remove(secretaries[i].Username);
                    secretaries.RemoveAt(i);
                    return;
                }
            }
            throw new LocalisedException("UserDoesntExist");
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
            throw new LocalisedException("UserDoesntExist");
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