// File:    DoctorType.cs
// Author:  halid
// Created: Thursday, 14 April 2022 22:30:27
// Purpose: Definition of Class DoctorType

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class DoctorType : Serializable
    {
        private String type;

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