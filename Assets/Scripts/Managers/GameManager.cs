using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region General Variables

    public int level;
    public bool isGameStarted;
    

    #endregion
    
    #region Panels
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject InGamePanel;
    [SerializeField] private GameObject BackToMenuPanel;
    

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

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    private void StartTheGame()
    {
        StartPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }
    

    #region Button Controls

    public void OnClickedTapToPlayButton()
    {
        StartTheGame();
        isGameStarted = !isGameStarted;
    }

    public void OnClickedInGameBackButton()
    {
        BackToMenuPanel.SetActive(true);
    }

    #endregion
}
