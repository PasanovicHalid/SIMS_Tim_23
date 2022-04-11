/***********************************************************************
 * Module:  EquipmentDescriptor.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.EquipmentDescriptor
 ***********************************************************************/

using System;

namespace Model
{
   public class EquipmentDescriptor : Repository.Serializable
   {
      public String name;
      public String description;

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