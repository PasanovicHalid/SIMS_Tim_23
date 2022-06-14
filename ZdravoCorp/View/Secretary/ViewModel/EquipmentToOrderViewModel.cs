using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ZdravoCorp.View.Core;

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ZdravoCorp.View.Secretary.ViewModel
{
    public class EquipmentToOrderViewModel
    {
        public EquipmentToOrderViewModel()
        {
            loadOrders();
        }

        public ObservableCollection<Modell.EquipmentToOrder> EquipmentToOrder { get; set; }

        public void loadOrders()
        {
            ObservableCollection<Modell.EquipmentToOrder> equipmentToOrder = new ObservableCollection<Modell.EquipmentToOrder>();
            equipmentToOrder.Add(new Modell.EquipmentToOrder { Name = "Krevet", Amount = 15});
            equipmentToOrder.Add(new Modell.EquipmentToOrder { Name = "Anestezija", Amount = 4});
            equipmentToOrder.Add(new Modell.EquipmentToOrder { Name = "Stolica", Amount = 30});
            equipmentToOrder.Add(new Modell.EquipmentToOrder { Name = "Brufen", Amount = 7});
            equipmentToOrder.Add(new Modell.EquipmentToOrder { Name = "Igla", Amount = 50});
            equipmentToOrder.Add(new Modell.EquipmentToOrder { Name = "Rukavice", Amount = 300});
            EquipmentToOrder = equipmentToOrder;
        }
    }
}
