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
            List<Anamnesis> anamneses = GetAllAnamnesis();
            List<int> ids = new List<int>();
            foreach (Anamnesis a in anamneses)
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
            List<Anamnesis> anamneses = GetAllAnamnesis();
            GenerateId(newAnamnesis);
            anamneses.Add(newAnamnesis);
            serializerAnamnesis.ToCSV(dbPath, anamneses);
            return true;
        }

        public Anamnesis ReadAnamnesis(int id)
        {
            List<Anamnesis> anamneses = GetAllAnamnesis();
            Anamnesis appointment = null;
            foreach (Anamnesis app in anamneses)
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
            List<Anamnesis> anamneses = serializerAnamnesis.FromCSV(dbPath);
            List<Anamnesis> appById = new List<Anamnesis>();
            foreach (Anamnesis anamnesis in anamneses)
            {
                foreach (int i in id)
                {
                    if (anamnesis.Id == i)
                    {
                        appById.Add(anamnesis);
                    }
                }
            }
            return appById;
        }

        public Boolean UpdateAnamnesis(Anamnesis anamnesis)
        {
            Boolean success = false;
            List<Anamnesis> anamneses = GetAllAnamnesis();
            for (int i = 0; i < anamneses.Count; i++)
            {
                if (anamnesis.Id == anamneses[i].Id)
                {
                    anamneses[i] = anamnesis;
                    serializerAnamnesis.ToCSV(dbPath, anamneses);
                    success = true;
                }
            }
            return success;
            

        }

        public Boolean DeleteAnamnesis(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anamnesis> GetAllAnamnesis()
        {
            List<Anamnesis> anamneses = serializerAnamnesis.FromCSV(dbPath);
            return anamneses;

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