// File:    Serializable.cs
// Author:  halid
// Created: Sunday, 10 April 2022 14:42:13
// Purpose: Definition of Interface Serializable

using System;

namespace Repository
{
   public interface Serializable
   {
      void ToCSV();
      
      void FromCSV(string[] values);
   
   }
}