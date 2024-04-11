using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseEnemy
{
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        
    }
    private void Start()
    {
        if (enemySpawner.health == 3)
            damage = 30;
        else if (enemySpawner.health == 2)
            damage = 20;
        else if (enemySpawner.health == 1)
            damage = 10;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
