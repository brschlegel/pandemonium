using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    Vector3 forward;
    public Vector3 Forward{
        get {return forward; }
        set {forward = value;}
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(forward.magnitude > .04){
        transform.forward = forward;
        }
    }
}
