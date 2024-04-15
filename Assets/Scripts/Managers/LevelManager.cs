using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Button lvl1Button;
        [SerializeField] private Button lvl2Button;
        [SerializeField] private Button lvl3Button;

        public bool isGame0,isLevel1Complete, isLevel2Complete, isLevel3Complete;
        public int shot11,shot12,shot13,shot14,shot15,shot16,shot17;
        public bool isObs1Complete, isObs2Complete, isObs3Complete, isObs4Complete, isObs5Complete, isObs6Complete, isObs7Complete;
        
        
        [SerializeField] private Text inGameLvlText;
        [SerializeField] private Text inGameNextLvlText;
        
        
        private ColorBlock cb;

        private void Start()
        {
            cb = lvl1Button.colors;
            cb.disabledColor = Color.cyan;
            if (GameManager.Instance.level == 0)
            {
                isGame0 = true;
                isObs1Complete = true;
                for (int i = 0; i < ObstacleManager.Instance.lvl1Obs1.Count; i++)
                {
                    ObstacleManager.Instance.lvl1Obs1[i].SetActive(true);
                }
            }

            if (GameManager.Instance.level == 1)
            {
                isLevel1Complete = true;
                isObs1Complete = true;
                for (int i = 0; i < ObstacleManager.Instance.lvl1Obs1.Count; i++)
                {
                    ObstacleManager.Instance.lvl1Obs1[i].SetActive(false);
                }
                for (int i = 0; i < ObstacleManager.Instance.lvl2Obs1.Count; i++)
                {
                    ObstacleManager.Instance.lvl2Obs1[i].SetActive(true);
                }
            }
            if (GameManager.Instance.level == 2)
            {
                isLevel2Complete = true;
                isObs1Complete = true;
                for (int i = 0; i < ObstacleManager.Instance.lvl2Obs1.Count; i++)
                {
                    ObstacleManager.Instance.lvl2Obs1[i].SetActive(false);
                }
                for (int i = 0; i < ObstacleManager.Instance.lvl3Obs1.Count; i++)
                {
                    ObstacleManager.Instance.lvl3Obs1[i].SetActive(true);
                }
            }
            
        }

        private void Update()
        {
            UpdateLevelUI();
            if (GameManager.Instance.level == 0)
            {
                if (isGame0 && GameManager.Instance.isGameStarted)
                {
                    Debug.Log("Level 1");
                
                    //1ST OBS
                    shot11 = 4;
                    int counter11 = 0;
                    if (isObs1Complete && shot11!=0)
                    {
                        for (int j = 0; j < ObstacleManager.Instance.lvl1Obs1.Count; j++)
                        {
                            if (ObstacleManager.Instance.lvl1Obs1[j].transform.localPosition.y <= -9f)
                            {
                                counter11++;
                            }
                        }
                        if (counter11 == ObstacleManager.Instance.lvl1Obs1.Count)
                        {
                            Debug.Log("All of them has felt at Obs1");
                            isObs1Complete = false;
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs2.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs2[i].SetActive(true);
                            }
                            isObs2Complete = true;
                            GameManager.Instance.levelSliderBlocks[0].color= Color.red;
                        }
                    
                    }
                    if(shot11==0 && counter11!=6)
                    {
                        Debug.Log("Not all of them has dropped");
                        GameManager.Instance.failPanel.SetActive(true);
                    }

                    //2ND OBS
                    shot12 = 4;
                    int counter12 = 0;
                    if (isObs2Complete && shot12 != 0)
                    {
                        for (int j = 0; j < ObstacleManager.Instance.lvl1Obs2.Count; j++)
                        {
                            if (ObstacleManager.Instance.lvl1Obs2[j].transform.localPosition.y <= -9f)
                            {
                                counter12++;
                            }
                        }
                        
                        if (counter12 == ObstacleManager.Instance.lvl1Obs2.Count)
                        {
                            Debug.Log("All of them has felt at Obs1");
                            isObs2Complete = false;
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs3.Count; i++)
                            {
                                ObstacleManager.Instance.lvl1Obs3[i].SetActive(true);
                            }
                            isObs3Complete = true;
                            GameManager.Instance.levelSliderBlocks[1].color= Color.red;
                        }
                    
                    }
                    if(shot12==0 && counter12!=6)
                    {
                        Debug.Log("Not all of them has dropped");
                        GameManager.Instance.failPanel.SetActive(true);
                    }
                
                    //3RD OBS
                    shot13 = 4;
                    int counter13 = 0;
                    if (isObs3Complete && shot13 != 0)
                    {
                        for (int j = 0; j < ObstacleManager.Instance.lvl1Obs3.Count; j++)
                        {
                            if (ObstacleManager.Instance.lvl1Obs3[j].transform.localPosition.y <= -9f)
                            {
                                counter13++;
                            }
                        }
                        
                        if (counter13 == ObstacleManager.Instance.lvl1Obs3.Count)
                        {
                            Debug.Log("All of them has felt at Obs1");
                            isObs3Complete = false;
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs4.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs4[i].SetActive(true);
                            }
                            isObs4Complete = true;  
                            GameManager.Instance.levelSliderBlocks[2].color= Color.red;
                        }
                    
                    }
                    if(shot13==0 && counter13!=6)
                    {
                        Debug.Log("Not all of them has dropped");
                        GameManager.Instance.failPanel.SetActive(true);
                    }
                
                    //4th OBS
                    shot14 = 4;
                    int counter14 = 0;
                    if (isObs4Complete && shot14 != 0)
                    {
                        for (int j = 0; j < ObstacleManager.Instance.lvl1Obs4.Count; j++)
                        {
                            if (ObstacleManager.Instance.lvl1Obs4[j].transform.localPosition.y <= -9f)
                            {
                                counter14++;
                            }
                        }
                        
                        if (counter14 == ObstacleManager.Instance.lvl1Obs4.Count)
                        {
                            Debug.Log("All of them has felt at Obs1");
                            isObs4Complete = false;
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs5.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs5[i].SetActive(true);
                            }
                            isObs5Complete = true;  
                            GameManager.Instance.levelSliderBlocks[3].color= Color.red;
                        }
                    
                    }
                    if(shot14==0 && counter14!=6)
                    {
                        Debug.Log("Not all of them has dropped");
                        GameManager.Instance.failPanel.SetActive(true);
                    }
               
                
                    //5th OBS
                    shot15 = 4;
                    int counter15 = 0;
                    if (isObs5Complete && shot15 != 0)
                    {
                        for (int j = 0; j < ObstacleManager.Instance.lvl1Obs5.Count; j++)
                        {
                            if (ObstacleManager.Instance.lvl1Obs5[j].transform.localPosition.y <= 0f)
                            {
                                counter15++;
                            }
                        }
                        
                        if (counter15 == ObstacleManager.Instance.lvl1Obs5.Count)
                        {
                            Debug.Log("All of them has felt at Obs1");
                            isObs5Complete = false;
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs6.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs6[i].SetActive(true);
                            }
                            isObs6Complete = true;  
                            GameManager.Instance.levelSliderBlocks[4].color= Color.red;
                        }
                    
                    }
                    if(shot15==0 && counter15!=6)
                    {
                        Debug.Log("Not all of them has dropped");
                        GameManager.Instance.failPanel.SetActive(true);
                    }
                
                    //6th OBS
                    shot16 = 4;
                    int counter16 = 0;
                    if (isObs6Complete && shot16 != 0)
                    {
                        for (int j = 0; j < ObstacleManager.Instance.lvl1Obs6.Count; j++)
                        {
                            if (ObstacleManager.Instance.lvl1Obs6[j].transform.localPosition.y <= -9f)
                            {
                                counter16++;
                            }
                        }
                        
                        if (counter16 == ObstacleManager.Instance.lvl1Obs6.Count)
                        {
                            Debug.Log("All of them has felt at Obs1");
                            isObs6Complete = false;
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs7.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs7[i].SetActive(true);
                            }
                            isObs7Complete = true;  
                            GameManager.Instance.levelSliderBlocks[5].color= Color.red;
                        }
                    
                    }
                    if(shot16==0 && counter16!=6)
                    {
                        Debug.Log("Not all of them has dropped");
                        GameManager.Instance.failPanel.SetActive(true);
                    }
                    //7th OBS
                    shot17 = 4;
                    int counter17 = 0;
                    if (isObs7Complete && shot17 != 0)
                    {
                        for (int j = 0; j < ObstacleManager.Instance.lvl1Obs7.Count; j++)
                        {
                            if (ObstacleManager.Instance.lvl1Obs7[j].transform.localPosition.y <= -9f)
                            {
                                counter17++;
                            }
                        }
                        
                        if (counter17 == ObstacleManager.Instance.lvl1Obs7.Count)
                        {
                            GameManager.Instance.levelSliderBlocks[6].color= Color.red;
                            Debug.Log("All of them has felt at Obs1");
                            isObs7Complete = false;
                            Debug.Log("LEVEL 1 HAS ENDED");
                            GameManager.Instance.level = 1;
                            PlayerPrefs.SetInt("level", 1);
                            GameManager.Instance.StopTheGame();
                            GameManager.Instance.isGameStarted = false;
                            isGame0 = false;
                            isLevel1Complete = true;
                            for (int i = 0; i < ObstacleManager.Instance.lvl2Obs1.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl2Obs1[i].SetActive(true);
                            }

                            for (int i = 0; i < GameManager.Instance.levelSliderBlocks.Count; i++)
                            {
                                GameManager.Instance.levelSliderBlocks[i].color=Color.gray;
                            }
                        }
                    
                    }
                    if(shot16==0 && counter16!=6)
                    {
                        Debug.Log("Not all of them has dropped");
                        GameManager.Instance.failPanel.SetActive(true);
                        GameManager.Instance.isGameStarted = false;
                    }
                }
            }
            
            //LVL 2
            

            if (GameManager.Instance.level == 1 && GameManager.Instance.isGameStarted)
            {
                Debug.Log("Level 2");
             if (isLevel1Complete && GameManager.Instance.isGameStarted)
             {
                
                 //1ST OBS
                 shot11 = 4;
                 int counter11 = 0;
                 if (isObs1Complete && shot11!=0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl2Obs1.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl2Obs1[j].transform.localPosition.y <= -9f)
                         {
                             counter11++;
                         }
                     }
                     if (counter11 == ObstacleManager.Instance.lvl2Obs1.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[0].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs1Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs2.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl2Obs2[i].SetActive(true);
                         }
                         isObs2Complete = true;
                     }
                    
                 }
                 if(shot11==0 && counter11!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }

                 //2ND OBS
                 shot12 = 4;
                 int counter12 = 0;
                 if (isObs2Complete && shot12 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl2Obs2.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl2Obs2[j].transform.localPosition.y <= -9f)
                         {
                             counter12++;
                         }
                     }
                        
                     if (counter12 == ObstacleManager.Instance.lvl2Obs2.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[1].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs2Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs3.Count; i++)
                         {
                             ObstacleManager.Instance.lvl2Obs3[i].SetActive(true);
                         }
                         isObs3Complete = true;
                     }
                    
                 }
                 if(shot12==0 && counter12!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                
                 //3RD OBS
                 shot13 = 4;
                 int counter13 = 0;
                 if (isObs3Complete && shot13 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl2Obs3.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl2Obs3[j].transform.localPosition.y <= -9f)
                         {
                             counter13++;
                         }
                     }
                        
                     if (counter13 == ObstacleManager.Instance.lvl2Obs3.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[2].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs3Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs4.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl2Obs4[i].SetActive(true);
                         }
                         isObs4Complete = true;  
                     }
                    
                 }
                 if(shot13==0 && counter13!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                
                 //4th OBS
                 shot14 = 4;
                 int counter14 = 0;
                 if (isObs4Complete && shot14 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl2Obs4.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl2Obs4[j].transform.localPosition.y <= -9f)
                         {
                             counter14++;
                         }
                     }
                        
                     if (counter14 == ObstacleManager.Instance.lvl2Obs4.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[3].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs4Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs5.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl2Obs5[i].SetActive(true);
                         }
                         isObs5Complete = true;  
                     }
                    
                 }
                 if(shot14==0 && counter14!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
               
                
                 //5th OBS
                 shot15 = 4;
                 int counter15 = 0;
                 if (isObs5Complete && shot15 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl2Obs5.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl2Obs5[j].transform.localPosition.y <= -9f)
                         {
                             counter15++;
                         }
                     }
                        
                     if (counter15 == ObstacleManager.Instance.lvl2Obs5.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[4].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs5Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs6.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl2Obs6[i].SetActive(true);
                         }
                         isObs6Complete = true;  
                     }
                    
                 }
                 if(shot15==0 && counter15!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                
                 //6th OBS
                 shot16 = 4;
                 int counter16 = 0;
                 if (isObs6Complete && shot16 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl2Obs6.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl2Obs6[j].transform.localPosition.y <= -9f)
                         {
                             counter16++;
                         }
                     }
                        
                     if (counter16 == ObstacleManager.Instance.lvl2Obs6.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[5].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs6Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs7.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl2Obs7[i].SetActive(true);
                         }
                         isObs7Complete = true;  
                     }
                    
                 }
                 if(shot16==0 && counter16!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                 //7th OBS
                 shot17 = 4;
                 int counter17 = 0;
                 if (isObs7Complete && shot17 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl2Obs7.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl2Obs7[j].transform.localPosition.y <= -9f)
                         {
                             counter17++;
                         }
                     }
                        
                     if (counter17 == ObstacleManager.Instance.lvl2Obs7.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[6].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs7Complete = false;
                         Debug.Log("LEVEL 2 HAS ENDED");
                         GameManager.Instance.level = 2;
                         PlayerPrefs.SetInt("level", 2);
                         GameManager.Instance.StopTheGame();
                         isLevel2Complete = true;
                         isLevel1Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs1.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs1[i].SetActive(true);
                         }
                         
                         for (int i = 0; i < GameManager.Instance.levelSliderBlocks.Count; i++)
                         {
                             GameManager.Instance.levelSliderBlocks[i].color=Color.gray;
                         }
                     }
                    
                 }
                 if(shot16==0 && counter16!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
             }
            }
            
            
            //LVL 3
            

            if (GameManager.Instance.level == 2 && GameManager.Instance.isGameStarted)
            {
                Debug.Log("Level 3");
             if (isLevel2Complete && GameManager.Instance.isGameStarted)
             {
                
                 //1ST OBS
                 shot11 = 4;
                 int counter11 = 0;
                 if (isObs1Complete && shot11!=0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl3Obs1.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl3Obs1[j].transform.localPosition.y <= -9f)
                         {
                             counter11++;
                         }
                     }
                     if (counter11 == ObstacleManager.Instance.lvl3Obs1.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[0].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs1Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs2.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs2[i].SetActive(true);
                         }
                         isObs2Complete = true;
                     }
                    
                 }
                 if(shot11==0 && counter11!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }

                 //2ND OBS
                 shot12 = 4;
                 int counter12 = 0;
                 if (isObs2Complete && shot12 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl3Obs2.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl3Obs2[j].transform.localPosition.y <= -9f)
                         {
                             counter12++;
                         }
                     }
                        
                     if (counter12 == ObstacleManager.Instance.lvl3Obs2.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[1].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs2Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs3.Count; i++)
                         {
                             ObstacleManager.Instance.lvl3Obs3[i].SetActive(true);
                         }
                         isObs3Complete = true;
                     }
                    
                 }
                 if(shot12==0 && counter12!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                
                 //3RD OBS
                 shot13 = 4;
                 int counter13 = 0;
                 if (isObs3Complete && shot13 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl3Obs3.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl3Obs3[j].transform.localPosition.y <= -9f)
                         {
                             counter13++;
                         }
                     }
                        
                     if (counter13 == ObstacleManager.Instance.lvl3Obs3.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[2].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs3Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs4.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs4[i].SetActive(true);
                         }
                         isObs4Complete = true;  
                     }
                    
                 }
                 if(shot13==0 && counter13!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                
                 //4th OBS
                 shot14 = 4;
                 int counter14 = 0;
                 if (isObs4Complete && shot14 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl3Obs4.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl3Obs4[j].transform.localPosition.y <= -9f)
                         {
                             counter14++;
                         }
                     }
                        
                     if (counter14 == ObstacleManager.Instance.lvl3Obs4.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[3].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs4Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs5.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs5[i].SetActive(true);
                         }
                         isObs5Complete = true;  
                     }
                    
                 }
                 if(shot14==0 && counter14!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
               
                
                 //5th OBS
                 shot15 = 4;
                 int counter15 = 0;
                 if (isObs5Complete && shot15 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl3Obs5.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl3Obs5[j].transform.localPosition.y <= -9f)
                         {
                             counter15++;
                         }
                     }
                        
                     if (counter15 == ObstacleManager.Instance.lvl3Obs5.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[4].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs5Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs6.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs6[i].SetActive(true);
                         }
                         isObs6Complete = true;  
                     }
                    
                 }
                 if(shot15==0 && counter15!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                
                 //6th OBS
                 shot16 = 4;
                 int counter16 = 0;
                 if (isObs6Complete && shot16 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl3Obs6.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl3Obs6[j].transform.localPosition.y <= -9f)
                         {
                             counter16++;
                         }
                     }
                        
                     if (counter16 == ObstacleManager.Instance.lvl3Obs6.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[5].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs6Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs7.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs7[i].SetActive(true);
                         }
                         isObs7Complete = true;  
                     }
                    
                 }
                 if(shot16==0 && counter16!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                 //7th OBS
                 shot17 = 4;
                 int counter17 = 0;
                 if (isObs7Complete && shot17 != 0)
                 {
                     for (int j = 0; j < ObstacleManager.Instance.lvl3Obs7.Count; j++)
                     {
                         if (ObstacleManager.Instance.lvl3Obs7[j].transform.localPosition.y <= -9f)
                         {
                             counter17++;
                         }
                     }
                        
                     if (counter17 == ObstacleManager.Instance.lvl3Obs7.Count)
                     {
                         GameManager.Instance.levelSliderBlocks[6].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs7Complete = false;
                         Debug.Log("LEVEL 3 HAS ENDED");
                         GameManager.Instance.level = 3;
                         PlayerPrefs.SetInt("level", 3);
                         GameManager.Instance.StopTheGame();
                         isLevel3Complete = true;
                         isLevel2Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs1.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs1[i].SetActive(true);
                         }
                         
                         for (int i = 0; i < GameManager.Instance.levelSliderBlocks.Count; i++)
                         {
                             GameManager.Instance.levelSliderBlocks[i].color=Color.gray;
                         }
                     }
                    
                 }
                 if(shot16==0 && counter16!=6)
                 {
                     Debug.Log("Not all of them has dropped");
                     GameManager.Instance.failPanel.SetActive(true);
                 }
             }
            }
           
        }
        
        private void UpdateLevelUI()
        {

            if (GameManager.Instance.level == 0 && GameManager.Instance.isGameStarted)
            {
                UpdateLevelButtonState(lvl1Button, true);
                UpdateLevelButtonState(lvl2Button, false);
                UpdateLevelButtonState(lvl3Button, false);

                SetLevelText(0, 1);
            }
            else if (GameManager.Instance.level == 1)
            {
                UpdateLevelButtonState(lvl1Button, false);
                UpdateLevelButtonState(lvl2Button, true);
                UpdateLevelButtonState(lvl3Button, false);

                SetLevelText(1, 2);
            }
            else if (GameManager.Instance.level == 2)
            {
                UpdateLevelButtonState(lvl1Button, false);
                UpdateLevelButtonState(lvl2Button, false);
                UpdateLevelButtonState(lvl3Button, true);

                SetLevelText(2, 3);
            }
            else if (GameManager.Instance.level == 3)
            {
                SetLevelText(3, 4);
            }
        }

        private void UpdateLevelButtonState(Button button, bool interactable)
        {
            button.interactable = interactable;
            button.colors = interactable ? cb : ColorBlock.defaultColorBlock;
        }

        private void SetLevelText(int currentLevel, int nextLevel)
        {
            inGameLvlText.text = currentLevel.ToString();
            inGameNextLvlText.text = nextLevel.ToString();
        }

        #region Level Button Controllers

        public void OnClickedLevel1Button()
        {
            Debug.Log("Level 1");
        }

        public void OnClickedLevel2Button()
        {
            Debug.Log("Level 2");
        }

        public void OnClickedLevel3Button()
        {
            Debug.Log("Level 3");
        }

        #endregion
    }
}
