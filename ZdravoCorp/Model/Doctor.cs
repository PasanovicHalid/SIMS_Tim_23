/***********************************************************************
 * Module:  Doctor.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Doctor
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Doctor : Employee, Serializable
    {
        private List<Appointment> appointment;

        public Doctor(int id)
        {
            this.id = id;
        }
        /// <summary>
        /// Property for collection of Appointment
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Appointment> Appointment
        {
            get
            {
                if (appointment == null)
                    appointment = new List<Appointment>();
                return appointment;
            }
            set
            {
                RemoveAllAppointment();
                if (value != null)
                {
                    foreach (Appointment oAppointment in value)
                        AddAppointment(oAppointment);
                }
            }
        }

        /// <summary>
        /// Add a new Appointment in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new List<Appointment>();
            if (!this.appointment.Contains(newAppointment))
            {
                this.appointment.Add(newAppointment);
                newAppointment.AddDoctor(this);
            }
        }

        /// <summary>
        /// Remove an existing Appointment from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointment != null)
                if (this.appointment.Contains(oldAppointment))
                {
                    this.appointment.Remove(oldAppointment);
                    oldAppointment.RemoveDoctor(this);
                }
        }

        /// <summary>
        /// Remove all instances of Appointment from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAppointment()
        {
            if (appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.RemoveDoctor(this);
                tmpAppointment.Clear();
            }
        }
        private DoctorType doctorType;

        /// <summary>
        /// Property for DoctorType
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public DoctorType DoctorType
        {
            get
            {
                return doctorType;
            }
            set
            {
                this.doctorType = value;
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