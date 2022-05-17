// File:    AppointmentRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:17
// Purpose: Definition of Class AppointmentRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class AppointmentSurveyRepository
    {
        private String dbPath = "..\\..\\Data\\appointmentSurveysDB.csv";
        private Serializer<AppointmentSurvey> serializerAppointment = new Serializer<AppointmentSurvey>();

        private static AppointmentSurveyRepository instance = null;

        public List<int> getAllAppointmentSurveyIds() {
            List<AppointmentSurvey> surveys = GetAllAppointmentSurveys();
            List<int> ids = new List<int>();
            foreach(AppointmentSurvey survey in surveys)
            {
                ids.Add(survey.Id);
            }
            return ids;
        }
        public void generateId(AppointmentSurvey newSurvey)
        {
            List<int> allSurveyIds = getAllAppointmentSurveyIds();
            Random random = new Random();
            do
            {
                newSurvey.Id = random.Next();
            }
            while (allSurveyIds.Contains(newSurvey.Id));

        }
        public Boolean CreateAppointmentSurvey(AppointmentSurvey newSurvey)
        {
            List<AppointmentSurvey> surveys = GetAllAppointmentSurveys();
            generateId(newSurvey);
            surveys.Add(newSurvey);
            serializerAppointment.ToCSV(dbPath, surveys);
            return true;
        }

        public AppointmentSurvey ReadAppointmentSurvey(int id)
        {
            List<AppointmentSurvey> surveys = GetAllAppointmentSurveys();
            AppointmentSurvey appointmentSurvey = null;
            foreach (AppointmentSurvey survey in surveys)
            {
                if (id == survey.Id)
                {
                    appointmentSurvey = survey;
                    break;
                }
            }
            return appointmentSurvey;
        }

        public List<AppointmentSurvey> GetSurveysById(List<int> id)
        {
            List<AppointmentSurvey> surveys = serializerAppointment.FromCSV(dbPath);
            List<AppointmentSurvey> surveyById = new List<AppointmentSurvey>();
            foreach (AppointmentSurvey survey in surveys)
            {
               foreach (int i in id)
                {
                    if(survey.Id == i)
                    {
                        surveyById.Add(survey);
                    }
                }
            }
            return surveyById;
        }

        public Boolean UpdateAppointmentSurvey(AppointmentSurvey appointment)
        {
            throw new NotImplementedException();

        }

        public Boolean DeleteAppointmentSurvey(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppointmentSurvey> GetAllAppointmentSurveys()
        {
            List<AppointmentSurvey> surveys = serializerAppointment.FromCSV(dbPath); 
            return surveys;
            
        }

        public AppointmentSurveyRepository()
        {
            
        }

        public static AppointmentSurveyRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new AppointmentSurveyRepository();
                }
                return instance ;
            }
        }
    }
}