using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ZdravoCorp.View.Secretary.Modell
{
    public class EquipmentToOrder: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String name;
        private int amount;
        

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public String Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public int Amount
        {
            get => amount;
            set
            {
                if (value != amount)
                {
                    amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }
    }
}
