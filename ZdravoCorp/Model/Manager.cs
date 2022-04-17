// File:    Manager.cs
// Author:  halid
// Created: Thursday, 14 April 2022 21:31:06
// Purpose: Definition of Class Manager

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Manager : Employee, Serializable
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