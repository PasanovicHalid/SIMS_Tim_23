using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;
using ZdravoCorp.Utility;
using ZdravoCorp.View.ViewModel;

namespace ZdravoCorp.View.Manager.Equipments
{
    /// <summary>
    /// Interaction logic for EditMoving.xaml
    /// </summary>
    public partial class EditMoving : Window, INotifyPropertyChanged
    {
        private ObservableCollection<RoomVO> roomsList;
        private ChangeActionVO action;
        private RoomController roomController;
        private ActionController actionController;
        private int count;
        private int count_max;
        private TimeSpan time;

        public event PropertyChangedEventHandler PropertyChanged;

        public String TypeTxt
        {
            get => action.Equipment;
            set
            {
                if (value != action.Equipment)
                {
                    action.Equipment = value;
                    OnPropertyChanged("TypeTxt");
                }
            }
        }

        public int CountTxt
        {
            get => action.Count;
            set
            {
                if (value != action.Count)
                {
                    action.Count = value;
                    OnPropertyChanged("CountTxt");
                }
            }
        }

        public int MaxCountTxt
        {
            get => count_max;
            set
            {
                if (value != count_max)
                {
                    count_max = value;
                    OnPropertyChanged("MaxCountTxt");
                }
            }
        }

        public String RoomTxt
        {
            get => action.OutgoingRoom;
            set
            {
                if (value != action.OutgoingRoom)
                {
                    action.OutgoingRoom = value;
                    OnPropertyChanged("RoomTxt");
                }
            }
        }

        public TimeSpan TimeTxt
        {
            get => time;
            set
            {
                if (value != time)
                {
                    time = value;
                    OnPropertyChanged("TimeTxt");
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public EditMoving(ChangeActionVO action)
        {
            InitializeComponent();
            this.DataContext = this;
            this.action = action;
            roomController = new RoomController();
            actionController = new ActionController();
            roomsList = roomController.GetAllRoomsVO();
            Date.SelectedDate = action.ExecutionDate;
            Room room = roomController.ReadRoom(action.Id_outgoing_room);
            foreach(Equipment it in room.Equipment)
            {
                if(it.Identifier == action.Id_equipment)
                {
                    count_max = it.Actual_count + action.Count;
                }
            }
            count = action.Count;
            Rooms.ItemsSource = roomsList;
            TimeTxt = action.ExecutionDate.TimeOfDay;
            foreach(RoomVO it in roomsList)
            {
                if(it.DesignationCode == action.IncomingRoom)
                {
                    Rooms.SelectedIndex = Rooms.Items.IndexOf(it);
                    break;
                }
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                MessageBox.Show("Kolicina treba da je veca od 0", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DateTime excecutionDate = new DateTime();
            excecutionDate = (DateTime)Date.SelectedDate;
            excecutionDate = DateManipulator.addTimeToDate(excecutionDate, time);
            action.ExecutionDate = excecutionDate;
            action.Id_incoming_room = roomsList[Rooms.SelectedIndex].Identifier;
            if (count > count_max)
            {
                MessageBox.Show("Kolicina treba da je manja od maksimalne", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(!actionController.UpdateChangeAction(action, count - action.Count))
            {
                MessageBox.Show("Neuspesno izmenjena akcija", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Close();
        }
    }
}
