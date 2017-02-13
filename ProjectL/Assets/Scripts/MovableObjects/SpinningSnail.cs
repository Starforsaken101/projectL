using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningSnail : Enemy
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _multiplier = 1;

    private bool _isTriggered;

    protected override void OnEnable()
    {
        base.OnEnable();
        _isTriggered = false;
    }

    public void TriggerShellAnimation()
    {
        _animator.ResetTrigger("NoticeSenpai");
        _animator.SetTrigger("NoticeSenpai");
    }

    public void TriggerMovement()
    {
        _isTriggered = true;
    }

    void Update()
    {
        if (SpeedController.Instance.IsInitialized && _isTriggered)
        {
            transform.parent.position += Vector3.left * (SpeedController.Instance.Speed * _multiplier * Time.deltaTime);
        }
    }

    protected override void OnEnemyBounce()
    {
        // Do nothing.
    }

    protected override void OnPlayerDeath()
    {
        base.OnPlayerDeath();
        GameController.Instance.CurrentTutorialState = TutorialState.DEATH_BY_SNAIL;
    }
}
