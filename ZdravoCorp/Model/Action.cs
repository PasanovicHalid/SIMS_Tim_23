// File:    Action.cs
// Author:  halid
// Created: Sunday, 24 April 2022 22:06:32
// Purpose: Definition of Class Action

using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Action: Serializable
    {
        private int id;
        private ActionType type;
        private DateTime executionDate;
        private Object obj;

        public Action()
        {
        }

        public Action(int id, ActionType type, object obj, DateTime executionDate)
        {
            this.Id = id;
            this.type = type;
            this.obj = obj;
            this.executionDate = executionDate;
        }

        public ActionType Type { get => type; }
        public DateTime ExecutionDate { get => executionDate; }
        public object Object { get => obj; }
        public int Id { get => id; set => id = value; }

        public void FromCSV(string[] values)
        {
            this.id = int.Parse(values[0]);
            this.type = (ActionType) Enum.Parse(typeof(ActionType), values[1]);
            this.executionDate = DateTime.Parse(values[2]);
            switch (type)
            {
                case ActionType.changePosition:
                    ChangeRoomAction change = new ChangeRoomAction();
                    values = values.Skip(3).ToArray();
                    change.FromCSV(values);
                    this.obj = change;
                    break;
                case ActionType.renovation:
                    RenovationAction reno = new RenovationAction();
                    values = values.Skip(3).ToArray();
                    reno.FromCSV(values);
                    this.obj = reno;
                    break;
            }
        }

        public List<string> ToCSV()
        {
            List<String> result = new List<String>();

            result.Add(id.ToString());
            result.Add(type.ToString());
            result.Add(executionDate.ToString());

            switch (type)
            {
                case ActionType.changePosition:
                    ChangeRoomAction change = (ChangeRoomAction)obj;
                    result = (List<string>) result.Concat(change.ToCSV());
                    break;
                case ActionType.renovation:
                    RenovationAction reno = (RenovationAction)obj;
                    result = (List<string>) result.Concat(reno.ToCSV());
                    break;
            }

            return result;
        }
    }
}