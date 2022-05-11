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
using ZdravoCorp.View.Manager.Model.Room;

namespace ZdravoCorp.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for ChangeRoom.xaml
    /// </summary>
    public partial class ChangeRoom : Window, INotifyPropertyChanged
    {
        private RoomController roomController;
        private ObservableCollection<RoomTypeModel> types;
        private Room room;

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

        public ChangeRoom(Room room)
        {
            InitializeComponent();
            this.DataContext = this;

            this.room = room;

            roomController = new RoomController();
            types = roomController.GetAllRoomTypeView();
            Types.ItemsSource = types;
            for(int i = 0 ; i < types.Count ; i++)
            {
                if(types[i].Name == room.RoomType.Name)
                {
                    Types.SelectedIndex = i;
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            room.RoomType.Name = types[Types.SelectedIndex].Name;
            if (!roomController.UpdateRoom(room))
            {
                MessageBox.Show("Nije uspesno izmenjen element", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Close();
            }
        }

        private void RoomTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            AddRoomType window = new AddRoomType();
            window.ShowDialog();
            types = roomController.GetAllRoomTypeView();
            Types.ItemsSource = types;
        }
    }
}
