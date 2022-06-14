/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using Repository;
using System;
using System.Collections.Generic;
using ZdravoCorp.Service.Interfaces;

namespace Service
{
    public class DoctorService : ICrud<Doctor> , IDoctorService
    {
        private static DoctorService instance = null;

        public void Create(Doctor newDoctor)
        {
            DoctorRepository.Instance.Create(newDoctor);
        }

        public void Update(Doctor updatedRoom)
        {
            DoctorRepository.Instance.Update(updatedRoom);
        }

        public void Delete(int doctor)
        {
            DoctorRepository.Instance.Delete(doctor);
        }

        public Doctor Read(int doctor)
        {
            return DoctorRepository.Instance.Read(doctor);
        }

        public List<Doctor> GetAll()
        {
            return DoctorRepository.Instance.GetAll();
        }

        public void CreateDoctorType(DoctorType newDoctorType)
        {
            DoctorTypeRepository.Instance.Create(newDoctorType);
        }

        public void UpdateDoctorType(DoctorType doctorType)
        {
            DoctorTypeRepository.Instance.Update(doctorType);
        }

        public void DeleteDoctorType(String doctorType)
        {
            DoctorTypeRepository.Instance.Delete(int.Parse(doctorType));
        }

        public DoctorType ReadDoctorType(String doctorType)
        {
            return DoctorTypeRepository.Instance.Read(int.Parse(doctorType));
        }
        
        public List<DoctorType> GetAllDoctorType()
        {
            return DoctorTypeRepository.Instance.GetAll();
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
            
            Doctor doctor = Read(id);
            List<DateTime> startDates = new List<DateTime>();
            List<DateTime> endDates = new List<DateTime>();
            foreach(Appointment a in doctor.Appointment)
            {
                startDates.Add(a.startDate);
                endDates.Add(a.endDate);
            }
            if (!(startDates.Contains(start) || endDates.Contains(end)))
            {
                isFree = true;
            }
            return isFree;
        }
    }
}