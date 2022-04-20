/***********************************************************************
 * Module:  Appointment.cs
 * Author:  PCX
 * Purpose: Definition of the Class Model.Appointment
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Appointment : Serializable
    {
        private DateTime startDate;
        private DateTime endDate;
        private int id;

        public Appointment(int id)
        {
            this.id = id;
        }

        public Appointment(DateTime startDate, DateTime endDate, int id, List<Doctor> doctor, Room room, Patient patient)
        {
            StartDate = startDate;
            EndDate = endDate;
            Id = id;
            this.doctor = doctor;
            this.room = room;
            this.patient = patient;
        }

        private List<Doctor> doctor;

        /// <summary>
        /// Property for collection of Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Doctor> Doctor
        {
            get
            {
                if (doctor == null)
                    doctor = new List<Doctor>();
                return doctor;
            }
            set
            {
                RemoveAllDoctor();
                if (value != null)
                {
                    foreach (Doctor oDoctor in value)
                        AddDoctor(oDoctor);
                }
            }
        }

        /// <summary>
        /// Add a new Doctor in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddDoctor(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this.doctor == null)
                this.doctor = new List<Doctor>();
            if (!this.doctor.Contains(newDoctor))
            {
                this.doctor.Add(newDoctor);
                newDoctor.AddAppointment(this);
            }
        }

        /// <summary>
        /// Remove an existing Doctor from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveDoctor(Doctor oldDoctor)
        {
            if (oldDoctor == null)
                return;
            if (this.doctor != null)
                if (this.doctor.Contains(oldDoctor))
                {
                    this.doctor.Remove(oldDoctor);
                    oldDoctor.RemoveAppointment(this);
                }
        }

        /// <summary>
        /// Remove all instances of Doctor from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllDoctor()
        {
            if (doctor != null)
            {
                System.Collections.ArrayList tmpDoctor = new System.Collections.ArrayList();
                foreach (Doctor oldDoctor in doctor)
                    tmpDoctor.Add(oldDoctor);
                doctor.Clear();
                foreach (Doctor oldDoctor in tmpDoctor)
                    oldDoctor.RemoveAppointment(this);
                tmpDoctor.Clear();
            }
        }
        private Room room;

        /// <summary>
        /// Property for Room
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Room Room
        {
            get
            {
                return room;
            }
            set
            {
                if (this.room == null || !this.room.Equals(value))
                {
                    if (this.room != null)
                    {
                        Room oldRoom = this.room;
                        this.room = null;
                        oldRoom.RemoveAppointment(this);
                    }
                    if (value != null)
                    {
                        this.room = value;
                        this.room.AddAppointment(this);
                    }
                }
            }
        }
        private Patient patient;
        public Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                if (this.patient == null || !this.patient.Equals(value))
                {
                    if (this.patient != null)
                    {
                        Patient oldPatient = this.patient;
                        this.patient = null;
                    }
                    if (value != null)
                    {
                        this.patient = value;
                    }
                }
            }
        }

        public int Id { get => id; set => id = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public List<String> ToCSV()
        {
            List<String> result = new List<String>();
            result.Add(Id.ToString());
            result.Add(StartDate.ToString());
            result.Add(EndDate.ToString());
            result.Add(Doctor.Count.ToString());
            foreach (Doctor d in Doctor)
            {
                result.Add(d.Id.ToString());
            }
            result.Add(Room.Identifier.ToString());
            result.Add(Patient.Id.ToString());
            return result;
        }

        public void FromCSV(string[] values)
        {
            int i = 0;
            Id = int.Parse(values[i++]);
            StartDate = DateTime.Parse(values[i++]);
            EndDate = DateTime.Parse(values[i++]);
            int count = int.Parse(values[i++]);
            doctor = new List<Doctor>();
            for (; i < i + count; i++)
            {
                doctor.Add(new Doctor(int.Parse(values[i++])));
            }
            Room = new Room(int.Parse(values[i++]));
            Patient = new Patient(int.Parse(values[i++]));
        }
    }
}