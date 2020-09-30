using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining; //Timer's total game time
    public float beginAfter; //Starts game timer after x seconds, default is 0. This is for countdowns, game intros etc.
    private bool timerRunning;
    public Text timerText;
    public GameObject canvas;

    public string timerFont;
    public int timerFontSize;
    public Vector2 timerBoxSize;
    public Vector3 timerLocation;
    public Color timerColor;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = false;
        CreateTimer(timerFont,timerFontSize,timerBoxSize,timerLocation,timerColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (beginAfter >= 0) //Checks to see if there's a countdown before timer starts
        {
            beginAfter -= Time.deltaTime;
            if (beginAfter <= 0)
            {
                timerRunning = true;
            }
        }
        if (timeRemaining > 0 && timerRunning == true)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                timeRemaining = 0; //This prevents the timer text from showing -1 
            }
            DisplayTime(timeRemaining);
        }
        else //After hitting 0, stops the timer and triggers the end of the game
        {
            timerRunning = false;
            //trigger end of the game here
        }
    }

    public void CreateTimer(string timerFont, int timerFontSize, Vector2 timerBoxSize, Vector3 timerBoxLocation, Color timerColor)
    {
        GameObject parentText = new GameObject("TimerText");
        parentText.transform.SetParent(canvas.transform, false); //Set its parent to the attached canvas
        timerText = parentText.AddComponent<Text>();

        timerText.text = string.Format("Time Left: {0:0}", timeRemaining); //Displays filler text if there's a countdown before timer starts
        timerText.font = Resources.GetBuiltinResource(typeof(Font), timerFont) as Font;

        timerText.fontSize = timerFontSize;
        timerText.rectTransform.sizeDelta = timerBoxSize;
        timerText.rectTransform.position = timerBoxLocation; 
        timerText.color = timerColor;
    }

    void DisplayTime(float timeToDisplay)
    {
        float timeLeft = Mathf.FloorToInt(timeToDisplay);

        timerText.text = string.Format("Time Left: {0:0}", timeLeft);
    }
}

