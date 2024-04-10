using Entities;
using UnityEngine;

namespace Interfaces
{
   public interface IFactory 
   {
      T CreateObject<T>() where T : MyObject;
      T CreateObject<T>(int varianId) where T : MyObject;
      T CreateObject<T>(Transform parent) where T : MyObject;
      T CreateObject<T>(int varianId, Transform parent) where T : MyObject;
   }
}
