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
    public bool allowBuying;
    private List<Transform> playerList = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        maxRange = 5;
        DisplayInventory();
        GetPlayers();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void DisplayInventory()
    {
        speechBubble = Instantiate(speechBubble, DetermineBubbleLoc(), Quaternion.identity);
        for(int i = 0; i < inventory.Count; ++i)
        {
            inventory[i] = Instantiate(inventory[i], new Vector3(0,0,0), inventory[i].transform.rotation);
            inventory[i].GetComponent<ItemInfo>().shopNum = shopNumber;
        }
    }

    public void GetPlayers()
    {
        GameObject inputManager = GameObject.Find("InputManager");
        foreach (Transform child in inputManager.transform)
        {
            playerList.Add(child);
            Debug.Log(child.GetComponent<PlayerInfo>().money);
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

    public void DetectNearbyPlayers(List<GameObject> PlayerList) //This code is really slow... should make it better
    {
        for (int i = 0; i < PlayerList.Count; i++)
        {
            if (Vector3.Distance(transform.position, PlayerList[i].transform.position) < maxRange) //If the distance between the shop and player is less than the max range...
            {
                allowBuying = true;
            }
            else
            {
                allowBuying = false;
            }
        }
    }

}
