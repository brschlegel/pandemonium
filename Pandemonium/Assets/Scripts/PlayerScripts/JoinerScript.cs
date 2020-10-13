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

    public List<Material[]> materialPerPlayer;
    public Material[] Player1;
    public Material[] Player2;
    public Material[] Player3;
    public Material[] Player4;
    public Material tester;
    private int count;

    private RendererSelector rendererSelector;
    

    void Awake(){
        materialPerPlayer = new List<Material[]>();
        materialPerPlayer.Add(Player1);
        materialPerPlayer.Add(Player2);
        materialPerPlayer.Add(Player3);
        materialPerPlayer.Add(Player4);
        count = 0;
    }
    void Start()
    {
     
    
        
        rendererSelector = transform.GetChild(0).GetComponent<RendererSelector>();
       
        
     
    }

    public void OnPlayerJoined(PlayerInput playerInput){
        if(pim.maxPlayerCount > count ){
        playerInput.transform.SetParent(transform);
        changePrefab(playerInput.gameObject);
        //playerInput.actions = actionMap;
        count++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void changePrefab(GameObject g)
    {
        MeshRenderer mr = g.transform.GetChild(1).GetComponent<MeshRenderer>();
        //for(int i = 0; i < mr.materials.Length; i++){
            
            //mr.materials = Player4;
                mr.materials = materialPerPlayer[count];
        //}
    }
}
