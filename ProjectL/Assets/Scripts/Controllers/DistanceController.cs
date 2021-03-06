﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceController
{
    private static DistanceController _instance;
    public static DistanceController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DistanceController();
            }
            return _instance;
        }
    }

    private float _distance;
    public float Distance
    {
        get { return _distance; }
    }

    public void AddToDistance(float distance)
    {
        _distance += distance;
    }

    public void ResetDistance()
    {
        _distance = 0;
    }
}
