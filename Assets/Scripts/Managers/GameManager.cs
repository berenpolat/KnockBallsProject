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
    private bool movingRight = true;
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
        if(!isGameStarted) MoveObsHolderAtTheStart();
    }
    #endregion

    private void StartTheGame()
    {
        StartPanel.SetActive(false);
        InGamePanel.SetActive(true);
        ObsHolder.transform.DOMove(new Vector3(0, -1.7f, 6.2f),0.5F);
    }

    private void MoveObsHolderAtTheStart()
    {
        float speed = 1.0f;
        float minX = -3.0f;
        float maxX = 3.0f;
        
        float targetX = movingRight ? maxX : minX;
        ObsHolder.transform.position = Vector3.MoveTowards(ObsHolder.transform.position, new Vector3(ObsHolder.transform.position.x, ObsHolder.transform.position.y,targetX ), speed * Time.deltaTime);
        
        if (ObsHolder.transform.position.z == targetX)
        {
            movingRight = !movingRight;
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
        BackToMenuPanel.SetActive(true);
    }

    #endregion
}
