using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinerScript : MonoBehaviour
{
    public PlayerInputManager pim;
    public List<GameObject> prefabs;

    public InputActionAsset actionMap;
    private int count;
    
    
    void Start()
    {
        count = 1;
    }

    public void OnPlayerJoined(PlayerInput playerInput){
        if(pim.maxPlayerCount > count ){
        pim.playerPrefab = prefabs[count];
        //playerInput.actions = actionMap;
        count++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
