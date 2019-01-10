using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Character : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField] // this prevents other scripts from changing the speed of the main character
    private float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>(); // this is the reference to the main character's rigidbody
    }

    // Update is called once per frame
    void FixedUpdate() //keeps the game fps on the same level for all PC's
    {
        float horizontal = Input.GetAxis("Horizontal");  //this function gives the player control over the main character on the x axis 
        HandleMovement(horizontal); 
    }
    private void HandleMovement(float horizontal) // this function handles all of the movement for the main character in the game
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); //this function is used  to apply force to the rigidbody of the main character, moving him across horizontal axis
    }

}
