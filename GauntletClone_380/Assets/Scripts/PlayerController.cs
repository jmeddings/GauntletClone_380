using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController _playerController;
    private Vector3 _playerVelo;
    private Vector2 moveInput = Vector2.zero;
    private bool isShooting = false;
    public bool isCooling = false;
    public Transform spawnPoint;
    public GameObject playerProjectile;
    private float _bulletSpeed = 13f;
    private float _playerSpeed = 8f;
    public bool deleteCamera = false;
    public bool isHealing = false;
    //
    public float playerScore;
    public float key;
    public float potion;
    public float health = 600;
    //
    public Demon demon;
    public Ghost ghost;
    public Grunt grunt;
    //

    private void Start()
    {
        _playerController = gameObject.AddComponent<CharacterController>();
        playerScore = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        health -= Time.deltaTime;
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        _playerController.Move(move * Time.deltaTime * _playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        _playerController.Move(_playerVelo * Time.deltaTime);

        if (isShooting && !isCooling)
        {
            playerAttack();
            Invoke(nameof(AttackCoolDown), 0.5f);
        }
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (isHealing && (potion>=1))
        {
            healPlayer();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        deleteCamera = true;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        isShooting = context.action.triggered;
        deleteCamera = true;
    }
    public void UsePotion(InputAction.CallbackContext context)
    {
        isHealing = context.action.triggered;
        Debug.Log("Healing");
    }

    private void playerAttack()
    {
        GameObject gm = Instantiate(playerProjectile, spawnPoint.position, playerProjectile.transform.rotation);
        Rigidbody rig = gm.GetComponent<Rigidbody>();
        rig.AddForce(spawnPoint.forward * _bulletSpeed, ForceMode.Impulse);
        isShooting = false;
        isCooling = true;
    }
    private void AttackCoolDown()
    {
        isCooling = false;
    }

    private void healPlayer()
    {
        health = health + 300;
        isHealing = false;
        Debug.Log("Healed");
    }

    private void OnCollisionEnter(Collision collision)
    {


        //Projectiles
        if (collision.gameObject.tag == "Rock")
        {
            health -= 3;
        }

        if (collision.gameObject.tag == "Fireball")
        {
            health -= 10;
        }

        //Enemy bodies
        if (collision.gameObject.tag == "Lobber")
        {
            health -= 3;
        }
        if (collision.gameObject.tag == "Demon")
        {
            if(demon.health == 3)
            {
                health -= 10;
            }
            if (demon.health == 2)
            {
                health -= 8;
            }
            if (demon.health == 3)
            {
                health -= 5;
            }
        }
        if (collision.gameObject.tag == "Grunt")
        {
            if (grunt.health == 3)
            {
                health -= 10;
            }
            if (grunt.health == 2)
            {
                health -= 8;
            }
            if (grunt.health == 3)
            {
                health -= 5;
            }
        }

        if (collision.gameObject.tag == "Ghost")
        {
            if (ghost.health == 3)
            {
                health -= 30;
            }
            if (ghost.health == 2)
            {
                health -= 20;
            }
            if (ghost.health == 3)
            {
                health -= 10;
            }
        }

        if(collision.gameObject.tag == "Thieve")
        {
            health -= 10;
        }

        if(collision.gameObject.tag == "Death")
        {
            health -= 200;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "end1")
        {
            SceneManager.LoadScene("Level 2");
        }
        if (other.gameObject.tag == "end2")
        {
            SceneManager.LoadScene("Level 3");
        }
        if(other.gameObject.tag == "Food")
        {
            health += 50;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Key")
        {
            key += 1;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Potion")
        {
            potion += 1;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
