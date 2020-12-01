using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinerScript : MonoBehaviour
{
    public PlayerInputManager pim;
    public List<GameObject> prefabs;
    public GameObject playerPrefab;
    public InputActionAsset actionMap;

    private string[] colors;
    public List<Material[]> materialPerPlayer;
    public Material[] Player1;
    public Material[] Player2;
    public Material[] Player3;
    public Material[] Player4;
    public Material tester;
    private int count;

    private bool lockedIn;
    private RendererSelector rendererSelector;
    public GameObject prefab;
    

    void Awake(){
        materialPerPlayer = new List<Material[]>();
        materialPerPlayer.Add(Player1);
        materialPerPlayer.Add(Player2);
        materialPerPlayer.Add(Player3);
        materialPerPlayer.Add(Player4);
        count = 0;
        colors = new string[4] {"Green", "Blue", "Purple", "Yellow"};
        lockedIn = false;
    }

    public void OnPlayerJoined(PlayerInput playerInput){
        if (pim.maxPlayerCount > count)
        {
            playerInput.transform.SetParent(transform);
            prefab = changePrefab(playerInput.gameObject);
            prefab.GetComponent<PlayerInfo>().money = 50;
            //playerInput.actions = actionMap;
            count++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject changePrefab(GameObject g)
    {
        MeshRenderer mr = g.transform.GetChild(1).GetComponent<MeshRenderer>();
      
        mr.materials = materialPerPlayer[count];
        g.GetComponent<PlayerInfo>().color = colors[count];
        return g;
    }
     
    public void PlayerLockIn()
    {
        if(!lockedIn){
            int numAI = 4 - transform.childCount;
            for (int i = 0; i < numAI; i++)
            {
                GameObject ai = Instantiate(prefab, transform.position, Quaternion.identity, transform);
                ai.GetComponent<PlayerInfo>().money = 50;
                ai.GetComponent<TagList>().AddTag("AI");

            }
            lockedIn = true;
        }
    }
}
