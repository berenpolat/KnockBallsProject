using System.Collections.Generic;
using System.Threading;
using Base.State;
using DG.Tweening;
using State;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region General Variables

        public int level;
        public int bestScore;
        public int inGameScore;
        public int coin;
        public bool isGameStarted = false;
        [SerializeField] private GameObject obsHolder;
        private bool _movingRight = true;
        #endregion
        
        private CancellationTokenSource StateCancellationTokenSource { get; set; } = null!;
        public static CancellationTokenSource GeneralCancellationTokenSource { get; } = new CancellationTokenSource();
        private IContext _finalContext = null!;
        
        #region Panels
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject inGamePanel;
        [SerializeField] private GameObject backToMenuPanel;
        [SerializeField] private GameObject levelTreePanel;
        public GameObject failPanel;
    
       
        #endregion

        #region LevelSliderImages

        public List<Image> levelSliderBlocks;

        #endregion

       
        
        #region LevelButtons

        [SerializeField] private Button Level1Button;
        [SerializeField] private Button Level2Button;
        [SerializeField] private Button Level3Button;
        
        #endregion
        #region Texts

        [SerializeField] private Text lvlText;
        [SerializeField] private Text bestScoreText;
        [SerializeField] private Text inGameScoreText;
        [SerializeField] private Text coinText;

        #endregion
        #region Singleton
        public static GameManager Instance { get; set; }
    
        private void Awake()
        {
            isGameStarted = false;
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
    
        #region Unity Methods
        
        // Start is called before the first frame update
        void Start()
        {
            level = PlayerPrefs.GetInt("level");
            bestScore = PlayerPrefs.GetInt("bestScore");
            coin = PlayerPrefs.GetInt("coin");
            if (level == 0 || level==1)
            {
                PlayerPrefs.SetInt("level",1);
                LevelManager.Instance.isGame0 = true;
                inGameScore = 0;
                LevelManager.Instance.isObs1Complete = true;
                failPanel.SetActive(false);
                ObstacleManager.Instance.Platform11.SetActive(true);
                for (int i = 0; i < ObstacleManager.Instance.lvl1Obs1.Count; i++)
                {
                    ObstacleManager.Instance.lvl1Obs1[i].SetActive(true);
                }
               
            }

            if (level == 2)
            {
                LevelManager.Instance.isLevel1Complete = true;
                LevelManager.Instance.isObs1Complete = true;
                inGameScore = 0;
                failPanel.SetActive(false);
                ObstacleManager.Instance.Platform21.SetActive(true);
                for (int i = 0; i < ObstacleManager.Instance.lvl2Obs1.Count; i++)
                {
                    ObstacleManager.Instance.lvl2Obs1[i].SetActive(true);
                }
            }
            if (level == 3)
            {
                LevelManager.Instance.isLevel2Complete = true;
                LevelManager.Instance.isObs1Complete = false;
                LevelManager.Instance.isGame0 = false;
                inGameScore = 0;
                failPanel.SetActive(false);
                ObstacleManager.Instance.Platform31.SetActive(true);
                for (int i = 0; i < ObstacleManager.Instance.lvl3Obs1.Count; i++)
                {
                    ObstacleManager.Instance.lvl3Obs1[i].SetActive(true);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            inGameScoreText.text = inGameScore.ToString();
            if (isGameStarted == false)
            {
                MoveObsHolderAtTheStart();
            }
            lvlText.text =  "Lvl. " +  PlayerPrefs.GetInt("level").ToString();
            bestScoreText.text ="BEST: " + PlayerPrefs.GetInt("bestScore").ToString();
            coinText.text = PlayerPrefs.GetInt("coin").ToString();
        }
        #endregion

        private void StartTheGame()
        {
            isGameStarted = true;
            startPanel.SetActive(false);
            inGamePanel.SetActive(true);
            obsHolder.transform.DOMove(new Vector3(0,-8.5f,13.6999998f),0.5F);
        }

        public void StopTheGame()
        {
            startPanel.SetActive(true);
            inGamePanel.SetActive(false);
            isGameStarted = false;
        }

        private void MoveObsHolderAtTheStart()
        {
            float speed = 0.5f;
            float minX = -1f;
            float maxX = 1f;
        
            float targetX = _movingRight ? maxX : minX;
            var position = obsHolder.transform.position;
            position = Vector3.MoveTowards(position, new Vector3(position.x, position.y,targetX ), speed * Time.deltaTime);
            obsHolder.transform.position = position;

            if (obsHolder.transform.position.z == targetX)
            {
                _movingRight = !_movingRight;
            }
        }
        

        #region Button Controls

        public void OnClickedTapToPlayButton()
        {
            isGameStarted = true;
            failPanel.SetActive(false);
            StartTheGame();
        }

        public void OnClickedInGameBackButton()
        {
            backToMenuPanel.SetActive(true);
            inGamePanel.SetActive(false);
        }

        public void OnClickedInGameBackButtonNo()
        {
            backToMenuPanel.SetActive(false);
            inGamePanel.SetActive(true);
        }

        public void OnClickedInGameBackButtonOK()
        {
            SceneManager.LoadSceneAsync(0);
        }
        public void OnClickLevelTreeDisplayButton()
        {
            levelTreePanel.SetActive(true);
            if (LevelManager.Instance.isLevel1Complete)
            {
                Level1Button.interactable = true;
            }
            else
            {
                Level1Button.interactable = false;
            }

            if (LevelManager.Instance.isLevel2Complete)
            {
                Level2Button.interactable = true;
            }
            else
            {
                Level2Button.interactable = false;
            }

            if (LevelManager.Instance.isLevel3Complete)
            {
                Level3Button.interactable = true;
            }
            else
            {
                Level3Button.interactable = false;
            }
        }
        public void OnClickCancelLevelTreeButton()
        {
            levelTreePanel.SetActive(false);
           
        }

        public void OnClickDisplayLevel1Button()
        {
            isGameStarted = true;
            LevelManager.Instance.isGame0 = true;
            levelTreePanel.SetActive(false);
            StartTheGame();
            level = 1;
            PlayerPrefs.SetInt("level",1);
            LevelManager.Instance.isGame0 = true;
            inGameScore = 0;
            LevelManager.Instance.isObs1Complete = true;
            failPanel.SetActive(false);
            ObstacleManager.Instance.Platform11.SetActive(true);
            for (int i = 0; i < ObstacleManager.Instance.lvl1Obs1.Count; i++)
            {
                ObstacleManager.Instance.lvl1Obs1[i].SetActive(true);
            }
               
            
        } 
        public void OnClickDisplayLevel2Button()
        {
            isGameStarted = true;
            LevelManager.Instance.isLevel1Complete = true;
            levelTreePanel.SetActive(false);
            StartTheGame();
            LevelManager.Instance.isLevel1Complete = true;
            LevelManager.Instance.isObs1Complete = true;
            inGameScore = 0;
            failPanel.SetActive(false);
            ObstacleManager.Instance.Platform21.SetActive(true);
            for (int i = 0; i < ObstacleManager.Instance.lvl2Obs1.Count; i++)
            {
                ObstacleManager.Instance.lvl2Obs1[i].SetActive(true);
            }
        }

        public void OnClickDisplayLevel3Button()
        {
            isGameStarted = true;
            LevelManager.Instance.isLevel2Complete = true;
            levelTreePanel.SetActive(false);
            StartTheGame();
            LevelManager.Instance.isLevel2Complete = true;
            LevelManager.Instance.isObs1Complete = false;
            LevelManager.Instance.isGame0 = false;
            inGameScore = 0;
            failPanel.SetActive(false);
            ObstacleManager.Instance.Platform31.SetActive(true);
            for (int i = 0; i < ObstacleManager.Instance.lvl3Obs1.Count; i++)
            {
                ObstacleManager.Instance.lvl3Obs1[i].SetActive(true);
            }
            
        }

        public void OnClickContinueButton()
        {
            inGamePanel.SetActive(false);
            startPanel.SetActive(true);
        }
        
        #endregion
        
    }
}
