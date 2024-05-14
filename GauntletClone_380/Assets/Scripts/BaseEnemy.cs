using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	public float speed = 4f;
	public Transform player;
	public Transform enemyTransform;
	public EnemySpawner enemySpawner;
	public Collider playerColl;
	public float detectionRadius = 200f;
    //prefabs
    public GameObject keyPref;
    public GameObject potPref;
    public GameObject foodPref;


	public void Awake()
	{
		playerColl = GameObject.Find("Player").GetComponent<Collider>();
		player = GameObject.Find("Player").transform;
		enemyTransform = this.GetComponent<Transform>();
		enemySpawner = FindObjectOfType<EnemySpawner>();
	}

	public void Update()
	{
		Physics.OverlapSphere(enemyTransform.position, detectionRadius);
		player = GameObject.FindWithTag("Player").transform;
		Vector3 toPlayer = player.position - transform.position;
		Vector3 playerDirection = toPlayer.normalized;
		transform.rotation = Quaternion.LookRotation(playerDirection);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;
	}

    public void gamba()
    {
        float chance = Random.Range(1, 10);
        if(chance >= 8)
        {
            if(chance == 8)
            {
                Instantiate(keyPref, transform.position, Quaternion.identity);
            }

            if(chance == 9)
            {
                Instantiate(potPref, transform.position, Quaternion.identity);
            }

            if(chance == 10)
            {
                Instantiate(foodPref, transform.position, Quaternion.identity);

            }
        }

    }
    
}
