// File:    AppointmenService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:42:17
// Purpose: Definition of Class AppointmenService

using Model;
using Repository;
using System;

namespace Service
{
    public class AppointmenService
    {
        private static AppointmenService instance = null;

        public Boolean CreateAppointment(Appointment newAppointment)
        {
            throw new NotImplementedException();
        }

        public Appointment ReadAppointment(Appointment appointment)
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

        public AppointmenService()
        {
            
        }

        public static AppointmenService Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new AppointmenService();
                }
                return instance ;
            }
        }

    }
}