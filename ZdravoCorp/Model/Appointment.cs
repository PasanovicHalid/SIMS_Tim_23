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
        private String appointmentId;
        private int type;
        private int id;

        public Appointment(int id)
        {
            this.id = id;
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

        public string AppointmentId { get => appointmentId; set => appointmentId = value; }
        public int Id { get => id; set => id = value; }

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

        public List<String> ToCSV()
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}