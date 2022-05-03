using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.View.ViewModel
{
    public class RoomTypeVO
    {
        private String name;

        public RoomTypeVO()
        {
        }

        public RoomTypeVO(string name)
        {
            this.Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}
