﻿using System;
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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window, INotifyPropertyChanged
    {
        private String identifier;
        private int size;
        private String roomType;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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

        public AddRoom()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Controller.RoomController controller =  new Controller.RoomController();
            if(!controller.CreateRoom(new Model.Room(identifier, size, new Model.RoomType(roomType), new System.Collections.ArrayList())))
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
