using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletScript : MonoBehaviour
{
    private void Update()
    {
        if (this.gameObject.transform.position.x >= 50)
        {
            Destroy(this.gameObject);
        }
        if (this.gameObject.transform.position.z >= 50)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
