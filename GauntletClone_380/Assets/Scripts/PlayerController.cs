using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Start()
    {
        _playerController = gameObject.AddComponent<CharacterController>();
    }

    private void Update()
    {
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
}
