using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDistanceController : MonoBehaviour
{
    [SerializeField]
    private Text _distanceText;

    private float _currTime = 0;
    private static float TIME_CONST = 0.1f;

    void Update()
    {
        if (_currTime >= TIME_CONST)
        {
            _currTime = 0;

            DistanceController.Instance.AddToDistance(1);
            _distanceText.text = DistanceController.Instance.Distance.ToString();
        }
        _currTime += SpeedController.Instance.GetDeltaTime(Time.deltaTime);
    }
}
