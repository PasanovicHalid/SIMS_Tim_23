// File:    AppointmentRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:17
// Purpose: Definition of Class AppointmentRepository

using Model;
using System;
using System.Collections.Generic;
using Repository;
namespace Service
{
    public class AnamnesisService : ICrud<Anamnesis>
    {
        
        private static AnamnesisService instance = null;

        public void Create(Anamnesis newAnamnesis)
        {
            AnamnesisRepository.Instance.Create(newAnamnesis);
        }

        public Anamnesis Read(int id)
        {
            return AnamnesisRepository.Instance.Read(id);
        }

        public void Update(Anamnesis anamnesis)
        {
            AnamnesisRepository.Instance.Update(anamnesis);

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anamnesis> GetAll()
        {
            return AnamnesisRepository.Instance.GetAll();
        }

        public AnamnesisService()
        {

        }

        public static AnamnesisService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnamnesisService();
                }
                return instance;
            }
        }
        public Anamnesis FindAnamnesisByAppointmentId(int id)
        {
            Anamnesis anamnesis = null;
            List<Anamnesis> anamneses = GetAll();
            foreach(Anamnesis a in anamneses)
            {
                if(a.Appointment.Id == id)
                {
                    anamnesis = a;
                }
            }
            return anamnesis;
        }
    }
}