using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.View.ViewModel
{
    public class RenovationActionVO
    {
        private int id;
        private DateTime executionDate;
        private DateTime expirationDate;
        private String designationCode;
        private int id_room;
        private bool renovation;

        public RenovationActionVO()
        {
        }

        public RenovationActionVO(int id, DateTime executionDate, DateTime expirationDate, String designationCode,int id_room, bool renovation)
        {
            this.Id = id;
            this.ExecutionDate = executionDate;
            this.ExpirationDate = expirationDate;
            this.designationCode = designationCode;
            this.Id_room = id_room;
            this.Renovation = renovation;
        }

        public int Id { get => id; set => id = value; }
        public DateTime ExecutionDate { get => executionDate; set => executionDate = value; }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }
        public int Id_room { get => id_room; set => id_room = value; }
        public bool Renovation { get => renovation; set => renovation = value; }
        public string DesignationCode { get => designationCode; set => designationCode = value; }
    }
}
