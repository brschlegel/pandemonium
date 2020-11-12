using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool rotate = false;
    public float X;
    public float Y;
    public float Z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate == true)
        {
            transform.Rotate(X, Y, Z);
        }
        
    }
}
