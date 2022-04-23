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
        private String dbPath = "..\\..\\Data\\doctorsDB.csv";
        private String DbDoctorType = "..\\..\\Data\\doctorTypesDB.csv";
        private Serializer<Doctor> serializerDoctor = new Serializer<Doctor>();
        private Serializer<DoctorType> serializerDoctorType = new Serializer<DoctorType>();

        private static DoctorRepository instance = null;

        public Boolean CreateDoctor(Model.Doctor newDoctor)
        {
            List<Doctor> doctors = GetAllDoctors();
            bool exists = false;
            
            foreach(Doctor d in doctors)
            {
                if(d.Jmbg.Equals(newDoctor.Jmbg))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                newDoctor.Id = doctors.Count + 1;
                doctors.Add(newDoctor);
                serializerDoctor.ToCSV(dbPath, doctors);
                return true;
            }
            return false;
        }

        public Boolean UpdateDoctor(Model.Doctor doctor)
        {
            Boolean success = false;
            List<Doctor> doctors = GetAllDoctors();
            foreach(Doctor d in doctors)
            {
                if (doctor.Id.Equals(d.Id))
                {
                    success = true;
                    doctors.Remove(d);
                    break;
                }
            }
            if (success)
            {
                doctors.Add(doctor);
                serializerDoctor.ToCSV(dbPath, doctors);
                
            }
            return success;
        }

        public Boolean DeleteDoctor(int id)
        {
            Boolean success = false;
            List<Doctor> doctors = GetAllDoctors();
            foreach (Doctor d in doctors)
            {
                if (id.Equals(d.Id))
                {
                    success = true;
                    doctors.Remove(d);
                    serializerDoctor.ToCSV(dbPath, doctors);
                    break;
                }
            }
            return success;
        }

        public Model.Doctor ReadDoctor(int id)
        {
            List<Doctor> doctors = GetAllDoctors();
            foreach (Doctor d in doctors)
            {
                if (id == d.Id)
                {
                    return d ;
                }
            }
            return null;
        }

        public List<Doctor> GetAllDoctors()
        {
            return serializerDoctor.FromCSV(dbPath);
        }

        public Boolean CreateDoctorType(DoctorType newDoctorType)
        {
            List<DoctorType> dcType = GetAllDoctorType();
            dcType.Add(newDoctorType);
            serializerDoctorType.ToCSV(dbPath, dcType);
            return true;
        }

        public Boolean UpdateDoctorType(DoctorType doctorType)
        {
            List<DoctorType> dcType = GetAllDoctorType();
            foreach (DoctorType dct in dcType)
            {
                if (dct.Type.Equals(doctorType.Type))
                {
                    dcType.Remove(doctorType);
                    break;
                }
            }
            dcType.Add(doctorType);
            serializerDoctorType.ToCSV(dbPath, dcType);
            return true;
        }

        public Boolean DeleteDoctorType(DoctorType doctorType)
        {
            List<DoctorType> dcType = GetAllDoctorType();
            foreach(DoctorType dct in dcType)
            {
                if (dct.Type.Equals(doctorType.Type))
                {
                    dcType.Remove(doctorType);
                    break;
                }
            }
            serializerDoctorType.ToCSV(dbPath, dcType);
            return true;
        }

        public DoctorType ReadDoctorType(DoctorType doctorType)
        {
            List<DoctorType> dcType = GetAllDoctorType();
            foreach (DoctorType dct in dcType)
            {
                if (dct.Type.Equals(doctorType.Type))
                {
                    return doctorType;
                }
            }
            return null;
        }

        public List<DoctorType> GetAllDoctorType()
        {
            return serializerDoctorType.FromCSV(dbPath);
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