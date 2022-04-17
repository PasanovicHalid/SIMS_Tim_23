// File:    DoctorRepository.cs
// Author:  10
// Created: Monday, 11 April 2022 21:52:49
// Purpose: Definition of Class DoctorRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class DoctorRepository
    {
        private String dbPath;

        private static DoctorRepository instance = null;

        public Boolean CreateDoctor(Model.Doctor newDoctor)
        {
            throw new NotImplementedException();
        }

        public Boolean UpdateDoctor(Model.Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteDoctor(Model.Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Model.Doctor ReadDoctor(Model.Doctor doctor)
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

        public DoctorRepository()
        {
            
        }

        public static DoctorRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new DoctorRepository();
                }
                return instance ;
            }
        }

    }
}