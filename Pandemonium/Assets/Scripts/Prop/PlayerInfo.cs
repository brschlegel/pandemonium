using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerNumber; //Green = 0, Blue = 1, Purple = 2, Yellow = 3
    public int score; //Total score across all mini-games
    public int money;
    public float speed;
    public float size;
    public float dashDistance;
    public float dashPower;
    public float knockback;
    public float moneyModifier;

    public ItemInfo item;

    public string color;
    void Start()
    {
        name = gameObject.name;
        score = 0;
        money = 0;
        speed = 10f;
        size = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
