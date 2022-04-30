// File:    AppointmentController.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:33:59
// Purpose: Definition of Class AppointmentController

using Model;
using System;
using Service;
using System.Collections.Generic;

namespace Controller
{
    public class AppointmentController
    {
        public Boolean CreateAppointment(Appointment newAppointment)
        {
            return AppointmenService.Instance.CreateAppointment(newAppointment);
        }

        public Appointment ReadAppointment(int appointment)
        {
            return AppointmenService.Instance.ReadAppointment(appointment);
        }

        public Boolean UpdateAppointment(Appointment appointment)
        {
            return AppointmenService.Instance.UpdateAppointment(appointment);
        }

        public Boolean DeleteAppointment(int appointment)
        {
            return AppointmenService.Instance.DeleteAppointment(appointment);
        }

        public List<Appointment> GetAllAppointments()
        {
            return AppointmenService.Instance.GetAllAppointments();
        }

        public List<Appointment> SuggestAppointments(Doctor doctor, DateTime start, DateTime end, bool priority, bool first)
        {
            return AppointmenService.Instance.SuggestAppointments(doctor, start, end, priority, first);
        }
    }
}