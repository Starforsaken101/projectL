using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HomingWasp : Projectile
{
    [SerializeField]
    private float _homingTime = 5.0f;
    [SerializeField]
    private float _multiplier = 1.0f;

    private bool _isTriggered = false;
    private float _currentTime = 0;

    private const float X_POSITION = 5.4f;

    void OnEnable()
    {
        _isTriggered = false;
        _currentTime = 0;

        transform.position = new Vector3(X_POSITION, transform.position.y, transform.position.z);

        StartCoroutine(TargetPlayer());
    }

    void Update()
    {
        if (SpeedController.Instance.IsInitialized && _isTriggered)
        {
            transform.position += Vector3.left * (SpeedController.Instance.Speed * _multiplier * Time.deltaTime);
        }
    }

    private IEnumerator TargetPlayer()
    {
        while (_currentTime <= _homingTime)
        {
            GameObject player = GameObject.Find("p_character");
            float playerY = player.transform.position.y - player.GetComponent<BoxCollider2D>().bounds.size.y / 2;
            if (transform.position.y != playerY)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, playerY, transform.position.z), Time.deltaTime);
            }
            _currentTime += Time.deltaTime;
            yield return null;
        }
        _isTriggered = true;
    }

    protected override void OnPlayerDeath()
    {
        base.OnPlayerDeath();
        GameController.Instance.CurrentTutorialState = TutorialState.DEATH_BY_WASP;
    }
}
