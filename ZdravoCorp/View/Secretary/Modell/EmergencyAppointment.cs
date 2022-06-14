using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ZdravoCorp.View.Secretary.Modell
{
    public class EmergencyAppointment: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String id;
        private String name;
        private String surname;
        private String bloodType;
        private String doctor;
        private String room;
        


        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public String Id
        {
            get => id;
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public String Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public String Surname
        {
            get => surname;
            set
            {
                if (value != surname)
                {
                    surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }
        public String BloodType
        {
            get => bloodType;
            set
            {
                if (value != bloodType)
                {
                    bloodType = value;
                    OnPropertyChanged("BloodType");
                }
            }
        }
        public String Doctor
        {
            get => doctor;
            set
            {
                if (value != doctor)
                {
                    doctor = value;
                    OnPropertyChanged("Doctor");
                }
            }
        }
        public String Room
        {
            get => room;
            set
            {
                if (value != room)
                {
                    room = value;
                    OnPropertyChanged("Room");
                }
            }
        }
    }
}
