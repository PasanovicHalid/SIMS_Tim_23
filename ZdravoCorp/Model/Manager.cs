/***********************************************************************
 * Module:  Manager.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Manager
 ***********************************************************************/

using System;

namespace Model
{
    public class Manager : Employee, Repository.Serializable
    {
        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }

        public string[] ToCSV()
        {
            throw new NotImplementedException();
        }
    }
}