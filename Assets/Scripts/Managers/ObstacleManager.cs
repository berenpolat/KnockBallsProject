using UnityEngine;

namespace Managers
{
   public class ObstacleManager : MonoBehaviour
   {
      #region Obstacle Prefs

      public GameObject normalObs;
      public GameObject cubeObs;
      public GameObject sphereObs;


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
