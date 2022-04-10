/***********************************************************************
 * Module:  RoomType.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.RoomType
 ***********************************************************************/

using System;

namespace Model
{
   public class RoomType : Repository.Serializable
   {
      public String name;

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