using System.Collections.Generic;
using System.Threading;
using Base.State;
using DG.Tweening;
using State;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region General Variables

        public int level=0;
        public int bestScore;
        public int inGameScore;
        public int coin;
        public bool isGameStarted;
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

        #region Texts

        [SerializeField] private Text lvlText;
        [SerializeField] private Text bestScoreText;
        [SerializeField] private Text inGameScoreText;

        #endregion
        #region Singleton
        public static GameManager Instance { get; set; }
    
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
    
        #region Unity Methods
        
        // Start is called before the first frame update
        void Start()
        {
            
            level = PlayerPrefs.GetInt("level");
            bestScore = PlayerPrefs.GetInt("bestScore");
            coin = PlayerPrefs.GetInt("coin");
            if (level == 0)
            {
                LevelManager.Instance.isGame0 = true;
                inGameScore = 1;
                LevelManager.Instance.isObs1Complete = true;
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
            
            if(!isGameStarted) MoveObsHolderAtTheStart();
            lvlText.text =  "Lvl. " +  PlayerPrefs.GetInt("level").ToString();
            bestScoreText.text ="BEST: " + PlayerPrefs.GetInt("bestScore").ToString();
        }
        #endregion

        private void StartTheGame()
        {
            isGameStarted = !isGameStarted;
            startPanel.SetActive(false);
            inGamePanel.SetActive(true);
            obsHolder.transform.DOMove(new Vector3(0,-8.53999996f,12.2200003f),0.5F);
            failPanel.SetActive(false);
        }

        public void StopTheGame()
        {
            startPanel.SetActive(true);
            inGamePanel.SetActive(false);
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
            StartTheGame();
        }

        public void OnClickedInGameBackButton()
        {
            backToMenuPanel.SetActive(true);
        }

        public void OnClickLevelTreeDisplayButton()
        {
            levelTreePanel.SetActive(true);
        }

        public void OnClickCancelLevelTreeButton()
        {
            levelTreePanel.SetActive(false);
        }
        #endregion
        
    }
}
