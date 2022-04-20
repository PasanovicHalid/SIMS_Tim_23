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
    /// Interaction logic for ChangeRoom.xaml
    /// </summary>
    public partial class ChangeRoom : Window, INotifyPropertyChanged
    {
        private Room room;
        private RoomController roomController;

        public event PropertyChangedEventHandler PropertyChanged;
        public ChangeRoom(Room room)
        {
            InitializeComponent();
            this.DataContext = this;
            roomController = new RoomController();
            this.room = room;
            RoomId.Text = room.Identifier.ToString();
            RoomIdentifier.Text = room.DesignationCode;
            RoomSize.Text = room.SurfaceArea.ToString();
            RoomType.Text = room.RoomType.Name.ToString();
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            room.DesignationCode = RoomIdentifier.Text;
            room.SurfaceArea = float.Parse(RoomSize.Text);
            room.RoomType.Name = RoomType.Text;
            if (!roomController.UpdateRoom(room))
            {
                MessageBox.Show("Nije uspesno izmenjen element", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Close();
            }
        }
    }
}
