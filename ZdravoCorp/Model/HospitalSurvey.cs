using Repository;
using System;
using System.Collections.Generic;
using ZdravoCorp.View.Core;
using System.ComponentModel;
namespace Model
{
    public class HospitalSurvey: Serializable
    {
        private int id;
        private int profesionalism;
        private int comfort;
        private int tidiness;
        private int kindness;
        private int hygiene;
        private int modernity;
        private int equipped;
        private int overallExperience;
        private Patient patient;

        public HospitalSurvey()
        {
        }

        public HospitalSurvey(int profesionalism, int comfort, int tidiness, int kindness, int hygiene, int modernity, int equipped, int overallExperience, Patient patient)
        {
            this.profesionalism = profesionalism;
            this.comfort = comfort;
            this.tidiness = tidiness;
            this.kindness = kindness;
            this.hygiene = hygiene;
            this.modernity = modernity;
            this.equipped = equipped;
            this.overallExperience = overallExperience;
            this.patient = patient;
        }
        public List<String> ToCSV()
        {
            List<String> result = new List<String>();
            result.Add(id.ToString());
            result.Add(profesionalism.ToString());
            result.Add(comfort.ToString());
            result.Add(tidiness.ToString());
            result.Add(kindness.ToString());
            result.Add(hygiene.ToString());
            result.Add(modernity.ToString());
            result.Add(equipped.ToString());
            result.Add(overallExperience.ToString());
            result.Add(patient.Id.ToString());
            return result;
        }

        public void FromCSV(string[] values)
        {
            int i = 0;
            id = int.Parse(values[i++]);
            profesionalism = int.Parse(values[i++]);
            comfort = int.Parse(values[i++]);
            tidiness = int.Parse(values[i++]);
            kindness = int.Parse(values[i++]);
            hygiene = int.Parse(values[i++]);
            modernity = int.Parse(values[i++]);
            equipped = int.Parse(values[i++]);
            overallExperience = int.Parse(values[i++]);
            patient = new Patient(int.Parse(values[i++]));
        }

        public int Id { get => id; set => id = value; }
        public int Preofesionalism { get => profesionalism; set => profesionalism = value; }
        public int Kindnes { get => kindness; set => kindness = value; }
        public int Comfort { get => comfort; set => comfort = value; }
        public int Tidiness { get => tidiness; set => tidiness = value; }
        public int Hygiene { get => hygiene; set => hygiene = value; }
        public int Modernity { get => modernity; set => modernity = value; }
        public int Equipped { get => equipped; set => equipped = value; }
        public int OverallExperience { get => overallExperience; set => overallExperience = value; }

    }
}
