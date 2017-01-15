using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidBody;

    private const float BOUNCE_BUFFER_TIME = 0.2f;
    private const float XPOSITION = -2.97f;

    private bool _isDead = false;
    private bool _isInAir = false;
    private bool _isBounce = false;

    private float _currentBounceBufferTime = 0;
    private float _currentFloatTime = 0;

    [SerializeField]
    private Transform _topTransform;
    [SerializeField]
    private Transform _middleTransform;
    [SerializeField]
    private Transform _bottomTransform;

    void Awake()
    {
        _isDead = false;
        _isInAir = false;
        _isBounce = false;

        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        StartCoroutine(KeepCentered());
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
            if ((Input.GetKeyDown("space") || Input.GetMouseButtonDown(0) || IsTouch()) && !_isInAir)
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

            if (_isInAir)
            {
                if (Input.GetMouseButton(0) || IsTouch())
                {
                    if (_rigidBody.velocity.y < 0 && _currentFloatTime > 0)
                    {
                        // Float
                        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, -0.5f);
                        _currentFloatTime -= Time.deltaTime;
                    }
                }
            }

            if (Input.GetKeyDown("x"))
            {
                OnDeath();
            }

            if (Input.GetKeyDown("y"))
            {
                PowerupController.Instance.ActivatePowerup(Powerup.MAGNET);
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

    private IEnumerator KeepCentered()
    {
        while (true)
        {
            yield return StartCoroutine(CheckOffCenter());
            yield return StartCoroutine(Recenter());
        }
        yield return null;
    }

    private IEnumerator CheckOffCenter()
    {
        while (transform.position.x == XPOSITION)
        {
            yield return null;
        }
    }

    private IEnumerator Recenter()
    {
        Vector3 offPosition = transform.position;
        float recenterSpeed = UpgradeManager.Instance.CurrentCatchupSpeed.speed;
        Vector3 currentPosition = Vector3.zero;
        while (transform.position.x <= XPOSITION)
        {
            currentPosition = transform.position;
            currentPosition.x = transform.position.x + (Time.deltaTime * recenterSpeed);

            transform.position = currentPosition;
            yield return null;
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

        _currentFloatTime = UpgradeManager.Instance.CurrentFloatTime.floatTime;
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
        PopupManager.Instance.ShowPopup(Popups.POPUP_LOSE);
    }
}
