// File:    AppointmentRepository.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:43:17
// Purpose: Definition of Class AppointmentRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class HospitalSurveyRepository
    {
        private String dbPath = "..\\..\\Data\\hospitalSurveysDB.csv";
        private Serializer<HospitalSurvey> serializerAppointment = new Serializer<HospitalSurvey>();

        private static HospitalSurveyRepository instance = null;

        public List<int> getAllHospitalSurveyIds() {
            List<HospitalSurvey> surveys = GetAllHospitalSurveys();
            List<int> ids = new List<int>();
            foreach(HospitalSurvey survey in surveys)
            {
                ids.Add(survey.Id);
            }
            return ids;
        }
        public void generateId(HospitalSurvey newSurvey)
        {
            List<int> allSurveyIds = getAllHospitalSurveyIds();
            Random random = new Random();
            do
            {
                newSurvey.Id = random.Next();
            }
            while (allSurveyIds.Contains(newSurvey.Id));

        }
        public Boolean CreateHospitalSurvey(HospitalSurvey newSurvey)
        {
            List<HospitalSurvey> surveys = GetAllHospitalSurveys();
            generateId(newSurvey);
            surveys.Add(newSurvey);
            serializerAppointment.ToCSV(dbPath, surveys);
            return true;
        }

        public HospitalSurvey ReadHospitalSurvey(int id)
        {
            List<HospitalSurvey> surveys = GetAllHospitalSurveys();
            HospitalSurvey appointmentSurvey = null;
            foreach (HospitalSurvey survey in surveys)
            {
                if (id == survey.Id)
                {
                    appointmentSurvey = survey;
                    break;
                }
            }
            return appointmentSurvey;
        }

        public List<HospitalSurvey> GetSurveysById(List<int> id)
        {
            List<HospitalSurvey> surveys = serializerAppointment.FromCSV(dbPath);
            List<HospitalSurvey> surveyById = new List<HospitalSurvey>();
            foreach (HospitalSurvey survey in surveys)
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

        public Boolean UpdateHospitalSurvey(HospitalSurvey appointment)
        {
            throw new NotImplementedException();

        }

        public Boolean DeleteHospitalSurvey(int id)
        {
            throw new NotImplementedException();
        }

        public List<HospitalSurvey> GetAllHospitalSurveys()
        {
            List<HospitalSurvey> surveys = serializerAppointment.FromCSV(dbPath); 
            return surveys;
            
        }

        public HospitalSurveyRepository()
        {
            
        }

        public static HospitalSurveyRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new HospitalSurveyRepository();
                }
                return instance ;
            }
        }
    }
}