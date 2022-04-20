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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window, INotifyPropertyChanged
    {

        private int id;
        private String identifier;
        private int size;
        private String roomType;
        public AddRoom()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public int Size
        {
            get { return size; }
            set
            {
                if (value != size)
                {
                    size = value;
                    OnPropertyChanged("Size");
                }
            }
        }

        public String Identifier
        {
            get { return identifier; }
            set
            {
                if (value != identifier)
                {
                    identifier = value;
                    OnPropertyChanged("Identifier");
                }
            }
        }

        public string RoomType
        {
            get { return roomType; }
            set
            {
                if (value != roomType)
                {
                    roomType = value;
                    OnPropertyChanged("RoomType");
                }
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Controller.RoomController controller = new Controller.RoomController();
            if (!controller.CreateRoom(new Room(id, identifier, size, new RoomType(roomType), new List<Appointment>(), new List<Equipment>(), new List<Medication>())))
            {
                MessageBox.Show("Nije uspesno dodat element", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Close();
            }
        }
    }
}
