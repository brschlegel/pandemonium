using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerLogic : MonoBehaviour
{
    public GameObject environment;
    public AudioSource deathSound;
    public float degreeStep;
    public float numRotate;
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
        numRotate = Random.Range(30,200);
        StartCoroutine("Rotate");
    }

    public void StopRotate(){
        StopCoroutine("Rotate");
    }
    public IEnumerator Rotate()
    {
        for(int i =0; i < numRotate; i++){
        environment.transform.Rotate(0,degreeStep,0);
        yield return null;
        }
    }

    public void SavePlayer(GameObject player){
        player.transform.position = new Vector3(0,1,0);
        deathSound.Play();
    }
}
