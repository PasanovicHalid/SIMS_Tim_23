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
    public class HospitalSurveyService
    {
        private static HospitalSurveyService instance = null;
        
        public Boolean CreateHospitalSurvey(HospitalSurvey newSurvey)
        {
            return HospitalSurveyRepository.Instance.CreateHospitalSurvey(newSurvey);
        }

        public HospitalSurvey ReadHospitalSurvey(int id)
        {
            return HospitalSurveyRepository.Instance.ReadHospitalSurvey(id);
        }

        public Boolean UpdateHospitalSurvey(HospitalSurvey survey)
        {
            return HospitalSurveyRepository.Instance.UpdateHospitalSurvey(survey);
        }

        public Boolean DeleteHospitalSurvey(int id)
        {
            return HospitalSurveyRepository.Instance.DeleteHospitalSurvey(id);
        }

        public List<HospitalSurvey> GetAllHospitalSurveys()
        {
            return HospitalSurveyRepository.Instance.GetAllHospitalSurveys();
        }
        public List<int> getAllHospitalSurveyIds()
        {
            return HospitalSurveyRepository.Instance.getAllHospitalSurveyIds();
        }
        public HospitalSurveyService()
        {

        }

        public static HospitalSurveyService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HospitalSurveyService();
                }
                return instance;
            }
        }
    }
}