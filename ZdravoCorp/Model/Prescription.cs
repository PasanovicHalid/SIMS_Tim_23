// File:    Prescription.cs
// Author:  halid
// Created: Friday, 15 April 2022 01:02:27
// Purpose: Definition of Class Prescription

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Prescription : Serializable
    {
        private int timesADay;
        private int durationDays;

        private List<Medication> medication;

        /// <summary>
        /// Property for collection of Medication
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Medication> Medication
        {
            get
            {
                if (medication == null)
                    medication = new List<Medication>();
                return medication;
            }
            set
            {
                RemoveAllMedication();
                if (value != null)
                {
                    foreach (Medication oMedication in value)
                        AddMedication(oMedication);
                }
            }
        }

        /// <summary>
        /// Add a new Medication in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddMedication(Medication newMedication)
        {
            if (newMedication == null)
                return;
            if (this.medication == null)
                this.medication = new List<Medication>();
            if (!this.medication.Contains(newMedication))
                this.medication.Add(newMedication);
        }

        /// <summary>
        /// Remove an existing Medication from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveMedication(Medication oldMedication)
        {
            if (oldMedication == null)
                return;
            if (this.medication != null)
                if (this.medication.Contains(oldMedication))
                    this.medication.Remove(oldMedication);
        }

        /// <summary>
        /// Remove all instances of Medication from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllMedication()
        {
            if (medication != null)
                medication.Clear();
        }

        public List<String> ToCSV()
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}