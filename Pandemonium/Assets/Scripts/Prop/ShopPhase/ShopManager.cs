using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private System.Random rand;

    public enum ShopType
    {
        Buff,
        Nerf,
        Double,
        Challenge,
        Universal,
        Count // <-- # of distinct shop types
    };

    public GameObject buffShopPrefab;
    public GameObject sabotageShopPrefab;
    public GameObject doubleShopPrefab;
    public GameObject challengeShopPrefab;
    public GameObject universalShopPrefab;

    public int shopCount;
    public int itemCount;

    // Master lists of possible items
    public List<GameObject> buffShopCatalogue;
    public List<GameObject> sabotageShopCatalogue;
    public List<GameObject> doubleShopCatalogue;
    public List<GameObject> challengeShopCatalogue;
    public List<GameObject> universalShopCatalogue;

    public List<Vector3> shopLocList;

    // List of randomly picked shops
    public List<ShopType> shopList;

    void Start()
    {
        rand = new System.Random();

        // Determine temporary world positions for the shops
        DetermineShopLoc();

        // Chooses "numOfSpawnedShops" random shop types and adds it to a collection
        PickRandomShops();
        
        // Chooses "numItemsPerShop" random item types for that particular shop type and populates the list in ShopInfo.cs
        PopulateShopInventories();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DetermineShopLoc()
    {
        shopLocList = new List<Vector3>();
        shopLocList.Add(new Vector3(-30f, 4f, 15f));
        shopLocList.Add(new Vector3(0f, 4f, 15f));
        shopLocList.Add(new Vector3(30f, 4f, 15f));
    }

    /// <summary>
    /// Utility function to pick random elements out of a master list
    /// </summary>
    /// <typeparam name="T">The type of the list templates passed in.</typeparam>
    /// <param name="mainList">Master list to choose items from</param>
    /// <param name="out_subList">Returned sub list</param>
    /// <param name="pickCount">Number of random elements</param>
    private void GenerateSubList<T>(List<T> mainList, out List<T> out_subList, int pickCount)
    {
        // Alloc new sub list
        List<T> subList = new List<T>();
        
        // Hold seen elements
        HashSet<int> seenIndices = new HashSet<int>();

        int randNum;
        int count = 0;
        while (count != pickCount)
        {
            // Pick random index from main list
            randNum = rand.Next(0, mainList.Count);

            // If unique, add it to sub list and mark as seen
            if (!seenIndices.Contains(randNum))
            {
                seenIndices.Add(randNum);
                subList.Add(mainList[randNum]);
                ++count;
            }
        }

        // Return sub list
        out_subList = subList;
    }

    public void PickRandomShops()
    {
        // Generate list of every type of shop
        List<ShopType> masterShopList = Enumerable.Range(0, (int)ShopType.Count).Select(i => (ShopType)i).ToList();

        // Pick random shops out of master list and add to member field
        GenerateSubList<ShopType>(masterShopList, out shopList, shopCount);
    }

    //Fills created shops with randomly chosen items
    public void PopulateShopInventories()
    {
        for(int i = 0; i < shopList.Count; ++i)
        {
            switch (shopList[i])
            {
                case ShopType.Buff:
                    GameObject shop = Instantiate(buffShopPrefab, shopLocList[i], Quaternion.Euler(0f,-90f,0f));
                    ShopInfo si = shop.GetComponent<ShopInfo>();
                    si.shopName = "Self-Buff Store";
                    GenerateSubList(buffShopCatalogue, out si.inventory, itemCount);
                    break;
                case ShopType.Nerf:
                    shop = Instantiate(sabotageShopPrefab, shopLocList[i], Quaternion.Euler(0f, -90f, 0f));
                    si = shop.GetComponent<ShopInfo>();
                    si.shopName = "Sabotage Store";
                    GenerateSubList(sabotageShopCatalogue, out si.inventory, itemCount);
                    break;
                case ShopType.Double:
                    shop = Instantiate(doubleShopPrefab, shopLocList[i], Quaternion.Euler(0f, -90f, 0f));
                    si = shop.GetComponent<ShopInfo>();
                    si.shopName = "Double-Edged Store";
                    GenerateSubList(doubleShopCatalogue, out si.inventory, itemCount);
                    break;
                case ShopType.Challenge:
                    shop = Instantiate(challengeShopPrefab, shopLocList[i], Quaternion.Euler(0f, -90f, 0f));
                    si = shop.GetComponent<ShopInfo>();
                    si.shopName = "Challenge Store";
                    GenerateSubList(challengeShopCatalogue, out si.inventory, itemCount);
                    break;
                case ShopType.Universal:
                    shop = Instantiate(universalShopPrefab, shopLocList[i], Quaternion.Euler(0f, -90f, 0f));
                    si = shop.GetComponent<ShopInfo>();
                    si.shopName = "Universal Store";
                    GenerateSubList(universalShopCatalogue, out si.inventory, itemCount);
                    break;
            }
        }
    }
}
