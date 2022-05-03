using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.View.ViewModel
{
    public class ChangeActionVO
    {
        private int id;
        private DateTime executionDate;
        private int id_incoming_room;
        private int id_outgoing_room;
        private int id_equipment;
        private int count;
        private String incomingRoom;
        private String outgoingRoom;
        private String equipment;

        public ChangeActionVO()
        {

        }

        public ChangeActionVO(int id, DateTime executionDate, int id_incoming_room, int id_outgoing_room, int id_equipment, int count, string incomingRoom, string outgoingRoom, string equipment)
        {
            this.Id = id;
            this.Id_incoming_room = id_incoming_room;
            this.Id_outgoing_room = id_outgoing_room;
            this.Id_equipment = id_equipment;
            this.Count = count;
            this.ExecutionDate = executionDate;
            this.IncomingRoom = incomingRoom;
            this.OutgoingRoom = outgoingRoom;
            this.Equipment = equipment;
        }

        public int Id { get => id; set => id = value; }
        public int Id_incoming_room { get => id_incoming_room; set => id_incoming_room = value; }
        public int Id_outgoing_room { get => id_outgoing_room; set => id_outgoing_room = value; }
        public int Id_equipment { get => id_equipment; set => id_equipment = value; }
        public int Count { get => count; set => count = value; }
        public DateTime ExecutionDate { get => executionDate; set => executionDate = value; }
        public string IncomingRoom { get => incomingRoom; set => incomingRoom = value; }
        public string OutgoingRoom { get => outgoingRoom; set => outgoingRoom = value; }
        public string Equipment { get => equipment; set => equipment = value; }
    }
}
