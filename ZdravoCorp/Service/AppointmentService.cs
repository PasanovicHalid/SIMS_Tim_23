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
    public class AppointmentService
    {
        public const int MAX_SUGGESTIONS = 30;
        public const int MAX_ITERATIONS = 10;
        private int num_of_iterations = 0;
        private static AppointmentService instance = null;
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

        public AppointmentService()
        {

        }

        public static AppointmentService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppointmentService();
                }
                return instance;
            }
        }
        
        public List<Appointment> SuggestAppointments(WantedAppointment wantedAppointment)
        {
            if (wantedAppointment.FirstTime)
            {
                appointments = new List<Appointment>();
                wantedAppointment.FirstTime = false;
            }
            if (wantedAppointment.Priority)
            {
                FindAppointmentsWithDoctorPriority(wantedAppointment);
            }
            else
            {
                FindAppointmentsWithDatePriority(wantedAppointment);
            }
            return appointments;
        }

        public void FindAppointmentsWithDoctorPriority(WantedAppointment wantedAppointment)
        {
            DateTime correctStart = SetStartTime(wantedAppointment);
            DateTime correctEnd = correctStart.Date + new TimeSpan(correctStart.Hour, correctStart.Minute + 45, correctStart.Second);
            SuggestAppointmentsForOneWorkingDay(wantedAppointment, correctStart);
            if (appointments.Count < MAX_SUGGESTIONS && num_of_iterations < MAX_ITERATIONS) 
            {
                num_of_iterations++;
                SetDateTimeForNextDay(wantedAppointment);
                SuggestAppointments(wantedAppointment);
            }
        }

        public void FindAppointmentsWithDatePriority(WantedAppointment wantedAppointment)
        {
            DateTime resetStart = wantedAppointment.Start;
            GoThroughAllDoctors(wantedAppointment, resetStart);
            if (appointments.Count < MAX_SUGGESTIONS && num_of_iterations < MAX_ITERATIONS)
            {
                num_of_iterations++;
                SetDateTimeForNextDay(wantedAppointment);
                
                SuggestAppointments(wantedAppointment);
            }

        }

        public void GoThroughAllDoctors(WantedAppointment wantedAppointment, DateTime resetStart)
        {
            List<Doctor> doctors = DoctorService.Instance.GetAllDoctors();
            foreach (Doctor d in doctors)
            {
                DateTime correctStart = SetStartTimeForDatePriority(resetStart, d);
                DateTime correctEnd = correctStart.Date + new TimeSpan(correctStart.Hour, correctStart.Minute + 45, correctStart.Second);
                SuggestAppointmentsForOneWorkingDay(wantedAppointment, correctStart, d);
            }
        }

        public void SuggestAppointmentsForOneWorkingDay(WantedAppointment wantedAppointment, DateTime correctStart, Doctor d = null)
        {
            d = d == null ? wantedAppointment.Doctor : d;
            while ((correctStart.TimeOfDay >= d.workStartTime.TimeOfDay) && (correctStart.AddMinutes(45).TimeOfDay <= d.workEndTime.TimeOfDay))
            {
                if (DoctorService.Instance.IsDoctorFree(wantedAppointment.Doctor.Id, correctStart, correctStart.AddMinutes(45)))
                {
                    Room room = RoomService.Instance.findFreeRoom(correctStart, correctStart.AddMinutes(45));
                    if (room != null)
                    {
                        wantedAppointment.Doctor = d;
                        AddAppointmentToSuggestedAppointments(correctStart, room, wantedAppointment);
                    }
                }
                correctStart = SetTimeForNextAppointment(correctStart, correctStart.AddMinutes(45));
            }
        }

        public DateTime SetStartTimeForDatePriority(DateTime resetStart, Doctor doctor)
        {
            TimeSpan ts = new TimeSpan(doctor.workStartTime.Hour, doctor.workStartTime.Minute, doctor.workStartTime.Second);
            DateTime correctStartTime = resetStart.Date + ts;
            return correctStartTime;
        }

        public DateTime SetStartTime(WantedAppointment wantedAppointment)
        {
            DateTime correctStartTime = wantedAppointment.Start;
            TimeSpan ts = new TimeSpan(wantedAppointment.Doctor.workStartTime.Hour, wantedAppointment.Doctor.workStartTime.Minute, wantedAppointment.Doctor.workStartTime.Second);
            correctStartTime = correctStartTime.Date + ts;
            return correctStartTime;
        }

        public void AddAppointmentToSuggestedAppointments(DateTime start, Room room, WantedAppointment wantedAppointment)
        {
            Appointment appointment = new Appointment();
            appointment.Doctor = wantedAppointment.Doctor;
            appointment.StartDate = start;
            appointment.EndDate = start.AddMinutes(45);
            appointment.Room = room;
            appointment.Patient = wantedAppointment.Patient;
            appointments.Add(appointment);
        }

        public DateTime SetTimeForNextAppointment(DateTime start, DateTime end)
        {
            TimeSpan ts2 = new TimeSpan(start.Hour, start.Minute + 45, start.Second);
            TimeSpan ts3 = new TimeSpan(end.Hour, end.Minute + 45, end.Second);
            start = start.Date + ts2;
            end = end.Date + ts3;
            return start;
        }

        public void SetDateTimeForNextDay(WantedAppointment wantedAppointment)
        {
            TimeSpan ts2 = new TimeSpan(1, 0, 0, 0);
            TimeSpan ts3 = new TimeSpan(1, 0, 0, 0);
            wantedAppointment.Start = wantedAppointment.Start.Date + ts2;
            wantedAppointment.End = wantedAppointment.End.Date + ts3;
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
        public List<Appointment> GetFutureAppointments()
        {
            List<Appointment> appointments = GetAllAppointments();
            List<Appointment> futureAppointments = new List<Appointment>();
            foreach(Appointment appointment in appointments)
            {
                if(appointment.StartDate >= DateTime.Now)
                {
                    futureAppointments.Add(appointment);
                }
            }
            return futureAppointments;
        }
        public List<Appointment> GetPastAppointments()
        {
            List<Appointment> appointments = GetAllAppointments();
            List<Appointment> pastAppointments = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.EndDate <= DateTime.Now)
                {
                    pastAppointments.Add(appointment);
                }
            }
            return pastAppointments;
        }

        public Boolean IsTroll(Appointment appointment)
        {
            Patient patient = PatientRepository.Instance.ReadPatient(appointment.Patient.Id);
            if(patient.ChangedOrCanceledAppointmentsDates == null)
            {
                patient.ChangedOrCanceledAppointmentsDates = new List<DateTime>();
            }
            if(patient.ChangedOrCanceledAppointmentsDates.Count >= 5)
            {
                patient.CanLog = false;
                PatientRepository.Instance.UpdatePatient(patient);
            }
            return !patient.CanLog;
        }
        
        public List<Appointment> GetFutureAppointmentsForPatient(Patient patient)
        {
            List<Appointment> allFutureAppointments = GetFutureAppointments();
            List<Appointment> futureAppointmentsForPatient = new List<Appointment>();
            foreach(Appointment appointment in allFutureAppointments)
            {
                if(appointment.Patient.Id == patient.Id)
                {
                    futureAppointmentsForPatient.Add(appointment);
                }
            }
            return futureAppointmentsForPatient;
        }

        public List<Appointment> GetPastAppointmentsForPatient(Patient patient)
        {
            List<Appointment> allPastAppointments = GetPastAppointments();
            List<Appointment> pastAppointmentsForPatient = new List<Appointment>();
            foreach (Appointment appointment in allPastAppointments)
            {
                if (appointment.Patient.Id == patient.Id)
                {
                    pastAppointmentsForPatient.Add(appointment);
                }
            }
            return pastAppointmentsForPatient;
        }
    }
}