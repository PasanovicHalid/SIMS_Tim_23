// File:    MedicationType.cs
// Author:  halid
// Created: Sunday, 17 April 2022 01:56:20
// Purpose: Definition of Class MedicationType

using System;

namespace Model
{
    public class MedicationType
    {
        private int id;

        public MedicationType(int id)
        {
            this.Id = id;
        }
        private String name;
        private String manufacturer;
        private String description;

        public int Id { get => id; set => id = value; }
    }
}