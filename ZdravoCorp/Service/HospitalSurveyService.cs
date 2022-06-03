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
    public class HospitalSurveyService : ICrud<HospitalSurvey>
    {
        private static HospitalSurveyService instance = null;
        
        public void Create(HospitalSurvey newSurvey)
        {
            HospitalSurveyRepository.Instance.Create(newSurvey);
        }

        public HospitalSurvey Read(int id)
        {
            return HospitalSurveyRepository.Instance.Read(id);
        }

        public void Update(HospitalSurvey survey)
        {
            HospitalSurveyRepository.Instance.Update(survey);
        }

        public void Delete(int id)
        {
            HospitalSurveyRepository.Instance.Delete(id);
        }

        public List<HospitalSurvey> GetAll()
        {
            return HospitalSurveyRepository.Instance.GetAll();
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