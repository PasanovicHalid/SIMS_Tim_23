// File:    EquipmentRepository.cs
// Author:  halid
// Created: Tuesday, 12 April 2022 12:26:08
// Purpose: Definition of Class EquipmentRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class EquipmentRepository
   {
      private String dbPath;
      
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
   
   }
}