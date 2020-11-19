using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopTimer : MonoBehaviour
{
    public float timeRemaining; //Timer's total game time
    public float beginAfter; //Starts game timer after x seconds, default is 0. This is for countdowns, game intros etc.
    private bool timerRunning;
    public Text timerText;
    public Text startupText;

    public ScoredEvent defaultEvent;
    public List<EventTagMap> eventTagMap;

    // Start is called before the first frame update
    void Start()
    {
        timerText.gameObject.SetActive(false);
        timerRunning = false;
        timerText.text = string.Format("Time Left: {0:0}", timeRemaining); //Displays filler text if there's a countdown before timer starts
    }

    // Update is called once per frame
    void Update()
    {
        if (beginAfter >= 0) //Checks to see if there's a countdown before timer starts
        {
            DisplayStartupText(); //Displays the startup text with the countdown
            beginAfter -= Time.deltaTime;
            if (beginAfter <= 0)
            {
                timerText.gameObject.SetActive(true);
                timerRunning = true;
                startupText.gameObject.SetActive(false); //Hides the startup text
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
            if (timerRunning == true)
            {
                TriggerEnd(); //Stops the game score manager from getting additional points
            }
            timerRunning = false; //Stops the timer
        }
    }


    void DisplayTime(float timeToDisplay)
    {
        float timeLeft = Mathf.FloorToInt(timeToDisplay);

        timerText.text = string.Format("Time Left: {0:0}", timeLeft);
    }

    public void TriggerEnd()
    {
        timerText.gameObject.SetActive(false);
        startupText.text = "Phase end!";
        startupText.gameObject.SetActive(true);
    }

    public void DisplayStartupText()
    {
        startupText.gameObject.SetActive(true);
        float timeLeft = Mathf.FloorToInt(beginAfter);
        startupText.text = string.Format("{0:0}", timeLeft);
    }
}

