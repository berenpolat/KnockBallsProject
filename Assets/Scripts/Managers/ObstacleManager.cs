using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
   public class ObstacleManager : MonoBehaviour
   {
      #region Obstacle Prefs
      [Header("Level1 Obs")]
      public List<GameObject> lvl1Obs1;
      public List<GameObject> lvl1Obs2;
      public List<GameObject> lvl1Obs3;
      public List<GameObject> lvl1Obs4;
      public List<GameObject> lvl1Obs5;
      public List<GameObject> lvl1Obs6;
      public List<GameObject> lvl1Obs7;
      [Header("Level2 Obs")]
      public List<GameObject> lvl2Obs1;
      public List<GameObject> lvl2Obs2;
      public List<GameObject> lvl2Obs3;
      public List<GameObject> lvl2Obs4;
      public List<GameObject> lvl2Obs5;
      public List<GameObject> lvl2Obs6;
      public List<GameObject> lvl2Obs7;
      [Header("Level3 Obs")]
      public List<GameObject> lvl3Obs1;
      public List<GameObject> lvl3Obs2;
      public List<GameObject> lvl3Obs3;
      public List<GameObject> lvl3Obs4;
      public List<GameObject> lvl3Obs5;
      public List<GameObject> lvl3Obs6;
      public List<GameObject> lvl3Obs7;
      #endregion
      

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
