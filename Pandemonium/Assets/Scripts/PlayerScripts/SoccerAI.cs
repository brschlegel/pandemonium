using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerAI : MonoBehaviour
{
    // stay near goal
    // find ball coming towards goal
    // block it
    BasicMovement bm;
    GameObject ballParent;
    public GameObject goal;
    public Vector3 goalTransform;
    void Awake(){
        bm = transform.GetComponent<BasicMovement>();
        ballParent = GameObject.Find("SoccerBallParent");
        goal = GameObject.FindGameObjectWithTag(transform.GetComponent<PlayerInfo>().color);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Update goal position
        goalTransform = goal.transform.TransformPoint(goal.transform.position)  /*(.1f *goal.transform.TransformDirection(goal.transform.forward))*/;
        bm.moving = true;
        bm.movementDirection = transform.InverseTransformPoint((transform.TransformPoint(transform.position) - goalTransform)).normalized;
        Debug.Log(transform.InverseTransformPoint((transform.TransformPoint(transform.position) - goalTransform)).normalized);

    }
}
