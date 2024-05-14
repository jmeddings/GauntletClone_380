using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    private static CameraFollow _instance;

    public float speed = 100f;
    public Transform target;
    public Rigidbody rb;
    public Vector3 moveDirection;
    public bool isTargetFound;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    private void OnEnable()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        MoveSpeed();
        MoveToPlayer();
    }

    public void MoveSpeed()
    {
        if (target)
        {
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y, 0f) * speed;
        }
    }
    public void MoveToPlayer()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            moveDirection = direction;
        }
    }
}
