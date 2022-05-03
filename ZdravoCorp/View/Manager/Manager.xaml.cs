﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZdravoCorp.View.Manager
{
    /// <summary>
    /// Interaction logic for MainWindowManager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private AutoResetEvent autoEvent;
        public Manager(AutoResetEvent autoEvent)
        {
            this.autoEvent = autoEvent;
            InitializeComponent();
        }

        private void Rooms_Click(object sender, RoutedEventArgs e)
        {
            ZdravoCorp.View.Manager.Rooms.Rooms rooms = new ZdravoCorp.View.Manager.Rooms.Rooms();
            this.Hide();
            rooms.ShowDialog();
            this.Show();
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            Equipments.Equipments window = new Equipments.Equipments();
            this.Hide();
            window.ShowDialog();
            this.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Drag_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            autoEvent.Set();
        }
    }
}
