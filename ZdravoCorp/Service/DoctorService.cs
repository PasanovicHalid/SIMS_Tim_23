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

        public Boolean DeleteDoctor(Doctor doctor)
        {
            return DoctorRepository.Instance.DeleteDoctor(doctor);
        }

        public Doctor ReadDoctor(Doctor doctor)
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

        public Boolean DeleteDoctorType(DoctorType doctorType)
        {
            return DoctorRepository.Instance.DeleteDoctorType(doctorType);
        }

        public DoctorType ReadDoctorType(DoctorType doctorType)
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
    }
}