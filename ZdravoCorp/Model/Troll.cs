using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository;
using System.Globalization;
namespace Model
{
    public class Troll : Serializable
    {
        private int id;
        private int patientId;
        private List<DateTime> changedOrCanceledAppointmnetsDates;
        public int Id { get => id; set => id = value; }
        public int PatientId { get => patientId; set => patientId = value; }   
        public List<DateTime> ChangedOrCanceledAppointmentsDates { get => changedOrCanceledAppointmnetsDates; set => changedOrCanceledAppointmnetsDates = value; }


        public List<String> ToCSV()
        {
            List<String> result = new List<String>();
            result.Add(id.ToString());
            result.Add(patientId.ToString());
            result.Add(changedOrCanceledAppointmnetsDates.Count.ToString());
            foreach(DateTime date in changedOrCanceledAppointmnetsDates)
            {
                result.Add(date.ToString());
            }
            return result;
        }

        public void FromCSV(string[] values)
        {
            int i = 0;
            id = int.Parse(values[i++]);
            patientId = int.Parse(values[i++]);
            int numberOfElementsInList = int.Parse(values[i++]);
            for(int j = 0; j < numberOfElementsInList; j++)
            {
                changedOrCanceledAppointmnetsDates.Add(DateTime.Parse(values[i++]));
            }
           
        }
    }
}
