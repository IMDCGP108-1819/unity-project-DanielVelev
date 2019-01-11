using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBullet : MonoBehaviour
{
    private float beamspeed = 10f;
    public Rigidbody2D rigbody;

    void Start()
    {
        rigbody.velocity = transform.right * beamspeed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
       Enemy enemy = hitInfo.GetComponent<Enemy>();
        if( enemy != null)
        {
            enemy.TakeDamage(50);
        }
        Destroy(gameObject);
    }
}
