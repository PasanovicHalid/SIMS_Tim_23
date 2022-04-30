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
        public const int MAX_SUGGESTIONS = 30;
        private static AppointmenService instance = null;
        List<Appointment> appointments = new List<Appointment>();
        
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
                return instance;
            }
        }
        public List<Appointment> SuggestAppointments(Doctor doctor, DateTime start, DateTime end, bool priority, bool firstTime)
        {

            if (firstTime)
            {
                appointments = new List<Appointment>();
            }
            //prioritet ima doktor
            if (priority)
            {
                DateTime thisStart = start;

                TimeSpan ts = new TimeSpan(doctor.workStartTime.Hour, doctor.workStartTime.Minute, doctor.workStartTime.Second);
                thisStart = thisStart.Date + ts;
                DateTime thisEnd = thisStart.AddMinutes(45);

                while ((thisStart.TimeOfDay >= doctor.workStartTime.TimeOfDay) && (thisEnd.TimeOfDay <= doctor.workEndTime.TimeOfDay))
                {
                    if (DoctorService.Instance.IsDoctorFree(doctor.Id, thisStart, thisEnd))
                    {
                        Room r = RoomService.Instance.findFreeRoom(thisStart, thisEnd);
                        if (r != null)
                        {
                            Appointment appointment = new Appointment();
                            appointment.doctor = doctor;
                            appointment.StartDate = thisStart;
                            appointment.endDate = thisEnd;
                            appointment.Room = r;

                            appointment.Patient = PatientService.Instance.ReadPatient(0);

                            appointments.Add(appointment);


                        }
                    }
                    TimeSpan ts2 = new TimeSpan(thisStart.Hour, thisStart.Minute + 45, thisStart.Second);
                    TimeSpan ts3 = new TimeSpan(thisEnd.Hour, thisEnd.Minute + 45, thisEnd.Second);
                    thisStart = thisStart.Date + ts2;
                    thisEnd = thisEnd.Date + ts3;
                }
                if (appointments.Count < MAX_SUGGESTIONS)
                {
                    TimeSpan ts2 = new TimeSpan(1, 0, 0, 0);
                    TimeSpan ts3 = new TimeSpan(1, 0, 0, 0);
                    start = start.Date + ts2;
                    end = end.Date + ts3;
                    
                    SuggestAppointments(doctor, start, end, true, false);

                }
            }
            else
            {
                DateTime resetStart = start;
                TimeSpan t = new TimeSpan(resetStart.Hour, resetStart.Minute + 45, resetStart.Second);
                DateTime resetEnd = resetStart.Date + t;

                List<Doctor> doctors = DoctorService.Instance.GetAllDoctors();
                foreach (Doctor d in doctors)
                {
                    TimeSpan ts = new TimeSpan(d.workStartTime.Hour, d.workStartTime.Minute, d.workStartTime.Second);

                    DateTime thisStart = resetStart.Date + ts;
                    TimeSpan te = new TimeSpan(thisStart.Hour, thisStart.Minute + 45, thisStart.Second);

                    DateTime thisEnd = resetEnd.Date + te;
                    List<Appointment> apps = doctorsAppointments(d.Id);
                    while ((thisStart.TimeOfDay >= d.workStartTime.TimeOfDay) && (thisEnd.TimeOfDay <= d.workEndTime.TimeOfDay))
                    {
                        if (DoctorService.Instance.IsDoctorFree(d.Id, thisStart, thisEnd))
                        {
                            Room r = RoomService.Instance.findFreeRoom(thisStart, thisEnd);
                            if (r != null)
                            {
                                Appointment appointment = new Appointment();
                                appointment.doctor = d;
                                appointment.StartDate = thisStart;
                                appointment.endDate = thisEnd;
                                appointment.Room = r;

                                appointment.Patient = PatientService.Instance.ReadPatient(0);

                                appointments.Add(appointment);


                            }
                        }
                        TimeSpan ts2 = new TimeSpan(thisStart.Hour, thisStart.Minute + 45, thisStart.Second);
                        TimeSpan ts3 = new TimeSpan(thisEnd.Hour, thisEnd.Minute + 45, thisEnd.Second);
                        thisStart = thisStart.Date + ts2;
                        thisEnd = thisEnd.Date + ts3;
                    }
                }
                if (appointments.Count < MAX_SUGGESTIONS)
                {
                    TimeSpan ts2 = new TimeSpan(1, 0, 0, 0);
                    TimeSpan ts3 = new TimeSpan(1, 0, 0, 0);
                    start = start.Date + ts2;
                    end = end.Date + ts3;
                    
                    SuggestAppointments(doctor, start, end, false, false);


                }
            }
            return appointments;
        }

        public List<Appointment> doctorsAppointments(int id)
        {
            List<Appointment> result = new List<Appointment>();
            foreach (Appointment app in GetAllAppointments())
            {
                foreach (Doctor doc in DoctorService.Instance.GetAllDoctors())
                {
                    if (doc.Id == id)
                    {
                        result.Add(app);
                    }
                }
            }
            return result;
        }

    }
}