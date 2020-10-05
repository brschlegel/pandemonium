using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Windows.Speech;
using UnityEngine.WSA;

public class ShopManager : MonoBehaviour
{
    // "Spawn all shops and populate their item lists"
    // How do we lay out the item lists?
    // -> n shopPrefabs -> 3 items each
    // do: for n shops, choose 3 items 
    // build the prefabs, fill

    // Shop:
    // - Shop Script
    //      - List<GameObjects>

    // Items:
    // = ItemInfo Script
    //      - ... 

    // PlayerInfo {List<GameObject> items <- each has ItemInfo}
    // 

    private System.Random rand;
    // Start is called before the first frame update
    public List<int> shopList;

    public enum ShopType : UInt16
    {
        Buff,
        Nerf,
        Double,
        Challenge,
        Universal,
        ShopType_Count
    };

 

    public GameObject shopPrefab;
    public List<Vector3> shopLocList;

    public int numOfSpawnedShops;
    public int numItemsPerShop;

    public List<GameObject> buffShopInventory;
    public List<GameObject> nerfShopInventory;
    public List<GameObject> doubleShopInventory;
    public List<GameObject> challengeShopInventory;
    public List<GameObject> universalShopInventory;

    void Start()
    {
        rand = new System.Random();
        DetermineShopLoc();
        ShopSetup(numOfSpawnedShops); //Picks random shops and puts data into a dictionary with empty lists
        CreateShops();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DetermineShopLoc()
    {
        shopLocList = new List<Vector3>();
        shopLocList.Add(new Vector3(1.8f, 5.24f, 1.8f));
        shopLocList.Add(new Vector3(15.4f, 5.24f, 1.8f));
        shopLocList.Add(new Vector3(29.7f, 5.24f, 1.8f));
    }
    public void ShopSetup(int neededShopNumber)
    {
        shopList = ChooseShops(neededShopNumber); //Chooses the shops that will show up and saves it into a list
    }

    public void CreateShops()
    {
        for(int i = 0; i < shopList.Count; ++i)
        {
            GameObject shop = Instantiate(shopPrefab,shopLocList[i], Quaternion.identity);
            ShopInfo si = shop.GetComponent<ShopInfo>();

            switch (shopList[i])
            {
                case 0: //Buff
                    si.shopName = "Self-Buff Store";
                    si.inventory = ChooseRandomItems(buffShopInventory, 3);
                    break;
                case 1: //Nerf
                    si.shopName = "Sabotage Store";
                    si.inventory = ChooseRandomItems(nerfShopInventory, 3);
                    break;
                case 2: //Double
                    si.shopName = "Double-Edged Store";
                    si.inventory = ChooseRandomItems(doubleShopInventory, 3);
                    break;
                case 3: //Challenge
                    si.shopName = "Challenge Store";
                    si.inventory = ChooseRandomItems(challengeShopInventory, 3);
                    break;
                case 4: //Universal
                    si.shopName = "Universal Store";
                    si.inventory = ChooseRandomItems(universalShopInventory, 3);
                    break;

                default:
                    break;

            }
        }
    }

    public List<GameObject> ChooseRandomItems(List<GameObject> itemList, int numChosen)
    {
        int count = 0;
        bool isDuplicate = false;
        int tempNum;
        List<int> tempList = new List<int>();
        List<GameObject> chosenItems = new List<GameObject>();
        while(count != numChosen)
        {
            if(count == 0)
            {
                tempNum = rand.Next(0, itemList.Count);
                tempList.Add(tempNum);
                chosenItems.Add(itemList[tempNum]);
                ++count;
            }
            tempNum = rand.Next(0, itemList.Count);
            isDuplicate = false;
            for(int i = 0; i < tempList.Count; ++i)
            {
                if(tempList[i] == tempNum)
                {
                    isDuplicate = true;
                }
            }
            if(isDuplicate == false)
            {
                tempList.Add(tempNum);
                chosenItems.Add(itemList[tempNum]);
                ++count;
            }
        }
        return chosenItems;
    }

    public List<int> ChooseShops(int neededShopNumber)
    {
        const UInt16 numShops = (UInt16)ShopType.ShopType_Count;

        bool isDuplicate;
        List<int> tempList = new List<int>();
        int count = 0;
        int tempNum;
        while (count != neededShopNumber) //Runs until there's the right amount of shops with no duplicates
        {
            if (count == 0) //The first shop will never be a duplicate
            {
                tempNum = rand.Next(0, numShops);
                tempList.Add(tempNum);
                ++count;
            }
            tempNum = rand.Next(0, numShops);
            isDuplicate = false; //Resets it back to false
            for (int i = 0; i < tempList.Count; ++i) //Loops through the finished list to see if there's a duplicate
            {
                if (tempList[i] == tempNum) //If there's a duplicate set it to true
                {
                    isDuplicate = true;
                }
            }
            if (isDuplicate == false) //Only adds the number to the list if isDuplicate is false
            {
                tempList.Add(tempNum);
                ++count;
            }

        }
        return tempList; //Returns the finished list
    }

   
}
