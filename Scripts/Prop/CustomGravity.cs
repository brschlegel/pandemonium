using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class CustomGravity : MonoBehaviour
{
    public Rigidbody rb;
    public float gravity;

    public AudioSource ballBounce;
    public AudioSource pushSound;
    public AudioClip clip;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        ballBounce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        rb.AddForce(0,-gravity, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arena")
        {
            ballBounce.Play();
        }

        if (collision.gameObject.tag == "MainCollider")
        {
            pushSound.PlayOneShot(clip);
        }
    }
}
