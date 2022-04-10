/***********************************************************************
 * Module:  Patient.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Patient
 ***********************************************************************/

using System;

namespace Model
{
   public class Patient : User, Repository.Serializable
   {
      private Gender gender;
      private int jmbg;
      private String phoneNumber;
      private DateTime dateOfBirth;
      
      public Gender GetGender()
      {
         throw new NotImplementedException();
      }
      
      public void SetGender(Gender gender)
      {
         throw new NotImplementedException();
      }
      
      public System.Collections.ArrayList appointment;
      
      /// <summary>
      /// Property for collection of Appointment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList Appointment
      {
         get
         {
            if (appointment == null)
               appointment = new System.Collections.ArrayList();
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
            this.appointment = new System.Collections.ArrayList();
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

        public void ToCSV()
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}