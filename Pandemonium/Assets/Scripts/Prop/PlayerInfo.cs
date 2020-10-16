using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public string name;
    public int score;
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
