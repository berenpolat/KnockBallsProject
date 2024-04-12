using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
   public class ObstacleManager : MonoBehaviour
   {
      #region Obstacle Prefs

      public GameObject normalObs;
      public GameObject cubeObs;
      public GameObject sphereObs;

      public List<GameObject> lvl1Obs;
      #endregion

      private void Start()
      {
         lvl1Obs.Add(normalObs);
         lvl1Obs.Add(cubeObs);
         lvl1Obs.Add(sphereObs);
      }

      #region Singleton
      public static ObstacleManager Instance { get; set; }
    
      private void Awake()
      {
         if (Instance != null && Instance != this)
         {
            Destroy(gameObject);
         }
         else
         {
            Instance = this;
            DontDestroyOnLoad(gameObject);
         }
      }
    

      #endregion
   }
}
