using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    public Text Green; //0 in player list
    public Text Blue; //1
    public Text Purple; //2
    public Text Yellow; //3
    private List<Transform> playerList = new List<Transform>();

    void Start()
    {
        GetPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        Green.text = "Green: " + playerList[0].GetComponent<PlayerInfo>().money;
        Blue.text = "Blue: " + playerList[1].GetComponent<PlayerInfo>().money;
        Purple.text = "Purple " + playerList[2].GetComponent<PlayerInfo>().money;
        Yellow.text = "Yellow " + playerList[3].GetComponent<PlayerInfo>().money;
    }

    public void GetPlayers()
    {
        GameObject inputManager = GameObject.Find("InputManager");
        foreach (Transform child in inputManager.transform)
        {
            playerList.Add(child);
        }
    }
}
