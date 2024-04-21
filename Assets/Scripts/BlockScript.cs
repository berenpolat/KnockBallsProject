using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BlockScript : MonoBehaviour
{
   private void OnCollisionEnter(Collision other)
   {
      //Lvl 1
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("11"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter11++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("12"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter12++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("13"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter13++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("14"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter14++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("15"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter15++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("16"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter16++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("17"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter17++;
         Destroy(this.gameObject);
      }
      
      //Lvl2
      
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("21"))
      {
         Debug.Log("A");
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter21++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("22"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter22++;
         Destroy(this.gameObject);
         
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("23"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter23++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("24"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter24++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("25"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter25++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("26"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter26++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("27"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter27++;
         Destroy(this.gameObject);
      }
      
      
      //Lvl3
      
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("31"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter31++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("32"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter32++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("33"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter33++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("34"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter34++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("35"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter35++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("36"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter36++;
         Destroy(this.gameObject);
      }
      if (other.gameObject.CompareTag($"BottomCollider") && this.gameObject.CompareTag("37"))
      {
         GameManager.Instance.inGameScore++;
         LevelManager.Instance.counter37++;
         Destroy(this.gameObject);
      }
   }

}
