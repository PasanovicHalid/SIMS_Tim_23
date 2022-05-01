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
using ZdravoCorp.View.ViewModel;

namespace ZdravoCorp.View.Manager.Equipments
{
    /// <summary>
    /// Interaction logic for AddEquipmentType.xaml
    /// </summary>
    public partial class AddEquipmentType : Window, INotifyPropertyChanged
    {
        private EquipmentTypeVO type;
        private String description;
        private String name;
        private EquipmentController controller;
        private bool done;
        private bool disposable;
        public AddEquipmentType(ref EquipmentTypeVO type,ref bool done)
        {
            InitializeComponent();
            this.DataContext = this;
            this.type = type;
            this.done = done;
            controller = new EquipmentController();
        }
        public String Description
        {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public String Name1
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name1");
                }
            }
        }

        public bool Disposable
        {
            get { return disposable; }
            set
            {
                if (value != disposable)
                {
                    disposable = value;
                    OnPropertyChanged("Disposable");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (!controller.CreateEquipmentType(new EquipmentTypeVO(name, description, disposable)))
            {
                MessageBox.Show("Nije uspesno dodat element", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                done = true;
                this.Close();
            }
        }
    }
}
