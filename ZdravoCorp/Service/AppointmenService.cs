// File:    AppointmenService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:42:17
// Purpose: Definition of Class AppointmenService

using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AppointmenService
    {
        private static AppointmenService instance = null;

        public Boolean CreateAppointment(Appointment newAppointment)
        {
            return AppointmentRepository.Instance.CreateAppointment(newAppointment);
        }

        public Appointment ReadAppointment(Appointment appointment)
        {
            return AppointmentRepository.Instance.ReadAppointment(appointment.Id);
        }

        public Boolean UpdateAppointment(Appointment appointment)
        {
            return AppointmentRepository.Instance.UpdateAppointment(appointment);
        }

        public Boolean DeleteAppointment(Appointment appointment)
        {
            return AppointmentRepository.Instance.DeleteAppointment(appointment);
        }

        public List<Appointment> GetAllAppointments()
        {
            return AppointmentRepository.Instance.GetAllAppointments();
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