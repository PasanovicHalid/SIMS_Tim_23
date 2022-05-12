/***********************************************************************
 * Module:  Appointment.cs
 * Author:  PCX
 * Purpose: Definition of the Class Model.Appointment
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Model
{
    public class Appointment : Serializable
    {
        CultureInfo dateTimeFormat = new CultureInfo("en-GB");

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
        public Room room { get; set; }

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
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public String NameSurname { get => doctor.nameSurname; set => doctor.nameSurname = value; }

        public int DoctorID { get => doctor.Id; set => doctor.Id = value; }

        public int RoomID { get => room.Identifier; set => room.Identifier = value; }

        public int PatientID { get => patient.Id; set => patient.Id = value; }

        public List<String> ToCSV()
        {
            CultureInfo dateTimeFormat = new CultureInfo("en-GB");
            List<String> result = new List<String>();
            result.Add(Id.ToString());
            result.Add(StartDate.ToString(dateTimeFormat));
            result.Add(EndDate.ToString(dateTimeFormat));
            result.Add(doctor.Id.ToString());
            result.Add(Room.Identifier.ToString());
            result.Add(Patient.Id.ToString());
            return result;
        }

        public void FromCSV(string[] values)
        {
            CultureInfo dateTimeFormat = new CultureInfo("en-GB");
            int i = 0;
            Id = int.Parse(values[i++]);
            StartDate = DateTime.Parse(values[i++], dateTimeFormat);
            EndDate = DateTime.Parse(values[i++], dateTimeFormat);
            doctor = new Doctor(int.Parse(values[i++]));
            Room = new Room(int.Parse(values[i++]));
            Patient = new Patient(int.Parse(values[i++]));
        }
    }
}