// File:    AppointmentRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:17
// Purpose: Definition of Class AppointmentRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class AnamnesisRepository
    {
        private String dbPath = "..\\..\\Data\\anamnesisDB.csv";
        private Serializer<Anamnesis> serializerAnamnesis = new Serializer<Anamnesis>();

        private static AnamnesisRepository instance = null;
        public List<int> GetAllAnamnesisIds()
        {
            List<Anamnesis> anamnesis = GetAllAnamnesis();
            List<int> ids = new List<int>();
            foreach (Anamnesis a in anamnesis)
            {
                ids.Add(a.Id);
            }
            return ids;
        }
        public void GenerateId(Anamnesis newAnamnesis)
        {
            List<int> allAnamnesisIds = GetAllAnamnesisIds();
            Random random = new Random();
            do
            {
                newAnamnesis.Id = random.Next();
            }
            while (allAnamnesisIds.Contains(newAnamnesis.Id));
        }
        public Boolean CreateAnamnesis(Anamnesis newAnamnesis)
        {
            List<Anamnesis> anamnesisList = GetAllAnamnesis();
            GenerateId(newAnamnesis);
            anamnesisList.Add(newAnamnesis);
            serializerAnamnesis.ToCSV(dbPath, anamnesisList);
            return true;
        }

        public Anamnesis ReadAnamnesis(int id)
        {
            List<Anamnesis> anamnesisList = GetAllAnamnesis();
            Anamnesis appointment = null;
            foreach (Anamnesis app in anamnesisList)
            {
                if (id == app.Id)
                {
                    appointment = app;
                }
            }
            return appointment;
        }

        public List<Anamnesis> GetAnamnesisById(List<int> id)
        {
            List<Anamnesis> anamnesis = serializerAnamnesis.FromCSV(dbPath);
            List<Anamnesis> appById = new List<Anamnesis>();
            foreach (Anamnesis appointment in anamnesis)
            {
                foreach (int i in id)
                {
                    if (appointment.Id == i)
                    {
                        appById.Add(appointment);
                    }
                }
            }
            return appById;
        }

        public Boolean UpdateAnamnesis(Anamnesis appointment)
        {
            throw new NotImplementedException();

        }

        public Boolean DeleteAnamnesis(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anamnesis> GetAllAnamnesis()
        {
            List<Anamnesis> anamnesisList = serializerAnamnesis.FromCSV(dbPath);
            return anamnesisList;

        }

        public AnamnesisRepository()
        {

        }

        public static AnamnesisRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnamnesisRepository();
                }
                return instance;
            }
        }
    }
}