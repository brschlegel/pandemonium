using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class BasicMovement : MonoBehaviour
{
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
    public bool moving = false;
    public Vector2 movementDirection;
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

    }

    public void OnMovement(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            movementDirection = ctx.ReadValue<Vector2>();
            Moving();
            

        }
        else if (ctx.canceled)
        {
            moving = false;
        }
    }

    public void Moving(){
        moving = true;
            if(rotator != null){
            rotator.Forward = new Vector3(movementDirection.x,0,movementDirection.y);
            }
    }
    public void OnMovementEnd(InputAction.CallbackContext ctx)
    {
        moving = false;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed){
            Jump();

        }
       
    }

    public void Jump(){
     if (jumps < maxJumps - 1 )
        {
            movementDirection = Vector2.zero;
            moving = false;
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            jumps++;
        }
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        if(ctx.performed){
            Dash();
        }
    }

    public void Dash(){
           if (canDash)
        {
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
            if (moving)
            {

                Vector3 targetVelocity = new Vector3(movementDirection.x, 0, movementDirection.y);
                targetVelocity = transform.TransformDirection(targetVelocity);
                targetVelocity *= speed;

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

        }

        //applying our own gravity 
        //rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
        // Debug.Log(new Vector3(0, -gravity * rb.mass, 0));

        //movementDirection = Vector2.zero;
        grounded = false;
    }



}

