using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidBody;

    private bool _isDead = false;
    private bool _isInAir = false;

    void Awake()
    {
        _isDead = false;
        _isInAir = false;

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
            if (Input.GetKeyDown("space") && !_isInAir)
            {
                _rigidBody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                Jump();
            }
        }
	}

    private void Jump()
    {
        _animator.ResetTrigger("Land");
        _animator.SetTrigger("Jump");
        _isInAir = true;
    }

    public void OnEnemyJump()
    {
        _rigidBody.AddForce(Vector2.up * 300);
        Jump();
    }

    public void OnDeath()
    {
        _isDead = true;
        _animator.SetTrigger("Die");
        SpeedController.Instance.Speed = 0;
    }
}
