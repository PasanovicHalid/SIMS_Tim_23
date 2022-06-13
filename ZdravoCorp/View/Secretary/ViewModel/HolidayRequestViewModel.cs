using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ZdravoCorp.View.Core;

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ZdravoCorp.View.Secretary.ViewModel
{
    public class HolidayRequestViewModel
    {
        private SecretaryMainWindow secretaryyMainWindow;   
        private SecretaryMainPage secretaryMainPage;
        public HolidayRequestViewModel(SecretaryMainPage smp, SecretaryMainWindow secretaryMainWindow)
        {
            this.secretaryyMainWindow = secretaryMainWindow;
            this.secretaryMainPage = smp;
            loadHolidays();
            MenuCommand = new RelayCommand(o =>
            {
                try
                {
                    secretaryyMainWindow.Content = secretaryMainPage;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            DeclineCommand = new RelayCommand(o =>
            {
                try
                {
                    MessageBoxResult dialogResult = (MessageBoxResult) System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da odbijete zahtev za odsustvo?", "Upozorenje", MessageBoxButtons.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        //do something
                    }
                    else if (dialogResult == MessageBoxResult.No)
                    {
                        //do something else
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            AcceptCommand = new RelayCommand(o =>
            {
                try
                {
                    MessageBoxResult dialogResult = (MessageBoxResult)System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da odobrite zahtev za odsustvo?", "Upozorenje", MessageBoxButtons.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        //do something
                    }
                    else if (dialogResult == MessageBoxResult.No)
                    {
                        //do something else
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
        public RelayCommand MenuCommand { get; set; }
        public RelayCommand DeclineCommand { get; set; }
        public RelayCommand AcceptCommand { get; set; }
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
