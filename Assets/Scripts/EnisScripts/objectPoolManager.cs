using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class objectPoolManager : MonoBehaviour
{
    public static List<pooledObjectInfo> objectPools = new List<pooledObjectInfo>();

    public static GameObject spawnGameObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        pooledObjectInfo pool = objectPools.Find(p => p.lookupString == objectToSpawn.name);

      /*  pooledObjectInfo pool = null;
        foreach (pooledObjectInfo p in objectPools)
        {
            if (p.lookupString == objectToSpawn.name)
            {
                pool = p;
                break;
            }
        }
      if the pool doesent exist , create it
        */
      if (pool == null)
      {
          pool = new pooledObjectInfo() { lookupString = objectToSpawn.name };
          objectPools.Add(pool);
      }
      // check if there are any inactive obejcts in the pool
     GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();
     /*  GameObject spawnableObj = null;
      foreach (GameObject obj in pool.InactiveObjects)
      {
          if (obj != null)
          {
              spawnableObj = obj;
              break;
          }
      }
      */
     if (spawnableObj == null)
     {
         spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
     }
     else
     {
         spawnableObj.transform.position = spawnPosition;
         spawnableObj.transform.rotation = spawnRotation;
         pool.InactiveObjects.Remove(spawnableObj);
         spawnableObj.SetActive(true);
     }

     return spawnableObj;
    }

    public static void ReturnObectsToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7); 
        pooledObjectInfo pool = objectPools.Find(p => p.lookupString == goName);
        if (pool == null)
        {
            Debug.LogWarning("trying to relase an object that is not pooled : " + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }
}
    public class pooledObjectInfo
    {
        public string lookupString;
        public List<GameObject> InactiveObjects = new List<GameObject>();
    }
