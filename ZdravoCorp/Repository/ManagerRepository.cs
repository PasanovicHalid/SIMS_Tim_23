// File:    ManagerRepository.cs
// Author:  halid
// Created: Saturday, 16 April 2022 01:42:18
// Purpose: Definition of Class ManagerRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class ManagerRepository
   {
      private String dbPath;
      
      private ManagerRepository instance;
      
      public Boolean CreateManager(Manager newManager)
      {
         throw new NotImplementedException();
      }
      
      public Boolean UpdateManager(Manager manager)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteManager(int id)
      {
         throw new NotImplementedException();
      }
      
      public Patient ReadManager(int id)
      {
         throw new NotImplementedException();
      }
      
      public List<Manager> GetAllManagers()
      {
         throw new NotImplementedException();
      }
   
   }
}