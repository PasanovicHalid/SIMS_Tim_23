/***********************************************************************
 * Module:  Appointment.cs
 * Author:  PCX
 * Purpose: Definition of the Class Model.Appointment
 ***********************************************************************/

using System;
using System.ComponentModel;
using System.Linq;
using System.Globalization;

namespace Model
{
    public class Appointment : Repository.Serializable
    {
        protected DateTime startDate;
        protected DateTime endDate;
        protected String appointmentId;
        protected String doctorID;
        protected String patientID;
        protected String roomID;

        public System.Collections.Generic.List<Equipment> equipment;

        public Appointment(String start, String end, String id, String docid, String patientid, String roomID)
        {
            this.startDate = DateTime.ParseExact(start, "dd.MM.yyyy. HH:mm:ss", CultureInfo.InvariantCulture);
            this.endDate = DateTime.ParseExact(end, "dd.MM.yyyy. HH:mm:ss", CultureInfo.InvariantCulture);
            this.appointmentId = id;
            this.patientID = patientid;
            this.doctorID = docid;
            this.roomID = roomID;
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void PropertyChanged(Appointment appointment, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            throw new NotImplementedException();
        }

        public String StartDate
        {
            get { return startDate.ToString(); }
            set
            {
                if (startDate.ToString() != value)
                {
                    startDate = Convert.ToDateTime(value);
                    OnPropertyChanged("StartDate");
                }
            }
        }

        public String EndDate
        {
            get { return endDate.ToString(); }
            set
            {
                if (endDate.ToString() != value)
                {
                    endDate = Convert.ToDateTime(value);
                    OnPropertyChanged("EndDate");
                }
            }
        }


        public String AppointmentID
        {
            get { return appointmentId; }
            set
            {
                if (appointmentId != value)
                {
                    appointmentId = value;
                    OnPropertyChanged("AppointmentID");
                }
            }
        }

        public String DoctorID
        {
            get { return doctorID; }
            set
            {
                if (doctorID != value)
                {
                    doctorID = value;
                    OnPropertyChanged("DoctorID");
                }
            }
        }

        public String RoomID
        {
            get { return roomID; }
            set
            {
                if (roomID != value)
                {
                    roomID = value;
                    OnPropertyChanged("RoomID");
                }
            }
        }

        public String PatientID
        {
            get { return patientID; }
            set
            {
                if (patientID != value)
                {
                    patientID = value;
                    OnPropertyChanged("patientID");
                }
            }
        }


        public Appointment()
        {

        }



        /// <summary>
        /// Property for collection of Equipment
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Equipment> Equipment
        {
            get
            {
                if (equipment == null)
                    equipment = new System.Collections.Generic.List<Equipment>();
                return equipment;
            }
            set
            {
                RemoveAllEquipment();
                if (value != null)
                {
                    foreach (Equipment oEquipment in value)
                        AddEquipment(oEquipment);
                }
            }
        }

        /// <summary>
        /// Add a new Equipment in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddEquipment(Equipment newEquipment)
        {
            if (newEquipment == null)
                return;
            if (this.equipment == null)
                this.equipment = new System.Collections.Generic.List<Equipment>();
            if (!this.equipment.Contains(newEquipment))
                this.equipment.Add(newEquipment);
        }

        /// <summary>
        /// Remove an existing Equipment from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveEquipment(Equipment oldEquipment)
        {
            if (oldEquipment == null)
                return;
            if (this.equipment != null)
                if (this.equipment.Contains(oldEquipment))
                    this.equipment.Remove(oldEquipment);
        }

        /// <summary>
        /// Remove all instances of Equipment from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllEquipment()
        {
            if (equipment != null)
                equipment.Clear();
        }

        public String getAppointmentID()
        {
            return appointmentId;
        }

        public void FromCSV(string[] values)
        {
            startDate = Convert.ToDateTime(values[0]);
            endDate = Convert.ToDateTime(values[1]);
            appointmentId = values[2];
            doctorID = values[3];
            patientID = values[4];
            roomID = values[5];
            //int count = int.Parse(values[5]);

            //equipment = new System.Collections.Generic.List<Equipment>();   

            /*for (int i = 0; i < count; i++)
            {
                equipment.Add(new Equipment(values[4 * (i + 1)], new EquipmentDescriptor(values[4 * (i + 1) + 1], values[4 * (i + 1) + 2]), values[4 * (i + 1) + 3]));
            }*/
        }

        public string[] ToCSV()
        {
            string[] csvValue =
            {
                startDate.ToString(),
                endDate.ToString(),
                appointmentId,
                doctorID,
                patientID,
                roomID
                //equipment.Count.ToString()
            };
            /*foreach (Equipment eq in equipment)
            {
                csvValue = csvValue.Concat(eq.ToCSV()).ToArray();
            }*/
            return csvValue;
        }
    }
}