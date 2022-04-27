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

        public Appointment ReadAppointment(int appointment)
        {
            return AppointmentRepository.Instance.ReadAppointment(appointment);
        }

        public Boolean UpdateAppointment(Appointment appointment)
        {
            return AppointmentRepository.Instance.UpdateAppointment(appointment);
        }

        public Boolean DeleteAppointment(int appointment)
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

        public Appointment SuggestAppointment(Doctor doctor, DateTime start, DateTime end, bool priority)
        {
            Appointment appointment = new Appointment();
            //prioritet ima doktor
            if(priority == true)
            {
                appointment.StartDate = GetFirstFreeAppointmentForDoctor(doctor, start, end);
            }
            else
            {

            }
            return appointment;
        }
        public DateTime GetFirstFreeAppointmentForDoctor(Doctor doctor, DateTime start, DateTime end)
        {
            
            while (start < end)
            {
                start = start.AddMinutes(45);
            }
            return DateTime.MinValue;    
        }
    }
}