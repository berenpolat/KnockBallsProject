using System.Linq;
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
            isGame0 = true;
            isObs1Complete = true;
        }

        private void Update()
        {
            UpdateLevelUI();
            
            if (isGame0 && GameManager.Instance.isGameStarted)
            {
                
                //1ST OBS
                shot11 = 4;
                int counter11 = 0;
                if (isObs1Complete && shot11!=0)
                {
                        for (int j = 0; j < ObstacleManager.Instance.lvl1Obs1.Count; j++)
                        {
                            if (ObstacleManager.Instance.lvl1Obs1[j].transform.localPosition.y <= 0f)
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
                        }
                    
                }
                if(shot11==0 && counter11!=6)
                {
                    Debug.Log("Not all of them has dropped");
                    //FAIL PANEL IS ON
                }

                //2ND OBS
                shot12 = 4;
                int counter12 = 0;
                if (isObs2Complete && shot12 != 0)
                {
                        for (int j = 0; j < ObstacleManager.Instance.lvl1Obs2.Count; j++)
                        {
                            if (ObstacleManager.Instance.lvl1Obs2[j].transform.localPosition.y <= 0f)
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
                        }
                    
                }
                if(shot12==0 && counter12!=6)
                {
                    Debug.Log("Not all of them has dropped");
                }
                
                //3RD OBS
                shot13 = 4;
                int counter13 = 0;
                if (isObs3Complete && shot13 != 0)
                {
                    for (int j = 0; j < ObstacleManager.Instance.lvl1Obs3.Count; j++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs3[j].transform.localPosition.y <= 0f)
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
                    }
                    
                }
                if(shot13==0 && counter13!=6)
                {
                    Debug.Log("Not all of them has dropped");
                }
                
                //4th OBS
                shot14 = 4;
                int counter14 = 0;
                if (isObs4Complete && shot14 != 0)
                {
                    for (int j = 0; j < ObstacleManager.Instance.lvl1Obs4.Count; j++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs4[j].transform.localPosition.y <= 0f)
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
                    }
                    
                }
                if(shot14==0 && counter14!=6)
                {
                    Debug.Log("Not all of them has dropped");
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
                    }
                    
                }
                if(shot15==0 && counter15!=6)
                {
                    Debug.Log("Not all of them has dropped");
                }
                
                //6th OBS
                shot16 = 4;
                int counter16 = 0;
                if (isObs6Complete && shot16 != 0)
                {
                    for (int j = 0; j < ObstacleManager.Instance.lvl1Obs6.Count; j++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs6[j].transform.localPosition.y <= 0f)
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
                    }
                    
                }
                if(shot16==0 && counter16!=6)
                {
                    Debug.Log("Not all of them has dropped");
                }
                //7th OBS
                shot17 = 4;
                int counter17 = 0;
                if (isObs7Complete && shot17 != 0)
                {
                    for (int j = 0; j < ObstacleManager.Instance.lvl1Obs7.Count; j++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs7[j].transform.localPosition.y <= 0f)
                        {
                            counter17++;
                        }
                    }
                        
                    if (counter17 == ObstacleManager.Instance.lvl1Obs7.Count)
                    {
                        Debug.Log("All of them has felt at Obs1");
                        isObs7Complete = false;
                        Debug.Log("LEVEL 1 HAS ENDED");
                    }
                    
                }
                if(shot16==0 && counter16!=6)
                {
                    Debug.Log("Not all of them has dropped");
                }
            }
        }

        
        private void UpdateLevelUI()
        {
            GameManager gm = GameManager.Instance;

            if (gm.level == 0 && gm.isGameStarted)
            {
                UpdateLevelButtonState(lvl1Button, true);
                UpdateLevelButtonState(lvl2Button, false);
                UpdateLevelButtonState(lvl3Button, false);

                SetLevelText(0, 1);
            }
            else if (gm.level == 1)
            {
                UpdateLevelButtonState(lvl1Button, false);
                UpdateLevelButtonState(lvl2Button, true);
                UpdateLevelButtonState(lvl3Button, false);

                SetLevelText(1, 2);
            }
            else if (gm.level == 2)
            {
                UpdateLevelButtonState(lvl1Button, false);
                UpdateLevelButtonState(lvl2Button, false);
                UpdateLevelButtonState(lvl3Button, true);

                SetLevelText(2, 3);
            }
            else if (gm.level == 3)
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
