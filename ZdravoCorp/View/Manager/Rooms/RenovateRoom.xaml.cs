using Controller;
using Model;
using System;
using System.Collections.Generic;
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

namespace ZdravoCorp.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for RenovateRoom.xaml
    /// </summary>
    public partial class RenovateRoom : Window, INotifyPropertyChanged
    {
        private Room room;
        private RoomController controller;

        public RenovateRoom(Room room)
        {
            InitializeComponent();
            this.DataContext = this;

            this.room = room;
            controller = new RoomController();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public float Size
        {
            get { return room.SurfaceArea; }
            set
            {
                if (value != room.SurfaceArea)
                {
                    room.SurfaceArea = value;
                    OnPropertyChanged("Size");
                }
            }
        }

        public String Identifier
        {
            get { return room.DesignationCode; }
            set
            {
                if (value != room.DesignationCode)
                {
                    room.DesignationCode = value;
                    OnPropertyChanged("Identifier");
                }
            }
        }

        public String RoomType
        {
            get { return room.RoomTypeString; }
            set
            {
                if (value != room.RoomTypeString)
                {
                    room.RoomTypeString = value;
                    OnPropertyChanged("Identifier");
                }
            }
        }

        private void Renovate_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = (DateTime) StartDate.SelectedDate;
            DateTime end = (DateTime)EndDate.SelectedDate;
            if (!controller.RenovateRoom(room.Identifier, start, end))
            {
                MessageBox.Show("Nije uspesno izvrsen zadatak", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Close();
            }
        }
    }
}
