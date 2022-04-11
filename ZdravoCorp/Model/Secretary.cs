/***********************************************************************
 * Module:  Secretary.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Secretary
 ***********************************************************************/

using System;

namespace Model
{
    public class Secretary : Employee, Repository.Serializable
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