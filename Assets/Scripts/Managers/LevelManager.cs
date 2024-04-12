using System.Threading;
using Base.State;
using State;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Button lvl1Button;
        [SerializeField] private Button lvl2Button;
        [SerializeField] private Button lvl3Button;
        
        public bool isObs11Complete,isObs12Complete,isObs13Complete,isObs14Complete,isObs15Complete,isObs16Complete,isObs17Complete;

        [SerializeField] private Text inGameLvlText;
        [SerializeField] private Text inGameNextLvlText;

        private ColorBlock cb;
        
        public int counter;
      
        
        private CancellationTokenSource StateCancellationTokenSource { get; set; } = null!;
        public static CancellationTokenSource GeneralCancellationTokenSource { get; } = new CancellationTokenSource();
        private IContext _finalContext = null!;
        
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
            cb = lvl1Button.colors;
            cb.disabledColor = Color.cyan;
        }
        

        void Update()
        {
            if (GameManager.Instance.level == 0 && GameManager.Instance.isGameStarted)
            {
                lvl1Button.interactable = true;
                lvl2Button.interactable = false;
                lvl3Button.interactable = false;
                inGameLvlText.text = "0";
                inGameNextLvlText.text = "1";
                
                for (int i = 0; i < ObstacleManager.Instance.lvl1Obs1.Count; i++)
                {
                    if (ObstacleManager.Instance.lvl1Obs1[i].transform.localPosition.y <= -2f)
                    {
                        counter++;
                    }
                }

                if (counter == ObstacleManager.Instance.lvl1Obs1.Count)
                {
                    StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
                    _finalContext = new Context();
                    _finalContext.TransitionTo(new DisplayObs2State());
                    _ = _finalContext.RunStateAsync(StateCancellationTokenSource.Token);
                    counter = 0;
                    isObs11Complete = true;
                }

                if (isObs11Complete)
                {
                    for (int i = 0; i < ObstacleManager.Instance.lvl1Obs2.Count; i++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs2[i].transform.localPosition.y <= -2f)
                        {
                            counter++;
                        }
                    }

                    if (counter == ObstacleManager.Instance.lvl1Obs2.Count)
                    {
                        StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
                        _finalContext = new Context();
                        _finalContext.TransitionTo(new DisplayObs3State());
                        _ = _finalContext.RunStateAsync(StateCancellationTokenSource.Token);
                        counter = 0;
                        isObs12Complete = true;
                    }
                }

                if (isObs12Complete)
                {
                    for (int i = 0; i < ObstacleManager.Instance.lvl1Obs3.Count; i++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs3[i].transform.localPosition.y <= -2f)
                        {
                            counter++;
                        }
                    }

                    if (counter == ObstacleManager.Instance.lvl1Obs3.Count)
                    {
                        StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
                        _finalContext = new Context();
                        _finalContext.TransitionTo(new DisplayObs4State());
                        _ = _finalContext.RunStateAsync(StateCancellationTokenSource.Token);
                        counter = 0;
                        isObs13Complete = true;
                    }
                    
                }

                if (isObs13Complete)
                {
                    for (int i = 0; i < ObstacleManager.Instance.lvl1Obs4.Count; i++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs4[i].transform.localPosition.y <= -2f)
                        {
                            counter++;
                        }
                    }
                    if (counter == ObstacleManager.Instance.lvl1Obs4.Count)
                    {
                        StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
                        _finalContext = new Context();
                        _finalContext.TransitionTo(new DisplayObs5State());
                        _ = _finalContext.RunStateAsync(StateCancellationTokenSource.Token);
                        counter = 0;
                        isObs14Complete = true;
                    }
                }

                if (isObs14Complete)
                {
                    for (int i = 0; i < ObstacleManager.Instance.lvl1Obs5.Count; i++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs5[i].transform.localPosition.y <= -2f)
                        {
                            counter++;
                        }
                    }

                    if (counter == ObstacleManager.Instance.lvl1Obs5.Count)
                    {
                        StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
                        _finalContext = new Context();
                        _finalContext.TransitionTo(new DisplayObs6State());
                        _ = _finalContext.RunStateAsync(StateCancellationTokenSource.Token);
                        counter = 0;
                        isObs15Complete = true;
                    }
                }

                if (isObs15Complete)
                {
                    for (int i = 0; i < ObstacleManager.Instance.lvl1Obs6.Count; i++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs6[i].transform.localPosition.y <= -2f)
                        {
                            counter++;
                        }
                    }

                    if (counter == ObstacleManager.Instance.lvl1Obs6.Count)
                    {
                        StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
                        _finalContext = new Context();
                        _finalContext.TransitionTo(new DisplayObs2State());
                        _ = _finalContext.RunStateAsync(StateCancellationTokenSource.Token);
                        counter = 0;
                        isObs16Complete = true;
                    }
                }

                if (isObs16Complete)
                {
                    for (int i = 0; i < ObstacleManager.Instance.lvl1Obs7.Count; i++)
                    {
                        if (ObstacleManager.Instance.lvl1Obs7[i].transform.localPosition.y <= -2f)
                        {
                            counter++;
                        }
                    }

                    if (counter == ObstacleManager.Instance.lvl1Obs7.Count)
                    {
                        StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
                        _finalContext = new Context();
                        _finalContext.TransitionTo(new DisplayObs2State());
                        _ = _finalContext.RunStateAsync(StateCancellationTokenSource.Token);
                        counter = 0;
                        isObs17Complete = true;
                    }

                }
          
            }
            else if (GameManager.Instance.level == 1)
            {
                lvl1Button.colors = cb;
                lvl1Button.interactable = false;
                lvl2Button.interactable = true;
                lvl3Button.interactable = false;
                inGameLvlText.text = "1";
                inGameNextLvlText.text = "2";
                
            }
            else if (GameManager.Instance.level == 2)
            {
                lvl1Button.colors = cb;
                lvl2Button.colors = cb;
                lvl1Button.interactable = false;
                lvl2Button.interactable = false;
                lvl3Button.interactable = true;
                inGameLvlText.text = "2";
                inGameNextLvlText.text = "3";
            }
            else if (GameManager.Instance.level == 3)
            {
                lvl1Button.colors = cb;
                lvl2Button.colors = cb;
                lvl3Button.colors = cb;
                inGameLvlText.text = "3";
                inGameNextLvlText.text = "4";
            }
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