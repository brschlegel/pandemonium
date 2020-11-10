using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject explosion;
    public float destructionHeight;
    public float rotateX;
    public float rotateY;
    public float rotateZ;
    public bool rotate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate == true)
        {
            transform.Rotate(rotateX, rotateY, rotateZ);
        }
        if(transform.position.y <= destructionHeight)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
