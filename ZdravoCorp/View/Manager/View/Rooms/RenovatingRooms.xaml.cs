﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoCorp.View.Manager.ViewModel.Rooms;

namespace ZdravoCorp.View.Manager.View.Rooms
{
    /// <summary>
    /// Interaction logic for RenovatingRooms.xaml
    /// </summary>
    public partial class RenovatingRooms : UserControl
    {
        public RenovatingRooms(RenovatingRoomsViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
        }
    }
}
