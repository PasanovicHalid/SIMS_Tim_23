// File:    AppointmenServicet.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:42:17
// Purpose: Definition of Class AppointmenServicet

using System;
using Model;
using Repository;
using System.Collections.Generic;


namespace Service
{
    public class AppointmenServicet
    {

        public AppointmentRepository appointmentRepository;

        public AppointmenServicet()
        {
            appointmentRepository = new AppointmentRepository();
        }

        public Boolean CreateAppointment(Appointment newAppointment)
        {
            return appointmentRepository.CreateAppointment(newAppointment);
        }

        public Appointment ReadAppointment(String appointmentID)
        {
            return appointmentRepository.ReadAppointment(appointmentID);
        }

        public Boolean UpdateAppointment(Appointment appointment)
        {
            return appointmentRepository.UpdateAppointment(appointment);
        }

        public Boolean DeleteAppointment(String appointmentID)
        {
            return appointmentRepository.DeleteAppointment(appointmentID);
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointmentRepository.GetAllAppointments();
        }

    }
}