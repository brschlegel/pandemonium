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
    public bool countdownOnly;
    public bool instruction;

    public Text timerText;
    public Text startupText;
    public GameObject manager; //Manager the timer is linked to

    public ScoredEvent defaultEvent;
    public List<EventTagMap> eventTagMap;

    public AudioSource StartOnClick;
    public AudioSource bgm;
    public AudioSource win;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = false;
        if (countdownOnly == false)
        {
            timerText.text = string.Format("{0:0}", timeRemaining); //Displays filler text if there's a countdown before timer starts
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (beginAfter >= 0 && instruction == false) //Checks to see if there's a countdown before timer starts
        {
            DisplayStartupText(); //Displays the startup text with the countdown
            beginAfter -= Time.deltaTime;
            if (beginAfter <= 0)
            {
                timerRunning = true;
                startupText.gameObject.SetActive(false); //Hides the startup text
                TriggerStart(); //Lets the game score manager begin to collect points
            }
           
        }
        if (timeRemaining > 0 && timerRunning == true && countdownOnly == false)
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
                TriggerEnd(); //Runs code that happens once timer hits 0
            }
            timerRunning = false; //Stops the timer
        }
    }


    void DisplayTime(float timeToDisplay)
    {
        float timeLeft = Mathf.FloorToInt(timeToDisplay);

        timerText.text = string.Format("{0:0}", timeLeft);
    }

    public void TriggerEnd() //Trigers code that happens after timer runs out
    {
        if (manager.gameObject.tag == "Score")
        {
            eventTagMap[1].tagEvent.Invoke(manager.gameObject); //Runs whatever's under the first tag which is "Disable Scoring"
            bgm.Stop();
            win.Play();
            return;
        }
        else if(manager.gameObject.tag == "Rise")
        {
            eventTagMap[0].tagEvent.Invoke(manager.gameObject); //Runs whatever's under the first tag which is "Enable Water"
            return;
        }
        
    }

    public void TriggerStart() //Allows players to collect points
    {
        if (manager.gameObject.tag == "Score")
        {
            eventTagMap[0].tagEvent.Invoke(manager.gameObject);
            return;
        }
    }

    public void DisplayStartupText()
    {
        startupText.gameObject.SetActive(true);
        float timeLeft = Mathf.FloorToInt(beginAfter);
        startupText.text = string.Format("Game begins in: {0:0}", timeLeft);
    }

    //so countdown timers only starts after player click on startBtn
    public void StartBtnClick()
    {
        instruction = false;
        Debug.Log("button clicked");
    }
    //to play comfirmation UI sound effect
    public void PlaySoundEffect()
    {
        StartOnClick.Play();
        bgm.Play();
    }
}

