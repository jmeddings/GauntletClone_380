using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobber : BaseEnemy
{
    public GameObject rockPrefab;
    public float attackSpeed = 7f;
    public int damage;
    public int health;
    public void Start()
    {
        if (enemySpawner.health == 3)
        {
            damage = 3;
            health = 3;
        }
        else if (enemySpawner.health == 2)
        {
            damage = 3;
            health = 2;
        }
        else if (enemySpawner.health == 1)
        {
            damage = 3;
            health = 1;
        }

        InvokeRepeating("throwRock", 3f, attackSpeed);
    }
    private void LateUpdate()
    {
        
    }
    private void OnDisable()
    {
        CancelInvoke("throwRock");
    }

    private void throwRock()
    {
        GameObject _projectile = Instantiate((rockPrefab), transform.position, transform.rotation);
        Rigidbody _projectileRB = _projectile.GetComponent<Rigidbody>();
        Vector3 forceToAdd = transform.forward * 10f + transform.up;
        _projectileRB.AddForce(forceToAdd, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
