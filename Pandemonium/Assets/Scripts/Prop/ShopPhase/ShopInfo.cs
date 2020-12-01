using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class ShopInfo : MonoBehaviour
{
    // interaction code:
    // - displaying items (price, name, picture)
    // - input handling and buying
    // - item (GameObject) destruction

    public string shopName;
    public List<GameObject> inventory;
    private int maxRange; //Max range for the shops to serve the player
    public int shopNumber;
    public GameObject speechBubble;
    public List<Transform> playerList = new List<Transform>();
    public List<Vector3> plateLoc = new List<Vector3>();
    public List<GameObject> plateList = new List<GameObject>();
    public GameObject platePrefab;
    // Start is called before the first frame update
    void Start()
    {
        DeterminePlateLoc();
        CreatePlayerList();
        maxRange = 3;
        DisplayInventory();
        ChangePlateColor();
    }

    // Update is called once per frame
    void Update()
    {
        DetectNearbyPlayers();
    }

    public void CreatePlayerList()
    {
        GameObject InputManager = GameObject.Find("InputManager");
        foreach (Transform child in InputManager.transform)
        {
            playerList.Add(child);

        }
    }

    public void DisplayInventory()
    {
        speechBubble = Instantiate(speechBubble, DetermineBubbleLoc(), Quaternion.identity);
        for(int i = 0; i < inventory.Count; ++i)
        {
            inventory[i] = Instantiate(inventory[i], new Vector3(0,0,0), inventory[i].transform.rotation);
            inventory[i].GetComponent<ItemInfo>().shopNum = shopNumber;
            GameObject tempPlate = Instantiate(platePrefab, plateLoc[i], Quaternion.identity);
            plateList.Add(tempPlate);
        }
    }

  
    public Vector3 DetermineBubbleLoc()
    {
        switch (shopNumber)
        {
            case 0:
                return new Vector3(transform.position.x + 3.6f, transform.position.y + 16.5f, transform.position.z - 11);
            case 1:
                return new Vector3(transform.position.x - .7f, transform.position.y + 16.5f, transform.position.z - 11);
            case 2:
                return new Vector3(transform.position.x - 4f, transform.position.y + 16.5f, transform.position.z - 11);

        }
        return new Vector3(0, 0, 0); //Should never hit this

    }

    public void ChangePlateColor()
    {
        for(int i = 0; i < plateList.Count; ++i)
        {
            switch(i)
            {
                case 0:
                    plateList[i].GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 1:
                    plateList[i].GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 2:
                    plateList[i].GetComponent<Renderer>().material.color = Color.blue;
                    break;
            }
        }
    }

    public void DeterminePlateLoc()
    {
        plateLoc.Add(new Vector3(transform.position.x - 7f, 0, 3.5f));
        plateLoc.Add(new Vector3(transform.position.x, 0, 3.5f));
        plateLoc.Add(new Vector3(transform.position.x + 7f, 0, 3.5f));
    }

    public void DetectNearbyPlayers() //This code is really slow... should make it better
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            for(int j = 0; j < plateList.Count; j++)
            {
                if (Vector3.Distance(plateList[j].transform.position, playerList[i].transform.position) < maxRange) //If the distance between the shop and player is less than the max range...
                {
                    if(playerList[i].GetComponent<PlayerInfo>().money >= inventory[j].GetComponent<ItemInfo>().price && inventory[j].GetComponent<ItemInfo>().isBought == false)
                    {
                        playerList[i].GetComponent<PlayerInfo>().inventory.Add(inventory[j]);
                        playerList[i].GetComponent<PlayerInfo>().money -= inventory[j].GetComponent<ItemInfo>().price;
                        inventory[j].GetComponent<ItemInfo>().isBought = true;
                        plateList[j].GetComponent<Renderer>().material.color = Color.black;

                    }
                }
                else
                {

                    
                }
            }
        }
    }

}
