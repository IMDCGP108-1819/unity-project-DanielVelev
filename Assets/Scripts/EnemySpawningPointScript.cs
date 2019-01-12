using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningPointScript : MonoBehaviour
{
    public GameObject enemy;
    float randomSpawnPoint;
    Vector2 spawningPointArea;
    private float spawnSpeed = 2.5f;
    float nextSpawn = 0.0f;
    void Start()
    {
    }
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnSpeed;
            randomSpawnPoint = Random.Range(-9f, 9f);
            spawningPointArea = new Vector2(randomSpawnPoint, transform.position.y);
            Instantiate(enemy, spawningPointArea, Quaternion.identity);
        }
    }
}
