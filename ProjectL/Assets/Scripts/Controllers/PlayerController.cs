using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private bool _isDead = false;

    void Awake()
    {
        _isDead = false;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

	void Update ()
    {
        if (!_isDead)
        {
            if (Input.GetKeyDown("space"))
            {
                _rigidBody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
        }
	}

    public void OnDeath()
    {
        _isDead = true;
        SpeedController.Instance.Speed = 0;
    }
}
