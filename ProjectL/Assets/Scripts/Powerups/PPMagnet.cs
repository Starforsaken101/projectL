using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PPMagnet : PPBase
{
    [SerializeField]
    private GameObject _debug;

    private CircleCollider2D _collider;

    void Awake()
    {
        PowerupController.Instance.OnPowerupActivated.AddListener(OnPowerupActivated);

        _powerup = Powerup.MAGNET;
        _collider = GetComponent<CircleCollider2D>();
        _collider.enabled = false;
    }

    protected override void OnPowerupActivated(Powerup powerup)
    {
        base.OnPowerupActivated(powerup);
        _collider.enabled = true;
        _debug.SetActive(true);
    }

    protected override void DeactivatePowerup()
    {
        base.DeactivatePowerup();
        _collider.enabled = false;
        _debug.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            CollectableCat test = collision.gameObject.GetComponent<CollectableCat>();
            if (test != null)
            {
                test.MoveTowardsPlayer(transform.root.gameObject);
            }
        }
    }
}
