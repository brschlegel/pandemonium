using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        maxRange = 5;
        Debug.Log(this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayInventory()
    {
        //Code that does the visuals
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
