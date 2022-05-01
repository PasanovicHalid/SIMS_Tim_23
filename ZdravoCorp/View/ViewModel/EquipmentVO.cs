using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.View.ViewModel
{
    public class EquipmentTyoeVO
    {
        private int count;
        private String name;

        public EquipmentTyoeVO()
        {

        }

        public EquipmentTyoeVO(int count, string name)
        {
            this.count = count;
            this.name = name;
        }

        public int Count { get => count; set => count = value; }
        public string Name { get => name; set => name = value; }
    }
}
