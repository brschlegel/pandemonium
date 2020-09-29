using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerLogic : MonoBehaviour
{
    public GameObject environment;
    public float degreeStep;
    void Start()
    {
        degreeStep = 1;
        InvokeRepeating("StartRotate", 0, 10);
        InvokeRepeating("StopRotate", 5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRotate(){
        StartCoroutine("Rotate");
    }

    public void StopRotate(){
        StopCoroutine("Rotate");
    }
    public IEnumerator Rotate()
    {
        for(int i =0; i < 100; i++){
        environment.transform.Rotate(0,degreeStep,0);
        yield return null;
        }
    }
}
