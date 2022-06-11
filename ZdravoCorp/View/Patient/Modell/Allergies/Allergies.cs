using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZdravoCorp.View.Core;

namespace ZdravoCorp.View.Patient.Modell.Allergies
{
    public class Allergies : ObservableObject
    {
        private String other;
        private String medicine;
        private String note;

        public Allergies()
        {
        }

        public Allergies(string other, string medicine, string note)
        {
            this.other = other;
            this.medicine = medicine;
            this.note = note;
        }

        public String Other
        {
            get => other;
            set
            {
                if (value != other)
                {
                    other = value;
                    OnPropertyChanged();
                }
            }
        }

        public String Medicine
        {
            get => medicine;
            set
            {
                if (value != medicine)
                {
                    medicine = value;
                    OnPropertyChanged();
                }
            }
        }

        public String Note
        {
            get => note;
            set
            {
                if (value != note)
                {
                    note = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
