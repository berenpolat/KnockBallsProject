using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
   private objectPooler _objectPooler;
  
   private void Start()
   {
      _objectPooler = objectPooler.Instance;
      
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
         mousePosition.z = 0f;

         _objectPooler.spawnFromPool("cube", mousePosition, Quaternion.identity);
      }
   }
}
