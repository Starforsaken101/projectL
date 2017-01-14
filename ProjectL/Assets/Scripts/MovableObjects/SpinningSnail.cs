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

    void OnEnable()
    {
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
            transform.position += Vector3.left * (SpeedController.Instance.Speed * _multiplier * Time.deltaTime);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.y - (collision.bounds.size.y / 2) > transform.position.y + (GetComponent<Collider2D>().bounds.size.y / 2) &&
                collision.transform.position.x + (collision.bounds.size.x / 2) > transform.position.x - (GetComponent<Collider2D>().bounds.size.x / 2))
            {
                collision.GetComponent<PlayerController>().OnEnemyJump();
            }
            else
            {
                collision.GetComponent<PlayerController>().OnDeath();
            }
        }
    }
}
