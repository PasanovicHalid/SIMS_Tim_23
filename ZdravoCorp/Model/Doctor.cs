/***********************************************************************
 * Module:  Doctor.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Doctor
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Doctor : Employee, Serializable
    {
        private List<Appointment> appointment = new List<Appointment>();
        private List<Vacation> vacations = new List<Vacation>();

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



        public Doctor(int id, string password, string username, string name, string surname, string jmbg, string email, string address, string phoneNumber, Gender gender, DateTime dateOfBirth, List<Notification> notification, List<AppointmentSurvey> survey, float salary, DateTime enrolementdate, DateTime workstarttime, DateTime workendtime, DateTime vacationstarttime, DateTime vacationendtime, int vacationdays) : base(id, password, username, name, surname, jmbg, email, address, phoneNumber, gender, dateOfBirth, notification, survey, salary, enrolementdate, workstarttime, workendtime, vacationstarttime, vacationendtime, vacationdays)
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

        public List<Vacation> Vacations
        {
            get 
            {
                if(vacations == null)
                    vacations = new List<Vacation>();
                return vacations; 
            }
            set
            {
                RemoveAllVacations();
                if(value != null)
                {
                    foreach (Vacation oVacation in value)
                        AddVacation(oVacation);
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

        public void AddVacation(Vacation newVacation)
        {
            if (newVacation == null)
                return;
            if(this.vacations == null)
                this.vacations = new List<Vacation>();
            if(!this.vacations.Contains(newVacation))
            {
                this.vacations.Add(newVacation);
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

        public void RemoveVacation(Vacation oldVacation)
        {
            if (oldVacation == null)
                return;
            if (this.vacations != null)
                if (this.vacations.Contains(oldVacation))
                {
                    this.vacations.Remove(oldVacation);
                }
        }

        public void UpdateVacation(Vacation vacation)
        {
            for(int j = 0; j < vacations.Count; j++)
            {
                if (vacations[j].Id == vacation.Id)
                {
                    RemoveVacation(vacations[j]);
                    AddVacation(vacation);
                    return;
                }    
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

        public void RemoveAllVacations()
        {
            if (vacations != null)
            {
                System.Collections.ArrayList tmpVacations = new System.Collections.ArrayList();
                foreach (Vacation oldVacation in vacations)
                    tmpVacations.Add(oldVacation);
                vacations.Clear();

                tmpVacations.Clear();
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

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        { get { return this.name; } set { this.name = value; } }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Surname
        {
            get { return this.surname; }
            set { this.surname = value; }
        }

        public string Jmbg
        {
            get { return this.jmbg; }
            set { this.jmbg = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public Gender Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }

        public List<Notification> Notification
        {
            get { return this.notification; }
            set { this.notification = value; }
        }

        public float Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public DateTime EnrolementDate
        {
            get { return this.enrolementDate; }
            set { this.enrolementDate = value; }
        }

        public DateTime WorkStartTime
        {
            get { return this.workStartTime; }
            set { this.workStartTime = value; }
        }

        public DateTime WorkEndTime
        {
            get { return this.workEndTime; }
            set { this.workEndTime = value; }
        }

        public DateTime VacationStartTime
        {
            get { return this.vacationStartTime; }
            set { this.vacationStartTime = value; }
        }

        public DateTime VacationEndTime
        {
            get { return this.vacationEndTime; }
            set { this.vacationEndTime = value; }
        }

        public String getName() { return name + surname; }


        public List<String> ToCSV()
        {
            List<String> result = new List<String>();
            int nf = 0;
            if (appointment == null)
            {
                result.Add(nf.ToString());
            }
            else
            {
                result.Add(appointment.Count.ToString());
                foreach (Appointment a in appointment)
                {
                    result.Add(a.Id.ToString());
                }
            }
            result.AddRange(DoctorType.ToCSV());
            if (vacations == null)
            {
                result.Add(nf.ToString());
            }
            else
            {
                result.Add(vacations.Count.ToString());
                foreach (Vacation vacation in vacations)
                {
                    result.Add(vacation.Id.ToString());
                }
            }
            result.AddRange(base.ToCSV());
            return result;


        }

        public void FromCSV(string[] values)
        {
            int i = 0;
            int count = int.Parse(values[i++]);
            for (int j = 0; j < count; j++)
            {
                appointment.Add(new Appointment(int.Parse(values[i++])));
            }
            doctorType = new DoctorType(values[i++]);
            count = int.Parse(values[i++]);
            List<int> vacationsIDs = new List<int>();
            for (int j = 0; j < count; j++)
            {
                vacationsIDs.Add(int.Parse(values[i++]));
            }
            values = values.Skip(i).ToArray();
            base.FromCSV(values);
            convertToVacations(vacationsIDs);
        }

        public void convertToVacations(List<int> list)
        {
            Controller.VacationController vacationController = new Controller.VacationController();
            for(int i = 0; i < list.Count; i++)
            {
                vacations.Add(vacationController.ReadVacation(list[i]));
            }
        }

    }
}