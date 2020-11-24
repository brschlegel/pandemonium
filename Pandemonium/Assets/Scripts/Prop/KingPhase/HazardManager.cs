using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public GameObject crabPrefab;
    private Vector3 bottomLeft;
    private Vector3 topRight;
    private System.Random rand;
    public int crabsSpanwed;

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        bottomLeft = new Vector3(-25f, -27f, -23f);
        topRight = new Vector3(61f, 2f, 60f);
        //SpawnCrabs();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnCrabs()
    {
        for(int i = 0; i < crabsSpanwed; ++i)
        {
            float randX = rand.Next((int)bottomLeft.x, (int)topRight.x);
            float randY = rand.Next((int)bottomLeft.y, (int)topRight.y);
            float randZ = rand.Next((int)bottomLeft.z, (int)topRight.z);
            GameObject tempCrab = Instantiate(crabPrefab, new Vector3(randX, randY, randZ), Quaternion.identity);
        }
    }

}
