using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : Enemy
{
    public UnityEvent OnDespawn = new UnityEvent();

    void OnDisable()
    {
        OnDespawn.Invoke();
    }
}
