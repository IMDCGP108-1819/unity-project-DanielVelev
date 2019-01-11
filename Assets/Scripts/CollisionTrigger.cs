using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{

    private BoxCollider2D playerCollinder;

    [SerializeField]
    private BoxCollider2D platformCollider;

    [SerializeField]
    private BoxCollider2D platformTrigger;

    // Start is called before the first frame update
    void Start()
    {
        playerCollinder = GameObject.Find("Main_Character").GetComponent<BoxCollider2D>(); // this is a reference to the main character's collider
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true); // this function makes sure that the two box colliders do not collide with eachother

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Main_Character")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollinder, true); // this function makes the collider of the main character ignore the collider of the platform when in collision with the trigger collider
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Main_Character")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollinder, false); // this function re-enables the platform collider, so that the main character can land on it
        }
    }
}
