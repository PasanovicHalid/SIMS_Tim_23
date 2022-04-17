/***********************************************************************
 * Module:  Equipment.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Equipment
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Equipment : Serializable
    {
        private int count;

        private EquipmentType equipmentType;

        /// <summary>
        /// Property for EquipmentType
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public EquipmentType EquipmentType
        {
            get
            {
                return equipmentType;
            }
            set
            {
                this.equipmentType = value;
            }
        }

        public int Count { get => count; set => count = value; }

        public Equipment(int identifier, int count)
        {
            this.EquipmentType = new EquipmentType(identifier);
            this.Count = count;
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }

        public List<String> ToCSV()
        {
            throw new NotImplementedException();
        }
    }
}