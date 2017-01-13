using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class DetectionRadius : MonoBehaviour
{
    public UnityEvent OnDetection = new UnityEvent();

    private bool _isDetected;

    void OnEnable()
    {
        _isDetected = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !_isDetected)
        {
            _isDetected = true;
            OnDetection.Invoke();
        }
    }
}
