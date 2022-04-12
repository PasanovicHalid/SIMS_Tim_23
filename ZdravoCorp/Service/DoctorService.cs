/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using System;
using Model;
using System.Collections.Generic;

namespace Service
{
   public class DoctorService
   {
        public Repository.DoctorRepository doctorRepository;
        public DoctorService()
        {
            doctorRepository = new Repository.DoctorRepository();
        }
        public Boolean CreateDoctor(Model.Doctor newDoctor)
      {
            return doctorRepository.CreateDoctor(newDoctor);
      }
      
      public Boolean UpdateDoctor(Model.Doctor updatedRoom)
      {
        return doctorRepository.UpdateDoctor(updatedRoom);  
      }
      
      public Boolean DeleteDoctor(Model.Doctor doctor)
      {
         return doctorRepository.DeleteDoctor(doctor);
      }
      
      public Model.Doctor ReadDoctor(Model.Doctor doctor)
      {
            return doctorRepository.ReadDoctor(doctor);
      }
      
      public List<Doctor> GetAllDoctors()
      {
            return doctorRepository.GetAllDoctors();
      }
      


        
    }
}