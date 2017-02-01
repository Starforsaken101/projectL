using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class EnemyBounceCollider : MonoBehaviour
{
    public UnityEvent OnBounce = new UnityEvent();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerController>().OnEnemyJump();
            OnBounce.Invoke();
        }
    }
}
