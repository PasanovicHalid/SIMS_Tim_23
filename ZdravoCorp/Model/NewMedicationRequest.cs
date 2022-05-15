using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using ZdravoCorp.View.Core;

namespace Model
{
    public class NewMedicationRequest : ObservableObject, Serializable
    {
        private int id;

        private MedicationType medicationType;

        private Status status;

        private String comment;
        public int Id 
        {
            get => id;
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => medicationType.Name;
            set
            {
                if (value != medicationType.Name)
                {
                    medicationType.Name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Manufacturer
        {
            get => medicationType.Manufacturer;
            set
            {
                if (value != medicationType.Manufacturer)
                {
                    medicationType.Manufacturer = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Description
        {
            get => medicationType.Manufacturer;
            set
            {
                if (value != medicationType.Manufacturer)
                {
                    medicationType.Manufacturer = value;
                    OnPropertyChanged();
                }
            }
        }
        public MedicationType MedicationType
        {
            get => medicationType;
            set
            {
                if (value != medicationType)
                {
                    medicationType = value;
                    OnPropertyChanged();
                }
            }
        }
        public Status Status
        {
            get => status;
            set
            {
                if (value != status)
                {
                    status = value;
                    OnPropertyChanged();
                }
            }
        }

        public String Comment
        {
            get => comment;
            set
            {
                if (value != comment)
                {
                    comment = value;
                    OnPropertyChanged();
                }
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
