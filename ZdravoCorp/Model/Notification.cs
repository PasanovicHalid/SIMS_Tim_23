/***********************************************************************
 * Module:  Notification.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Notification
 ***********************************************************************/

using System;

namespace Model
{
   public class Notification : Repository.Serializable
   {
      public DateTime dateCreated;
      public String content;
      
      public User creator;
      
      /// <summary>
      /// Property for User
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public User Creator
      {
         get
         {
            return creator;
         }
         set
         {
            if (this.creator == null || !this.creator.Equals(value))
            {
               if (this.creator != null)
               {
                  User oldUser = this.creator;
                  this.creator = null;
                  oldUser.RemoveNotifications(this);
               }
               if (value != null)
               {
                  this.creator = value;
                  this.creator.AddNotifications(this);
               }
            }
         }
      }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }

        public void ToCSV()
        {
            throw new NotImplementedException();
        }
    }
}