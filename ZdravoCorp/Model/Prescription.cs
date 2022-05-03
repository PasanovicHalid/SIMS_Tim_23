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
        private int id;
        private int timesADay;
        private int durationDays;
        private int quantity;

        private Medication medication;

        private Notification notification;

        public int Id { get => id; set => id = value; }

        public Prescription(int id)
        {
            this.id = id;
        }

        public List<String> ToCSV()
        {
            List<String> result = new List<String>();
            result.Add(id.ToString());
            result.Add(timesADay.ToString());
            result.Add(durationDays.ToString());
            result.Add(quantity.ToString());
            /*Mozda nije dobro*/
            result.Add(medication.Id.ToString());
            result.Add(notification.Id.ToString());
            return result;
        }

        public void FromCSV(string[] values)
        {
            int i = 0;
            id = int.Parse(values[i++]);
            timesADay = int.Parse(values[i++]);
            durationDays = int.Parse (values[i++]);
            quantity = int.Parse(values[i++]);
            /*Mozda nije dobro*/
            medication.Id = int.Parse(values[i++]);
            notification.Id = int.Parse(values[i++]);

        }
    }
}