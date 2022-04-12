// File:    EquipmentController.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:34:26
// Purpose: Definition of Class EquipmentController

using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class EquipmentController
   {
      public Boolean CreateEquipment(Model.Equipment newEquipment)
      {
         throw new NotImplementedException();
      }
      
      public Boolean UpdateEquipment(Model.Equipment equipment)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteEquipment(String identificator)
      {
         throw new NotImplementedException();
      }
      
      public Model.Equipment ReadEquipment(String identificator)
      {
         throw new NotImplementedException();
      }
      
      public List<Equipment> GetAllEquipment()
      {
         throw new NotImplementedException();
      }
      
      public Service.EquipmentService equipmentService;
   
   }
}