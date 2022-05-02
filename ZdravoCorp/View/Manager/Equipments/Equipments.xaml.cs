using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ZdravoCorp.View.ViewModel;

namespace ZdravoCorp.View.Manager.Equipments
{
    /// <summary>
    /// Interaction logic for Equipments.xaml
    /// </summary>
    public partial class Equipments : Window
    {
        private ObservableCollection<EquipmentTableVO> table;
        private EquipmentController controller;
        public Equipments()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new EquipmentController();
            UpdateTable();
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEquipment window = new AddEquipment();
            window.ShowDialog();
            UpdateTable();
        }

        private void UpdateTable()
        {
            table = controller.GetAllEquipmentTableVO();
            EquipmentTable.DataContext = table;
        }

        private void ChangePosition_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentTable.SelectedIndex == -1)
            {
                return;
            }
            ChangePosition window = new ChangePosition(table[EquipmentTable.SelectedIndex]);
            window.ShowDialog();
            UpdateTable();
        }
    }
}
