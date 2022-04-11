// File:    Serializer.cs
// Author:  halid
// Created: Sunday, 10 April 2022 14:42:13
// Purpose: Definition of Class Serializer

using System;
using System.Collections.Generic;

namespace Repository
{
   public class Serializer<T> where T:Serializable, new()
   {
      private char dELIMITER = '|';
      
      public void ToCSV(string fileName, List<T> objects)
      {
         throw new NotImplementedException();
      }
      
      public List<T> FromCSV(string filename)
      {
         throw new NotImplementedException();
      }
   
   }
}