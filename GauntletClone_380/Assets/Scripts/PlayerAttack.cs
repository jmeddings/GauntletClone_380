using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject playerProjectile;
    private float bulletSpeed = 5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            playerAttack();
        }
    }
    private void playerAttack()
    {
        //Debug.Log("attack");
        GameObject gm = Instantiate(playerProjectile, SpawnPoint.position, playerProjectile.transform.rotation);
        //create a new spawnpoint and use that position for bullet to spawn or else it spawns inside player = not good
        Rigidbody rig = gm.GetComponent<Rigidbody>();

        rig.AddForce(SpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
