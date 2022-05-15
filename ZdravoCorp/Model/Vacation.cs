using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Model
{
    public class Vacation : Serializable
    {
        int id;
        private DateTime vacationStartDate;
        private DateTime vacationEndDate;
        private String vacationCause;
        private Doctor doctor;
        private Status status;

        public int Id { get { return id; } set { id = value; } } 

        public DateTime VacationStartDate { get { return vacationStartDate; } set { vacationStartDate = value; } }  

        public DateTime VacationEndDate { get { return vacationEndDate; } set { vacationEndDate = value; } }

        public String VacationCause { get { return vacationCause; } set { vacationCause = value; } }

        public Doctor Doctor { get { return doctor; } set { doctor = value; } }

        public int DoctorID { get { return doctor.Id; } }

        public Status Status
        {
            get => status;
            set
            {
                if (value != status)
                {
                    status = value;
                }
            }
        }

        public Vacation(DateTime vacationStartDate, DateTime vacationEndDate, string vacationCause, Doctor doctor)
        {
            VacationStartDate = vacationStartDate;
            VacationEndDate = vacationEndDate;
            VacationCause = vacationCause;
            Doctor = doctor;
            Status = Status.PENDING;
        }

        public Vacation()
        {

        }

        public List<String> ToCSV()
        {
            CultureInfo dateTimeFormat = new CultureInfo("en-GB");
            List<String> result = new List<String>();
            result.Add(Id.ToString());
            result.Add(vacationStartDate.ToString(dateTimeFormat));
            result.Add(vacationEndDate.ToString(dateTimeFormat));
            result.Add(vacationCause);
            result.Add(DoctorID.ToString());
            result.Add(Status.ToString());
            return result;
        }

        public void FromCSV(string[] values)
        {
            CultureInfo dateTimeFormat = new CultureInfo("en-GB");
            int i = 0;
            Id = int.Parse(values[i++]);
            VacationStartDate = DateTime.Parse(values[i++], dateTimeFormat);
            VacationEndDate = DateTime.Parse(values[i++], dateTimeFormat);
            vacationCause = values[i++];
            Controller.DoctorController doctorController = new Controller.DoctorController();
            Doctor = doctorController.ReadDoctor(int.Parse(values[i++]));
            Status = (Status)Enum.Parse(typeof(Status), values[i++]);
        }
    }
}
