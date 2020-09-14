using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject toBeSpawned;
    public GameObject spawnUnder;
    public Vector3 spawnOffset;
    public float spawnForce;
    public Vector3 spawnDirection; 
    public bool useRandomDirection;
    public Vector3 spawnRotation;

    
    void Start()
    {
        Spawn();
    }

    void Update()
    {
        
    }
    public void Spawn()
    {
        if(useRandomDirection)
        {
            spawnDirection = Random.insideUnitSphere;
        }
        GameObject g = Instantiate(toBeSpawned,transform.position + spawnOffset, Quaternion.Euler(transform.eulerAngles + spawnRotation), spawnUnder.transform );
        g.GetComponent<Rigidbody>().AddForce(spawnForce * spawnDirection);
    }
}

