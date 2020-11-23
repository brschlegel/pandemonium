using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    private System.Random rand;

    Vector3 pos;
    public Vector3 dir;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20;
        rand = new System.Random();
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = this.transform.position;
        RandomMovement();
    }

    public void RandomMovement()
    {
        float randX = rand.Next(-3, 3);
        float randY = rand.Next(0, 0);
        float randZ = rand.Next(-3, 3);

        dir = new Vector3(randX, randY, randZ);
        pos += dir;

        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }


}

