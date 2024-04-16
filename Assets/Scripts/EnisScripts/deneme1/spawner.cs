using UnityEngine;

namespace EnisScripts.deneme1
{
   public class Spawner : MonoBehaviour
   {
      private ObjectPooler _objectPooler;
  
      private void Start()
      {
         _objectPooler = ObjectPooler.Instance;
      
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
}
