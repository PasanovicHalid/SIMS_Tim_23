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
    public class EmergencyAppointmentViewModel
    {
        ObservableCollection<string> bloodTypes = new ObservableCollection<string>();
        ObservableCollection<string> rooms = new ObservableCollection<string>();
        ObservableCollection<string> doctors = new ObservableCollection<string>();
        

        public ObservableCollection<Modell.EmergencyAppointment> EmergencyAppointments { get; set; }
        public EmergencyAppointmentViewModel()
        {
            loadData();
            EmergencyAppointments = new ObservableCollection<Modell.EmergencyAppointment>();

            

        }
        public void loadData()
        {
            bloodTypes.Add("aPlus");
            bloodTypes.Add("aMinus");
            bloodTypes.Add("bPlus");
            bloodTypes.Add("bMinus");
            bloodTypes.Add("aBPlus");
            bloodTypes.Add("aBMinus");
            bloodTypes.Add("oPlus");
            bloodTypes.Add("oMinus");

            rooms.Add("RS110");
            rooms.Add("RS111");
            rooms.Add("RS201");
            rooms.Add("RS202");
            rooms.Add("RS301");

            doctors.Add("Duško Dušković");
            doctors.Add("Mina Minić");
            doctors.Add("Luka Kostić");
            doctors.Add("Lazar Petković");

        }
        public RelayCommand MenuCommand { get; set; }
    }
}
