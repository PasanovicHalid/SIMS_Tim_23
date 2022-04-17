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
            throw new NotImplementedException();
        }

        public Boolean UpdateDoctor(Doctor updatedRoom)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Doctor ReadDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Array GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public Boolean CreateDoctorType(DoctorType newDoctorType)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateDoctorType(DoctorType doctorType)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteDoctorType(DoctorType doctorType)
        {
            throw new NotImplementedException();
        }

        public DoctorType ReadDoctorType(DoctorType doctorType)
        {
            throw new NotImplementedException();
        }

        public List<DoctorType> GetAllDoctorType()
        {
            throw new NotImplementedException();
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