using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletScript : MonoBehaviour
{
    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Demon")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Ghost")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Death")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Thief")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Lobber")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Grunt")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Key")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Food")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Potion")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "end1")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "end2")
        {
            Destroy(this.gameObject);
        }
    }
}
