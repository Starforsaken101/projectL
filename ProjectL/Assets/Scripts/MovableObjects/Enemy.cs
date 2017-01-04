using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.y - (collision.bounds.size.y/2) > transform.position.y + (GetComponent<Collider2D>().bounds.size.y / 2) && 
                collision.transform.position.x + (collision.bounds.size.x/2) > transform.position.x - (GetComponent<Collider2D>().bounds.size.x / 2)) 
            {
                collision.GetComponent<PlayerController>().OnEnemyJump();
                gameObject.SetActive(false);
            }
            else
            {
                collision.GetComponent<PlayerController>().OnDeath();
            }
        }
    }
}
