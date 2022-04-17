// File:    Rating.cs
// Author:  halid
// Created: Friday, 15 April 2022 01:39:11
// Purpose: Definition of Class Rating

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Rating : Serializable
    {
        private int rating;

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