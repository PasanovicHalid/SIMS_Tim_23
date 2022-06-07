// File:    AppointmenService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:42:17
// Purpose: Definition of Class AppointmenService

using Model;
using Repository;
using System;
using System.Collections.Generic;
using Service;
using Repository;

namespace Controller
{
    public class AppointmentSurveyController : ICrud<AppointmentSurvey>
    {
        
        public void Create(AppointmentSurvey newSurvey)
        {
            AppointmentSurveyService.Instance.Create(newSurvey);
        }

        public AppointmentSurvey Read(int id)
        {
            return AppointmentSurveyService.Instance.Read(id);
        }

        public void Update(AppointmentSurvey survey)
        {
            AppointmentSurveyService.Instance.Update(survey);
        }

        public void Delete(int id)
        {
            AppointmentSurveyService.Instance.Delete(id);
        }

        public List<AppointmentSurvey> GetAll()
        {
            return AppointmentSurveyService.Instance.GetAll();
        }
       
        public Boolean DoneSurvey(Appointment appointment)
        {
            return AppointmentSurveyService.Instance.DoneSurvey(appointment);
        }

        public string GetResultsForDoctor(Doctor doctor)
        {
            return AppointmentSurveyService.Instance.GetResultsForDoctor(doctor);
        }
    }
}