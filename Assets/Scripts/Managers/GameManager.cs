using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region General Variables

        public int level;
        public int bestScore;
        public bool isGameStarted;
        [SerializeField] private GameObject obsHolder;
        private bool _movingRight = true;
        #endregion

        #region Panels
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject ınGamePanel;
        [SerializeField] private GameObject backToMenuPanel;
    

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
            startPanel.SetActive(false);
            ınGamePanel.SetActive(true);
            obsHolder.transform.DOMove(new Vector3(0, -1.7f, 6.2f),0.5F);
            level++;
            PlayerPrefs.SetInt("level",1);
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
            isGameStarted = !isGameStarted;
        }

        public void OnClickedInGameBackButton()
        {
            backToMenuPanel.SetActive(true);
        }

        #endregion
    }
}
