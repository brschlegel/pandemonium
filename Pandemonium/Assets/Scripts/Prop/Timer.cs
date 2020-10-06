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
    public GameObject gameScoreManager; //Score manager the timer is linked to

    public ScoredEvent defaultEvent;
    public List<EventTagMap> eventTagMap;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = false;
        timerText.text = string.Format("Time Left: {0:0}", timeRemaining); //Displays filler text if there's a countdown before timer starts
    }

    // Update is called once per frame
    void Update()
    {
        if (beginAfter >= 0) //Checks to see if there's a countdown before timer starts
        {
            Debug.Log("Players cannot collect points for another " + beginAfter + " seconds");
            beginAfter -= Time.deltaTime;
            if (beginAfter <= 0)
            {
                timerRunning = true;
                TriggerStart(gameScoreManager); //Lets the game score manager begin to collect points
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
            if(timerRunning == true)
            {
                TriggerEnd(gameScoreManager); //Stops the game score manager from getting additional points
            }
            timerRunning = false; //Stops the timer
        }
    }


    void DisplayTime(float timeToDisplay)
    {
        float timeLeft = Mathf.FloorToInt(timeToDisplay);

        timerText.text = string.Format("Time Left: {0:0}", timeLeft);
    }

    public void TriggerEnd(GameObject ScoreManager) //Disables players from collecting points
    {
        if (ScoreManager.gameObject.tag == "Score")
        {
            Debug.Log("Players can no longer collect points");
            eventTagMap[1].tagEvent.Invoke(ScoreManager.gameObject); //Runs whatever's under the first tag which is "Disable Scoring"
            return;
        }
    }

    public void TriggerStart(GameObject ScoreManager) //Allows players to collect points
    {
        if (ScoreManager.gameObject.tag == "Score")
        {
            Debug.Log("Players can now collect points for " + timeRemaining + " seconds");
            eventTagMap[0].tagEvent.Invoke(ScoreManager.gameObject);
            return;
        }
    }
}

