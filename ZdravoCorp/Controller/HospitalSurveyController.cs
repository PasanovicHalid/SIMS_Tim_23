// File:    AppointmenService.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:42:17
// Purpose: Definition of Class AppointmenService

using Model;
using Service;
using System;
using System.Collections.Generic;


namespace Controller
{
    public class HospitalSurveyController
    {        
        public Boolean CreateHospitalSurvey(HospitalSurvey newSurvey)
        {
            return HospitalSurveyService.Instance.CreateHospitalSurvey(newSurvey);
        }

        public HospitalSurvey ReadHospitalSurvey(int id)
        {
            return HospitalSurveyService.Instance.ReadHospitalSurvey(id);
        }

        public Boolean UpdateHospitalSurvey(HospitalSurvey survey)
        {
            return HospitalSurveyService.Instance.UpdateHospitalSurvey(survey);
        }

        public Boolean DeleteHospitalSurvey(int id)
        {
            return HospitalSurveyService.Instance.DeleteHospitalSurvey(id);
        }

        public List<HospitalSurvey> GetAllHospitalSurveys()
        {
            return HospitalSurveyService.Instance.GetAllHospitalSurveys();
        }
        public List<int> getAllHospitalSurveyIds()
        {
            return HospitalSurveyService.Instance.getAllHospitalSurveyIds();
        }
    }
}