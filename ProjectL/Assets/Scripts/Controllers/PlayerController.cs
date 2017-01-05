using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidBody;

    [SerializeField]
    private UILosePopup _losePopup; // This is super temp;

    private const float BOUNCE_BUFFER_TIME = 0.2f;
    private const float XPOSITION = -2.97f;

    private bool _isDead = false;
    private bool _isInAir = false;
    private bool _isBounce = false;
    private float _currentBounceBufferTime = 0;

    void Awake()
    {
        _isDead = false;
        _isInAir = false;
        _isBounce = false;

        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isInAir)
        {
            _animator.SetTrigger("Land");
            _isInAir = false;
        }
    }

	void Update ()
    {
        if (!_isDead)
        {
            if ((Input.GetKeyDown("space") || IsTouch()) && !_isInAir)
            {
                if (_isBounce)
                {
                    _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 7);
                    _isBounce = false;
                }
                else
                {
                    _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 5);
                }
                Jump();
            }

            if (Input.GetKeyDown("x"))
            {
                OnDeath();
            }

            if (_isBounce)
            {
                if (_currentBounceBufferTime <= 0)
                {
                    _isInAir = true;
                    _isBounce = false;
                }
                _currentBounceBufferTime -= Time.deltaTime;
            }
        }
	}

    private bool IsTouch()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }

    private void Jump()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            _animator.ResetTrigger("Land");
            _animator.SetTrigger("Jump");
        }
        _isInAir = true;
    }

    public void OnEnemyJump()
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 3);
        Jump();

        _isInAir = false;
        _isBounce = true;
        _currentBounceBufferTime = BOUNCE_BUFFER_TIME;
    }

    public void OnDeath()
    {
        _isDead = true;
        _animator.SetTrigger("Die");
        SpeedController.Instance.Speed = 0;
        // Temp
        _losePopup.gameObject.SetActive(true);
    }
}
