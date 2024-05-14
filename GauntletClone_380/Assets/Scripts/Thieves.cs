using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thieves : BaseEnemy
{
    public int health;

    public void Start()
    {
        if (enemySpawner.health == 3)
        {
            health = 3;
        }
        else if (enemySpawner.health == 2)
        {
            health = 2;
        }
        else if (enemySpawner.health == 1)
        {
            health = 1;
        }
    }

    private void LateUpdate()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
