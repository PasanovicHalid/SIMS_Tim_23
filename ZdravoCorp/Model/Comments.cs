// File:    Comments.cs
// Author:  halid
// Created: Friday, 15 April 2022 01:31:44
// Purpose: Definition of Class Comments

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Comments : Serializable
    {
        private String comment;

        private Doctor doctor;

        /// <summary>
        /// Property for Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Doctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                this.doctor = value;
            }
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