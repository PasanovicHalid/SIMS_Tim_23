using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ZdravoCorp.View.Secretary
{
    /// <summary>
    /// Interaction logic for Meetings.xaml
    /// </summary>
    public partial class Meetings : Page
    {
        private SecretaryMainPage smp;
        private SecretaryMainWindow smw;
        public ObservableCollection<Meeting> MeetingsCollection;
        private List<Meeting> meetingsList;
        private List<String> members;

        public Meetings(SecretaryMainPage smp, SecretaryMainWindow smw)
        {
            
            loadData();
            this.smp = smp;
            this.smw = smw;
            InitializeComponent();
            MeetingsTable.DataContext = MeetingsCollection;

        }

        public void loadData() {
            members = new List<String>();
            meetingsList = new List<Meeting>();
            members.Add("Duško Dušković");
            members.Add("Luka Kostić");
            members.Add("Mina Minić");
            Meeting m1 = new Meeting { Room = "RS205", Time = "15.00", Date = "7/7/2022", Topic = "Povecan broj operacija srca", Members = members };
            Meeting m2 = new Meeting { Room = "RS201", Time = "10.30", Date = "18/7/2022", Topic = "Povecana potrosnja rukavica", Members = members };
            Meeting m3 = new Meeting { Room = "RS103", Time = "9.00", Date = "11/7/2022", Topic = "Losa higijena u bolnici", Members = members };
           
            meetingsList.Add(m1);
            meetingsList.Add(m2);
            meetingsList.Add(m3);
            MeetingsCollection = new ObservableCollection<Meeting>(meetingsList);
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            smw.Content = smp;
        }
    }
}
