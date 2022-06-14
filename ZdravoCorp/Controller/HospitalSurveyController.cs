// File:    AppointmenService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:42:17
// Purpose: Definition of Class AppointmenService

using Model;
using Service;
using System;
using System.Collections.Generic;
using Repository;


namespace Controller
{
    public class HospitalSurveyController : ICrud<HospitalSurvey>
    {        
        public void Create(HospitalSurvey newSurvey)
        {
            HospitalSurveyService.Instance.Create(newSurvey);
        }

        public HospitalSurvey Read(int id)
        {
            return HospitalSurveyService.Instance.Read(id);
        }

        public void Update(HospitalSurvey survey)
        {
            HospitalSurveyService.Instance.Update(survey);
        }

        public void Delete(int id)
        {
            HospitalSurveyService.Instance.Delete(id);
        }

        public List<HospitalSurvey> GetAll()
        {
            return HospitalSurveyService.Instance.GetAll();
        }
        public List<int> getAllHospitalSurveyIds()
        {
            return HospitalSurveyService.Instance.getAllHospitalSurveyIds();
        }

        public string GetResults(DateTime start, DateTime end)
        {
            return HospitalSurveyService.Instance.GetResults(start, end);
        }
    }
}