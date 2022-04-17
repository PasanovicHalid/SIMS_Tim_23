// File:    MedicalRecord.cs
// Author:  halid
// Created: Thursday, 14 April 2022 22:39:27
// Purpose: Definition of Class MedicalRecord

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class MedicalRecord : Serializable
    {
        private BloodType bloodType;
        private float height;
        private float weight;

        private System.Collections.Generic.List<Comments> comments;

        /// <summary>
        /// Property for collection of Comments
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Comments> Comments
        {
            get
            {
                if (comments == null)
                    comments = new System.Collections.Generic.List<Comments>();
                return comments;
            }
            set
            {
                RemoveAllComments();
                if (value != null)
                {
                    foreach (Comments oComments in value)
                        AddComments(oComments);
                }
            }
        }

        /// <summary>
        /// Add a new Comments in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddComments(Comments newComments)
        {
            if (newComments == null)
                return;
            if (this.comments == null)
                this.comments = new System.Collections.Generic.List<Comments>();
            if (!this.comments.Contains(newComments))
                this.comments.Add(newComments);
        }

        /// <summary>
        /// Remove an existing Comments from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveComments(Comments oldComments)
        {
            if (oldComments == null)
                return;
            if (this.comments != null)
                if (this.comments.Contains(oldComments))
                    this.comments.Remove(oldComments);
        }

        /// <summary>
        /// Remove all instances of Comments from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllComments()
        {
            if (comments != null)
                comments.Clear();
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