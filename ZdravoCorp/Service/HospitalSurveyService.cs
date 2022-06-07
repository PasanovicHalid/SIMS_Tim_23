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

        public string GetResults()
        {
            string result = "Hospital:\n\t";
            List<HospitalSurvey> surveys = GetAll();
            int count = HospitalSurvey.ratingsLabel.Count;
            for (int i = 0; i < count; i++)
            {
                List<int> ratings = GetRatingsForSpecificRating(surveys, i);
                result += HospitalSurvey.ratingsLabel[i] + ":\n\t\t";
                result += "Score: " + GetAvgOfRatings(ratings) + "\n\n\t\t";
                result = CreateTextOfAmmountOfRatings(result, ratings);
            }
            return result;
        }

        public List<int> getAllHospitalSurveyIds()
        {
            return HospitalSurveyRepository.Instance.getAllHospitalSurveyIds();
        }

        private float GetAvgOfRatings(List<int> ratings)
        {
            int count = 0;
            float sum = 0;
            foreach(int rating in ratings)
            {
                count++;
                sum += rating;
            }
            return sum / count;
        }

        private string CreateTextOfAmmountOfRatings(string result, List<int> ratings)
        {
            for (int i = 0; i < HospitalSurvey.ratingRangeLabels.Count; i++)
            {
                result += HospitalSurvey.ratingRangeLabels[i] + ": " + GetCountOfRating(ratings, 5 - i) + "\n\t\t";
            }
            result += "\n\t";
            return result;
        }


        private List<int> GetRatingsForSpecificRating(List<HospitalSurvey> surveys, int rating)
        {
            List<int> ratings = new List<int>();
            foreach (HospitalSurvey survey in surveys)
            {
                ratings.Add(survey.ratings[rating]);
            }
            return ratings;
        }
        private float GetCountOfRating(List<int> ratings, int rating)
        {
            int count = 0;       
            foreach (int it in ratings)
            {
                if(it == rating)
                {
                    count++;
                }
            }
            return count;
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