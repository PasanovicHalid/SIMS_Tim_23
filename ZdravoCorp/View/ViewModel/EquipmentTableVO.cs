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
        private int actual_count;
        private String name;
        private String designationCode;
        private String description;
        private Boolean disposable;
        private int room_identifier;
        private int equipment_identifier;

        public EquipmentTableVO()
        {
        }

        public EquipmentTableVO(int count, int actual_count,  string name, string designationCode, string description,Boolean disposable, int room_identifier, int equipment_identifier)
        {
            this.count = count;
            this.name = name;
            this.Actual_count = actual_count;
            this.designationCode = designationCode;
            this.Description = description;
            this.disposable = disposable;
            this.room_identifier = room_identifier;
            this.equipment_identifier = equipment_identifier;
        }

        public int Count { get => count; set => count = value; }
        public string Name { get => name; set => name = value; }
        public string DesignationCode { get => designationCode; set => designationCode = value; }
        public int Room_identifier { get => room_identifier; set => room_identifier = value; }
        public int Equipment_identifier { get => equipment_identifier; set => equipment_identifier = value; }
        public bool Disposable { get => disposable; set => disposable = value; }
        public int Actual_count { get => actual_count; set => actual_count = value; }
        public string Description { get => description; set => description = value; }
    }
}
