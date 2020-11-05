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
    // Start is called before the first frame update
    void Start()
    {
        maxRange = 5;
        DisplayInventory();
        Debug.Log(shopNumber);
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
            inventory[i] = Instantiate(inventory[i], DetermineItemLoc(i), inventory[i].transform.rotation);
        }
    }

    public Vector3 DetermineItemLoc(int itemNum)
    {
        switch (itemNum)
        {
            case 0:
                return new Vector3(speechBubble.transform.position.x + 3.6f, speechBubble.transform.position.y, speechBubble.transform.position.z - 3);
            case 1:
                return new Vector3(speechBubble.transform.position.x - .7f, speechBubble.transform.position.y, speechBubble.transform.position.z - 3);
            case 2:
                return new Vector3(speechBubble.transform.position.x - 4f, speechBubble.transform.position.y, speechBubble.transform.position.z - 3);

        }
        return new Vector3(0, 0, 0); //Should never hit this
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

            }
        }
    }

}
