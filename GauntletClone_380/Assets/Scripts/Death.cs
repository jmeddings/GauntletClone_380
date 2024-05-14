using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : BaseEnemy
{
    public int health;

    public void Start()
    {
        if (enemySpawner.health == 3)
        {
            health = 6;
        }
        else if (enemySpawner.health == 2)
        {
            health = 4;
        }
        else if (enemySpawner.health == 1)
        {
            health = 2;
        }
    }

    private void Update()
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
