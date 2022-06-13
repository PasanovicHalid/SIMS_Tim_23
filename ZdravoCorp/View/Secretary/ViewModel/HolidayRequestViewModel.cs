using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace ZdravoCorp.View.Secretary.ViewModel
{
    public class HolidayRequestViewModel
    {
        public HolidayRequestViewModel()
        {
            loadHolidays();
        }

        public ObservableCollection<Modell.HolidayRequest> Holidays { get; set; }

        public void loadHolidays() 
        {
            ObservableCollection<Modell.HolidayRequest> holidays = new ObservableCollection<Modell.HolidayRequest>();
            holidays.Add(new Modell.HolidayRequest { RequestSender = "Duško Dušković", HolidayStartDate = "7/7/2022", HolidayEndDate = "10/7/2022" });
            holidays.Add(new Modell.HolidayRequest { RequestSender = "Mina Milić", HolidayStartDate = "20/7/2022", HolidayEndDate = "30/7/2022" });
            holidays.Add(new Modell.HolidayRequest { RequestSender = "Miroljub Petrović", HolidayStartDate = "25/7/2022", HolidayEndDate = "5/8/2022" });
            holidays.Add(new Modell.HolidayRequest { RequestSender = "Lazar Petković", HolidayStartDate = "13/7/2022", HolidayEndDate = "16/7/2022" });
            holidays.Add(new Modell.HolidayRequest { RequestSender = "Luka Kostić", HolidayStartDate = "16/7/2022", HolidayEndDate = "17/7/2022" });
            holidays.Add(new Modell.HolidayRequest { RequestSender = "Darko Marić", HolidayStartDate = "23/7/2022", HolidayEndDate = "3/8/2022" });
            Holidays = holidays;
        }

    }
}
