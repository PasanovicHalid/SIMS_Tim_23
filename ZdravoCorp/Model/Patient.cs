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


        public Patient(int id)
        {
            this.id = id;
        }

        public Patient()
        {
        }

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
            List<String> result = new List<String>();
            result.Add(Id.ToString());
            result.Add(password);
            result.Add(username);
            result.Add(name);
            result.Add(surname);
            result.Add(jmbg);
            result.Add(email);
            result.Add(address);
            result.Add(phoneNumber);
            result.Add(gender.ToString());
            result.Add(dateOfBirth.ToString());
            result.Add(notification.Count.ToString());
            /*Mozda nije dobro*/
            foreach (Notification n in notification)
            {
                result.Add(n.DateCreated.ToString());
                result.Add(n.Content);
                result.Add(n.User.Id.ToString());
            }
            result.Add(appointment.Count.ToString());
            foreach(Appointment a in appointment)
            {
                result.Add(a.Id.ToString());
            }
            result.Add(prescription.Count.ToString());
            foreach(Prescription p in prescription)
            {
                result.Add(p.Id.ToString());
            }
            return result;
        }

        public void FromCSV(string[] values)
        {
            int i = 0;
            id = int.Parse(values[i++]);
            password = values[i++];
            username = values[i++];
            name = values[i++];
            surname = values[i++];
            jmbg = values[i++];
            email = values[i++];
            address = values[i++];
            phoneNumber = values[i++];
            if (values[i++] == "Male")
            {
                gender = Gender.Male;
            }
            else
            {
                gender = Gender.Female;
            }
            dateOfBirth = DateTime.Parse(values[i++]);
            int count = int.Parse(values[i++]);
            /*Mozda nije dobro*/
            for (int j = 0; j < count; j++)
            {
                notification.Add(new Notification(DateTime.Parse(values[i++]), values[i++], int.Parse(values[i++])));
            }

            int count2 = int.Parse(values[i++]);
            for(int j = 0; j < count2; j++)
            {
                appointment.Add(new Appointment(int.Parse(values[i++])));
            }

            int count3 = int.Parse(values[i++]);
            for (int j = 0; j < count3; j++)
            {
                prescription.Add(new Prescription(int.Parse(values[i++])));
            }
        }

    }
}