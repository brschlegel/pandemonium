using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameScoresManager : MonoBehaviour
{
    public AudioSource winSound;
    //This is for the current mini-game's score. Not overall
    private List<GameObject> Players; //I'd like to make it so I can just reference this somewhere someday without making a new list of players each time
    private List<int> PlayerGameScores;
    private List<string> colors = new List<string>();
    public bool isActive; // Allows players to score

    public GameObject canvas;
    public Text TempWinnerText; //In the full game, the winner isn't displayed in this scene

    public Text Green_Score_txt;
    public Text Blue_Score_txt;
    public Text Purple_Score_txt;
    public Text Yellow_Score_txt;
    

    void Start()
    {
        if(TempWinnerText != null)
        {
            TempWinnerText.gameObject.SetActive(false); //Disabled in the beginning
        }
        GameScoreSetup();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GameScoreSetup()
    {
        isActive = false;
        PlayerGameScores = new List<int>();
        colors.AddRange(new List<string> { "Green", "Blue", "Purple", "Yellow" }); //This makes it so it doesn't always display 4 people's worth of scores every time
        for (int i = 0; i < 4; i++) //4 is hardcoded in for testing purposes, will change to Player count later
        {
            PlayerGameScores.Add(0); //Everyone starts the mini-game with 0 points.
        }
    }

    public Text CreateText(int playerNumber, string fontName, int fontSize, Vector2 textBoxSize, Vector3 pos, int xOffset, int yOffset)
    {
        GameObject parentText = new GameObject("GameScoreText");
        parentText.transform.SetParent(canvas.transform); //Set its parent to the attached canvas
        Text tempText = parentText.AddComponent<Text>();

        tempText.text = colors[playerNumber] + ": " + PlayerGameScores[playerNumber]; //Ex. Red: 3
        tempText.font = Resources.GetBuiltinResource(typeof(Font), fontName) as Font; //This lets us easily change the font to whatever we want. Ex. FontName.ttf
        tempText.rectTransform.sizeDelta = textBoxSize; //Size of the box surrounding the text. This affects placement
        tempText.transform.position = new Vector3(pos.x + (xOffset * playerNumber), pos.y + (yOffset * playerNumber), pos.z); //Location of the text with offset. Should keep it the same despite different devices
        tempText.fontSize = fontSize; //Font size
        return tempText;
    }
    public void Player0Score()
    {
        if (isActive == true)
        {
            PlayerGameScores[0] += 1;
            Green_Score_txt.text = PlayerGameScores[0].ToString();
}
    }

    public void Player1Score()
    {
        if(isActive == true)
        {
            PlayerGameScores[1] += 1;
            Blue_Score_txt.text = PlayerGameScores[1].ToString();
        }
    }

    public void Player2Score()
    {
        if(isActive == true)
        {
            PlayerGameScores[2] += 1;
            Purple_Score_txt.text = PlayerGameScores[2].ToString();
        }
    }

    public void Player3Score()
    {
        if(isActive == true)
        {
            PlayerGameScores[3] += 1;
            Yellow_Score_txt.text = PlayerGameScores[3].ToString();
        }
    }

    public void AllowScoring()
    {
        isActive = true;
    }

    public void DisableScoring()
    {
        isActive = false;
    }

    public void FindWinner()
    {
        int currentLowestScore = 1000; //This helps with deciding ties since no one should get 1000 points
        List<string> colorWithHighestScore = new List<string>(); //Red = 0; Green = 1; Yellow = 2; Blue = 3;
        List<GameObject> ListofWinners = new List<GameObject>();
        int index = -1;
        for(int i = 0; i < PlayerGameScores.Count; ++i)
        {
            if(PlayerGameScores[i] <= currentLowestScore)
            {
                currentLowestScore = PlayerGameScores[i];
                index = i;
            }
        }
        colorWithHighestScore.Add(colors[index]);
        PlayerGameScores.RemoveAt(index); //Removes the highest score from the list to make it easier to calculate ties
        colors.RemoveAt(index); //Remove the color from the pool of possible ties
        //Players.RemoveAt(index); //This might break something, but I'd need to test it first. Also there's currently no list of players
        //ListofWinners.Add(Players[index]); //Add that player to a list of winners for this mini-game
        for (int i = 0; i < PlayerGameScores.Count; ++i)
        {
            if(PlayerGameScores[i] == currentLowestScore)
            {
                colorWithHighestScore.Add(colors[i]);
                //ListofWinners.Add(Players[i]); List of players doesn't exist yet
            }
        }
        DisplayWinner(colorWithHighestScore, currentLowestScore);
    }

    public void DisplayWinner(List<string> colorsWithHighestScore, int highestScore)
    {
        TempWinnerText.gameObject.SetActive(true);
        if(colorsWithHighestScore.Count > 1) //There's a tie
        {
            TempWinnerText.text = "Winners are ";
            Debug.Log(colorsWithHighestScore.Count + " is count");
            for(int i = 0; i < colorsWithHighestScore.Count; i++)
            {
                if (i != colorsWithHighestScore.Count-1)
                {
                    TempWinnerText.text = TempWinnerText.text + colorsWithHighestScore[i] + ", ";
                }
                else //No comma since it's the last winner
                {
                    TempWinnerText.text = TempWinnerText.text + "and " + colorsWithHighestScore[i] + " ";
                }
            }
            TempWinnerText.text = TempWinnerText.text + "with a score of " + highestScore + "!";
        }
        else //No tie only 1 winner
        {
            winSound.Play();
            TempWinnerText.text = colorsWithHighestScore[0] + " wins with a score of " + highestScore + "!";
        }
        
    }
}
