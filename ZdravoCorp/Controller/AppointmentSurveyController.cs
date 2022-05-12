// File:    AppointmenService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:42:17
// Purpose: Definition of Class AppointmenService

using Model;
using Repository;
using System;
using System.Collections.Generic;
using Service;

namespace Controller
{
    public class AppointmentSurveyController
    {
        
        public Boolean CreateAppointmentSurvey(AppointmentSurvey newSurvey)
        {
            return AppointmentSurveyService.Instance.CreateAppointmentSurvey(newSurvey);
        }

        public AppointmentSurvey ReadAppointmentSurvey(int id)
        {
            return AppointmentSurveyService.Instance.ReadAppointmentSurvey(id);
        }

        public Boolean UpdateAppointmentSurvey(AppointmentSurvey survey)
        {
            return AppointmentSurveyService.Instance.UpdateAppointmentSurvey(survey);
        }

        public Boolean DeleteAppointmentSurvey(int id)
        {
            return AppointmentSurveyService.Instance.DeleteAppointmentSurvey(id);
        }

        public List<AppointmentSurvey> GetAllAppointmentSurveys()
        {
            return AppointmentSurveyService.Instance.GetAllAppointmentSurveys();
        }
       
        public Boolean DoneSurvey(Appointment appointment)
        {
            return AppointmentSurveyService.Instance.DoneSurvey(appointment);
        }
    }
}