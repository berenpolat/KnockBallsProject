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

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        DrawBlackScreen();
    }

    private void Update()
    {
        //When we run out of balls the coroutine starts
        if (Input.GetKeyDown(KeyCode.A))
        {
            OpenBlackScreen();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            CloseBlackScreen();
        }
    }

    public void OpenBlackScreen()
    {
        StartCoroutine(Transition(2, 0, 1));
    }

    public void CloseBlackScreen()
    {
        StartCoroutine(Transition(2, 1, 0));
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
    }
}