using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MovableObject
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // TODO: Make a better way to kill the player
            GameObject.Destroy(collision.gameObject);
            PoolManager.Instance.ReturnGameObject(PoolManager.PROJECTILE, gameObject);
        }
    }
}
