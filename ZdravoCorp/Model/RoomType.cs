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

        public RoomType()
        {

        }

        public RoomType(string name)
        {
            this.name = name;
        }

        public void FromCSV(string[] values)
        {
            name = values[0];
        }

        public string[] ToCSV()
        {
            string[] csvValue =
            {
                name
            };
            return csvValue;
        }
    }
}