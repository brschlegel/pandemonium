using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManger : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> playerList = new List<Transform>();
    public List<string> winners = new List<string>();
    public Text winnerText;
    void Start()
    {
        CreatePlayerList();
        FindWinner();
        DisplayWinnerText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindWinner()
    {
        for(int i = 0; i < playerList.Count; ++i)
        {
            int highestScore = 0;
            if(playerList[i].GetComponent<PlayerInfo>().score >= highestScore)
            {
                winners.Add(playerList[i].GetComponent<PlayerInfo>().color);
                highestScore = playerList[i].GetComponent<PlayerInfo>().score;
            }
        }
    }

    public void CreatePlayerList()
    {
        GameObject InputManager = GameObject.Find("InputManager");
        foreach (Transform child in InputManager.transform)
        {
            playerList.Add(child);

        }
    }

    public void DisplayWinnerText()
    {
        for(int i = 0; i > winners.Count; ++i)
        {
            if(winners.Count > 1)
            {
                if(i != winners.Count - 1)
                {
                    winnerText.text += winners[i];
                }
                else
                {
                    winnerText.text += winners[i] + ", ";
                }
            }
            else
            {
                winnerText.text += winners[i];
            }
        }
    }
}
