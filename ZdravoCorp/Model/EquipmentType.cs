/***********************************************************************
 * Module:  Equipment.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Equipment
 ***********************************************************************/

using System;

namespace Model
{
    public class EquipmentType
    {
        private int identifier;

        public EquipmentType(int identifier)
        {
            this.Identifier = identifier;
        }

        private String name;
        private String description;
        private bool disposable;

        public int Identifier { get => identifier; set => identifier = value; }
    }
}