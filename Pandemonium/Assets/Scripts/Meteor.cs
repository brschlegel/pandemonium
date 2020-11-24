using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteor : MonoBehaviour
{
    public ScoredEvent defaultEvent;
    public List<EventTagMap> eventTagMap;
    
    public AudioClip clip;
    public AudioSource explosionSound;
    public GameObject explosion;
    public float destructionHeight;
    public float rotateX;
    public float rotateY;
    public float rotateZ;
    public bool rotate = false;
    public int stayCount = 0;
    public bool bounce = false;
    public int destructionCount;
    public float YCount;
    public float PreviousYCount;
    // Start is called before the first frame update
    void Start()
    {
       
        YCount = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        YCount = transform.position.y;
        if (rotate == true)
        {
            //explosionSound.PlayOneShot(clip);
            transform.Rotate(rotateX, rotateY, rotateZ);
        }
        if(transform.position.y <= destructionHeight)
        {
            explosionSound.PlayOneShot(clip);
            Explode();
        }
        PreviousYCount = transform.position.y;
        if(bounce == true)
        {
            explosionSound.PlayOneShot(clip);
            if (PreviousYCount == YCount)
            {
                stayCount += 1;
            }
            else
            {
                stayCount = 0;
            }

            if (stayCount == destructionCount)
            {
                explosionSound.PlayOneShot(clip);
                Explode();
            }
        }
        
    }

    public void Explode()
    {
        explosionSound.PlayOneShot(clip);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "island")
        {
            explosionSound.PlayOneShot(clip);
            Explode();
            
        }

        if (collision.gameObject.tag == "MainCollider")
        {
            explosionSound.PlayOneShot(clip);
            Explode();
            Debug.Log("HIT");
            //eventTagMap[0].tagEvent.Invoke(collision.gameObject);
        }
    }

    
}
