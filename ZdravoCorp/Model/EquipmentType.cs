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
    public class EquipmentType : Serializable
    {
        private int identifier;

        public EquipmentType(int identifier)
        {
            this.Identifier = identifier;
        }

        public EquipmentType()
        {
        }

        private String name;
        private String description;
        private bool disposable;

        public int Identifier { get => identifier; set => identifier = value; }
        public string Name { get => name; set => name = value; }

        public void FromCSV(string[] values)
        {
            this.identifier = int.Parse(values[0]);
            this.Name = values[1];
            this.description = values[2];
            this.disposable = bool.Parse(values[3]);
        }

        public List<String> ToCSV()
        {
            List<String> result = new List<String>();

            result.Add(identifier.ToString());
            result.Add(Name.ToString());
            result.Add(description.ToString());
            result.Add(disposable.ToString());

            return result;
        }
    }
}