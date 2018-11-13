using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D myRigiddoby;
    bool facingRight = true; //this is the starting position that the character is facing

    [SerializeField]
    private float movementSpeed; //this is where we choose what the player movementspeed is
    // Use this for initialization
    void Start()
    {

        myRigiddoby = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        if (horizontal > 0 && !facingRight)
            Flip();
        else if (horizontal < 0 && facingRight)
            Flip();


    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void HandleMovement(float horizontal)
    {

        myRigiddoby.velocity = new Vector2(horizontal * movementSpeed, myRigiddoby.velocity.y);

    }

}