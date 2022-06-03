/***********************************************************************
 * Module:  RoomController.cs
 * Author:  halid
 * Purpose: Definition of the Class Controller.RoomController
 ***********************************************************************/

using Model;
using System;
using Repository;
using Service;
using System.Collections.Generic;

namespace Controller
{
    public class DoctorController : ICrud<Doctor>
    {
        public void Create(Model.Doctor newDoctor)
        {
            DoctorService.Instance.Create(newDoctor);
        }

        public void Update(Model.Doctor updatedRoom)
        {
            DoctorService.Instance.Update(updatedRoom);
        }

        public void Delete(int doctor)
        {
            DoctorService.Instance.Delete(doctor);
        }

        public Doctor Read(int doctor)
        {
            return DoctorService.Instance.Read(doctor);
        }
        
        public List<Doctor> GetAll()
        {
            return DoctorService.Instance.GetAll();
        }

        public void CreateDoctorType(DoctorType newDoctorType)
        {
            DoctorService.Instance.CreateDoctorType(newDoctorType);
        }

        public void UpdateDoctorType(DoctorType doctorType)
        {
            DoctorService.Instance.UpdateDoctorType(doctorType);
        }

        public void DeleteDoctorType(DoctorType doctorType)
        {
            DoctorService.Instance.DeleteDoctorType(doctorType.Type);
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