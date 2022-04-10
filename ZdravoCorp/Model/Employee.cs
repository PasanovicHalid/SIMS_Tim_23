/***********************************************************************
 * Module:  Employee.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Employee
 ***********************************************************************/

using System;

namespace Model
{
   public abstract class Employee : User
   {
      protected float salary;
      protected DateTime enrolementDate;
      protected DateTime workStartTime;
      protected DateTime workEndTime;
   
   }
}