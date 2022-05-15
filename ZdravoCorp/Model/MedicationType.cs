// File:    MedicationType.cs
// Author:  halid
// Created: Sunday, 17 April 2022 01:56:20
// Purpose: Definition of Class MedicationType

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class MedicationType : Serializable
    {
        private int id;

        public MedicationType(int id)
        {
            this.Id = id;
        }
        private String name;
        private String manufacturer;
        private String description;
        private List<MedicationType> replacement;

        public int Id { get => id; set => id = value; }
        public String Name { get => name; set => name = value; }    
        public String Manufacturer { get => manufacturer; set => manufacturer = value; }    
        public String Description { get => description; set => description = value; }

        public MedicationType(int id, string name, string manufacturer, string description) : this(id)
        {
            this.name = name;
            this.manufacturer = manufacturer;
            this.description = description;
        }

        public List<string> ToCSV()
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}