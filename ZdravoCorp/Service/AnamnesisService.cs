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
    public class AnamnesisService
    {
        
        private static AnamnesisService instance = null;
        public Boolean CreateAnamnesis(Anamnesis newAnamnesis)
        {
            return AnamnesisRepository.Instance.CreateAnamnesis(newAnamnesis);
        }

        public Anamnesis ReadAnamnesis(int id)
        {
            return AnamnesisRepository.Instance.ReadAnamnesis(id);
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
            return AnamnesisRepository.Instance.GetAllAnamnesis();
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
            List<Anamnesis> anamneses = GetAllAnamnesis();
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