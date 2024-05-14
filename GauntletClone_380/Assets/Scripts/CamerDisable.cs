using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerDisable : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private void Awake()
    {
        playerController = gameObject.GetComponent<PlayerController>();
    }
    private void Update()
    {
        if(playerController.deleteCamera == true)
        {
            Destroy(gameObject);
        }
    }
}
