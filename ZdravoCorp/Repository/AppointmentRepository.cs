// File:    AppointmentRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:17
// Purpose: Definition of Class AppointmentRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class AppointmentRepository
    {
        private String dbPath;

        private static AppointmentRepository instance = null;

        public Boolean CreateAppointment(Appointment newAppointment)
        {
            throw new NotImplementedException();
        }

        public Appointment ReadAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsById(List<int> id)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Array GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public AppointmentRepository()
        {
            
        }

        public static AppointmentRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new AppointmentRepository();
                }
                return instance ;
            }
        }
    }
}