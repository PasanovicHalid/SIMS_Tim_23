// File:    AppointmentController.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:33:59
// Purpose: Definition of Class AppointmentController

using Model;
using System;
using Service;
using System.Collections.Generic;
using Repository;
using ZdravoCorp.Exceptions;

namespace Controller
{
    public class AppointmentController : ICrud<Appointment>
    {
        public void Create(Appointment newAppointment)
        {
            List<Appointment> appointmentList = GetAll();
            foreach (Appointment tempAppointment in appointmentList)
            {
                if(CheckAppointmentsDates(tempAppointment,newAppointment) && CheckOtherAppointmenstInformations(tempAppointment,newAppointment))
                {
                    throw new LocalisedException("Appointment cannot be created,change input data!");
                }
            }
            AppointmentService.Instance.Create(newAppointment);
        }

        public Appointment Read(int appointment)
        {
            return AppointmentService.Instance.Read(appointment);
        }

        public void Update(Appointment appointment)
        {
            AppointmentService.Instance.Update(appointment);
        }

        public void Delete(int appointment)
        {
            AppointmentService.Instance.Delete(appointment);
        }

        public List<Appointment> GetAll()
        {
            return AppointmentService.Instance.GetAll();
        }

        public List<Appointment> GetFutureAppointments()
        {
            return AppointmentService.Instance.GetFutureAppointments();
        }
        public List<Appointment> GetPastAppointments()
        {
            return AppointmentService.Instance.GetPastAppointments();
        }

        public Boolean IsTroll(Appointment appointment)
        {
            return AppointmentService.Instance.IsTroll(appointment);
        }
        public List<Appointment> GetFutureAppointmentsForPatient(Patient patient)
        {
            return AppointmentService.Instance.GetFutureAppointmentsForPatient(patient);
        }
        public List<Appointment> GetPastAppointmentsForPatient(Patient patient)
        {
            return AppointmentService.Instance.GetPastAppointmentsForPatient(patient);
        }
        public List<Appointment> SuggestAppointments(WantedAppointment wantedAppointment)
        {
            return AppointmentService.Instance.SuggestAppointments(wantedAppointment);
        }

        public Boolean CheckDoctorAppointments(Doctor currentDoctor,DateTime vacationStartDate, DateTime vacationEndDate)
        {
            List<Appointment> appointments = GetAll();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.DoctorID == currentDoctor.Id)
                {
                    if (((vacationStartDate.CompareTo(appointment.startDate.Date) < 0)) && (vacationEndDate.CompareTo(appointment.EndDate.Date) > 0))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Boolean CheckAppointmentsDates(Appointment appointmentOne, Appointment appointmentTwo)
        {
            if ((DateTime.Compare(appointmentOne.StartDate, appointmentTwo.StartDate) < 0 && DateTime.Compare(appointmentOne.EndDate, appointmentTwo.EndDate) > 0)
               || (DateTime.Compare(appointmentOne.StartDate, appointmentTwo.endDate) < 0 && DateTime.Compare(appointmentOne.EndDate, appointmentTwo.StartDate) > 0)
                   || (DateTime.Compare(appointmentOne.StartDate, appointmentTwo.StartDate) < 0 && DateTime.Compare(appointmentOne.EndDate, appointmentTwo.EndDate) > 0)
                       || (DateTime.Compare(appointmentOne.StartDate, appointmentTwo.StartDate) > 0 && DateTime.Compare(appointmentOne.EndDate, appointmentTwo.EndDate) < 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Boolean CheckOtherAppointmenstInformations(Appointment appointmentOne, Appointment appointmentTwo)
        {
            if (appointmentOne.DoctorID == appointmentTwo.DoctorID || appointmentTwo.RoomID == appointmentOne.RoomID || appointmentTwo.PatientID == appointmentOne.PatientID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}