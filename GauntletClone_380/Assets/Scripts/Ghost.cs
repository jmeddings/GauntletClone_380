using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseEnemy
{
    public int damage;
    public int health;
    public void Start()
    {
        if (enemySpawner.health == 3)
        {
            damage = 30;
            health = 3;
        }
        else if (enemySpawner.health == 2)
        {
            damage = 20;
            health = 2;
        }
        else if (enemySpawner.health == 1)
        {
            damage = 10;
            health = 1;
        }
    }

    /***private void Update()
    {
        Physics.OverlapSphere(enemyTransform.position, detectionRadius);
        player = GameObject.FindWithTag("Player").transform;
        Vector3 toPlayer = player.position - transform.position;
        Vector3 playerDirection = toPlayer.normalized;
        transform.rotation = Quaternion.LookRotation(playerDirection);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;
        if (health <= 0)
        {
            gamba();
            Destroy(gameObject);
        }
    }***/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
        if (collision.gameObject.tag == "Player")
        {
            gamba();
            Destroy(gameObject);
        }
    }
}
