// File:    ChangeRoomAction.cs
// Author:  halid
// Created: Sunday, 24 April 2022 22:23:04
// Purpose: Definition of Class ChangeRoomAction

using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class ChangeRoomAction : Serializable
    {
        private int id_incoming_room;
        private int id_outgoing_room;
        private int id_equipment;
        private int count;

        public int Id_equipment { get => id_equipment; }
        public int Count { get => count; }
        public int Id_incoming_room { get => id_incoming_room; }
        public int Id_outgoing_room { get => id_outgoing_room; }

        public void FromCSV(string[] values)
        {
            this.id_incoming_room = int.Parse(values[0]);
            this.id_outgoing_room = int.Parse(values[1]);
            this.id_equipment = int.Parse(values[2]);
            this.count = int.Parse(values[3]);
        }

        public List<string> ToCSV()
        {
            List<String> result = new List<String>();
            result.Add(id_incoming_room.ToString());
            result.Add(id_outgoing_room.ToString());
            result.Add(id_equipment.ToString());
            result.Add(count.ToString());

            return result;
        }
    }
}