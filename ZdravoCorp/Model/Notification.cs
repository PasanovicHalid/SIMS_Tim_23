/***********************************************************************
 * Module:  Notification.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Notification
 ***********************************************************************/

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Notification : Serializable
    {
        private DateTime dateCreated;
        private String content;

        private User user;

        public DateTime DateCreated { get { return dateCreated; } set { dateCreated = value; } }    
        public String Content { get { return content; } set { content = value; } }

        public Notification(DateTime dateCreated, string content, int id)
        {
            this.dateCreated = dateCreated;
            this.content = content;
            this.user.Id = id;
        }

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
                        oldUser.RemoveNotification(this);
                    }
                    if (value != null)
                    {
                        this.user = value;
                        this.user.AddNotification(this);
                    }
                }
            }
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }

        public List<String> ToCSV()
        {
            throw new NotImplementedException();
        }
    }
}