using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerNumber; //Green = 0, Blue = 1, Purple = 2, Yellow = 3
    public int score; //Total score across all mini-games
    public int money;
    void Start()
    {
        name = gameObject.name;
        score = 0;
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
