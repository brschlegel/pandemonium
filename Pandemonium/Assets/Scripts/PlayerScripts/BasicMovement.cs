using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class BasicMovement : MonoBehaviour
{
    
    public AudioSource movementSound;
    public AudioSource jumpSound;
    public AudioSource dashSound;
    public AudioClip clip;
    public AudioClip clip2;

    private void Start()
    {
        
    }

    #region Variables

    private GroundColliderScript groundCallBack;
    public GameObject rotatorGO;
    private PlayerRotator rotator;
    public Rigidbody rb;
    [Header("Movement Variables")]
    public float speed = 10.0f;
    public float maxVelocityChange = 20.0f;
    public float dashTime = .25f;
    public float dashSpeed = 7;
    Vector3 dashVelocity;
    public float dashCooldown = 3f;
    public float frictionCoeff = .93f;

    Vector3 dashVector;

    [Header("Jump Variables")]
    public float gravity = 10.0f;
    public float jumpMaxVelocityChangeRatio = .6666f;

    public float jumpMovementVelocityRatio = .5f;
    public float jumpForce = 500f;
    public float maxJumps = 2;
    private bool moving = false;
    Vector2 movementDirection;
    private bool grounded = true;

    private float jumpMaxVelocityChange;
    int jumps = 0;
    bool canDash;
    #endregion
    private void Awake()
    {


       
        groundCallBack = transform.GetChild(0).GetComponent<GroundColliderScript>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        canDash = true;
        jumpMaxVelocityChange = maxVelocityChange * jumpMaxVelocityChangeRatio;
        groundCallBack.groundCollision.AddListener(GroundCollision);
        rotator = rotatorGO.GetComponent<PlayerRotator>();
    }
   
    #region Event Methods
    //Called when bottom collider hits ground
    public void GroundCollision(Collider other)
    {
        grounded = true;
        jumps = 0;
        movementSound = GetComponent<AudioSource>();

    }

    public void OnMovement(InputAction.CallbackContext ctx)
    {
        movementSound.Play();
        if (ctx.performed)
        {
            movementDirection = ctx.ReadValue<Vector2>();
            moving = true;
            movementSound.Play();
            if (rotator != null){
            rotator.Forward = new Vector3(movementDirection.x,0,movementDirection.y);
                movementSound.Play();
            }

        }
        else if (ctx.canceled)
        {
            moving = false;
            movementSound.Stop();
        }
    }
    public void OnMovementEnd(InputAction.CallbackContext ctx)
    {
        moving = false;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        //jumpSound = GetComponent<AudioSource>();
        if (jumps < maxJumps - 1 && ctx.performed)
        {
            jumpSound.PlayOneShot(clip);
            movementDirection = Vector2.zero;
            moving = false;
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            jumps++;
        }
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (canDash)
        {
            dashSound.PlayOneShot(clip2);
            canDash = false;
            dashVelocity = dashSpeed * ((new Vector3(movementDirection.x, 0, movementDirection.y)).normalized);
            StartCoroutine("Cooldown", dashCooldown);
            StartCoroutine("Dash", .25f);

        }
    }

    public IEnumerator Cooldown(float time)
    {

        yield return new WaitForSeconds(time);
        canDash = true;

    }

    public IEnumerator Dash(float time)
    {
        Vector3 prevVelocity = rb.velocity;
        rb.velocity = dashVelocity;
        yield return new WaitForSeconds(time);
        rb.velocity = prevVelocity;
    }


    #endregion
    private void FixedUpdate()
    {
        //I really wish there was an neater way to do this, but I think this is the only way to have continous movement on a held key
        if (grounded)
        {

            // jumpSound.Play();
            //jumpSound.Stop();
            if (moving)
            {
                
                Vector3 targetVelocity = new Vector3(movementDirection.x, 0, movementDirection.y);
                targetVelocity = transform.TransformDirection(targetVelocity);
                targetVelocity *= speed;
                //movementSound.Play();
               
                

                Vector3 velocity = rb.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);

                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                rb.AddForce(velocityChange,ForceMode.VelocityChange);

                //this is used for a bit more friction 
              
                rb.velocity *= frictionCoeff;
                

               
            }
        }

        //still some control while jumping, but its lesser
        if (!grounded)
        {
            rb.AddForce(new Vector3(0, -2 * gravity * rb.mass, 0));
           
            Vector3 targetVelocity = new Vector3(movementDirection.x, 0, movementDirection.y);
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed * jumpMovementVelocityRatio;

            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -jumpMaxVelocityChange, jumpMaxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -jumpMaxVelocityChange, jumpMaxVelocityChange);
            velocityChange.y = 0;
            rb.AddForce(velocityChange);
            //jumpSound.Play();

        }

        //applying our own gravity 
        //rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
        // Debug.Log(new Vector3(0, -gravity * rb.mass, 0));

        //movementDirection = Vector2.zero;
        grounded = false;
    }
    

}

