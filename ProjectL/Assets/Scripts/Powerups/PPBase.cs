using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPBase : MonoBehaviour
{
    protected bool _isActive = false;
    protected Powerup _powerup = Powerup.NONE;

    private const float POWERUP_ACTIVE_TIME = 5;
    private float _currentActiveTime = 0;

    protected virtual void OnPowerupActivated(Powerup powerup)
    {
        if (_powerup == powerup)
        {
            _isActive = true;
            _currentActiveTime += POWERUP_ACTIVE_TIME;
        }
    }

    protected virtual void DeactivatePowerup()
    {
        _isActive = false;
    }

    void Update()
    {
        if (_isActive)
        {
            if (_currentActiveTime <= 0)
            {
                DeactivatePowerup();
            }
            _currentActiveTime -= Time.deltaTime;
        }
    }
}
