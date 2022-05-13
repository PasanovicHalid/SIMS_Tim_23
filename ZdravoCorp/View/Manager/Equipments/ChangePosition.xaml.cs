using Controller;
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
using ZdravoCorp.View.Manager.Model.Equipments;
using ZdravoCorp.View.Manager.Model.Rooms;

namespace ZdravoCorp.View.Manager.Equipments
{
    /// <summary>
    /// Interaction logic for ChangePosition.xaml
    /// </summary>
    public partial class ChangePosition : Window, INotifyPropertyChanged
    {
        private ObservableCollection<RoomModel> roomsList;
        private EquipmentModel equipmentType;
        private RoomController roomController;
        private EquipmentController equipmentController;
        private int count;
        private int count_max;
        private TimeSpan time;

        public event PropertyChangedEventHandler PropertyChanged;

        public String TypeTxt
        {
            get => equipmentType.Name;
            set
            {
                if (value != equipmentType.Name)
                {
                    equipmentType.Name = value;
                    OnPropertyChanged("TypeTxt");
                }
            }
        }

        public int CountTxt
        {
            get => count;
            set
            {
                if (value != count)
                {
                    count = value;
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
            get => equipmentType.DesignationCode;
            set
            {
                if (value != equipmentType.DesignationCode)
                {
                    equipmentType.DesignationCode = value;
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

        public ChangePosition(EquipmentModel type)
        {
            InitializeComponent();
            this.DataContext = this;
            this.equipmentType = type;
            roomController = new RoomController();
            equipmentController = new EquipmentController();
            roomsList = roomController.GetAllRoomsVO();
            MaxCountTxt = type.Actual_count;
            Rooms.ItemsSource = roomsList;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                MessageBox.Show("Kolicina treba da je veca od 0", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DateTime excecutionDate = new DateTime();
            if (equipmentType.Disposable == false)
            {
                excecutionDate = (DateTime)Date.SelectedDate;
                excecutionDate = DateManipulator.addTimeToDate(excecutionDate, time);
            }

            int id_to_room = roomsList[Rooms.SelectedIndex].Identifier;
            int id_from_room = equipmentType.Room_identifier;
            int id_equipment = equipmentType.Equipment_identifier;
            if(count > count_max)
            {
                MessageBox.Show("Kolicina treba da je manja od maksimalne", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            equipmentController.ChangePositionOfEquipment(excecutionDate, id_from_room, id_to_room, id_equipment, count);
            this.Close();
        }
    }
}
