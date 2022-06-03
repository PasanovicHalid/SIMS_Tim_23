/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DoctorService
    {
        private static DoctorService instance = null;

        public Boolean CreateDoctor(Doctor newDoctor)
        {
            return DoctorRepository.Instance.CreateDoctor(newDoctor);
        }

        public Boolean UpdateDoctor(Doctor updatedRoom)
        {
            return DoctorRepository.Instance.UpdateDoctor(updatedRoom);
        }

        public Boolean DeleteDoctor(int doctor)
        {
            return DoctorRepository.Instance.DeleteDoctor(doctor);
        }

        public Doctor ReadDoctor(int doctor)
        {
            return DoctorRepository.Instance.ReadDoctor(doctor);
        }

        public List<Doctor> GetAllDoctors()
        {
            return DoctorRepository.Instance.GetAllDoctors();
        }

        public Boolean CreateDoctorType(DoctorType newDoctorType)
        {
            return DoctorRepository.Instance.CreateDoctorType(newDoctorType);
        }

        public Boolean UpdateDoctorType(DoctorType doctorType)
        {
            return DoctorRepository.Instance.UpdateDoctorType(doctorType);
        }

        public Boolean DeleteDoctorType(String doctorType)
        {
            return DoctorRepository.Instance.DeleteDoctorType(doctorType);
        }

        public DoctorType ReadDoctorType(String doctorType)
        {
            return DoctorRepository.Instance.ReadDoctorType(doctorType);
        }
        
        public List<DoctorType> GetAllDoctorType()
        {
            return DoctorRepository.Instance.GetAllDoctorType();
        }

        public DoctorService()
        {
           
        }

        public static DoctorService Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new DoctorService();
                }
                return instance ;
            }
        }
        public bool IsDoctorFree(int id, DateTime start, DateTime end)
        {
            bool isFree = false;
            
            Doctor doctor = ReadDoctor(id);
            List<DateTime> startDates = new List<DateTime>();
            List<DateTime> endDates = new List<DateTime>();
            foreach(Appointment a in doctor.Appointment)
            {
                startDates.Add(a.startDate);
                endDates.Add(a.endDate);
            }
            if(!(startDates.Contains(start) || endDates.Contains(end)))
            {
                isFree = true;
            }
            //if(start.Date > doctor.WorkStartTime.Date && end.Date< doctor.WorkEndTime.Date && start.Hour > doctor.WorkStartTime.Hour && end.Hour < doctor.WorkEndTime.Hour)
            //{
            //    List<Appointment> appointments = AppointmenService.Instance.doctorsAppointments(doctor.Id); 
            //    foreach(Appointment app in appointments)
            //    {
            //        //if((app.startDate.TimeOfDay <= start.TimeOfDay) && (app.EndDate.TimeOfDay <= end.TimeOfDay)) { isFree = true; }
                    
                    
            //        if(app.StartDate.TimeOfDay < start.TimeOfDay)
            //        {
            //            if(app.EndDate.TimeOfDay > start.TimeOfDay && app.EndDate.TimeOfDay < end.TimeOfDay)
            //            {
            //                return false;
            //            }
            //            if (app.EndDate.TimeOfDay > end.TimeOfDay)
            //            {
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            if(app.StartDate < end && app.EndDate > end)
            //            {
            //                return false;
            //            }
            //            if(app.EndDate < end)
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //}

            return isFree;
        }
    }
}