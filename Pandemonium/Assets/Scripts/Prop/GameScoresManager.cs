using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameScoresManager : MonoBehaviour
{
    //This is for the current mini-game's score
    private List<GameObject> Players; //I'd like to make it so I can just reference this somewhere someday without making a new list of players each time
    private List<int> PlayerGameScores;
    private List<Text> PlayerScoreTextList;
    private List<string> colors = new List<string>();

    public GameObject canvas;


    public string currentMinigame; //There's no way to put variables in the text inspector so this keeps the script universal
    void Start()
    {
        GameScoreSetup();
        CreateScoreText();
        Player0Score();
        Player1Score();
        Player2Score();
        Player3Score();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GameScoreSetup()
    {
        PlayerGameScores = new List<int>();
        PlayerScoreTextList = new List<Text>();
        colors.AddRange(new List<string> { "Red", "Blue", "Green", "Yellow" }); //This makes it so it doesn't always display 4 people's worth of scores every time
        for (int i = 0; i < 4; i++) //4 is hardcoded in for testing purposes, will change to Player count later
        {
            PlayerGameScores.Add(-1); //Everyone starts the mini-game with 0 points. -1 is because all the score functions run once at start. Should fix this
            Debug.Log("Player " + i + " has a score of " + PlayerGameScores[i]);
        }
    }

    public void CreateScoreText() //Creates and displays the current # of points depending on the mini-game and # of players
    {
        if(currentMinigame == "Soccer")
        {

            for(int i = 0; i < 4; i++)
            {
                PlayerScoreTextList.Add(CreateText(i,"Arial.ttf",14, new Vector2(80,30), new Vector3((Screen.width / 10), Screen.height - (Screen.height / 15), 0f), Screen.width / 6, 0)); //Add to a list so I can reference it later
            }
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
        PlayerGameScores[0] += 1;
        PlayerScoreTextList[0].text = colors[0] + ": " + PlayerGameScores[0];
    }

    public void Player1Score()
    {
        PlayerGameScores[1] += 1;
        PlayerScoreTextList[1].text = colors[1] + ": " + PlayerGameScores[1];
    }

    public void Player2Score()
    {
        PlayerGameScores[2] += 1;
        PlayerScoreTextList[2].text = colors[2] + ": " + PlayerGameScores[2];
    }

    public void Player3Score()
    {
        PlayerGameScores[3] += 1;
        PlayerScoreTextList[3].text = colors[3] + ": " + PlayerGameScores[3];
    }




}
