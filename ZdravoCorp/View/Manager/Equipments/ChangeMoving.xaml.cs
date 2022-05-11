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
using ZdravoCorp.View.Manager.Model.Equipment;

namespace ZdravoCorp.View.Manager.Equipments
{
    /// <summary>
    /// Interaction logic for ChangeMoving.xaml
    /// </summary>
    public partial class ChangeMoving : Window
    {
        private ActionController controller;
        private ObservableCollection<ChangeActionModel> actionTable;
        public ChangeMoving()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new ActionController();
            UpdateTable();
        }

        public void UpdateTable()
        {
            actionTable = controller.GetAllChangeRoomActions();
            ActionTable.DataContext = actionTable;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (ActionTable.SelectedIndex == -1)
            {
                return;
            }
            if (!controller.DeleteChangeAction(actionTable[ActionTable.SelectedIndex]))
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
            EditMoving window = new EditMoving(actionTable[ActionTable.SelectedIndex]);
            window.ShowDialog();
            UpdateTable();
        }
    }
}
