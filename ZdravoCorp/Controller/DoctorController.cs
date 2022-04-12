/***********************************************************************
 * Module:  DoctorController.cs
 * Author:  10
 * Purpose: Definition of the Class Controller.DoctorController
 ***********************************************************************/

using System;
using Service;
using Repository;
using Model;

namespace Controller
{
    public class DoctorController
    {
        public DoctorService doctorService;


        public Boolean CreateDoctor(Doctor newDoctor)
        {
            return doctorService.CreateDoctor(newDoctor); 
        }

        public Boolean UpdateDoctor(Doctor updatedRoom)
        {
            return doctorService.UpdateDoctor(updatedRoom);
        }

        public Boolean DeleteDoctor(Doctor doctor)
        {
            return doctorService.DeleteDoctor(doctor);  
        }

        public Doctor ReadDoctor(Doctor doctor)
        {
            return doctorService.ReadDoctor(doctor);
        }

        public Array GetAllDoctors()
        {
            return doctorService.GetAllDoctors();
        }


        public DoctorController(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }
    }
}
