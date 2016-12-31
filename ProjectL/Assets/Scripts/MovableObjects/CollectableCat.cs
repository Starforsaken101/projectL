using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCat : MovableObject
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Inventory.Instance.AddCat();
            PoolManager.Instance.ReturnGameObject(gameObject.name, gameObject);
        }
    }
}
