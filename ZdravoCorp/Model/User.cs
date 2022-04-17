/***********************************************************************
 * Module:  User.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.User
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public abstract class User : Serializable
    {
        protected int id;
        protected String password;
        protected String username;
        protected String name;
        protected String surname;
        protected String email;
        protected String address;
        protected String phoneNumber;
        protected Gender gender;
        protected DateTime dateOfBirth;

        protected List<Notification> notification;

        /// <summary>
        /// Property for collection of Notification
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Notification> Notification
        {
            get
            {
                if (notification == null)
                    notification = new List<Notification>();
                return notification;
            }
            set
            {
                RemoveAllNotification();
                if (value != null)
                {
                    foreach (Notification oNotification in value)
                        AddNotification(oNotification);
                }
            }
        }

        /// <summary>
        /// Add a new Notification in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddNotification(Notification newNotification)
        {
            if (newNotification == null)
                return;
            if (this.notification == null)
                this.notification = new List<Notification>();
            if (!this.notification.Contains(newNotification))
            {
                this.notification.Add(newNotification);
                newNotification.User = this;
            }
        }

        /// <summary>
        /// Remove an existing Notification from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveNotification(Notification oldNotification)
        {
            if (oldNotification == null)
                return;
            if (this.notification != null)
                if (this.notification.Contains(oldNotification))
                {
                    this.notification.Remove(oldNotification);
                    oldNotification.User = null;
                }
        }

        /// <summary>
        /// Remove all instances of Notification from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllNotification()
        {
            if (notification != null)
            {
                System.Collections.ArrayList tmpNotification = new System.Collections.ArrayList();
                foreach (Notification oldNotification in notification)
                    tmpNotification.Add(oldNotification);
                notification.Clear();
                foreach (Notification oldNotification in tmpNotification)
                    oldNotification.User = null;
                tmpNotification.Clear();
            }
        }
        protected List<Survey> survey;

        /// <summary>
        /// Property for collection of Survey
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Survey> Survey
        {
            get
            {
                if (survey == null)
                    survey = new List<Survey>();
                return survey;
            }
            set
            {
                RemoveAllSurvey();
                if (value != null)
                {
                    foreach (Survey oSurvey in value)
                        AddSurvey(oSurvey);
                }
            }
        }

        /// <summary>
        /// Add a new Survey in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddSurvey(Survey newSurvey)
        {
            if (newSurvey == null)
                return;
            if (this.survey == null)
                this.survey = new List<Survey>();
            if (!this.survey.Contains(newSurvey))
            {
                this.survey.Add(newSurvey);
                newSurvey.User = this;
            }
        }

        /// <summary>
        /// Remove an existing Survey from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveSurvey(Survey oldSurvey)
        {
            if (oldSurvey == null)
                return;
            if (this.survey != null)
                if (this.survey.Contains(oldSurvey))
                {
                    this.survey.Remove(oldSurvey);
                    oldSurvey.User = null;
                }
        }

        /// <summary>
        /// Remove all instances of Survey from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllSurvey()
        {
            if (survey != null)
            {
                System.Collections.ArrayList tmpSurvey = new System.Collections.ArrayList();
                foreach (Survey oldSurvey in survey)
                    tmpSurvey.Add(oldSurvey);
                survey.Clear();
                foreach (Survey oldSurvey in tmpSurvey)
                    oldSurvey.User = null;
                tmpSurvey.Clear();
            }
        }

        public List<String> ToCSV()
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}