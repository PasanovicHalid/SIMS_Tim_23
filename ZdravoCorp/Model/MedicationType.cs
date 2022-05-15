// File:    MedicationType.cs
// Author:  halid
// Created: Sunday, 17 April 2022 01:56:20
// Purpose: Definition of Class MedicationType

using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class MedicationType : Serializable
    {
        private int id;
        private String name;
        private String manufacturer;
        private String description;
        private List<MedicationType> replacement;

        public int Id { get => id; set => id = value; }
        public String Name { get => name; set => name = value; }    
        public String Manufacturer { get => manufacturer; set => manufacturer = value; }    
        public String Description { get => description; set => description = value; }
        public List<MedicationType> Replacement { get => replacement; set => replacement = value; }

        public MedicationType(int id)
        {
            this.Id = id;
        }

        public MedicationType(int id, string name, string manufacturer, string description) : this(id)
        {
            this.name = name;
            this.manufacturer = manufacturer;
            this.description = description;
            Replacement = new List<MedicationType>();
        }

        public MedicationType()
        {
        }

        private void InfoToListString(List<string> result)
        {
            result.Add(id.ToString());
            result.Add(Name);
            result.Add(Manufacturer);
            result.Add(Description);
        }

        private void ReplacementsToListString(List<string> result)
        {
            result.Add(Replacement.Count.ToString());
            foreach(MedicationType type in Replacement)
            {
                result.Add(type.Id.ToString());
            }
        }

        public List<string> ToCSV()
        {
            List<string> result = new List<string>();
            InfoToListString(result);
            ReplacementsToListString(result);
            return result;
        }

        private string[] ReadInfo(string[] values)
        {
            int i = 0;
            Id = int.Parse(values[i++]);
            Name = values[i++];
            Manufacturer = values[i++];
            Description = values[i++];
            return values.Skip(i).ToArray();
        }

        private string[] ReadReplacements(string[] values)
        {
            Replacement = new List<MedicationType>();
            int i = 0;
            int count = int.Parse(values[i++]) + i;
            for(; i < count; i++)
            {
                Replacement.Add(new MedicationType(int.Parse(values[i])));
            }
            return values.Skip(i).ToArray();
        }

        public void FromCSV(string[] values)
        {
            values = ReadInfo(values);
            ReadReplacements(values);
        }
    }
}