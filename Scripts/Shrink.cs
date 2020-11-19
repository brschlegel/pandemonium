using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    public Vector3 shrinkFactor;
    public float minSize;
    public bool shrink = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shrink == true)
        {
            transform.localScale -= shrinkFactor;
            if (transform.localScale.x <= minSize && transform.localScale.z <= minSize)
            {
                Destroy(gameObject);
            }
        }
    }
}
