using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITutorialPopup : UIPopup
{
    [SerializeField]
    private TextMeshProUGUI _textTutorial;

    private const float ACTIVE_TIME = 3f;
    private float _currentTime = ACTIVE_TIME;
    
    void OnEnable()
    {
        _currentTime = ACTIVE_TIME;
        _textTutorial.text = GameController.Instance.GetStringForTutorialState();
    }

    void Update()
    {
        if (_currentTime <= 0)
        {
            ClosePopup();
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }
    }
}
