using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class UpTinyMagnet : MonoBehaviour
{
    private CircleCollider2D _collider;

    void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        _collider.radius = UpgradeManager.Instance.CurrentTinyMagnet.radius;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            CollectableCat test = collision.gameObject.GetComponent<CollectableCat>();
            if (test != null)
            {
                test.MoveTowardsPlayer(transform.root.gameObject);
            }
        }
    }
}
