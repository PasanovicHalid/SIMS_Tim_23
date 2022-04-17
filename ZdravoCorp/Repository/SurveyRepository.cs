// File:    SurveyRepository.cs
// Author:  halid
// Created: Saturday, 16 April 2022 01:04:40
// Purpose: Definition of Class SurveyRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class SurveyRepository
   {
      private String dbPath;
      
      private SurveyRepository instance;
      
      public Boolean CreateSurvey(Survey newSurvey)
      {
         throw new NotImplementedException();
      }
      
      public Boolean UpdateSurvey(Survey survey)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteSurvey(int identificator)
      {
         throw new NotImplementedException();
      }
      
      public Survey ReadSurvey(int identificator)
      {
         throw new NotImplementedException();
      }
      
      public List<Survey> GetAllSurvey()
      {
         throw new NotImplementedException();
      }
   
   }
}