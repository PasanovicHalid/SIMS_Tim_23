/***********************************************************************
 * Module:  Doctor.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Doctor
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Doctor : Employee, Serializable
    {
        private List<Appointment> appointment;


        public Doctor()
        {
        }

        //public Doctor(List<Appointment> appointment, DoctorType doctorType)
        //{
        //    this.appointment = appointment;
        //    this.doctorType = doctorType;
        //}

        public Doctor(int id)
        {
            this.id = id;
        }



        public Doctor(int id, string password, string username, string name, string surname, string jmbg, string email, string address, string phoneNumber, Gender gender, DateTime dateOfBirth, List<Notification> notification, List<Survey> survey, float salary, DateTime enrolementdate, DateTime workstarttime, DateTime workendtime, DateTime vacationstarttime, DateTime vacationendtime, int vacationdays) : base(id, password, username, name, surname, jmbg, email, address, phoneNumber, gender, dateOfBirth, notification, survey, salary, enrolementdate, workstarttime, workendtime, vacationstarttime, vacationendtime, vacationdays)
        {
        }

        /// <summary>
        /// Property for collection of Appointment
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Appointment> Appointment
        {
            get
            {
                if (appointment == null)
                    appointment = new List<Appointment>();
                return appointment;
            }
            set
            {
                RemoveAllAppointment();
                if (value != null)
                {
                    foreach (Appointment oAppointment in value)
                        AddAppointment(oAppointment);
                }
            }
        }

        /// <summary>
        /// Add a new Appointment in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new List<Appointment>();
            if (!this.appointment.Contains(newAppointment))
            {
                this.appointment.Add(newAppointment);
                
            }
        }

        /// <summary>
        /// Remove an existing Appointment from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointment != null)
                if (this.appointment.Contains(oldAppointment))
                {
                    this.appointment.Remove(oldAppointment);
                }
        }

        /// <summary>
        /// Remove all instances of Appointment from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAppointment()
        {
            if (appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                
                tmpAppointment.Clear();
            }
        }
        private DoctorType doctorType;

        /// <summary>
        /// Property for DoctorType
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public DoctorType DoctorType
        {
            get
            {
                return doctorType;
            }
            set
            {
                this.doctorType = value;
            }
        }
        public String getName() { return name + surname; }
        public List<String> ToCSV()
        {
            List<String> result = new List<String>();
            result.Add(Id.ToString());
            result.Add(password);
            result.Add(username);
            result.Add(name);
            result.Add(surname);
            result.Add(jmbg);
            result.Add(email);
            result.Add(address);
            result.Add(phoneNumber);
            result.Add(gender.ToString());
            result.Add(dateOfBirth.ToString());
            int nf = 0;
            if (notification == null)
            {
                result.Add(nf.ToString());
            }
            else
            {
                result.Add(notification.Count.ToString());
                foreach (Notification n in notification)
                {
                    result.Add(n.DateCreated.ToString());
                    result.Add(n.Content);
                    result.Add(n.User.Id.ToString());
                }
            }
            result.Add(salary.ToString());
            result.Add(enrolementDate.ToString());
            result.Add(workStartTime.ToString());
            result.Add(workEndTime.ToString());
            result.Add(vacationStartTime.ToString());
            result.Add(vacationEndTime.ToString());
            result.Add(vacationDays.ToString());
            result.AddRange(DoctorType.ToCSV());
            return result;
        }

        public void FromCSV(string[] values)
        {
            int i = 0;
            id = int.Parse(values[i++]);
            password = values[i++];
            username = values[i++];
            name = values[i++];
            surname = values[i++];
            jmbg = values[i++];
            email = values[i++];
            address = values[i++];
            phoneNumber = values[i++];
            if(values[i++] == "Male")
            {
                gender = Gender.Male;
            }
            else
            {
                gender = Gender.Female;
            }
            dateOfBirth = DateTime.Parse(values[i++]);
            int count = int.Parse(values[i++]);
            for(int j = 0 ; j < count; j++)
            {
                notification.Add(new Notification(DateTime.Parse(values[i++]), values[i++], int.Parse(values[i++])));
            }
            salary = float.Parse(values[i++]);
            enrolementDate = DateTime.Parse(values[i++]);
            workStartTime = DateTime.Parse(values[i++]);
            workEndTime = DateTime.Parse(values[i++]);
            vacationStartTime = DateTime.Parse(values[i++]);
            vacationEndTime = DateTime.Parse(values[i++]);
            vacationDays = int.Parse(values[i++]);
            doctorType = new DoctorType(values[i++]);
        }

    }
}