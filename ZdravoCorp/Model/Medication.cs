// File:    Medication.cs
// Author:  halid
// Created: Thursday, 14 April 2022 21:58:54
// Purpose: Definition of Class Medication

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Medication : Serializable
    {
        private int id;
        private int count;

        private MedicationType medicationType;

        /// <summary>
        /// Property for MedicationType
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public MedicationType MedicationType
        {
            get
            {
                return medicationType;
            }
            set
            {
                this.medicationType = value;
            }
        }
        public int Id { get => id; set => id = value; }
        public int Count { get => count; set => count = value; }

        public Medication(int id, int count)
        {
            this.medicationType = new MedicationType(id);
            this.count = count;
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