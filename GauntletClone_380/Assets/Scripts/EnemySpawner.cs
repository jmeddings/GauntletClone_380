using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public int health = 3;
    public GameObject enemyPrefab;
    public int spawnFreq;
    public int spawnStart;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy",spawnStart, spawnFreq);
    }

    private void Update()
    {
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            CancelInvoke("SpawnEnemy");
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            --health;
        }
        if (other.gameObject.tag == "Bullet")
        {
            --health;
        }
    }
}
