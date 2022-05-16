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
        private int id;
        private Patient patient;
        private BloodType bloodType;
        private float height;
        private float weight;
        private List<String> allergens = new List<String>();

        private System.Collections.Generic.List<Comments> comments = new List<Comments>();

        public MedicalRecord() { }

        public MedicalRecord(int id)
        {
            this.id = id;
        }

        public MedicalRecord(float height, float weight, BloodType bloodType, List<String> allergens, List<Comments> comments, Patient patient) {
            this.height = height;
            this.weight = weight;
            this.bloodType = bloodType;
            this.allergens = allergens;
            this.comments = comments;
            this.patient = patient;
        }

        public String btname { get => bloodType.ToString(); }
        public BloodType BloodType { get => bloodType; set => bloodType = value; }
        public float Height { get => height; set => height = value; }
        public float Weight { get => weight; set => weight = value; }
        public int Id { get => id; set => id = value; }

        public Patient Patient { get => patient; set => patient = value; }

        public List<String> Allergens
        {
            get
            {
                if (allergens == null)
                    allergens = new List<String>();
                return allergens;
            }
            set
            {
                RemoveAllAllergens();
                if (value != null)
                {
                    foreach (String oAllergen in value)
                        AddAllergen(oAllergen);
                }
            }
        }

        public void AddAllergen(String newAllergen)
        {
            if (newAllergen == null)
                return;
            if (this.allergens == null)
                this.allergens = new List<String>();
            if (!this.allergens.Contains(newAllergen))
            {
                this.allergens.Add(newAllergen);

            }
        }

        public void RemoveAllergen(String oldAllergen)
        {
            if (oldAllergen == null)
                return;
            if (this.allergens != null)
                if (this.allergens.Contains(oldAllergen))
                {
                    this.allergens.Remove(oldAllergen);
                }
        }

        public void RemoveAllAllergens()
        {
            if (allergens != null)
            {
                System.Collections.ArrayList tmpAllergens = new System.Collections.ArrayList();
                foreach (String oldAllergen in allergens)
                    tmpAllergens.Add(oldAllergen);
                allergens.Clear();

                tmpAllergens.Clear();
            }
        }



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
            List<String> result = new List<String>();
            result.Add(Id.ToString());
            result.Add(Height.ToString());
            result.Add(Weight.ToString());
            result.Add(BloodType.ToString());
            result.Add(Patient.Id.ToString());

            int aller = 0;
            if (allergens == null)
            {
                result.Add(aller.ToString());
            }
            else
            {
                result.Add(allergens.Count.ToString());

                foreach (String s in allergens)
                {
                    result.Add(s.ToString());
                }
            }
            int com = 0;
            if (comments == null)
            {
                result.Add(com.ToString());
            }
            else
            {
                result.Add(comments.Count.ToString());

                foreach (Comments c in comments)
                {
                    result.Add(c.Id.ToString());
                }
            }

            return result;
        }

        public void FromCSV(string[] values)
        {
            int i = 0;
            id = int.Parse(values[i++]);
            height = float.Parse(values[i++]);
            weight = float.Parse(values[i++]);
            switch (values[i++])
            {
                case "aPlus":
                    bloodType = BloodType.aPlus;
                    break;
                case "aMinus":
                    bloodType = BloodType.aMinus;
                    break;
                case "bPlus":
                    bloodType = BloodType.bPlus;
                    break;
                case "bMinus":
                    bloodType = BloodType.bMinus;
                    break;
                case "aBPlus":
                    bloodType = BloodType.aBPlus;
                    break;
                case "aBMinus":
                    bloodType = BloodType.aBMinus;
                    break;
                case "oPlus":
                    bloodType = BloodType.oPlus;
                    break;
                case "oMinus":
                    bloodType = BloodType.oMinus;
                    break;
                default:
                    break;

            }
            //bloodType = BloodType.aPlus;
            //i++;
            patient = new Patient(int.Parse(values[i++]));
            int count = int.Parse(values[i++]);
            for(int j = 0; j < count; j++)
            {
                allergens.Add(values[i++]);
            }
            count = int.Parse(values[i++]);
            ZdravoCorp.Controller.CommentController cc = new ZdravoCorp.Controller.CommentController();
            for (int j = 0; j < count; j++)
            {
                comments.Add(cc.ReadComment(int.Parse(values[i++])));
            }
        }
    }
}