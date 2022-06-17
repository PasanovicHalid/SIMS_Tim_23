using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ZdravoCorp.View.Secretary.Modell
{
    public class Secretary : INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private string email;
        private string dateOfBirth;
        private string id;
        private string phoneNumber;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
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
        public String Email
        {
            get => email;
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public String DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                if (value != dateOfBirth)
                {
                    dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
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
       
        public String PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }
    }
}
