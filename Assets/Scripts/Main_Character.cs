using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Character : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    private Animator myAnimator; 

    [SerializeField] // this prevents other scripts from changing the speed of the main character
    private float movementSpeed;

    private bool facingLeft;

    void Start()
    {
        facingLeft = true;
        myRigidbody = GetComponent<Rigidbody2D>(); // this is the reference to the main character's rigidbody
        myAnimator = GetComponent<Animator>(); //this references the animator of the main character
    }

    void FixedUpdate() //keeps the game fps on the same level for all PC's
    {
        float horizontal = Input.GetAxis("Horizontal");  //this function gives the player control over the main character on the x axis 
        HandleMovement(horizontal);

        Flip(horizontal);
    }
    private void HandleMovement(float horizontal) // this function handles all of the movement for the main character in the game
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); //this function is used  to apply force to the rigidbody of the main character, moving him across horizontal axis
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal)); //in this way,by using the mathf.abs i restrict the horizontal function from returning a negative  value
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
}
