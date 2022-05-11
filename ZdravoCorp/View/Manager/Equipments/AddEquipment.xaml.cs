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
using ZdravoCorp.View.Manager.Model.Equipment;
using ZdravoCorp.View.Manager.Model.Room;

namespace ZdravoCorp.View.Manager.Equipments
{
    /// <summary>
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window, INotifyPropertyChanged
    {
        private ObservableCollection<EquipmentTypeModel> equipmentList;
        private ObservableCollection<RoomModel> roomsList;
        private EquipmentController equipmentController;
        private RoomController roomController;
        private int count;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Count 
        { 
            get => count;
            set 
            {
                if (value != count)
                {
                    count = value;
                    OnPropertyChanged("Count");
                }
            } 
        }

        public AddEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            equipmentController = new EquipmentController();
            roomController = new RoomController();
            UpdateDataFromDB();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (!equipmentController.CreateEquipment(equipmentList.ElementAt(Types.SelectedIndex), count, roomsList.ElementAt(Rooms.SelectedIndex)))
            {
                MessageBox.Show("Nije uspesno dodat element", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Close();
            }
        }
        private void EquipmentTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEquipmentType window = new AddEquipmentType();
            window.ShowDialog();
            UpdateDataFromDB();
        }
        private void UpdateDataFromDB()
        {
            equipmentList = equipmentController.GetAllEquipmentType();
            roomsList = roomController.GetAllRoomsVO();
            Types.ItemsSource = equipmentList;
            Rooms.ItemsSource = roomsList;
        }

        private void UpdateData()
        {
            Types.ItemsSource = equipmentList;
        }
    }
}
