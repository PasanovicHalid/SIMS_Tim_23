/***********************************************************************
 * Module:  Appointment.cs
 * Author:  PCX
 * Purpose: Definition of the Class Model.Appointment
 ***********************************************************************/

using System;

namespace Model
{
   public class Appointment : Repository.Serializable
   {
      protected DateTime startDate;
      protected DateTime endDate;
      protected String appointmentId;
      protected int trebaIDoktor;
      protected int type;

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();
        }

        public string[] ToCSV()
        {
            throw new NotImplementedException();
        }
    }
}