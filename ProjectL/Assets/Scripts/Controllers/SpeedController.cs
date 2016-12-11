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

    private float _speed = 3;
    public float Speed {  get { return _speed; } }
}
