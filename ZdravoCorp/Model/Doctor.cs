/***********************************************************************
 * Module:  Doctor.cs
 * Author:  10
 * Purpose: Definition of the Class Model.Doctor
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;

namespace Model
{
    public class Doctor : Employee, Repository.Serializable
    {
        private new String id { get; set; }
        private DoctorType type { get; set; }
      
      public System.Collections.Generic.List<Appointment> appointment;
      
      /// <summary>
      /// Property for collection of Appointment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Appointment> Appointment
      {
         get
         {
            if (appointment == null)
               appointment = new System.Collections.Generic.List<Appointment>();
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
            this.appointment = new System.Collections.Generic.List<Appointment>();
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

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }

        public string[] ToCSV()
        {
            throw new NotImplementedException();
        }

        public Doctor(string id, DoctorType type, List<Appointment> appointment)
        {
            this.id = id;
            this.type = type;
            Appointment = appointment;
        }

        public Doctor() { }
    }
}