/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  10
 * Purpose: Definition of the Class Service.DoctorService
 ***********************************************************************/

using System;
using Repository;
using Model;

namespace Service
{
    public class DoctorService
    {
        DoctorRepository doctorRepository;

        public DoctorService()
        {
            doctorRepository = new DoctorRepository();
        }
        public Boolean CreateDoctor(Doctor newDoctor)
        {
            return doctorRepository.CreateDoctor(newDoctor);
        }

        public Boolean UpdateDoctor(Doctor updatedDoctor)
        {
            return doctorRepository.UpdateDoctor(updatedDoctor);
        }

        public Boolean DeleteDoctor(Doctor doctor)
        {
            return doctorRepository.DeleteDoctor(doctor);
        }

        public Doctor ReadDoctor(Doctor doctor)
        {
            return doctorRepository.ReadDoctor(doctor);
        }

        public Array GetAllDoctors()
        {
            return doctorRepository.GetAllDoctors();
        }


    }
}
