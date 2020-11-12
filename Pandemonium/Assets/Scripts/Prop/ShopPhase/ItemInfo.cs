using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;



public class ItemInfo : MonoBehaviour
{
    public string itemName;
    public int price;
    public int moneyRequirement;   //Minimum money to use this item (For coin cup challenge items)
    public int itemSlot; //Which slot it is in the store (For display)
    public Vector3 itemLoc;
    public bool isUsed;
    public bool selfUse;            //Is it used on the player or someone else?
    public bool isChallenge;        //Is this item a challenge item?
    public bool universal;          //Is this item used on everyone?


    public bool controlSwap;
    public bool doomsday;

    public enum ItemCategory
    {
        Buff,
        Challenge,
        Double,
        Sabotage,
        Universal
    }

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
    public ItemCategory itemType;

    public List<StatType> statTypes;    //What stat types this item changes
    public List<float> statMod;         //Changes by how much


    public List<WinChange> winChanges;  //Self consenquences of your challenge if you win
    public List<float> winMod;          //Changes by how much if you win


    public List<LoseChange> loseChanges;    //Self consenquences of your challenge if you lose
    public List<float> loseMod;             //Vice versa

    // Start is called before the first frame update
    void Start()
    {
        DetermineItemLoc();
        this.transform.position = itemLoc;
    }

    // Update is called once per frame
    void Update()
    {
             
    }

    public void DetermineItemLoc()
    {
        itemLoc = new Vector3(0, 0, 0);
        if(itemType == ItemCategory.Buff)
        {
            switch(itemSlot)
            {
                case 0:

                    break;

                case 1:

                    break;
                case 2:

                    break;
            }
        }
        else if(itemType == ItemCategory.Challenge)
        {
            switch (itemSlot)
            {
                case 0:

                    break;

                case 1:

                    break;
                case 2:

                    break;
            }
        }
        else if(itemType == ItemCategory.Double)
        {
            switch (itemSlot)
            {
                case 0:

                    break;

                case 1:

                    break;
                case 2:

                    break;
            }
        }
        else if (itemType == ItemCategory.Sabotage)
        {
            switch (itemSlot)
            {
                case 0:
                    itemLoc = new Vector3(-33.3f, 0f, 0f);
                    break;

                case 1:
                    itemLoc = new Vector3(-26f, 0f, 0f);
                    break;
                case 2:
                    itemLoc = new Vector3(-17.9f, 0f, 0f);
                    break;
            }
        }
        else if (itemType == ItemCategory.Universal)
        {
            switch (itemSlot)
            {
                case 0:

                    break;

                case 1:

                    break;
                case 2:

                    break;
            }
        }
    }
}