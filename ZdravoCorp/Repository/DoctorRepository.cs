// File:    DoctorRepository.cs
// Author:  10
// Created: Monday, 11 April 2022 21:52:49
// Purpose: Definition of Class DoctorRepository

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using ZdravoCorp.Exceptions;

namespace Repository
{
    public class DoctorRepository : UserRepository<Doctor>
    {
        private static DoctorRepository instance = null;

        public DoctorRepository()
        {
            dbPath = "..\\..\\Data\\doctorsDB.csv";
            InstantiateHashSets(GetAll());
        }

        public new List<Doctor> GetAll()
        {
            lock (key)
            {
                List<Doctor> doctors = base.GetAll();
                foreach (Doctor it in doctors)
                {
                    it.Appointment = AppointmentRepository.Instance
                        .GetAppointmentsById(GetIdsOfAppointments(it));
                }
                return doctors;
            }
        }

        public Dictionary<string, Doctor> GetUsernameHashSet()
        {
            return Users;
        }

        public override Doctor Read(int id)
        {
            lock (key)
            {
                CheckIfIDExists(id);
                return FindDoctorByID(GetAll(), id);
            }
        }

        public override void Create(Doctor element)
        {
            lock (key)
            {
                List<Doctor> elements = GetAll();
                CheckIfDoctorExists(elements, element);
                CheckIfUsernameExists(element.Username);
                element.Id = GenerateID();
                Users.Add(element.Username, element);
                idMap.Add(element.Id);
                AppendToDB(element);
            }
        }

        public override void Update(Doctor element)
        {
            lock (key)
            {
                CheckIfIDExists(element.Id);
                CheckIfUsernameExists(element.Username);
                List<Doctor> elements = GetAll();
                SwapDoctorByID(elements, element);
                SaveChanges(elements);
            }
        }

        public override void Delete(int id)
        {
            lock (key)
            {
                CheckIfIDExists(id);
                List<Doctor> elements = GetAll();
                DeleteDoctorByID(elements, id);
                SaveChanges(elements);
            }
        }

        protected override void InstantiateIDSet(List<Doctor> elements)
        {
            lock (key)
            {
                foreach(Doctor element in elements)
                {
                    idMap.Add(element.Id);
                }
            }
        }

        private void InstantiateHashSets(List<Doctor> doctors)
        {
            InstantiateIDSet(doctors);
            InstantiateUserSet(doctors);
        }

        private void CheckIfDoctorExists(List<Doctor> doctors, Doctor doctor)
        {
            foreach (Doctor it in doctors)
            {
                if (it.Jmbg.Equals(doctor.Jmbg))
                {
                    throw new LocalisedException("UserExists");
                }
            }
        }

        private void CheckIfUsernameExists(string username)
        {
            if (Users.ContainsKey(username))
                throw new LocalisedException("UserExists");
        }

        private void CheckIfIDExists(int id)
        {
            if (idMap.Contains(id))
                throw new LocalisedException("UserDoesntExist");
        }

        private Doctor FindDoctorByID(List<Doctor> doctors, int id)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == id)
                {
                    return doctors[i];
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private void DeleteDoctorByID(List<Doctor> doctors, int id)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == id)
                {
                    idMap.Remove(id);
                    Users.Remove(doctors[i].Username);
                    doctors.RemoveAt(i);
                    return;
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private void SwapDoctorByID(List<Doctor> doctors, Doctor doctor)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == doctor.Id)
                {
                    doctors[i] = doctor;
                    return;
                }
            }
            throw new LocalisedException("UserDoesntExist");
        }

        private List<int> GetIdsOfAppointments(Doctor doctor)
        {
            List<int> ids = new List<int>();
            foreach (Appointment it in doctor.Appointment)
            {
                ids.Add(it.Id);
            }
            return ids;
        }

        public static DoctorRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new DoctorRepository();
                        }
                    }
                }
                return instance;
            }
        }

    }
}