using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseEnemy
{
    public int _damage;
    public int _health;

    public void Start()
    {
        if (enemySpawner.health == 3)
        {
            _damage = 30;
            _health = 3;
        }
        else if (enemySpawner.health == 2)
        {
            _damage = 20;
            _health = 2;
        }
        else if (enemySpawner.health == 1)
        {
            _damage = 10;
            _health = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}