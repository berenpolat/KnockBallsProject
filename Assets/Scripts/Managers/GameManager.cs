using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region General Variables

    public int level;
    public bool isGameStarted;
    [SerializeField] private GameObject ObsHolder;
    private bool movingForward = true;

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
        MoveObsHolderAtTheStart();
    }
    #endregion

    private void StartTheGame()
    {
        StartPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }

    private void MoveObsHolderAtTheStart()
    {
        float distance = 5f;
        float duration = 1f;

        if (movingForward)
        {
            ObsHolder.transform.DOMoveZ(ObsHolder.transform.position.z + distance, duration);
            movingForward = !movingForward;
        }
        else
        {
            ObsHolder.transform.DOMoveZ(ObsHolder.transform.position.z - distance, duration);
            movingForward = !movingForward;
        }

        movingForward = !movingForward;
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
