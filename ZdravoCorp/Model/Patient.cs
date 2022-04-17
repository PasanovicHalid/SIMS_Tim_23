/***********************************************************************
 * Module:  Patient.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Patient
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Patient : User, Serializable
    {
        private Boolean guest = false;

        private List<Appointment> appointment;

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
                this.appointment.Add(newAppointment);
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
                    this.appointment.Remove(oldAppointment);
        }

        /// <summary>
        /// Remove all instances of Appointment from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAppointment()
        {
            if (appointment != null)
                appointment.Clear();
        }
        private MedicalRecord medicalRecord;
        private List<Prescription> prescription;

        /// <summary>
        /// Property for collection of Prescription
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Prescription> Prescription
        {
            get
            {
                if (prescription == null)
                    prescription = new List<Prescription>();
                return prescription;
            }
            set
            {
                RemoveAllPrescription();
                if (value != null)
                {
                    foreach (Prescription oPrescription in value)
                        AddPrescription(oPrescription);
                }
            }
        }

        /// <summary>
        /// Add a new Prescription in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddPrescription(Prescription newPrescription)
        {
            if (newPrescription == null)
                return;
            if (this.prescription == null)
                this.prescription = new List<Prescription>();
            if (!this.prescription.Contains(newPrescription))
                this.prescription.Add(newPrescription);
        }

        /// <summary>
        /// Remove an existing Prescription from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemovePrescription(Prescription oldPrescription)
        {
            if (oldPrescription == null)
                return;
            if (this.prescription != null)
                if (this.prescription.Contains(oldPrescription))
                    this.prescription.Remove(oldPrescription);
        }

        /// <summary>
        /// Remove all instances of Prescription from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllPrescription()
        {
            if (prescription != null)
                prescription.Clear();
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