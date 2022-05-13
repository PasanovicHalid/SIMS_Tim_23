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
using ZdravoCorp.View.Manager.Model.Rooms;

namespace ZdravoCorp.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for ChangeRenovation.xaml
    /// </summary>
    public partial class ChangeRenovation : Window
    {
        private ObservableCollection<RenovationActionModel> actionTable;
        private ActionController controller;
        public ChangeRenovation()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new ActionController();
            UpdateTable();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (ActionTable.SelectedIndex == -1)
            {
                return;
            }
            if (!controller.DeleteRenovationAction(actionTable[ActionTable.SelectedIndex]))
            {
                MessageBox.Show("Nije uspesno obrisana akcija", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateTable();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ActionTable.SelectedIndex == -1)
            {
                return;
            }
            if (actionTable[ActionTable.SelectedIndex].Renovation)
            {
                ChangeTrue window = new ChangeTrue(actionTable[ActionTable.SelectedIndex]);
                window.ShowDialog();
                UpdateTable();
            }
            else
            {
                ChangeFalse window = new ChangeFalse(actionTable[ActionTable.SelectedIndex]);
                window.ShowDialog();
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            actionTable = controller.GetAllRenovationActions();
            ActionTable.DataContext = actionTable;
        }
    }
}
