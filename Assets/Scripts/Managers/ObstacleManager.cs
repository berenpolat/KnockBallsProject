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

      public List<List<GameObject>> Lvl1Objects;
      public List<List<GameObject>> Lvl2Objects;
      public List<List<GameObject>> Lvl3Objects;


      [Header(" Lvl1 Platforms")] 
      public GameObject Platform11;
      public GameObject Platform12;
      public GameObject Platform13;
      public GameObject Platform14;
      public GameObject Platform15;
      public GameObject Platform16;
      public GameObject Platform17;
      [Header(" Lvl2 Platforms")]
      public GameObject Platform21;
      public GameObject Platform22;
      public GameObject Platform23;
      public GameObject Platform24;
      public GameObject Platform25;
      public GameObject Platform26;
      public GameObject Platform27;
      [Header(" Lvl,3 Platforms")]
      public GameObject Platform31;
      public GameObject Platform32;
      public GameObject Platform33;
      public GameObject Platform34;
      public GameObject Platform35;
      public GameObject Platform36;
      public GameObject Platform37;


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

         Lvl1Objects = new List<List<GameObject>>();
         Lvl2Objects = new List<List<GameObject>>();
         Lvl3Objects = new List<List<GameObject>>();
      }


      #endregion
      
      
      private void Start()
      {
         Lvl1Objects.Add(lvl1Obs1);
         Lvl1Objects.Add(lvl1Obs2);
         Lvl1Objects.Add(lvl1Obs3);
         Lvl1Objects.Add(lvl1Obs4);
         Lvl1Objects.Add(lvl1Obs5);
         Lvl1Objects.Add(lvl1Obs6);
         Lvl1Objects.Add(lvl1Obs7);
         
         Lvl2Objects.Add(lvl2Obs1);
         Lvl2Objects.Add(lvl2Obs2);
         Lvl2Objects.Add(lvl2Obs3);
         Lvl2Objects.Add(lvl2Obs4);
         Lvl2Objects.Add(lvl2Obs5);
         Lvl2Objects.Add(lvl2Obs6);
         Lvl2Objects.Add(lvl2Obs7);
         
         Lvl3Objects.Add(lvl3Obs1);
         Lvl3Objects.Add(lvl3Obs2);
         Lvl3Objects.Add(lvl3Obs3);
         Lvl3Objects.Add(lvl3Obs4);
         Lvl3Objects.Add(lvl3Obs5);
         Lvl3Objects.Add(lvl3Obs6);
         Lvl3Objects.Add(lvl3Obs7);
      }
   }
}
