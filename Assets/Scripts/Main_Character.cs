﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Character : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    

    private bool shooting;
    private bool facingLeft;
    private bool isGrounded;
    private bool jump;


    [SerializeField] // this prevents other scripts from changing the speed of the main character
    private float movementSpeed;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private Transform[] groundPointChecks;

    [SerializeField]
    private float jumpForce;

    void Start()
    {
        facingLeft = true;
        myRigidbody = GetComponent<Rigidbody2D>(); // this is the reference to the main character's rigidbody
        myAnimator = GetComponent<Animator>(); //this references the animator of the main character
    }

    void Update()

    {
        HandleInput();

    }

    void FixedUpdate() //keeps the game fps on the same level for all PC's
    {
        float horizontal = Input.GetAxis("Horizontal");  //this function gives the player control over the main character on the x axis 

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        Flip(horizontal);

        HandleShooting();

        HandleLayers();

        ResetValues();

    }
    private void HandleMovement(float horizontal) // this function handles all of the movement for the main character in the game
    {
        if(myRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("Land", true);
        }
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Scream_Shooting"))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); //this function is used  to apply force to the rigidbody of the main character, moving him across horizontal axis
        }
        if(isGrounded && jump) // in this way it is checked if the main character is on the ground or not
        {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("Jump");
        }

        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal)); //in this way,by using the mathf.abs i restrict the horizontal function from returning a negative  value
    }
    private void HandleShooting()
    {
        if (shooting && isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Scream_Shooting"))
        {
            myAnimator.SetTrigger("Scream");
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooting = true;
        }
        if (Input.GetKeyDown(KeyCode. W))
        {
            jump = true;
        }
    }
    private void Flip(float horizontal) // this function helps to flip the facing position of the character
    {
        if (horizontal < 0 && !facingLeft || horizontal > 0 && facingLeft)
        {
            facingLeft = !facingLeft;

            Vector3 theScale = transform.localScale; // this code line references the local scale of the main character in unity, so that he can be flipped 
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    private void ResetValues() // this function resets all values of every function after it has been executed
    {
        shooting = false;
        jump = false;

    }
    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPointChecks)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        myAnimator.ResetTrigger("Jump");
                        myAnimator.SetBool("Land", false);
                        return true;
                    }
                }
            }          
        }
        return false;
    }
    private void HandleLayers()
    {
        if (isGrounded)
        {
            myAnimator.SetLayerWeight(1, 0);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 1);
        }
    }
}

