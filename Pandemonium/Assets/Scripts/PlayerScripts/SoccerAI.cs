﻿using System.Collections;
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
    float prevTheta;

    public GameObject closestBall;

    public float centerWeight = 1;
    public float sigma;
    public Vector3 goalTransform;
    void Awake(){
        bm = transform.GetComponent<BasicMovement>();
        ballParent = GameObject.Find("SoccerBallParent");
        goal = GameObject.FindGameObjectWithTag(transform.GetComponent<PlayerInfo>().color);
        centerWeight = .15f;
        sigma = .25f;
    }
    void Start()
    {
        
    }

    //Generated by Box-Muller Transform
    float GenerateNormalNoise(float sigma, float  mu)
    {
        float num1 = Random.value;
        float num2 = Random.value;

       
        float z = Mathf.Sqrt(-2 * Mathf.Log(num1)) * Mathf.Cos(2*Mathf.PI * num2);
        return z * sigma + mu;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Update goal position
      
        bm.Moving();
      //  bm.movementDirection = (goalWeight * goalVector + (ballWeight / minDistance) * toBall).normalized;
       // Debug.Log((goalWeight * goalVector + (ballWeight / minDistance) * toBall).normalized);
       float theta = GenerateNormalNoise(sigma,prevTheta);
       Vector2 rNV = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
       Vector2 centerBias = centerWeight * (new Vector2(transform.position.x,transform.position.z));
       
        prevTheta = theta;
        Debug.Log((rNV - centerBias).normalized);
        bm.movementDirection = (rNV - centerBias).normalized;

        
    }
}