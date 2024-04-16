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

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        DrawBlackScreen();
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
}