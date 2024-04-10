using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Panels

    [SerializeField] private GameObject startPanel;
    

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
        startPanel.SetActive(false);
    }
    
    
    

    #region Button Controls

    public void OnClickedTapToPlayButton()
    {
        StartTheGame();
    }

    #endregion
}
