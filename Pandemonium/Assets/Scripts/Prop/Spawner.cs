using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject toBeSpawned;
    public GameObject spawnUnder;
    public Vector3 spawnOffset;
    public float spawnForce;
    public List<Vector3> spawnDirectionQueue;
    public bool useRandomDirection;
    public Vector3 spawnRotation;
    public int numSpawned;

    public float timedInterval;
    public float startDelay;
    private int queueIndex;



    void Start()
    {

        if (timedInterval != 0)
        {
            InvokeRepeating("Spawn", startDelay, timedInterval);
        }
        //Spawn(); //The initial spawn is now triggered by the Game Timer object
        queueIndex = 0;

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
                spawnDirectionQueue[0] = Util.GetRandomUnitVector(0, 2 * Mathf.PI, 0, 2 * Mathf.PI);
            }
            Transform freeObject = CheckParent();
            GameObject obj = null;
            //we do be recyclin
            //If there is a disabled version of the prefab we want to spawn, use that instead
            if (freeObject == null)
            {
                
                obj = Instantiate(toBeSpawned, transform.position + spawnOffset, Quaternion.Euler(transform.eulerAngles + spawnRotation), spawnUnder.transform);
            }
            else
            {
                freeObject.position = spawnOffset + transform.position;
                freeObject.rotation = Quaternion.Euler(transform.eulerAngles + spawnRotation);
                freeObject.gameObject.SetActive(true);
                obj = freeObject.gameObject;
            }
            obj.GetComponent<Rigidbody>().AddForce(spawnForce * spawnDirectionQueue[queueIndex % spawnDirectionQueue.Count].normalized);
            queueIndex++;
        }

    }

    //checks for disabled children, returns null if none found
    public Transform CheckParent()
    {
        foreach (Transform child in spawnUnder.transform)
        {
            if (!child.gameObject.activeInHierarchy)
            {
                return child;
            }


        }
        return null;
    }
}

