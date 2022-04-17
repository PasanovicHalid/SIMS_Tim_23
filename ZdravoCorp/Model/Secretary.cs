// File:    Secretary.cs
// Author:  halid
// Created: Thursday, 14 April 2022 21:31:18
// Purpose: Definition of Class Secretary

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Secretary : Employee, Serializable
    {
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