using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public string playerName;
    public int overallScore;
    public int money;
    List<GameObject> itemInventory;
    void Start()
    {
        playerName = gameObject.name;
        overallScore = 0;
        money = 0;
        itemInventory = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
