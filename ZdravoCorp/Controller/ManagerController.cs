// File:    ManagerController.cs
// Author:  halid
// Created: Saturday, 16 April 2022 01:47:12
// Purpose: Definition of Class ManagerController

using Model;
using System;
using System.Collections.Generic;
using Repository;

namespace Controller
{
   public class ManagerController : ICrud<Manager>
   {
      public void Create(Manager newManager)
      {
         throw new NotImplementedException();
      }
      
      public void Update(Manager manager)
      {
         throw new NotImplementedException();
      }
      
      public void Delete(int id)
      {
         throw new NotImplementedException();
      }
      
      public Manager Read(int id)
      {
         throw new NotImplementedException();
      }

      public List<Manager> GetAll ()
      {
         throw new NotImplementedException();
      }
   
   }
}