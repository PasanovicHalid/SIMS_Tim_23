// File:    RenovationAction.cs
// Author:  halid
// Created: Sunday, 24 April 2022 22:24:01
// Purpose: Definition of Class RenovationAction

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class RenovationAction : Serializable
    {
        private DateTime expirationDate;

        private int id_room;
        private bool renovation;

        public void FromCSV(string[] values)
        {
            this.expirationDate = DateTime.Parse(values[0]);
            this.id_room = int.Parse(values[1]);
            this.renovation =Boolean.Parse(values[2]);
        }

        public List<string> ToCSV()
        {
            List<String> result = new List<String>();
            result.Add(expirationDate.ToString());
            result.Add(id_room.ToString());
            result.Add(renovation.ToString());

            return result;
        }
    }
}