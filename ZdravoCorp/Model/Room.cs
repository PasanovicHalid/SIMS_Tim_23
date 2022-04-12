/***********************************************************************
 * Module:  Rooms.cs
 * Author:  halid
 * Purpose: Definition of the Class Model.Rooms
 ***********************************************************************/

using System;
using System.ComponentModel;
using System.Linq;

namespace Model
{
   public class Room : Repository.Serializable, INotifyPropertyChanged
    {
        private String identifier;
        private float size;
      
        private RoomType type;

        public System.Collections.ArrayList equipmentList;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public String Identificator
        {
            get { return identifier; }
            set
            {
                if (identifier != value)
                {
                    identifier = value;
                    OnPropertyChanged("Identificator");
                }
            }
        }

        public float Size
        {
            get { return size; }
            set
            {
                if (size != value)
                {
                    size = value;
                    OnPropertyChanged("Size");
                }
            }
        }

        public String Type
        {
            get
            {
                return type.name;
            }
            set
            {
                if (type.name != value)
                {
                    type.name = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        /// <summary>
        /// Property for RoomType
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public RoomType TypeClass
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public String Equpments
        {
            get 
            {
                String returnVal = "";
                foreach (Equipment item in equipmentList)
                {
                    returnVal += item.Identifier;
                    returnVal += ", ";
                }
                returnVal = returnVal.Remove(returnVal.Length - 1);
                return returnVal;
            }
        }

        public Room()
        {
            identifier = "";
            type = new RoomType();
            equipmentList = new System.Collections.ArrayList();
        }

        public Room(string identifier, float size, RoomType type, System.Collections.ArrayList equipmentList)
        {
            this.type = type;
            this.identifier = identifier;
            this.size = size;
            this.equipmentList = equipmentList;
        }

        

        /// <summary>
        /// Property for collection of Equipment
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.ArrayList EquipmentList
        {
            get
            {
                if (equipmentList == null)
                    equipmentList = new System.Collections.ArrayList();
                return equipmentList;
            }
            set
            {
                RemoveAllEquipmentList();
                if (value != null)
                {
                    foreach (Equipment oEquipment in value)
                        AddEquipmentList(oEquipment);
                }
            }
        }

        /// <summary>
        /// Add a new Equipment in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddEquipmentList(Equipment newEquipment)
        {
            if (newEquipment == null)
                return;
            if (this.equipmentList == null)
                this.equipmentList = new System.Collections.ArrayList();
            if (!this.equipmentList.Contains(newEquipment))
                this.equipmentList.Add(newEquipment);
        }

        /// <summary>
        /// Remove an existing Equipment from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveEquipmentList(Equipment oldEquipment)
        {
            if (oldEquipment == null)
                return;
            if (this.equipmentList != null)
                if (this.equipmentList.Contains(oldEquipment))
                    this.equipmentList.Remove(oldEquipment);
        }

        /// <summary>
        /// Remove all instances of Equipment from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllEquipmentList()
        {
            if (equipmentList != null)
                equipmentList.Clear();
        }

        public string[] ToCSV()
        {
            string[] csvValue =
            {
                identifier,
                size.ToString(),
                EquipmentList.Count.ToString()
            };
            csvValue = csvValue.Concat(type.ToCSV()).ToArray();
            foreach (Equipment equipment in equipmentList)
            {
                csvValue = csvValue.Concat(equipment.ToCSV()).ToArray();
            }
            return csvValue;
        }

        public void FromCSV(string[] values)
        {
            identifier = values[0];
            size = float.Parse(values[1]);
            int count = int.Parse(values[2]);
            type = new RoomType(values[3]);

            equipmentList = new System.Collections.ArrayList();

            for (int i = 0; i < count; i++)
            {
                equipmentList.Add(new Equipment(values[4 * (i + 1)], new EquipmentDescriptor(values[4 * (i + 1) + 1], values[4 * (i + 1) + 2]), values[4 * (i + 1) + 3]));
            }
        }
    }
}