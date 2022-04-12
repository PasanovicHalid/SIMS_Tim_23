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

namespace ZdravoCorp.View
{
    /// <summary>
    /// Interaction logic for ChangeRoom.xaml
    /// </summary>
    public partial class ChangeRoom : Window, INotifyPropertyChanged
    {
        private Room room;
        private RoomController roomController;
        public ChangeRoom(Room room)
        {
            InitializeComponent();
            this.DataContext = this;
            roomController = new RoomController();
            this.room = room;
            id.Text = room.Identificator;
            sz.Text = room.Size.ToString();
            tp.Text = room.Type;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            roomController.UpdateRoom(new Room(id.Text, float.Parse(sz.Text), new RoomType(tp.Text), room.equipmentList), room.Identificator);
            this.Close();
        }
    }
}
