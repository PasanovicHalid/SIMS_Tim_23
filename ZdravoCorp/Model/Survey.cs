// File:    Survey.cs
// Author:  halid
// Created: Thursday, 14 April 2022 21:08:18
// Purpose: Definition of Class Survey

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Survey : Serializable
    {
        private int id;
        private DateTime startTime;
        private DateTime endTime;
        private int description;

        private List<Rating> rating;

        /// <summary>
        /// Property for collection of Rating
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Rating> Rating
        {
            get
            {
                if (rating == null)
                    rating = new List<Rating>();
                return rating;
            }
            set
            {
                RemoveAllRating();
                if (value != null)
                {
                    foreach (Rating oRating in value)
                        AddRating(oRating);
                }
            }
        }

        /// <summary>
        /// Add a new Rating in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddRating(Rating newRating)
        {
            if (newRating == null)
                return;
            if (this.rating == null)
                this.rating = new List<Rating>();
            if (!this.rating.Contains(newRating))
                this.rating.Add(newRating);
        }

        /// <summary>
        /// Remove an existing Rating from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveRating(Rating oldRating)
        {
            if (oldRating == null)
                return;
            if (this.rating != null)
                if (this.rating.Contains(oldRating))
                    this.rating.Remove(oldRating);
        }

        /// <summary>
        /// Remove all instances of Rating from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllRating()
        {
            if (rating != null)
                rating.Clear();
        }

        public List<String> ToCSV()
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }

        private User user;

        /// <summary>
        /// Property for User
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                if (this.user == null || !this.user.Equals(value))
                {
                    if (this.user != null)
                    {
                        User oldUser = this.user;
                        this.user = null;
                        oldUser.RemoveSurvey(this);
                    }
                    if (value != null)
                    {
                        this.user = value;
                        this.user.AddSurvey(this);
                    }
                }
            }
        }

    }
}