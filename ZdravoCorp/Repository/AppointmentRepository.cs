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
            appointments.Add(newAppointment);
            serializerAppointment.ToCSV(dbPath,appointments);
            return true;
        }

        public Appointment ReadAppointment(int id)
        {
            List<Appointment> appointments = GetAllAppointments();
            foreach (Appointment appointment in appointments)
            {
                if (id.Equals(appointment.Id))
                {
                    appointment.doctor = DoctorRepository.Instance.ReadDoctor(appointment.doctor.Id);
                    appointment.Room = RoomRepository.Instance.ReadRoom(appointment.Room.Identifier);
                    appointment.Patient = PatientRepository.Instance.ReadPatient(appointment.Patient.Id);
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
            Boolean success = false;
            List<Appointment> appointments = GetAllAppointments();
            foreach (Appointment temp in appointments)
            {
                if (appointment.Id.Equals(temp.Id)) 
                {
                    success = true;
                    appointments.Remove(temp);
                    break;
                }
            }
            if (success)
            {
                appointments.Add(appointment);
                serializerAppointment.ToCSV(dbPath, appointments);
                
            }
            return success;

        }

        public Boolean DeleteAppointment(int id)
        {
            Boolean success = false;
            List<Appointment> appointments = GetAllAppointments();
            foreach (Appointment temp in appointments)
            {
                if (temp.Id == id)
                {
                    success = true;
                    appointments.Remove(temp);
                    serializerAppointment.ToCSV(dbPath, appointments);
                    break;
                }
            }
            return success;
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