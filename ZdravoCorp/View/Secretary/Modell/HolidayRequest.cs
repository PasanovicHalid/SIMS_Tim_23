using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace ZdravoCorp.View.Secretary.Modell
{
    public class HolidayRequest: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String requestSender;
        private String holidayStartDate;
        private String holidayEndDate;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public String RequestSender
        {
            get => requestSender;
            set
            {
                if (value != requestSender)
                {
                    requestSender = value;
                    OnPropertyChanged("RequestSender");
                }
            }
        }

        public String HolidayStartDate
        {
            get => holidayStartDate;
            set
            {
                if (value != holidayStartDate)
                {
                    holidayStartDate = value;
                    OnPropertyChanged("HolidayStartDate");
                }
            }
        }

        public String HolidayEndDate
        {
            get => holidayEndDate;
            set
            {
                if (value != holidayEndDate)
                {
                    holidayEndDate = value;
                    OnPropertyChanged("HolidayEndDate");
                }
            }
        }
    }
}
