// File:    AppointmentController.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:33:59
// Purpose: Definition of Class AppointmentController

using System;

namespace Controller
{
   public class AppointmentController
   {
      public Boolean CreateAppointment(Appointment newAppointment)
      {
         throw new NotImplementedException();
      }
      
      public Appointment ReadAppointment(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Boolean UpdateAppointment(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteAppointment(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Array GetAllAppointments()
      {
         throw new NotImplementedException();
      }
      
      public System.Collections.Generic.List<AppointmenServicet> appointmenServicet;
      
      /// <summary>
      /// Property for collection of Service.AppointmenServicet
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<AppointmenServicet> AppointmenServicet
      {
         get
         {
            if (appointmenServicet == null)
               appointmenServicet = new System.Collections.Generic.List<AppointmenServicet>();
            return appointmenServicet;
         }
         set
         {
            RemoveAllAppointmenServicet();
            if (value != null)
            {
               foreach (Service.AppointmenServicet oAppointmenServicet in value)
                  AddAppointmenServicet(oAppointmenServicet);
            }
         }
      }
      
      /// <summary>
      /// Add a new Service.AppointmenServicet in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAppointmenServicet(Service.AppointmenServicet newAppointmenServicet)
      {
         if (newAppointmenServicet == null)
            return;
         if (this.appointmenServicet == null)
            this.appointmenServicet = new System.Collections.Generic.List<AppointmenServicet>();
         if (!this.appointmenServicet.Contains(newAppointmenServicet))
            this.appointmenServicet.Add(newAppointmenServicet);
      }
      
      /// <summary>
      /// Remove an existing Service.AppointmenServicet from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAppointmenServicet(Service.AppointmenServicet oldAppointmenServicet)
      {
         if (oldAppointmenServicet == null)
            return;
         if (this.appointmenServicet != null)
            if (this.appointmenServicet.Contains(oldAppointmenServicet))
               this.appointmenServicet.Remove(oldAppointmenServicet);
      }
      
      /// <summary>
      /// Remove all instances of Service.AppointmenServicet from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAppointmenServicet()
      {
         if (appointmenServicet != null)
            appointmenServicet.Clear();
      }
   
   }
}