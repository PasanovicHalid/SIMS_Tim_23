// File:    EquipmentService.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:33:08
// Purpose: Definition of Class EquipmentService

using Model;
using System;
using System.Collections.Generic;

namespace Service
{
   public class EquipmentService
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
      
      public Repository.EquipmentRepository equipmentRepository;
   
   }
}