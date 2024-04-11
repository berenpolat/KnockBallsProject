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

   private void FixedUpdate()
   {
      _objectPooler.spawnFromPool("cube", transform.position, Quaternion.identity);
   }
}
