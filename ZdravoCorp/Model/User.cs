/***********************************************************************
 * Module:  User.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.User
 ***********************************************************************/

using System;
using System.Collections;

namespace Model
{
    public abstract class User
    {
        public String Password { get; set; }
        public String Username { get; set; }
        public String Surname { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public String Id { get; set; }
        public String PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }


        protected System.Collections.ArrayList notifications;

        protected User()
        {
        }

        public User(string password, string username, string name, string surname, string email, string address, string id, string phoneNumber, Gender gender, DateTime dateOfBirth, ArrayList notifications)
        {
            this.Password = password;
            this.Username = username;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Address = address;
            this.Id = id;
            this.PhoneNumber = phoneNumber;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.Notifications = notifications;
        }


        /// <summary>
        /// Property for collection of Notification
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.ArrayList Notifications
        {
            get
            {
                if (notifications == null)
                    notifications = new System.Collections.ArrayList();
                return notifications;
            }
            set
            {
                RemoveAllNotifications();
                if (value != null)
                {
                    foreach (Notification oNotification in value)
                        AddNotifications(oNotification);
                }
            }
        }

        /// <summary>
        /// Add a new Notification in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddNotifications(Notification newNotification)
        {
            if (newNotification == null)
                return;
            if (this.notifications == null)
                this.notifications = new System.Collections.ArrayList();
            if (!this.notifications.Contains(newNotification))
                this.notifications.Add(newNotification);
        }

        /// <summary>
        /// Remove an existing Notification from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveNotifications(Notification oldNotification)
        {
            if (oldNotification == null)
                return;
            if (this.notifications != null)
                if (this.notifications.Contains(oldNotification))
                    this.notifications.Remove(oldNotification);
        }

        /// <summary>
        /// Remove all instances of Notification from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllNotifications()
        {
            if (notifications != null)
                notifications.Clear();
        }

    }
}