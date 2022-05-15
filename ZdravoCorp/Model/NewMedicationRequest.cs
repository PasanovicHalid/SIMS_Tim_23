using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Model
{
    public class NewMedicationRequest : Serializable
    {
        private int id;

        private MedicationType medicationType;

        private Status status;

        private String comment;
        public int Id { get => id; set => id = value; }

        public string Name
        {
            get => medicationType.Name; set => medicationType.Name = value;
        }
        public string Manufacturer
        {
            get => medicationType.Manufacturer; set => medicationType.Manufacturer = value;
        }
        public string Description
        {
            get => medicationType.Description; set => medicationType.Description = value;
        }
        public MedicationType MedicationType
        {
            get
            {
                return medicationType;
            }
            set
            {
                this.medicationType = value;
            }
        }
        public Status Status { get => status; set => status = value; }

        public String Comment
        {
            get
            {
                if (comment == null)
                {
                    return "";
                }
                return comment;
            }
            set
            {
                comment = value;
            }
        }

        public NewMedicationRequest(String name, String manufacturer, String description)
        {
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            Status = Status.PENDING;
        }

        public NewMedicationRequest()
        { }

        private string[] ReadInfo(string[] values)
        {
            int i = 0;
            Id = int.Parse(values[i++]);
            Status = (Status)Enum.Parse(typeof(Status), values[i++]);
            Comment = values[i++];
            return values.Skip(i).ToArray();
        }
        public void FromCSV(string[] values)
        {
            int i = 0;
            values = ReadInfo(values);
            MedicationType = new MedicationType();
            MedicationType.FromCSV(values);
        }

        public List<String> ToCSV()
        {
            List<String> result = new List<String>();
            result.Add(id.ToString());
            result.Add(Status.ToString());
            result.Add(Comment);
            result.AddRange(MedicationType.ToCSV());
            return result;
        }
    }
}
