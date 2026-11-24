using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float maxSpeed;
    public float timeToMaxSpeed;
    float acceleration;

    //scripts
    public PlayerVisuals visualsScript;

    public float maxHeight;
    public float maxAirTime;

    float gravity;
    float initialJumpVelocity;

    public GameObject playerVisuals;

    bool jumpTrigger;

    public float timetoDecelerate;
    float deceleration;

    bool playerMovingRight = false;
    bool playerMovingLeft = false;

    

    public float terminalVelocity;
    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //acceleration
        acceleration = maxSpeed / timeToMaxSpeed;

        //deceleration
        deceleration = maxSpeed / timetoDecelerate;

        //jumping equations
        gravity = -2 * maxHeight / (maxAirTime * maxAirTime);
        initialJumpVelocity = 2 * maxHeight / maxAirTime;
    }

    // Update is called once per frame
    void Update()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        

        if (Keyboard.current.dKey.isPressed)
        {
            playerMovingRight = true;
            //playerInput.x += 1f;
            
            //visual Script Handler
            visualsScript.playerIsWalking = true;
            visualsScript.bodyRenderer.flipX = false;
        }
        else if(Keyboard.current.dKey.wasReleasedThisFrame)
        {
            playerMovingRight = false;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            playerMovingLeft = true;
            //playerInput.x -= 1f;

            //visual Script Handler
            visualsScript.playerIsWalking = true;
            visualsScript.bodyRenderer.flipX = true;
        }
        else if(Keyboard.current.aKey.wasReleasedThisFrame)
        {
            playerMovingLeft = false;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && visualsScript.touchingGround == true)
        {
            jumpTrigger = true;
            visualsScript.touchingGround = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 playerInput = new Vector2();
        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newVelocity = rb.linearVelocity;

        //applying gravity
        newVelocity.y += gravity * Time.deltaTime;

        newVelocity.y = Mathf.Clamp(newVelocity.y, -terminalVelocity, terminalVelocity);

        if (playerMovingRight == true)
        {
            playerInput.x = 1;
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;
            
            newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);
        }
        else if(playerMovingLeft == true)
        {
            playerInput.x = -1;
            //newVelocity
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;

            newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);
        }
        else
        {
            //decelerate

            //this works when x is positive, not when x is negative
            newVelocity.x -= Mathf.Sign(newVelocity.x) * deceleration * Time.deltaTime;
           if (newVelocity.x < 0.8f && newVelocity.x > -0.8f)
            {
                newVelocity.x = 0;
            }
        }

        if (jumpTrigger == true)
        {
            newVelocity.y = initialJumpVelocity;
            jumpTrigger = false;
        }

        

        rb.linearVelocity = newVelocity;

    }

   

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
       
            return FacingDirection.right;
      

       

    }

}
