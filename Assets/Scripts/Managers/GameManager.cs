using System.Collections.Generic;
using System.Threading;
using Base.State;
using DG.Tweening;
using State;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region General Variables

        public int level =0;
        public int bestScore;
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
        [SerializeField] private GameObject ınGamePanel;
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
        }

        // Update is called once per frame
        void Update()
        {
            if(!isGameStarted) MoveObsHolderAtTheStart();
            lvlText.text =  "Lvl. " +  PlayerPrefs.GetInt("level").ToString();
            bestScoreText.text ="BEST: " + PlayerPrefs.GetInt("bestScore").ToString();
        }
        #endregion

        private void StartTheGame()
        {
            isGameStarted = !isGameStarted;
            startPanel.SetActive(false);
            ınGamePanel.SetActive(true);
            obsHolder.transform.DOMove(new Vector3(0,-8.53999996f,12.2200003f),0.5F);
        }

        public void StopTheGame()
        {
            startPanel.SetActive(true);
            ınGamePanel.SetActive(false);
        }

        private void MoveObsHolderAtTheStart()
        {
            float speed = 1.0f;
            float minX = -3.0f;
            float maxX = 3.0f;
        
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
