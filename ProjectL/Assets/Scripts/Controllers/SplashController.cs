using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SplashController : MonoBehaviour
{
    public UnityEvent OnTimerEnd = new UnityEvent();
    public float time = 0;

    private bool _timerEnded = false;

    void Update()
    {
        if (!_timerEnded)
        {
            if (time <= 0)
            {
                OnTimerEnd.Invoke();
                _timerEnded = true;
            }

            time -= Time.deltaTime;
        }
    }
}
