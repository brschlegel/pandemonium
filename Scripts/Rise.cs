using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rise : MonoBehaviour
{
    public float riseSpeed = .001f;
    public Stack<GameObject> podium;
    private bool isWaterActive; //Is the rising water active?
   
    // Start is called before the first frame update
    void Start()
    {
        isWaterActive = false;
        podium = new Stack<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isWaterActive == true)
        {
            transform.Translate(new Vector3(0f, 0f, riseSpeed));
        }
        if(podium.Count > 3){
            FindPlacements();
        }
    }

    public void EnableWater()
    {
        isWaterActive = true;
    }

    public void DisableWater()
    {
        isWaterActive = false;
    }

    public void ElimPlayer(GameObject player){
        player.transform.position = new Vector3(0,-100, 0);
        podium.Push(player);
        Debug.Log("Eliminated");
    }

    public void FindPlacements(){
       int length = podium.Count;
       for(int i =0; i < length; i ++){
            GameObject player = podium.Pop();
            PlayerInfo pi = player.GetComponent<PlayerInfo>();
            pi.score += 15 - i*5; //If first with 4 ppl, 15 points and last gets 0. This is flawed if there's less ppl, should change this
            pi.money += 20 - i*5; //If first with 4 ppl 20 coins, and last place gets 5
            Debug.Log("Number " + i + ": " + pi.name);
       }

    }
}
