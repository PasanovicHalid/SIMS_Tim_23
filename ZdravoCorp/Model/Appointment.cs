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
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        private int id;

        public Appointment(int id)
        {
            this.id = id;
        }

        public Appointment()
        {
        }

        public Appointment(DateTime startDate, DateTime endDate, int id, Doctor doctor, Room room, Patient patient)
        {
            StartDate = startDate;
            EndDate = endDate;
            Id = id;
            this.doctor = doctor;
            this.room = room;
            this.patient = patient;
        }

        

        public Doctor doctor { get; set; }

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
            result.Add(doctor.Id.ToString());
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
            doctor = new Doctor(int.Parse(values[i++]));
            Room = new Room(int.Parse(values[i++]));
            Patient = new Patient(int.Parse(values[i++]));
        }
    }
}