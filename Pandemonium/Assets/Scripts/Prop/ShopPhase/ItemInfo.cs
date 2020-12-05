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
    float speedCupOffset = 0;
    float miniMeOffset = 0;
    public Vector3 itemLoc;
    public bool isUsed;
    public bool selfUse;            //Is it used on the player or someone else?
    public bool isChallenge;        //Is this item a challenge item?
    public bool universal;          //Is this item used on everyone?
    public bool isSpeedCup;
    public bool isMiniMe;
    public bool isBought;
    public Text itemPriceText;
    public AudioSource buySound;

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
        buySound = GetComponent<AudioSource>();
        isBought = false;
        BuyButtonList.AddRange(new List<char> { 'X', 'Y', 'A' }); //Which button the user needs to press to buy the button. B is reserved for Dash
        canvas = GameObject.Find("Canvas");
        DetermineItemLoc();
        this.transform.position = itemLoc;
        DisplayPrice();
        isBought2();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBought == true)
        {
            buySound.Play();
            itemPriceText.text = "";
            isBought = false;
        }
    }

    void FixedUpdate()
    {
        
    }

    public void isBought2()
    {
        if (isBought == true)
        {

            
        }
    }
    void OnCollisionEnter()
    {
        buySound.Play();
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
            if (isSpeedCup == true)
            {
                speedCupOffset = -3f;
            }
            switch (itemSlot)
            {
                case 0:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-33f, 18f, 6f + speedCupOffset);
                            break;
                        case 1:
                            itemLoc = new Vector3(-7f, 18f, 6f + speedCupOffset);
                            break;
                        case 2:
                            itemLoc = new Vector3(20f, 18f, 6f + speedCupOffset);
                            break;
                    }
                    break;

                case 1:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-27f, 18f, 6f + speedCupOffset);
                            break;
                        case 1:
                            itemLoc = new Vector3(-1f, 18f, 6f + speedCupOffset);
                            break;
                        case 2:
                            itemLoc = new Vector3(26f, 18f, 6f + speedCupOffset);
                            break;
                    }
                    break;
                case 2:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-21f, 18f, 6f + speedCupOffset);
                            break;
                        case 1:
                            itemLoc = new Vector3(5f, 18f, 6f + speedCupOffset);
                            break;
                        case 2:
                            itemLoc = new Vector3(32f, 18f, 6f + speedCupOffset);
                            break;
                    }
                    break;
            }
        }
        else if(itemType == ItemCategory.Double)
        {
            if (isMiniMe == true)
            {
                miniMeOffset = 1.3f;
            }
            switch (itemSlot)
            {
                case 0:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-33f, 18.7f + miniMeOffset, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-7f, 18.7f + miniMeOffset, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(20f, 18.7f + miniMeOffset, 3f);
                            break;
                    }
                    break;

                case 1:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-27f, 18.7f + miniMeOffset, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(-1f, 18.7f + miniMeOffset, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(26f, 18.7f + miniMeOffset, 3f);
                            break;
                    }
                    break;
                case 2:
                    switch (shopNum)
                    {
                        case 0:
                            itemLoc = new Vector3(-21f, 18.7f + miniMeOffset, 3f);
                            break;
                        case 1:
                            itemLoc = new Vector3(6f, 18.7f + miniMeOffset, 3f);
                            break;
                        case 2:
                            itemLoc = new Vector3(32f, 18.7f + miniMeOffset, 3f);
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
        float yOffset = 0;
        float addXOffset = 0;
        float addYOffset = 0;
        float addZOffset = 0;
        if(shopNum == 0)
        {
            xOffset = 2.6f;
            if (isSpeedCup == true)
            {
                addZOffset = speedCupOffset;
                addXOffset = 1.3f;
            }
        }
        else if(shopNum == 1)
        {
            xOffset = .7f;
            if (isSpeedCup == true)
            {
                addZOffset = speedCupOffset;
            }
        }
        else if(shopNum == 2)
        {
            xOffset = -1.3f;
            if (isSpeedCup == true)
            {
                addZOffset = speedCupOffset;
                addXOffset = -1.3f;
            }
        }
        if(isMiniMe == true)
        {
            addYOffset = -miniMeOffset;
        }
        itemPriceText = Instantiate(CreateText("Arial.ttf", 14, new Vector2(50, 20), xOffset, yOffset, addXOffset, addYOffset, addZOffset));
        

    }

    public Text CreateText(string fontName, int fontSize, Vector2 textBoxSize, float xOffset, float yOffset, float addXOffset, float addYOffset, float addZOffset)
    {
        GameObject parentText = new GameObject("PriceText");
        parentText.layer = LayerMask.NameToLayer("UI");
        parentText.transform.SetParent(canvas.transform); //Set its parent to the the item prefab
        Text tempText = parentText.AddComponent<Text>();

        tempText.text = price + ""; //Ex. price (X)
        tempText.color = Color.black;
        tempText.font = Resources.GetBuiltinResource(typeof(Font), fontName) as Font; //This lets us easily change the font to whatever we want. Ex. FontName.ttf
        tempText.rectTransform.sizeDelta = textBoxSize; //Size of the box surrounding the text. This affects placement
        tempText.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x+xOffset+addXOffset, transform.position.y-1.2f+yOffset+addYOffset, 0+addZOffset)); //Location of the text with offset. Should keep it the same despite different devices
     
        tempText.fontSize = fontSize; //Font size
        return tempText;
    }
    
}
