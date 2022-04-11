/***********************************************************************
 * Module:  Equipment.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Equipment
 ***********************************************************************/

using System;

namespace Model
{
   public class Equipment : Repository.Serializable
   {
      private String identifier;
      
      private EquipmentDescriptor description;
      
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
      
      public Room location;
      
      /// <summary>
      /// Property for Room
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Room Location
      {
         get
         {
            return location;
         }
         set
         {
            if (this.location == null || !this.location.Equals(value))
            {
               if (this.location != null)
               {
                  Room oldRoom = this.location;
                  this.location = null;
                  oldRoom.RemoveEquipmentList(this);
               }
               if (value != null)
               {
                  this.location = value;
                  this.location.AddEquipmentList(this);
               }
            }
         }
      }
   
   }
}