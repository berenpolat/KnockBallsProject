using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        public Button lvl1Button;
        public Button lvl2Button;
        public Button lvl3Button;
       
        public bool isGame0,isLevel1Complete, isLevel2Complete,isLevel3Complete;
        public int shot11,shot12,shot13,shot14,shot15,shot16,shot17,shot21,shot22,shot23,shot24,shot25,shot26,shot27,shot31,shot32,shot33,shot34,shot35,shot36,shot37;
        public bool isObs1Complete, isObs2Complete, isObs3Complete, isObs4Complete, isObs5Complete, isObs6Complete, isObs7Complete;
        
        public int counter11,
            counter12,
            counter13,
            counter14,
            counter15,
            counter16,
            counter17,
            counter21,
            counter22,
            counter23,
            counter24,
            counter25,
            counter26,
            counter27,
            counter31,
            counter32,
            counter33,
            counter34,
            counter35,
            counter36,
            counter37;
        
        [SerializeField] private Text inGameLvlText;
        [SerializeField] private Text inGameNextLvlText;
        [SerializeField] private Text BallCountText;
        
        
        private ColorBlock cb;
        

        public GameObject winPanel;
        [SerializeField] private Text winPanelLevelText;
        [SerializeField] private Text winPanelInGameScoreText;
        [SerializeField] private Text winPanelCoinText;

        private bool isActivated = false;
       
        
        #region Singleton
        public static LevelManager Instance { get; set; }
    
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

        private void Start()
        {
            
            shot11 = 4;
            shot12 = 5;
            shot13 = 6;
            shot14 = 7;
            shot15 = 8;
            shot16 = 9;
            shot17 = 10;
            shot21 = 10;
            shot22 = 4;
            shot23 = 5;
            shot24 = 6;
            shot25 = 8;
            shot26 = 8;
            shot27 = 9;
            shot31 = 4;
            shot32 = 5;
            shot33 = 6;
            shot34 = 7;
            shot35 = 8;
            shot36 = 9;
            shot37 = 10;
            cb = lvl1Button.colors;
            cb.disabledColor = Color.cyan;
            Canon.ammo = shot11;
        }
        IEnumerator WaitForThreeSeconds(float delaytime)
        {
            yield return new WaitForSeconds(delaytime);
            isActivated = true;
            Debug.Log("Three seconds have passed!");
        }
        private void Update()
        {
            UpdateLevelUI();
            BallCountText.text = Canon.ammo.ToString();
           
            if (GameManager.Instance.level ==0 || GameManager.Instance.level ==1  &&GameManager.Instance.isGameStarted)
            {
                if (isGame0 && GameManager.Instance.isGameStarted)
                { 
                   
                    if (isObs1Complete && shot11!=0)
                    {
                        
                        if (counter11 == ObstacleManager.Instance.lvl1Obs1.Count)
                        {
                            Canon.ammo = shot12;
                            Debug.Log("All of them has felt at Obs1");
                            isObs1Complete = false;
                            ObstacleManager.Instance.Platform11.SetActive(false);
                            ObstacleManager.Instance.Platform12.SetActive(true);
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs2.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs2[i].SetActive(true);
                            }
                            isObs2Complete = true;
                            GameManager.Instance.levelSliderBlocks[0].color= Color.red;
                            
                        }
                        if (Canon.ammo == 0)
                        {
                            StartCoroutine(WaitForThreeSeconds(4f));
                            
                        }

                        if (isActivated && Canon.ammo == 0 && counter11 != ObstacleManager.Instance.lvl1Obs1.Count)
                        {
                            GameManager.Instance.isGameStarted = false;
                            GameManager.Instance.failPanel.SetActive(true);
                            StopCoroutine(WaitForThreeSeconds(4f));
                            isActivated = false;
                        }
                    }
                   


                    //2ND OBS
                    if (isObs2Complete && shot12 != 0 && GameManager.Instance.isGameStarted)
                    {
                        //BallCountText.text = shot12.ToString();
                        if (counter12 == ObstacleManager.Instance.lvl1Obs2.Count)
                        {
                            Canon.ammo = shot13;
                            Debug.Log("All of them has felt at Obs1");
                            isObs2Complete = false;
                            ObstacleManager.Instance.Platform12.SetActive(false);
                            ObstacleManager.Instance.Platform13.SetActive(true);
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs3.Count; i++)
                            {
                                ObstacleManager.Instance.lvl1Obs3[i].SetActive(true);
                            }
                            isObs3Complete = true;
                            GameManager.Instance.levelSliderBlocks[1].color= Color.red;
                        }
                        if (Canon.ammo == 0)
                        {
                            StartCoroutine(WaitForThreeSeconds(4f));
                        }

                        if (isActivated && Canon.ammo == 0 && counter12 != ObstacleManager.Instance.lvl1Obs2.Count)
                        {
                            GameManager.Instance.isGameStarted = false;
                            GameManager.Instance.failPanel.SetActive(true);
                            StopCoroutine(WaitForThreeSeconds(4f));
                            isActivated = false;
                        }
                    }
                    
                
                    //3RD OBS
                    
                   
                    if (isObs3Complete && shot13 != 0 && GameManager.Instance.isGameStarted)
                    {
                        
                        
                        if (counter13 == ObstacleManager.Instance.lvl1Obs3.Count)
                        {
                            Canon.ammo = shot14;
                            Debug.Log("All of them has felt at Obs1");
                            isObs3Complete = false;
                            ObstacleManager.Instance.Platform13.SetActive(false);
                            ObstacleManager.Instance.Platform14.SetActive(true);
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs4.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs4[i].SetActive(true);
                            }
                            isObs4Complete = true;  
                            GameManager.Instance.levelSliderBlocks[2].color= Color.red;
                        }
                        if (Canon.ammo == 0)
                        {
                            StartCoroutine(WaitForThreeSeconds(4f));
                            
                        }

                        if (isActivated && Canon.ammo == 0 && counter13 != ObstacleManager.Instance.lvl1Obs3.Count)
                        {
                            GameManager.Instance.isGameStarted = false;
                            GameManager.Instance.failPanel.SetActive(true);
                            StopCoroutine(WaitForThreeSeconds(4f));
                            isActivated = false;
                        }
                    }
                   
                
                    //4th OBS
                    
                    if (isObs4Complete && shot14 != 0&& GameManager.Instance.isGameStarted)
                    {
                       
                        if (counter14 == ObstacleManager.Instance.lvl1Obs4.Count)
                        {
                            Canon.ammo = shot15;
                            Debug.Log("All of them has felt at Obs1");
                            isObs4Complete = false;
                            ObstacleManager.Instance.Platform14.SetActive(false);
                            ObstacleManager.Instance.Platform15.SetActive(true);
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs5.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs5[i].SetActive(true);
                            }
                            isObs5Complete = true;  
                            GameManager.Instance.levelSliderBlocks[3].color= Color.red;
                        }
                        if (Canon.ammo == 0)
                        {
                            StartCoroutine(WaitForThreeSeconds(4f));
                            
                        }

                        if (isActivated && Canon.ammo == 0 && counter14 != ObstacleManager.Instance.lvl1Obs4.Count)
                        {
                            GameManager.Instance.isGameStarted = false;
                            GameManager.Instance.failPanel.SetActive(true);
                            StopCoroutine(WaitForThreeSeconds(4f));
                            isActivated = false;
                        }
                    }
                    
               
                
                    //5th OBS
                   
                    
                    if (isObs5Complete && shot15 != 0&& GameManager.Instance.isGameStarted)
                    {
                        
                        
                        if (counter15 == ObstacleManager.Instance.lvl1Obs5.Count)
                        {
                            Canon.ammo = shot16;
                            Debug.Log("All of them has felt at Obs1");
                            isObs5Complete = false;
                            ObstacleManager.Instance.Platform15.SetActive(false);
                            ObstacleManager.Instance.Platform16.SetActive(true);
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs6.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs6[i].SetActive(true);
                            }
                            isObs6Complete = true;  
                            GameManager.Instance.levelSliderBlocks[4].color= Color.red;
                        }
                        if (Canon.ammo == 0)
                        {
                            StartCoroutine(WaitForThreeSeconds(4f));
                            
                        }

                        if (isActivated && Canon.ammo == 0 && counter15 != ObstacleManager.Instance.lvl1Obs5.Count)
                        {
                            GameManager.Instance.isGameStarted = false;
                            GameManager.Instance.failPanel.SetActive(true);
                            StopCoroutine(WaitForThreeSeconds(4f));
                            isActivated = false;
                        }
                    }
                    
                
                    //6th OBS
                    
                    
                    if (isObs6Complete && shot16 != 0&& GameManager.Instance.isGameStarted)
                    {
                      
                        
                        if (counter16 == ObstacleManager.Instance.lvl1Obs6.Count)
                        {
                            Canon.ammo = shot17;
                            Debug.Log("All of them has felt at Obs1");
                            isObs6Complete = false;
                            ObstacleManager.Instance.Platform16.SetActive(false);
                            ObstacleManager.Instance.Platform17.SetActive(true);
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs7.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs7[i].SetActive(true);
                            }
                            isObs7Complete = true;  
                            GameManager.Instance.levelSliderBlocks[5].color= Color.red;
                        }
                        if (Canon.ammo == 0)
                        {
                            StartCoroutine(WaitForThreeSeconds(4f));
                            
                        }

                        if (isActivated && Canon.ammo == 0 && counter16 != ObstacleManager.Instance.lvl1Obs6.Count)
                        {
                            GameManager.Instance.isGameStarted = false;
                            GameManager.Instance.failPanel.SetActive(true);
                            isActivated = false;
                        }
                    }
                   
                    //7th OBS
                   
                    
                    if (isObs7Complete && shot17 != 0&& GameManager.Instance.isGameStarted)
                    {
                        
                        if(Canon.ammo==0)
                        {
                            Canon.ammo = shot21;
                            GameManager.Instance.levelSliderBlocks[6].color= Color.red;
                            isObs7Complete = false;
                            GameManager.Instance.level = 2;
                            PlayerPrefs.SetInt("level", 2);
                            isGame0 = false;
                            isLevel1Complete = true;
                            ObstacleManager.Instance.Platform17.SetActive(false);
                            ObstacleManager.Instance.Platform21.SetActive(true);
                            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs7.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl1Obs7[i].SetActive(false);
                            }
                            for (int i = 0; i < ObstacleManager.Instance.lvl2Obs1.Count(); i++)
                            {
                                ObstacleManager.Instance.lvl2Obs1[i].SetActive(true);
                            }

                            for (int i = 0; i < GameManager.Instance.levelSliderBlocks.Count; i++)
                            {
                                GameManager.Instance.levelSliderBlocks[i].color=Color.gray;
                            }

                            GameManager.Instance.inGameScore = 0;
                            isObs1Complete = true;
                            winPanelInGameScoreText.text = Canon.ammo.ToString();
                            winPanelCoinText.text = "+10";
                            winPanelLevelText.text = "LEVEL 2";
                            winPanel.SetActive(true);
                            GameManager.Instance.coin = 10;
                            PlayerPrefs.SetInt("coin", 10);
                            winPanel.SetActive(true);
                            isActivated = false;
                            GameManager.Instance.isGameStarted = false;
                        }
                        
                    }
                    
                }
            }
            
            //LVL 2
            

            if (GameManager.Instance.level == 2 && GameManager.Instance.isGameStarted)
            {
               
                Debug.Log("Level 2");
                isObs1Complete = true;
             if (isLevel1Complete && GameManager.Instance.isGameStarted)
             {
                 //1ST OBS
                 
                 if (isObs1Complete && shot21!=0)
                 {
                     GameManager.Instance.failPanel.SetActive(false);
                     if (counter21 == ObstacleManager.Instance.lvl2Obs1.Count)
                     {
                         Canon.ammo = shot22;
                         GameManager.Instance.failPanel.SetActive(false);
                         ObstacleManager.Instance.Platform21.SetActive(false);
                         ObstacleManager.Instance.Platform22.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[0].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs1Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs2.Count(); i++)
                         {
                             if(ObstacleManager.Instance.lvl2Obs2[i]!=null)
                                ObstacleManager.Instance.lvl2Obs2[i].SetActive(true);
                         }
                         isObs2Complete = true;
                     }
                     if (Canon.ammo == 0)
                     {
                         StartCoroutine(WaitForThreeSeconds(3f));
                     }

                     if (isActivated && Canon.ammo == 0 && counter21 != ObstacleManager.Instance.lvl2Obs1.Count)
                     {
                         GameManager.Instance.isGameStarted = false;
                         GameManager.Instance.failPanel.SetActive(true);
                     }
                    
                 }
                 

                 //2ND OBS
                
                 
                 if (isObs2Complete && shot22 != 0&& GameManager.Instance.isGameStarted)
                 {
                     
                        
                     if (counter22 == ObstacleManager.Instance.lvl2Obs2.Count)
                     {
                         Canon.ammo = shot23;
                         GameManager.Instance.failPanel.SetActive(false);
                         ObstacleManager.Instance.Platform22.SetActive(false);
                         ObstacleManager.Instance.Platform23.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[1].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs2Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs3.Count; i++)
                         {
                             if(ObstacleManager.Instance.lvl2Obs3[i]!=null)
                                ObstacleManager.Instance.lvl2Obs3[i].SetActive(true);
                         }
                         isObs3Complete = true;
                     }
                    
                 }
                 if (Canon.ammo == 0)
                 {
                     StartCoroutine(WaitForThreeSeconds(3f));
                            
                 }

                 if (isActivated && Canon.ammo == 0 && counter22 != ObstacleManager.Instance.lvl2Obs2.Count)
                 {
                     GameManager.Instance.isGameStarted = false;
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                
                 //3RD OBS
                 
                 if (isObs3Complete && shot23 != 0)
                 {
                   
                     
                     if (counter23 == ObstacleManager.Instance.lvl2Obs3.Count)
                     {
                         Canon.ammo = shot24;
                         ObstacleManager.Instance.Platform23.SetActive(false);
                         ObstacleManager.Instance.Platform24.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[2].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs3Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs4.Count(); i++)
                         {
                             if(ObstacleManager.Instance.lvl2Obs4[i]!=null)
                                ObstacleManager.Instance.lvl2Obs4[i].SetActive(true);
                         }
                         isObs4Complete = true;  
                     }
                    
                 }
                 if (Canon.ammo == 0)
                 {
                     StartCoroutine(WaitForThreeSeconds(3f));
                            
                 }

                 if (isActivated && Canon.ammo == 0 && counter23 != ObstacleManager.Instance.lvl2Obs3.Count)
                 {
                     GameManager.Instance.isGameStarted = false;
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                
                 //4th OBS
                 
                 if (isObs4Complete && shot24 != 0)
                 {
                     
                    
                        
                     if (counter24 == ObstacleManager.Instance.lvl2Obs4.Count)
                     {
                         Canon.ammo = shot25;
                         GameManager.Instance.levelSliderBlocks[3].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs4Complete = false;
                         ObstacleManager.Instance.Platform24.SetActive(false);
                         ObstacleManager.Instance.Platform25.SetActive(true);
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs5.Count(); i++)
                         {
                             if(ObstacleManager.Instance.lvl2Obs5[i]!=null)
                                ObstacleManager.Instance.lvl2Obs5[i].SetActive(true);
                         }
                         isObs5Complete = true;  
                     }
                    
                 }
                 if (Canon.ammo == 0)
                 {
                     StartCoroutine(WaitForThreeSeconds(3f));
                            
                 }

                 if (isActivated && Canon.ammo == 0 && counter24 != ObstacleManager.Instance.lvl2Obs4.Count)
                 {
                     GameManager.Instance.isGameStarted = false;
                     GameManager.Instance.failPanel.SetActive(true);
                 }
               
                
                 //5th OBS
                 
                 if (isObs5Complete && shot25 != 0)
                 {
                     
                        
                     if (counter25 == ObstacleManager.Instance.lvl2Obs5.Count)
                     {
                         Canon.ammo = shot26;
                         ObstacleManager.Instance.Platform25.SetActive(false);
                         ObstacleManager.Instance.Platform26.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[4].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs5Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs6.Count(); i++)
                         {
                             if(ObstacleManager.Instance.lvl2Obs6[i]!=null)
                                ObstacleManager.Instance.lvl2Obs6[i].SetActive(true);
                         }
                         isObs6Complete = true;  
                     }
                    
                 }
                 if (Canon.ammo == 0)
                 {
                     StartCoroutine(WaitForThreeSeconds(3f));
                            
                 }

                 if (isActivated && Canon.ammo == 0 && counter25 != ObstacleManager.Instance.lvl2Obs5.Count)
                 {
                     GameManager.Instance.isGameStarted = false;
                     GameManager.Instance.failPanel.SetActive(true);
                 }
                
                 //6th OBS
                 
                 if (isObs6Complete && shot26 != 0)
                 {
                     
                        
                     if (counter26 == ObstacleManager.Instance.lvl2Obs6.Count)
                     {
                         Canon.ammo = shot27;
                         ObstacleManager.Instance.Platform26.SetActive(false);
                         ObstacleManager.Instance.Platform27.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[5].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs6Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl2Obs7.Count(); i++)
                         {
                             if(ObstacleManager.Instance.lvl2Obs7[i]!=null)
                                ObstacleManager.Instance.lvl2Obs7[i].SetActive(true);
                         }
                         isObs7Complete = true;  
                     }
                     if (Canon.ammo == 0)
                     {
                         StartCoroutine(WaitForThreeSeconds(3f));
                            
                     }

                     if (isActivated && Canon.ammo == 0 && counter26 != ObstacleManager.Instance.lvl2Obs6.Count)
                     {
                         GameManager.Instance.isGameStarted = false;
                         GameManager.Instance.failPanel.SetActive(true);
                     }
                    
                 }
                 
                 //7th OBS
                 
                 if (isObs7Complete && shot27 != 0)
                 {
                     
                        
                     if (counter27 == ObstacleManager.Instance.lvl2Obs7.Count)
                     {
                         Canon.ammo = shot31;
                         ObstacleManager.Instance.Platform27.SetActive(false);
                         ObstacleManager.Instance.Platform31.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[6].color= Color.red;
                         isObs7Complete = false;
                         Debug.Log("LEVEL 2 HAS ENDED");
                         GameManager.Instance.level = 3;
                         PlayerPrefs.SetInt("level", 3);
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
                     GameManager.Instance.inGameScore = 0;
                     isObs1Complete = true;
                     winPanelInGameScoreText.text = Canon.ammo.ToString();
                     winPanelCoinText.text = "+10";
                     winPanelLevelText.text = "LEVEL 3";
                     winPanel.SetActive(true);
                     GameManager.Instance.coin += 100;
                     PlayerPrefs.SetInt("coin",GameManager.Instance.coin);
                     if(Canon.ammo==0 && counter27!=ObstacleManager.Instance.lvl2Obs7.Count)
                     {
                         winPanel.SetActive(true);
                         GameManager.Instance.isGameStarted = false;
                     }
                 }
                 
             }
            }
            
            
            //LVL 3
            

            if (GameManager.Instance.level ==3 && GameManager.Instance.isGameStarted)
            {
                Debug.Log("Level 3");
             if (isLevel2Complete && GameManager.Instance.isGameStarted)
             {
                
                 //1ST OBS
                 
                 if (isObs1Complete && shot31!=0)
                 {
                     
                     if (counter31 == ObstacleManager.Instance.lvl3Obs1.Count)
                     {
                         Canon.ammo = shot32;
                         ObstacleManager.Instance.Platform31.SetActive(false);
                         ObstacleManager.Instance.Platform32.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[0].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs1Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs2.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs2[i].SetActive(true);
                         }
                         isObs2Complete = true;
                     }
                     if (Canon.ammo == 0)
                     {
                         StartCoroutine(WaitForThreeSeconds(3f));
                            
                     }

                     if (isActivated && Canon.ammo == 0 && counter31 != ObstacleManager.Instance.lvl3Obs1.Count)
                     {
                         GameManager.Instance.isGameStarted = false;
                         GameManager.Instance.failPanel.SetActive(true);
                     }
                 }
                 
                 //2ND OBS
                 
                 if (isObs2Complete && shot32 != 0)
                 {
                   
                     if (counter32 == ObstacleManager.Instance.lvl3Obs2.Count)
                     {
                         Canon.ammo = shot33;
                         ObstacleManager.Instance.Platform32.SetActive(false);
                         ObstacleManager.Instance.Platform33.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[1].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs2Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs3.Count; i++)
                         {
                             ObstacleManager.Instance.lvl3Obs3[i].SetActive(true);
                         }
                         isObs3Complete = true;
                     }
                     if (Canon.ammo == 0)
                     {
                         StartCoroutine(WaitForThreeSeconds(3f));
                            
                     }

                     if (isActivated && Canon.ammo == 0 && counter32 != ObstacleManager.Instance.lvl3Obs2.Count)
                     {
                         GameManager.Instance.isGameStarted = false;
                         GameManager.Instance.failPanel.SetActive(true);
                     }
                 }
                 
                
                 //3RD OBS
                 
                 if (isObs3Complete && shot33 != 0)
                 {
                     
                        
                     if (counter33 == ObstacleManager.Instance.lvl3Obs3.Count)
                     {
                         Canon.ammo = shot34;
                         ObstacleManager.Instance.Platform33.SetActive(false);
                         ObstacleManager.Instance.Platform34.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[2].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs3Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs4.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs4[i].SetActive(true);
                         }
                         isObs4Complete = true;  
                     }
                     if (Canon.ammo == 0)
                     {
                         StartCoroutine(WaitForThreeSeconds(3f));
                            
                     }

                     if (isActivated && Canon.ammo == 0 && counter33 != ObstacleManager.Instance.lvl3Obs4.Count)
                     {
                         GameManager.Instance.isGameStarted = false;
                         GameManager.Instance.failPanel.SetActive(true);
                     }
                 }
                
                
                 //4th OBS
                 if (isObs4Complete && shot34 != 0)
                 {
                   
                     if (counter34 == ObstacleManager.Instance.lvl3Obs4.Count)
                     {
                         Canon.ammo = shot35;
                         ObstacleManager.Instance.Platform34.SetActive(false);
                         ObstacleManager.Instance.Platform35.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[3].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs4Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs5.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs5[i].SetActive(true);
                         }
                         isObs5Complete = true;  
                     }
                     if (Canon.ammo == 0)
                     {
                         StartCoroutine(WaitForThreeSeconds(3f));
                            
                     }

                     if (isActivated && Canon.ammo == 0 && counter34 != ObstacleManager.Instance.lvl3Obs4.Count)
                     {
                         GameManager.Instance.isGameStarted = false;
                         GameManager.Instance.failPanel.SetActive(true);
                     }
                 }
                 
               
                
                 //5th OBS
                 if (isObs5Complete && shot35 != 0)
                 {
                    
                        
                     if (counter35 == ObstacleManager.Instance.lvl3Obs5.Count)
                     {
                         Canon.ammo = shot36;
                         ObstacleManager.Instance.Platform35.SetActive(false);
                         ObstacleManager.Instance.Platform36.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[4].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs5Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs6.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs6[i].SetActive(true);
                         }
                         isObs6Complete = true;  
                     }
                     if (Canon.ammo == 0)
                     {
                         StartCoroutine(WaitForThreeSeconds(3f));
                            
                     }

                     if (isActivated && Canon.ammo == 0 && counter35 != ObstacleManager.Instance.lvl3Obs5.Count)
                     {
                         GameManager.Instance.isGameStarted = false;
                         GameManager.Instance.failPanel.SetActive(true);
                     }
                 }
                
                
                 //6th OBS
                 if (isObs6Complete && shot36 != 0)
                 {
                     
                    
                     if (counter36 == ObstacleManager.Instance.lvl3Obs6.Count)
                     {
                         Canon.ammo = shot37;
                         ObstacleManager.Instance.Platform36.SetActive(false);
                         ObstacleManager.Instance.Platform37.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[5].color= Color.red;
                         Debug.Log("All of them has felt at Obs1");
                         isObs6Complete = false;
                         for (int i = 0; i < ObstacleManager.Instance.lvl3Obs7.Count(); i++)
                         {
                             ObstacleManager.Instance.lvl3Obs7[i].SetActive(true);
                         }
                         isObs7Complete = true;  
                     }
                     if (Canon.ammo == 0)
                     {
                         StartCoroutine(WaitForThreeSeconds(3f));
                            
                     }

                     if (isActivated && Canon.ammo == 0 && counter36 != ObstacleManager.Instance.lvl3Obs6.Count)
                     {
                         GameManager.Instance.isGameStarted = false;
                         GameManager.Instance.failPanel.SetActive(true);
                     }
                 }
               
                 //7th OBS
                 if (isObs7Complete && shot37 != 0)
                 {
                   
                        
                     if (counter37 == ObstacleManager.Instance.lvl3Obs7.Count)
                     {
                         ObstacleManager.Instance.Platform37.SetActive(false);
                         ObstacleManager.Instance.Platform11.SetActive(true);
                         GameManager.Instance.levelSliderBlocks[6].color= Color.red;
                         isObs7Complete = false;
                         Debug.Log("LEVEL 3 HAS ENDED");
                         GameManager.Instance.level = 4;
                         PlayerPrefs.SetInt("level", 4);
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
                         GameManager.Instance.inGameScore = 0;
                         isObs1Complete = true;
                         winPanelInGameScoreText.text = Canon.ammo.ToString();
                         winPanelCoinText.text = "+10";
                         winPanelLevelText.text = "LEVEL 4";
                         winPanel.SetActive(true);
                         GameManager.Instance.coin += 100;
                         PlayerPrefs.SetInt("coin",GameManager.Instance.coin);
                     }
                     if(Canon.ammo==0 && counter37!=ObstacleManager.Instance.lvl3Obs7.Count)
                     {
                         winPanel.SetActive(true);
                         GameManager.Instance.isGameStarted = false;
                     }
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
            else if (GameManager.Instance.level == 1 && GameManager.Instance.isGameStarted)
            {
                UpdateLevelButtonState(lvl1Button, false);
                UpdateLevelButtonState(lvl2Button, true);
                UpdateLevelButtonState(lvl3Button, false);

                SetLevelText(1, 2);
            }
            else if (GameManager.Instance.level == 2 && GameManager.Instance.isGameStarted)
            {
                UpdateLevelButtonState(lvl1Button, false);
                UpdateLevelButtonState(lvl2Button, false);
                UpdateLevelButtonState(lvl3Button, true);

                SetLevelText(2, 3);
            }
            else if (GameManager.Instance.level == 3 && GameManager.Instance.isGameStarted)
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
