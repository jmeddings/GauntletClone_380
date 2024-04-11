using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int health = 3;
    public GameObject ghost;
    public GameObject sorcerers;
    public GameObject demon;
    public GameObject grunt;
    public GameObject lobber;



    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
