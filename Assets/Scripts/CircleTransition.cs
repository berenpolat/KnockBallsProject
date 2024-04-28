using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CircleTransition : MonoBehaviour
{
    private Canvas canvas;
    public Image blackScreen;
    private static readonly int Radius = Shader.PropertyToID("Radius");
    private bool transitionInProgress = false;
    private Text shootCounterText;
    private GameObject objectWithTag;
    
    
    
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    

    private void Start()
    {
        DrawBlackScreen();
        objectWithTag = GameObject.FindGameObjectWithTag("ShootCounter");
        if (objectWithTag != null)
        {
            shootCounterText = objectWithTag.GetComponent<Text>();
        }
    }

    private void Update()
    {
        //When we run out of balls the coroutine starts
        if (shootCounterText != null && shootCounterText.text == "0" && !transitionInProgress)
        {
            OpenBlackScreen();
        }

    }

    public void OpenBlackScreen()
    {
        transitionInProgress = true;
        // blackScreen object
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(Transition(5f, 1f, 0f));
    }
    

    private void DrawBlackScreen()
    {
        var canvasRect = canvas.GetComponent<RectTransform>().rect;
        var canvasWidth = canvasRect.width;
        var canvasHeight = canvasRect.height;
        var squareValue = 0f;
        if (canvasWidth > canvasHeight)
        {
            //landscape
            squareValue = canvasWidth;
        }
        else
        {
            //portrait
            squareValue = canvasHeight;
        }

        blackScreen.rectTransform.sizeDelta = new Vector2(squareValue, squareValue);
    }

    private IEnumerator Transition(float duration, float beginRadius, float endRadius)
    {
        var time = 0f;
        while (time <= duration)
        {
            time += Time.deltaTime;
            var t = time / duration;
            var radius = Mathf.Lerp(beginRadius, endRadius, t);
            blackScreen.material.SetFloat(Radius, radius);
            yield return null;
        }

        transitionInProgress = false;
    }
    
}