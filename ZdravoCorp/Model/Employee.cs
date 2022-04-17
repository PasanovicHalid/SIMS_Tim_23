/***********************************************************************
 * Module:  Employee.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Employee
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public abstract class Employee : User
    {
        protected float salary;
        protected DateTime enrolementDate;
        protected DateTime workStartTime;
        protected DateTime workEndTime;
        protected DateTime vacationStartTime;
        protected DateTime vacationEndTime;
        protected int vacationDays;
    }
}