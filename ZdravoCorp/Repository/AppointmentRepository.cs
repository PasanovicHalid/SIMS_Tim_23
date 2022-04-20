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
        private String dbPath = "..\\..\\Data\\appointmentsDB.csv";
        private Serializer<Appointment> serializerAppointment = new Serializer<Appointment>();

        private static AppointmentRepository instance = null;

        public Boolean CreateAppointment(Appointment newAppointment)
        {
            List<Appointment> appointments = GetAllAppointments();
            int id = appointments.Count;
            newAppointment.Id = id;
            serializerAppointment.ToCSV(dbPath,appointments);
            return true;
        }

        public Appointment ReadAppointment(int id)
        {
            List<Appointment> appointments = serializerAppointment.FromCSV(dbPath);
            foreach (Appointment appointment in appointments)
            {
                if (id.Equals(appointment.Id)) ;
                {
                    return appointment;
                }
            }
            return null;
        }

        public List<Appointment> GetAppointmentsById(List<int> id)
        {
            List<Appointment> appointments = serializerAppointment.FromCSV(dbPath);
            List<Appointment> appById = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
               foreach (int i in id)
                {
                    if(appointment.Id == i)
                    {
                        appById.Add(appointment);
                    }
                }
            }
            return appById;
        }

        public Boolean UpdateAppointment(Appointment appointment)
        {
            List<Appointment> appointments = GetAllAppointments();
            foreach (Appointment temp in appointments)
            {
                if (appointment.Id.Equals(temp.Id)) 
                {
                    appointments.Remove(temp);
                    break;
                }
            }
            appointments.Add(appointment);
            serializerAppointment.ToCSV(dbPath, appointments);
            return true;

        }

        public Boolean DeleteAppointment(Appointment appointment)
        {
            List<Appointment> appointments = GetAllAppointments();
            foreach (Appointment temp in appointments)
            {
                if (temp.Equals(appointment.Id))
                {
                    appointments.Remove(appointment);
                    break;
                }
            }
            serializerAppointment.ToCSV(dbPath, appointments);
            return true;
        }

        public List<Appointment> GetAllAppointments()
        {
            return serializerAppointment.FromCSV(dbPath);
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