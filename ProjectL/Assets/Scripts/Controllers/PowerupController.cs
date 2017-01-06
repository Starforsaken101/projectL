using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Powerup
{
    NONE,
    MAGNET
}

public class PowerupController
{
    private static PowerupController _instance;
    public static PowerupController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PowerupController();
            }
            return _instance;
        }
    }

    public PowerupEvent OnPowerupActivated = new PowerupEvent();

    public void ActivatePowerup(Powerup powerup)
    {
        OnPowerupActivated.Invoke(powerup);
    }
}
