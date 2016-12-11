using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

	void Update ()
    {
		if (Input.GetKeyDown("space"))
        {
            _rigidBody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
	}
}
