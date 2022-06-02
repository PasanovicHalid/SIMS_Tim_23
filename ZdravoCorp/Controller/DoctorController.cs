/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using System;
using Service;
using System.Collections.Generic;

namespace Controller
{
    public class DoctorController
    {
        public Boolean CreateDoctor(Model.Doctor newDoctor)
        {
            return DoctorService.Instance.CreateDoctor(newDoctor);
        }

        public Boolean UpdateDoctor(Model.Doctor updatedRoom)
        {
            return DoctorService.Instance.UpdateDoctor(updatedRoom);
        }

        public Boolean DeleteDoctor(int doctor)
        {
            return DoctorService.Instance.DeleteDoctor(doctor);
        }

        public Model.Doctor ReadDoctor(int doctor)
        {
            return DoctorService.Instance.ReadDoctor(doctor);
        }
        
        public List<Doctor> GetAllDoctors()
        {
            return DoctorService.Instance.GetAllDoctors();
        }

        public Boolean CreateDoctorType(DoctorType newDoctorType)
        {
            return DoctorService.Instance.CreateDoctorType(newDoctorType);
        }

        public Boolean UpdateDoctorType(DoctorType doctorType)
        {
            return DoctorService.Instance.UpdateDoctorType(doctorType);
        }

        public Boolean DeleteDoctorType(DoctorType doctorType)
        {
            return DoctorService.Instance.DeleteDoctorType(doctorType.Type);
        }

        public DoctorType ReadDoctorType(DoctorType doctorType)
        {
            return DoctorService.Instance.ReadDoctorType(doctorType.Type);
        }

        public List<DoctorType> GetAllDoctorType()
        {
            return DoctorService.Instance.GetAllDoctorType();
        }
    }
}