using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController
{
    private static SpeedController _instance;
    public static SpeedController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SpeedController();
            }
            return _instance;
        }
    }

    public void Initialize()
    {
        _isInitialized = true;
    }

    private bool _isInitialized = false;
    public bool IsInitialized {  get { return _isInitialized; } }

    private const float DEFAULT_SPEED = 4;
    private float _speed = DEFAULT_SPEED;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public void ResetSpeedController()
    {
        _isInitialized = false;
        _speed = DEFAULT_SPEED;
    }

    public float GetDeltaTime(float deltaTime)
    {
        return (_speed / DEFAULT_SPEED) * deltaTime;
    }
}
