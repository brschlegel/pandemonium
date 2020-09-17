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
    public int numSpawned;

    public float timedInterval;
    public float startDelay;




    void Start()
    {
        if(timedInterval != 0)
        {
            InvokeRepeating("Spawn", startDelay, timedInterval);
        }
        Spawn();

    }

    void Update()
    {

    }
    public void Spawn()
    {

        for (int i = 0; i < numSpawned; i++)
        {
            if (useRandomDirection)
            {
                spawnDirection = Util.GetRandomUnitVector(0, 2 * Mathf.PI, 0, 2 * Mathf.PI);
            }

            GameObject g = Instantiate(toBeSpawned, transform.position + spawnOffset, Quaternion.Euler(transform.eulerAngles + spawnRotation), spawnUnder.transform);
            g.GetComponent<Rigidbody>().AddForce(spawnForce * spawnDirection);
        }

    }
}

