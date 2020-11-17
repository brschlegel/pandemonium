using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using UnityEngine.UI;



public class ItemInfo : MonoBehaviour
{
    public GameObject canvas;
    public List<char> BuyButtonList = new List<char>();
    public string itemName;
    public int price;
    public int moneyRequirement;   //Minimum money to use this item (For coin cup challenge items)
    public int itemSlot; //Which slot it is in the store (For display)
    public int shopNum; //Which store it's in
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
        BuyButtonList.AddRange(new List<char> { 'X', 'Y', 'A' }); //Which button the user needs to press to buy the button. B is reserved for Dash
        canvas = GameObject.Find("Canvas");
        DetermineItemLoc();
        this.transform.position = itemLoc;
        DisplayPrice();
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
            switch (itemSlot)
            {
                case 0:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-33f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-7f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(20f, 18.7f, 3f);
                            break;
                    }
                    break;

                case 1:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-27f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-1f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(26f, 18.7f, 3f);
                            break;
                    }
                    break;
                case 2:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-21f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(6f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(32f, 18.7f, 3f);
                            break;
                    }
                    break;
            }
        }
        else if(itemType == ItemCategory.Challenge)
        {
            switch (itemSlot)
            {
                case 0:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-33f, 18f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-7f, 18f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(20f, 18f, 3f);
                            break;
                    }
                    break;

                case 1:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-27f, 18f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-1f, 18f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(26f, 18f, 3f);
                            break;
                    }
                    break;
                case 2:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-21f, 18f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(5f, 18f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(32f, 18f, 3f);
                            break;
                    }
                    break;
            }
        }
        else if(itemType == ItemCategory.Double)
        {
            switch (itemSlot)
            {
                case 0:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-33f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-7f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(20f, 18.7f, 3f);
                            break;
                    }
                    break;

                case 1:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-27f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-1f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(26f, 18.7f, 3f);
                            break;
                    }
                    break;
                case 2:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-21f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(6f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(32f, 18.7f, 3f);
                            break;
                    }
                    break;
            }
        }
        else if (itemType == ItemCategory.Universal)
        {
            switch (itemSlot)
            {
                case 0:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-33f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-7f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(20f, 18.7f, 3f);
                            break;
                    }
                    break;

                case 1:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-27f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-1f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(26f, 18.7f, 3f);
                            break;
                    }
                    break;
                case 2:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-21f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(6f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(32f, 18.7f, 3f);
                            break;
                    }
                    break;
            }
        }
        else if (itemType == ItemCategory.Sabotage)
        {
            switch (itemSlot)
            {
                case 0:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-33f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-7f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(20f, 18.7f, 3f);
                            break;
                    }
                    break;

                case 1:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-27f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-1f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(26f, 18.7f, 3f);
                            break;
                    }
                    break;
                case 2:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-21f, 18.7f, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(6f, 18.7f, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(32f, 18.7f, 3f);
                            break;
                    }
                    break;
            }
        }
    }

    public void DisplayPrice()
    {
        float xOffset = 0; //Offset for prices depending on which shop they're located at
        if(shopNum == 0)
        {
            xOffset = 2.6f;
        }
        else if(shopNum == 2)
        {
            xOffset = -1.3f;
        }
        Instantiate(CreateText("Arial.ttf", 14, new Vector2(50, 20), xOffset));


    }
    public Text CreateText(string fontName, int fontSize, Vector2 textBoxSize, float xOffset)
    {
        GameObject parentText = new GameObject("PriceText");
        parentText.layer = LayerMask.NameToLayer("UI");
        parentText.transform.SetParent(canvas.transform); //Set its parent to the the item prefab
        Text tempText = parentText.AddComponent<Text>();

        tempText.text = price + " (" + BuyButtonList[itemSlot] + ")"; //Ex. price (X)
        tempText.color = Color.black;
        tempText.font = Resources.GetBuiltinResource(typeof(Font), fontName) as Font; //This lets us easily change the font to whatever we want. Ex. FontName.ttf
        tempText.rectTransform.sizeDelta = textBoxSize; //Size of the box surrounding the text. This affects placement
        tempText.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x+xOffset, transform.position.y-1.2f, 0)); //Location of the text with offset. Should keep it the same despite different devices

        tempText.fontSize = fontSize; //Font size
        return tempText;
    }

}