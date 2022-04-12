/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using System;
using Model;
using System.Collections.Generic;

namespace Controller
{
   public class DoctorController
   {
        public Service.DoctorService doctorService;

        public DoctorController()
        {
            doctorService = new Service.DoctorService() ;
        }

        public Boolean CreateDoctor(Model.Doctor newDoctor)
      {
         return doctorService.CreateDoctor(newDoctor);
      }
      
      public Boolean UpdateDoctor(Model.Doctor updatedRoom)
      {
        return doctorService.UpdateDoctor(updatedRoom);
      }
      
      public Boolean DeleteDoctor(Model.Doctor doctor)
      {
            return doctorService.DeleteDoctor(doctor);
      }
      
      public Model.Doctor ReadDoctor(Model.Doctor doctor)
      {
            return doctorService.ReadDoctor(doctor);
      }
      
      public List<Doctor> GetAllDoctors()
      {
            return doctorService.GetAllDoctors();
      }
      
   
   }
}