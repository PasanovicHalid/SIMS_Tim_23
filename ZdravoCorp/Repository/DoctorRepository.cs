// File:    DoctorRepository.cs
// Author:  10
// Created: Monday, 11 April 2022 21:52:49
// Purpose: Definition of Class DoctorRepository

using System;
using Model;
using System.Collections.Generic;

namespace Repository
{
   public class DoctorRepository
   {
        private String dbPath;
        private Serializer<Doctor> serializer;

        public DoctorRepository()
        {
            dbPath = "Resourses\\doctors.csv";
            serializer = new Serializer<Doctor>();
        }

        public Boolean CreateDoctor(Model.Doctor newDoctor)
      {
            dbPath = "Resourses\\doctors.csv";
            serializer = new Serializer<Doctor>();
            List<Doctor> doctors = serializer.FromCSV(dbPath);
            bool found = false;
            foreach (Doctor d in doctors)
            {
                if (newDoctor.Id.Equals(d.Id))
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                return false;
            }
            else
            {
                List<Doctor> temp = new List<Doctor> { newDoctor };
                serializer.ToCSVAppend(dbPath, temp);
                return true;
            }
        }
      
      public Boolean UpdateDoctor(Model.Doctor doctor)
      {
            return true;
        }
      
      public Boolean DeleteDoctor(Model.Doctor doctor)
      {
            return true;
      }
      
      public Model.Doctor ReadDoctor(Model.Doctor doctor)
      {
            List<Doctor> rooms = GetAllDoctors();
            foreach (Doctor d in rooms)
            {
                if (d.Id.Equals(doctor.Id))
                {
                    return d;
                }
            }
            return null;
        }
      
      public List<Doctor> GetAllDoctors()
      {
            return serializer.FromCSV(dbPath);
        }
   
   }
}