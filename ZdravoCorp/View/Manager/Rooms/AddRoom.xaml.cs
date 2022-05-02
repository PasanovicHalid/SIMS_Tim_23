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
using Model;
using Controller;
using System.Collections.ObjectModel;
using ZdravoCorp.View.ViewModel;

namespace ZdravoCorp.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window, INotifyPropertyChanged
    {

        private int id;
        private String identifier;
        private float size;
        private String roomType;
        private ObservableCollection<RoomTypeVO> types;
        private RoomController roomController;
        public AddRoom()
        {
            InitializeComponent();
            roomController = new RoomController();
            this.DataContext = this;
            types = roomController.GetAllRoomTypeView();
            Types.ItemsSource = types;
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

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            
            RoomController controller = new RoomController();
            if (!controller.CreateRoom(new Room(identifier, size, new RoomType(types.ElementAt(Types.SelectedIndex)), new List<Appointment>(), new List<Equipment>(), new List<Medication>())))
            {
                MessageBox.Show("Nije uspesno dodat element", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
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
