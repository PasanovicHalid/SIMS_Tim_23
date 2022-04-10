/***********************************************************************
 * Module:  Appointment.cs
 * Author:  PCX
 * Purpose: Definition of the Class Model.Appointment
 ***********************************************************************/

using System;

namespace Model
{
   public class Appointment : Repository.Serializable
   {
      private DateTime startDate;
      private DateTime endDate;
      private String appointmentId;
      
      public System.Collections.Generic.List<Notification> notification;
      
      /// <summary>
      /// Property for collection of Notification
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Notification> Notification
      {
         get
         {
            if (notification == null)
               notification = new System.Collections.Generic.List<Notification>();
            return notification;
         }
         set
         {
            RemoveAllNotification();
            if (value != null)
            {
               foreach (Notification oNotification in value)
                  AddNotification(oNotification);
            }
         }
      }
      
      /// <summary>
      /// Add a new Notification in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddNotification(Notification newNotification)
      {
         if (newNotification == null)
            return;
         if (this.notification == null)
            this.notification = new System.Collections.Generic.List<Notification>();
         if (!this.notification.Contains(newNotification))
            this.notification.Add(newNotification);
      }
      
      /// <summary>
      /// Remove an existing Notification from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveNotification(Notification oldNotification)
      {
         if (oldNotification == null)
            return;
         if (this.notification != null)
            if (this.notification.Contains(oldNotification))
               this.notification.Remove(oldNotification);
      }
      
      /// <summary>
      /// Remove all instances of Notification from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllNotification()
      {
         if (notification != null)
            notification.Clear();
      }

        public string[] ToCSV()
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}