using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
namespace ZdravoCorp.Model
{
    public class Suggestions
    {
        private int doctorID;
        private DateTime startInterval;
        private DateTime endInterval;
        private bool priorityDoctor;
        private bool priorityDate;

        public int DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }
        public DateTime StartInterval
        {
            get { return startInterval; }
            set { startInterval = value; }
        }
        public DateTime EndInterval
        {
            get { return endInterval; }
            set { endInterval = value; }
        }
        public bool PriorityDoctor
        {
            get { return priorityDoctor; }
            set { priorityDoctor = value; }
        }
        public bool PriorityDate
        {
            get { return priorityDate; }
            set { priorityDate = value; }
        }

        public Suggestions(int doctorID, DateTime startInterval, DateTime endInterval, bool priorityDoctor, bool priorityDate)
        {
            this.doctorID = doctorID;
            this.startInterval = startInterval;
            this.endInterval = endInterval;
            this.priorityDoctor = priorityDoctor;
            this.priorityDate = priorityDate;
        }
    }
}
