using Controller;
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
using ZdravoCorp.View.Manager.Model.Room;

namespace ZdravoCorp.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for ChangeFalse.xaml
    /// </summary>
    public partial class ChangeFalse : Window, INotifyPropertyChanged
    {
        private RenovationActionModel action;
        private ActionController controller;

        public ChangeFalse(RenovationActionModel action)
        {
            InitializeComponent();
            this.DataContext = this;
            this.action = action;
            controller = new ActionController();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public String Identifier
        {
            get { return action.DesignationCode; }
            set
            {
                if (value != action.DesignationCode)
                {
                    action.DesignationCode = value;
                    OnPropertyChanged("Identifier");
                }
            }
        }

        public DateTime End
        {
            get { return action.ExecutionDate; }
            set
            {
                if (value != action.ExecutionDate)
                {
                    action.ExecutionDate = value;
                    OnPropertyChanged("End");
                }
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (!controller.UpdateRenovationAction(action))
            {
                MessageBox.Show("Nije uspesno izmenjena akcija", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Close();
        }
    }
}
