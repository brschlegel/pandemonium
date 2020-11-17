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

    public float goalWeight = 1;
    public float ballWeight = 1;
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
        goalTransform = goal.transform.position + (.1f *goal.transform.right);
        bm.moving = true;
        Vector3 goalVector = (goalTransform - transform.position);
        
        GameObject closestBall = null;
        float minDistance = float.MaxValue;
        foreach(Transform g in ballParent.transform){
            if(minDistance > (g.position - transform.position).magnitude){
                minDistance = (g.position - transform.position).magnitude;
                closestBall = g.gameObject;
            }
        }
        Vector3 toBall = Vector3.zero;
        if(closestBall != null){
         toBall = closestBall.transform.position - transform.position;
        }

        bm.movementDirection = (goalWeight * goalVector + (ballWeight / minDistance) * toBall).normalized;
        Debug.Log((goalWeight * goalVector + (ballWeight / minDistance) * toBall).normalized);
    }
}
