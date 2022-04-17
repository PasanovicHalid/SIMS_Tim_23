// File:    SecretaryRepository.cs
// Author:  halid
// Created: Saturday, 16 April 2022 01:44:41
// Purpose: Definition of Class SecretaryRepository

using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class SecretaryRepository
   {
      private String dbPath;
      
      private SecretaryRepository instance;
      
      public Boolean CreateSecretary(Secretary newSecretary)
      {
         throw new NotImplementedException();
      }
      
      public Boolean UpdateSecretary(Secretary secretary)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteSecretary(int id)
      {
         throw new NotImplementedException();
      }
      
      public Secretary ReadSecretary(int id)
      {
         throw new NotImplementedException();
      }
      
      public List<Secretary> GetAllSecretaries()
      {
         throw new NotImplementedException();
      }
   
   }
}