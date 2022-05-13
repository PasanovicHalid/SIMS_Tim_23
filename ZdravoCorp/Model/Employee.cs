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
        public DateTime workStartTime { get; set; }
        public DateTime workEndTime { get; set; }    
        protected DateTime vacationStartTime;
        protected DateTime vacationEndTime;
        protected int vacationDays;

        public DateTime WorkStartTime { get => workStartTime; set => workStartTime = value; }   
        public DateTime WorkEndTime { get => workEndTime; set => workEndTime = value; }
        protected Employee(int id, string password, string username, string name, string surname, string jmbg, string email, string address, string phoneNumber, Gender gender, DateTime dateOfBirth, List<Notification> notification, List<AppointmentSurvey> survey, float salary, DateTime enrolementDate, DateTime workStartTime, DateTime workEndTime, DateTime vacationStartTime, DateTime vacationEndTime, int vacationDays) : base(id, password, username, name, surname, jmbg, email, address, phoneNumber, gender, dateOfBirth, notification, survey)
        {
            this.salary = salary;
            this.enrolementDate = enrolementDate;
            this.workStartTime = workStartTime;
            this.workEndTime = workEndTime;
            this.vacationStartTime = vacationStartTime;
            this.vacationEndTime = vacationEndTime;
            this.vacationDays = vacationDays;
        }

        protected Employee()
        {
        }
    }

    
}