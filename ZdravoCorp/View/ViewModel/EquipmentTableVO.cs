using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.View.ViewModel
{
    public class EquipmentTableVO
    {
        private int count;
        private String name;
        private String designationCode;
        private int room_identifier;
        private int equipment_identifier;

        public EquipmentTableVO()
        {
        }

        public EquipmentTableVO(int count, string name, string designationCode, int room_identifier, int equipment_identifier)
        {
            this.count = count;
            this.name = name;
            this.designationCode = designationCode;
            this.room_identifier = room_identifier;
            this.equipment_identifier = equipment_identifier;
        }

        public int Count { get => count; set => count = value; }
        public string Name { get => name; set => name = value; }
        public string DesignationCode { get => designationCode; set => designationCode = value; }
        public int Room_identifier { get => room_identifier; set => room_identifier = value; }
        public int Equipment_identifier { get => equipment_identifier; set => equipment_identifier = value; }
    }
}
