using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.View.ViewModel
{
    public class EquipmentTypeVO
    {
        private String name;
        private String description;
        private bool disposable;

        public EquipmentTypeVO()
        {
        }

        public EquipmentTypeVO(string name, string description, bool disposable)
        {
            this.name = name;
            this.description = description;
            this.disposable = disposable;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public bool Disposable { get => disposable; set => disposable = value; }
    }
}
