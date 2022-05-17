// File:    AppointmenService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:42:17
// Purpose: Definition of Class AppointmenService

using Model;
using Repository;
using System;
using System.Collections.Generic;


namespace Service
{
    public class AppointmentSurveyService
    {
        private static AppointmentSurveyService instance = null;
        
        public Boolean CreateAppointmentSurvey(AppointmentSurvey newSurvey)
        {
            return AppointmentSurveyRepository.Instance.CreateAppointmentSurvey(newSurvey);
        }

        public AppointmentSurvey ReadAppointmentSurvey(int id)
        {
            return AppointmentSurveyRepository.Instance.ReadAppointmentSurvey(id);
        }

        public Boolean UpdateAppointmentSurvey(AppointmentSurvey survey)
        {
            return AppointmentSurveyRepository.Instance.UpdateAppointmentSurvey(survey);
        }

        public Boolean DeleteAppointmentSurvey(int id)
        {
            return AppointmentSurveyRepository.Instance.DeleteAppointmentSurvey(id);
        }

        public List<AppointmentSurvey> GetAllAppointmentSurveys()
        {
            return AppointmentSurveyRepository.Instance.GetAllAppointmentSurveys();
        }
        public List<int> getAllAppointmentSurveyIds()
        {
            return AppointmentSurveyRepository.Instance.getAllAppointmentSurveyIds();
        }
        public AppointmentSurveyService()
        {

        }

        public static AppointmentSurveyService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppointmentSurveyService();
                }
                return instance;
            }
        }
        public Boolean DoneSurvey(Appointment appointment)
        {
            Boolean done = false;
            if (GetAllAppointmentsIds().Contains(appointment.Id))
            {
                done = true;
            }
            return done;
        }
        public List<int> GetAllAppointmentsIds()
        {
            List<int> ids = new List<int>();
            foreach(AppointmentSurvey appointmentSurvey in GetAllAppointmentSurveys())
            {
                ids.Add(appointmentSurvey.Appointment.Id);
            }
            return ids;
        }
    }
}