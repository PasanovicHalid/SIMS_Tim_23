// File:    Survey.cs
// Author:  halid
// Created: Thursday, 14 April 2022 21:08:18
// Purpose: Definition of Class Survey

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class AppointmentSurvey : Serializable
    {
        private int id;
        private int profesionalism;
        private int kindness;
        private int comfort;
        private int tidiness;
        private int waitingTime;
        private int roomComfort;
        private int overallExperience;
        //private String questionAboutProfesionalism = "Ocenite profesionalnost lekara";
        //private String questionAboutComfort = "Ocenite udobnost";
        //private String questionAboutKindness = "Ocenite ljubaznost lekara";
        //private String questionAboutWaitingTime = "Ocenite koliko ste zadovoljni cekanjem";
        //private String questionAboutRoom = "Ocenite zadovoljstvo prostorijom u kojoj je obavljen pregled";
        //private String questionAboutOverallExperience = "Ocenite opsti utisak";

        //private Dictionary<int,String> questions = new Dictionary<int, String>();
        private Appointment appointment;
        public AppointmentSurvey()
        {
            //int key = 0;
            //questions.Add(key++, questionAboutProfesionalism);
            //questions.Add(key++, questionAboutComfort);
            //questions.Add(key++, questionAboutKindness);
            //questions.Add(key++, questionAboutRoom);
            //questions.Add(key++, questionAboutWaitingTime);
            //questions.Add(key++, questionAboutOverallExperience);
        }

        public int Id { get => id; set => id = value; }
        public int Profesionalism { get => profesionalism; set => profesionalism = value; }
        public int Kindnes { get => kindness; set => kindness = value; }
        public int Comfort { get => comfort; set => comfort = value; }
        public int Tidiness { get => tidiness; set => tidiness = value; }
        public int WaitingTime { get => waitingTime; set => waitingTime = value; }
        public int RoomComfort { get => roomComfort; set => roomComfort = value; }
        public int OverallExperience { get => overallExperience; set => overallExperience = value; }
        public Appointment Appointment { get => appointment; set => appointment = value; }

        public List<String> ToCSV()
        {
            List<String> result = new List<String>();
            result.Add(id.ToString());
            result.Add(profesionalism.ToString());
            result.Add(kindness.ToString());
            result.Add(comfort.ToString());
            result.Add(tidiness.ToString());
            result.Add(waitingTime.ToString());
            result.Add(roomComfort.ToString());
            result.Add(overallExperience.ToString());
            result.Add(appointment.Id.ToString());
            return result;
        }

        public void FromCSV(string[] values)
        {
            int i = 0;
            id = int.Parse(values[i++]);
            profesionalism = int.Parse(values[i++]);
            kindness = int.Parse(values[i++]);
            comfort = int.Parse(values[i++]);
            tidiness = int.Parse(values[i++]);
            waitingTime = int.Parse(values[i++]);
            roomComfort = int.Parse(values[i++]);
            overallExperience = int.Parse(values[i++]);
            appointment = new Appointment(int.Parse(values[i++]));
        }

    }
}