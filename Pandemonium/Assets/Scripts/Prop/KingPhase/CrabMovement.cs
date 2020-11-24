using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    private System.Random rand;

    public float Speed;
    private float Angle;
    private float DeltaTicker; // Keeps track of the frame-by-frame change in Angle, reflecting the direction of change if it gets too high. This effectively ensures the crab will only move in a cone.
    private float DeltaTolerance;
    private float Omega; // Rotational Speed, should be a small value
    private float AngleSign;

    // Start is called before the first frame update
    void Start()
    {
        Speed = 20.0f;
        Omega = 0.01f;
        rand = new System.Random();
        Angle = Mathf.Deg2Rad * rand.Next(0, 360);

        DeltaTicker = 0;
        DeltaTolerance = Mathf.PI / 4;
        AngleSign = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Angle change this frame
        float delta = Omega * Time.deltaTime;
        DeltaTicker += delta;

        // Reflect Angle Change direction if past the tolerance
        if (DeltaTicker >= DeltaTolerance)
        {
            AngleSign = -AngleSign;
            DeltaTicker = 0;
        }

        Angle += AngleSign * delta;

        // Compute Velocity vector on the fly
        Vector3 velocity = new Vector3(Mathf.Cos(Angle), 0.0f, Mathf.Sin(Angle));
        this.transform.position = this.transform.position + velocity * Time.deltaTime;



        //RandomMovement();
    }

    public void RandomMovement()
    {
        float randX = rand.Next(-3, 3);
        float randY = rand.Next(0, 0);
        float randZ = rand.Next(-3, 3);
    }


}

