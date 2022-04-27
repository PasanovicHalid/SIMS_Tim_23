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
            bool isFree = true;
            AppointmenService appointmentService = new AppointmenService();
            Doctor doctor = ReadDoctor(id);
            if(start.Date > doctor.WorkStartTime.Date && end.Date< doctor.WorkEndTime.Date && start.Hour > doctor.WorkStartTime.Hour && end.Hour < doctor.WorkEndTime.Hour)
            {
                List<Appointment> appointments = appointmentService.doctorsAppointments(doctor.Id); 
                foreach(Appointment app in appointments)
                {
                    if(app.StartDate == start)
                    {
                        return false;
                    }
                    if(app.EndDate == end)
                    {
                        return false;
                    }
                    if(app.StartDate < start)
                    {
                        if(app.EndDate > start && app.EndDate < end)
                        {
                            return false;
                        }
                        if (app.EndDate > end)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if(app.StartDate < end && app.EndDate > end)
                        {
                            return false;
                        }
                        if(app.EndDate < end)
                        {
                            return false;
                        }
                    }
                }
            }
            return isFree;
        }
    }
}