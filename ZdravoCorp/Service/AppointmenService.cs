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
                return instance ;
            }
        }
        public List<Appointment> SuggestAppointments(Doctor doctor, DateTime start, DateTime end, bool priority)
        {
            
           
            //prioritet ima doktor
            if (priority)
            {
                DateTime thisStart = start;

                TimeSpan ts = new TimeSpan(doctor.workStartTime.Hour, doctor.workStartTime.Minute, doctor.workStartTime.Second);
                thisStart = thisStart.Date + ts;
                DateTime thisEnd = thisStart.AddMinutes(45);
                
                while ((thisStart.TimeOfDay >= doctor.workStartTime.TimeOfDay) && (thisEnd.TimeOfDay <= doctor.workEndTime.TimeOfDay))
                {
                    if(DoctorService.Instance.IsDoctorFree(doctor.Id, thisStart, thisEnd))
                    {
                        Room r = RoomService.Instance.findFreeRoom(thisStart, thisEnd);
                        if ( r != null)
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
                    TimeSpan ts2 = new TimeSpan(thisStart.Hour, thisStart.Minute +45,thisStart.Second);
                    TimeSpan ts3 = new TimeSpan(thisEnd.Hour, thisEnd.Minute + 45, thisEnd.Second);
                    thisStart = thisStart.Date + ts2;
                    thisEnd = thisEnd.Date + ts3;
                }
                if(appointments.Count < 30)
                {
                    TimeSpan ts2 = new TimeSpan(1 ,0, 0, 0);
                    TimeSpan ts3 = new TimeSpan( 1, 0, 0, 0);
                    start = start.Date + ts2;
                    end = end.Date + ts3;
                    

                    //ts = new TimeSpan(doctor.workStartTime.Hour, doctor.workStartTime.Minute, doctor.workStartTime.Second);
                    //thisStart = start.Date + ts;
                    //thisEnd = thisStart.AddMinutes(45);
                    SuggestAppointments(doctor, start, end, true);

                }
            }
            else
            {
                DateTime resetStart = start;
                DateTime resetEnd = start.AddMinutes(45);
                
                List<Doctor> doctors = DoctorService.Instance.GetAllDoctors();
                foreach(Doctor d in doctors)
                {
                    DateTime thisStart = resetStart;
                    DateTime thisEnd = resetEnd;
                    List<Appointment> apps = doctorsAppointments(d.Id);
                    while ((thisStart.Hour >= d.workStartTime.Hour) && (thisStart.Minute >= d.workStartTime.Minute) && (thisStart.Second >= d.workStartTime.Second)
                            && (thisEnd.Hour <= d.WorkEndTime.Hour) && (thisEnd.Minute <= d.WorkEndTime.Minute) && (thisEnd.Second <= d.WorkEndTime.Second))
                    {
                        if(DoctorService.Instance.IsDoctorFree(d.Id, thisStart, thisEnd))
                        {
                            Appointment appointment = new Appointment();
                            appointment.doctor = d;
                            appointment.StartDate = thisStart;
                            appointment.endDate = thisEnd;
                            appointment.Room = RoomService.Instance.findFreeRoom(thisStart, thisEnd);
                            appointment.Patient = PatientService.Instance.ReadPatient(0);
                            appointments.Add(appointment);
                        }
                        thisStart.AddMinutes(45);
                        thisEnd.AddMinutes(45);
                    }
                }
                if(appointments.Count == 0)
                {
                    start.AddDays(1);
                    end.AddDays(1);
                    SuggestAppointments(doctor, start, end, false);

                }
            }
            return appointments;
        }
        public Appointment SuggestAppointment(Doctor doctor, DateTime start, DateTime end, bool priority)
        {
            
            Appointment appointment = new Appointment();
            //prioritet ima doktor
            if(priority == true)
            {
                appointment.StartDate = GetFirstFreeAppointmentForDoctor(doctor, start, end);
                
                appointment.doctor = doctor;
                appointment.EndDate = appointment.StartDate.AddMinutes(45);
                
            }
            //prioritet ima datum
            else
            {
                if(GetFirstFreeAppointmentForDoctor(doctor, start, end) != DateTime.MinValue)
                {
                    appointment.StartDate = start;
                    
                    appointment.doctor = doctor;
                    appointment.EndDate = appointment.StartDate.AddMinutes(45);
                }
                else
                {
                    Doctor d = GetFirstFreeDoctorForDate(doctor, start, end);
                    appointment.StartDate = start;
                    
                    appointment.doctor = d;
                    appointment.EndDate = appointment.StartDate.AddMinutes(45);
                }
            }
            return appointment;
        }
        public DateTime GetFirstFreeAppointmentForDoctor(Doctor doctor, DateTime start, DateTime end)
        {
            
            while (start < end)
            {
                start = start.AddMinutes(45);
                if (DoctorService.Instance.IsDoctorFree(doctor.Id, start, start.AddMinutes(45)))
                {
                    return start;
                }
            }
            /*doktor nije slobodan taj dan*/
            while(start < DateTime.MinValue)
            {
                start = start.AddMinutes(45);
                if(DoctorService.Instance.IsDoctorFree(doctor.Id, start, start.AddMinutes(45)))
                {
                    return start;
                }
            }
            return DateTime.MinValue;    
        }
        public List<Appointment> doctorsAppointments(int id)
        {
            List<Appointment> result = new List<Appointment>();
            foreach(Appointment app in GetAllAppointments())
            {
                foreach(Doctor doc in DoctorService.Instance.GetAllDoctors())
                {
                    if (doc.Id == id)
                    {
                        result.Add(app);
                    }
                }
            }
            return result;
        }

        public Doctor GetFirstFreeDoctorForDate(Doctor doctor, DateTime start, DateTime end)
        {
            List<Doctor> doctors = DoctorService.Instance.GetAllDoctors();
            Doctor doc = new Doctor();
            
            foreach(Doctor d in doctors)
            {
                doc.Id = d.Id;
                while (start < end) 
                {
                    start = start.AddMinutes(45);
                    if (DoctorService.Instance.IsDoctorFree(d.Id, start, start.AddMinutes(45)))
                    {
                        return d;
                    }
                }
                
            }
            doc.Id = -1;
            return doc;
        }
        
    }
}