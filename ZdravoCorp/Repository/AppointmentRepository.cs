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
        public List<int> GetAllAppointmentIds()
        {
            List<Appointment> appointemnts = GetAllAppointments();
            List<int> ids = new List<int>();
            foreach (Appointment appointment in appointemnts)
            {
                ids.Add(appointment.Id);
            }
            return ids;
        }
        public void GenerateId(Appointment newAppointment)
        {
            List<int> allAppointmentsIds = GetAllAppointmentIds();
            Random random = new Random();
            do
            {
                newAppointment.Id = random.Next();
            }
            while (allAppointmentsIds.Contains(newAppointment.Id));
        }
        public Boolean CreateAppointment(Appointment newAppointment)
        {
            List<Appointment> appointments = GetAllAppointments();
            GenerateId(newAppointment);
            appointments.Add(newAppointment);
            serializerAppointment.ToCSV(dbPath, appointments);
            return true;
        }

        public Appointment ReadAppointment(int id)
        {
            List<Appointment> appointments = GetAllAppointments();
            Appointment appointment = null;
            foreach (Appointment app in appointments)
            {
                if (id == app.Id)
                {
                    appointment = app;
                }
            }
            return appointment;
        }

        public List<Appointment> GetAppointmentsById(List<int> id)
        {
            List<Appointment> appointments = serializerAppointment.FromCSV(dbPath);
            List<Appointment> appById = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                foreach (int i in id)
                {
                    if (appointment.Id == i)
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
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointment.Id == appointments[i].Id)
                {
                    int id = appointment.Id;
                    int id2 = appointments[i].Id;
                    success = true;
                    //DeleteAppointment(appointment.Id);
                    appointments[i] = appointment;
                    break;
                }
            }
            if (success)
            {
                //appointments = GetAllAppointments();
                //appointments.Add(appointment);
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
                    Doctor d = DoctorRepository.Instance.ReadDoctor(temp.doctor.Id);
                    d.RemoveAppointment(temp);
                    DoctorRepository.Instance.UpdateDoctor(d);
                    Room r = RoomRepository.Instance.ReadRoom(temp.Room.Identifier);
                    r.RemoveAppointment(temp);
                    RoomRepository.Instance.UpdateRoom(r);
                    Patient p = PatientRepository.Instance.ReadPatient(temp.Patient.Id);
                    p.RemoveAppointment(temp);
                    PatientRepository.Instance.UpdatePatient(p);
                    serializerAppointment.ToCSV(dbPath, appointments);
                    break;
                }
            }
            return success;
        }

        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = serializerAppointment.FromCSV(dbPath);
            return appointments;

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
                return instance;
            }
        }
    }
}