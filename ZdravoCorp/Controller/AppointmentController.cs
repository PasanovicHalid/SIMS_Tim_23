// File:    AppointmentController.cs
// Author:  Dusko
// Created: Sunday, 10 April 2022 22:33:59
// Purpose: Definition of Class AppointmentController

using System;
using Model;
using Service;
using System.Collections.Generic;


namespace Controller
{
   public class AppointmentController
   {
        public AppointmenServicet appointmentServicet;

        public AppointmentController()
        {
            appointmentServicet = new AppointmenServicet(); 
        }

      public Boolean CreateAppointment(Appointment newAppointment)
      {
            return appointmentServicet.CreateAppointment(newAppointment);  
      }
      
      public Appointment ReadAppointment(String appointmentID)
      {
         return appointmentServicet.ReadAppointment(appointmentID);
      }
      
      public Boolean UpdateAppointment(Appointment appointment)
      {
         return appointmentServicet.UpdateAppointment(appointment); 
      }
      
      public Boolean DeleteAppointment(String appointmentID)
      {
            return appointmentServicet.DeleteAppointment(appointmentID);
      }
      
      public List<Appointment> GetAllAppointments()
      {
         return appointmentServicet.GetAllAppointments();   
      }

   
   }
}