using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class EnemyDeathCollider : MonoBehaviour
{
    public UnityEvent OnDeath = new UnityEvent();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerController>().OnDeath();
            OnDeath.Invoke();
        }
    }
}
