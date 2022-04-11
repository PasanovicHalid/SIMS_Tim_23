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

        public EquipmentDescriptor()
        {
            name = "";
            description = "";
        }

        public EquipmentDescriptor(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public void FromCSV(string[] values)
        {
            name = values[0];
            description = values[1];
        }

        public string[] ToCSV()
        {
            string[] csvValue =
              {
                name,
                description
            };
            return csvValue;
        }
    }
}