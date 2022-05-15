// File:    SecretaryService.cs
// Author:  halid
// Created: Saturday, 16 April 2022 01:46:35
// Purpose: Definition of Class SecretaryService

using Model;
using System;
using System.Collections.Generic;
using Repository;

namespace Service
{
   public class SecretaryService
   {
      private static SecretaryService instance = null;
      
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
            return SecretaryRepository.Instance.GetAllSecretaries();
      }
        public SecretaryService()
        {

        }

        public static SecretaryService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SecretaryService();
                }
                return instance;
            }
        }
    }
}