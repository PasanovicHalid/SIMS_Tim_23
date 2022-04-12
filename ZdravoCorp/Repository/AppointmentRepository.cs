// File:    AppointmentRepository.cs
// Author:  10
// Created: Sunday, 10 April 2022 22:43:17
// Purpose: Definition of Class AppointmentRepository

using System;
using Model;
using System.Collections.Generic;


namespace Repository
{
   public class AppointmentRepository
   {
        private String dbPath;
        private Serializer<Appointment> serializer;

        public AppointmentRepository()
        {
            dbPath = "Resourses\\appointmentCSV.csv";
            serializer = new Serializer<Appointment>(); 
        }


        public Boolean CreateAppointment(Appointment newAppointment)
      {
            List<Appointment> temp = new List<Appointment>();
            temp.Add(newAppointment);
            serializer.ToCSVAppend(dbPath, temp);
            return true;
        }
      
      public Appointment ReadAppointment(String appointmentID)
      {
            List<Appointment> appointments = serializer.FromCSV(dbPath);
            foreach (Appointment appointment in appointments)
            {
                if (appointmentID.Equals(appointment.getAppointmentID()));
                {
                    return appointment;
                }
            }
            return null;
        }
      
      public Boolean UpdateAppointment(Appointment appointment)
      {
            List<Appointment> appointments = serializer.FromCSV(dbPath);
            foreach (Appointment temp in appointments)
            {
                if (appointment.getAppointmentID().Equals(temp.getAppointmentID()));
                {
                    appointments.Remove(temp);
                    break;
                }
            }
            appointments.Add(appointment);
            serializer.ToCSV(dbPath, appointments);
            return true;
        }
      
      public Boolean DeleteAppointment(String appointmentID)
      {
            List<Appointment> appointments = serializer.FromCSV(dbPath);
            foreach (Appointment appointment in appointments)
            {
                if (appointmentID.Equals(appointment.getAppointmentID()))
                {
                    appointments.Remove(appointment);
                    break;
                }
            }
            serializer.ToCSV(dbPath, appointments);
            return true;
        }
      
      public List<Appointment> GetAllAppointments()
      {
            return serializer.FromCSV(dbPath);
      }
   
   }
}