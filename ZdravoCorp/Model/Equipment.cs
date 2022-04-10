/***********************************************************************
 * Module:  Equipment.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Equipment
 ***********************************************************************/

using System;
using System.Linq;

namespace Model
{
   public class Equipment : Repository.Serializable
   {
      private String identifier;
      
      private EquipmentDescriptor description;

      public string locationIdentifier;

        public Equipment()
        {

        }

        public Equipment(string ident, EquipmentDescriptor desc, string local)
        {
            this.identifier = ident;
            this.description = desc;
            this.locationIdentifier = local;
        }

        /// <summary>
        /// Property for EquipmentDescriptor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
      public EquipmentDescriptor Description
      {
         get
         {
            return description;
         }
         set
         {
            this.description = value;
         }
      }
      
      

      public string[] ToCSV()
      {
            string[] csvValue =
              {
                identifier,
                locationIdentifier
            };
            csvValue = csvValue.Concat(description.ToCSV()).ToArray();
            return csvValue;
        }

      public void FromCSV(string[] values)
      {
          identifier = values[0];
          locationIdentifier = values[1];
          description = new EquipmentDescriptor(values[2], values[3]);
      }
    }
}