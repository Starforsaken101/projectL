using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.y > transform.position.y && 
                collision.transform.position.x + (collision.bounds.size.x/2) > transform.position.x - (GetComponent<Collider2D>().bounds.size.x / 2)) 
            {
                collision.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up*300);
                gameObject.SetActive(false);
            }
            else
            {
                collision.GetComponent<PlayerController>().OnDeath();
            }
        }
    }
}
