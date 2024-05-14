using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : BaseEnemy
{
    public GameObject fireBallPrefab;
    public float throwSpeed = 7f;
    public int throwDamage;
    public int meleeDamage;
    public int health;
    public void Start()
    {
        if (enemySpawner.health == 3)
        {
            throwDamage = 10;
            meleeDamage = 10;
            health = 3;
        }
        else if (enemySpawner.health == 2)
        {
            throwDamage = 10;
            meleeDamage = 8;
            health = 2;
        }
        else if (enemySpawner.health == 1)
        {
            throwDamage = 10;
            meleeDamage = 5;
            health = 1;
        }

        InvokeRepeating("throwRock", 4.5f, throwSpeed);
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
        GameObject _projectile = Instantiate((fireBallPrefab), transform.position, transform.rotation);
        Rigidbody _projectileRB = _projectile.GetComponent<Rigidbody>();
        Vector3 forceToAdd = transform.forward * 10f + transform.up;
        _projectileRB.AddForce(forceToAdd, ForceMode.Impulse);
    }

    private void Update()
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
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
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
