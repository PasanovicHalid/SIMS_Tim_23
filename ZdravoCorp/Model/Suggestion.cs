using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Suggestion
    {
        private Doctor doctor;
        private DateTime startInterval;
        private DateTime endInterval;
        private bool priorityDoctor;
        private bool priorityDate;

        public Doctor Doctor
        {
            get { return doctor; }
            set { doctor = value; }
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

        public Suggestion(Doctor doctorID, DateTime startInterval, DateTime endInterval, bool priorityDoctor, bool priorityDate)
        {
            this.doctor = doctorID;
            this.startInterval = startInterval;
            this.endInterval = endInterval;
            this.priorityDoctor = priorityDoctor;
            this.priorityDate = priorityDate;
        }
    }
}

