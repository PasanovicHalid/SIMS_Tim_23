/***********************************************************************
 * Module:  Rooms.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Rooms
 ***********************************************************************/

using System;

namespace Model
{
   public class Room : Repository.Serializable
   {
      private String identifier;
      private float size;
      
      private RoomType type;
      
      /// <summary>
      /// Property for RoomType
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public RoomType Type
      {
         get
         {
            return type;
         }
         set
         {
            this.type = value;
         }
      }
      
      public System.Collections.ArrayList equipmentList;
      
      /// <summary>
      /// Property for collection of Equipment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList EquipmentList
      {
         get
         {
            if (equipmentList == null)
               equipmentList = new System.Collections.ArrayList();
            return equipmentList;
         }
         set
         {
            RemoveAllEquipmentList();
            if (value != null)
            {
               foreach (Equipment oEquipment in value)
                  AddEquipmentList(oEquipment);
            }
         }
      }
      
      /// <summary>
      /// Add a new Equipment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddEquipmentList(Equipment newEquipment)
      {
         if (newEquipment == null)
            return;
         if (this.equipmentList == null)
            this.equipmentList = new System.Collections.ArrayList();
         if (!this.equipmentList.Contains(newEquipment))
         {
            this.equipmentList.Add(newEquipment);
            newEquipment.Location = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Equipment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveEquipmentList(Equipment oldEquipment)
      {
         if (oldEquipment == null)
            return;
         if (this.equipmentList != null)
            if (this.equipmentList.Contains(oldEquipment))
            {
               this.equipmentList.Remove(oldEquipment);
               oldEquipment.Location = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Equipment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllEquipmentList()
      {
         if (equipmentList != null)
         {
            System.Collections.ArrayList tmpEquipmentList = new System.Collections.ArrayList();
            foreach (Equipment oldEquipment in equipmentList)
               tmpEquipmentList.Add(oldEquipment);
            equipmentList.Clear();
            foreach (Equipment oldEquipment in tmpEquipmentList)
               oldEquipment.Location = null;
            tmpEquipmentList.Clear();
         }
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