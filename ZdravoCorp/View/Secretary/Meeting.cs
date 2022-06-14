using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ZdravoCorp.View.Secretary
{
    public class Meeting : INotifyPropertyChanged
    {
        private string room;
        private string time;
        private string date;
        private string topic;
        private List<string> members;
        public event PropertyChangedEventHandler PropertyChanged;



        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
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

        public String Time
        {
            get => time;
            set
            {
                if (value != time)
                {
                    time = value;
                    OnPropertyChanged("Time");
                }
            }
        }
        public String Date
        {
            get => date;
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        public String Topic
        {
            get => topic;
            set
            {
                if (value != topic)
                {
                    topic = value;
                    OnPropertyChanged("Topic");
                }
            }
        }

        public List<String> Members
        {
            get => members;
            set
            {
                if (value != members)
                {
                    members = value;
                    OnPropertyChanged("Members");
                }
            }
        }

        //public String Room { get => room; set => room = value; }
        //public String Time { get => time; set => time = value; }
        //public String Date { get => date; set => date = value; }
        //public String Topic { get => topic; set => topic = value; }
        //public List<string> Members { get => members; set => members = value; }

        //public Meeting(string room, string time, string date, string topic, List<String> members) {
        //    this.room = room;
        //    this.time = time;
        //    this.date = date;
        //    this.topic = topic;
        //    this.members = members;
        //}

    }
}
