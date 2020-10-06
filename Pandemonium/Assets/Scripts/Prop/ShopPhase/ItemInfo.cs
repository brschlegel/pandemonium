using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;



public class ItemInfo : MonoBehaviour
{
    public string itemName;
    public uint price;
    public uint moneyRequirement;   //Minimum money to use this item (For coin cup challenge items)
    public bool isUsed;
    public bool selfUse;            //Is it used on the player or someone else?
    public bool isChallenge;        //Is this item a challenge item?
    public bool universal;          //Is this item used on everyone?


    public bool controlSwap;
    public bool doomsday;

    public enum WinChange
    {
        MoneyAmount,
        Speed,
        Size,
        Dash
    }

    public enum LoseChange
    {
        MoneyAmount,
        Speed,
        Size,
        Dash
    }

    public enum StatType
    {
        Speed,
        Size,
        DashDistance,
        DashPower,
        Knockback,
        MoneyModifier
    }
    public List<StatType> statTypes;    //What stat types this item changes
    public List<float> statMod;         //Changes by how much


    public List<WinChange> winChanges;  //Self consenquences of your challenge if you win
    public List<float> winMod;          //Changes by how much if you win


    public List<LoseChange> loseChanges;    //Self consenquences of your challenge if you lose
    public List<float> loseMod;             //Vice versa

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
             
    }
}