using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemySpeed = 4f;
    Transform leftWayPoint, rightWayPoint;
    private int health = 100;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rigBody;

    private void Start()
    {
        localScale = transform.localScale;
        rigBody = GetComponent<Rigidbody2D>();
        leftWayPoint = GameObject.Find("LeftWayPoint").GetComponent<Transform>();
        rightWayPoint = GameObject.Find("RightWayPoint").GetComponent<Transform>();

    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    void Die() // this function removes any enemy from the scene, after being killed
    {
         gameObject.SetActive(false);
        Destroy(gameObject);
    }

    
    void Update()// here lies a function that controlls the movement of the enemy
    {
        if (transform.position.x > rightWayPoint.position.x)
            movingRight = false;
        if (transform.position.x < leftWayPoint.position.x)
            movingRight = true;

        if (movingRight)
        {
            moveRight();
        }
        else{
            moveLeft();
        }
    }
    
    void moveRight()
    {
        movingRight = true;
        localScale.x = 1;
        transform.localScale = localScale;
        rigBody.velocity = new Vector2(localScale.x*enemySpeed, rigBody.velocity.y);

    }
    void moveLeft()
    {
        movingRight = false;
        localScale.x = -1;
        transform.localScale = localScale;
        rigBody.velocity = new Vector2(localScale.x * enemySpeed, rigBody.velocity.y);

    }
}
