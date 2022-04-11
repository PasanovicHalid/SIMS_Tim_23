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

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }

        public string[] ToCSV()
        {
            throw new NotImplementedException();
        }
    }
}