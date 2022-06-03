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
    public class AppointmentSurveyService : ICrud<AppointmentSurvey>
    {
        private static AppointmentSurveyService instance = null;
        
        public void Create(AppointmentSurvey newSurvey)
        {
            AppointmentSurveyRepository.Instance.Create(newSurvey);
        }

        public AppointmentSurvey Read(int id)
        {
            return AppointmentSurveyRepository.Instance.Read(id);
        }

        public void Update(AppointmentSurvey survey)
        {
            AppointmentSurveyRepository.Instance.Update(survey);
        }

        public void Delete(int id)
        {
            AppointmentSurveyRepository.Instance.Delete(id);
        }

        public List<AppointmentSurvey> GetAll()
        {
            return AppointmentSurveyRepository.Instance.GetAll();
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
            foreach(AppointmentSurvey appointmentSurvey in GetAll())
            {
                ids.Add(appointmentSurvey.Appointment.Id);
            }
            return ids;
        }
    }
}