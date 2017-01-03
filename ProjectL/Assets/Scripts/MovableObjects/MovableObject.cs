using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [SerializeField]
    private float _multiplier = 1;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Sprite _defaultSprite;

    public void SetPlatformSprite(Sprite platformSprite)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = platformSprite;
        }
    }

    public void RestoreDefaultPlatformSprite()
    {
        if (_defaultSprite != null && _spriteRenderer != null)
        {
            _spriteRenderer.sprite = _defaultSprite;
        }
    }

    void Update()
    {
        if (SpeedController.Instance.IsInitialized)
        {
            transform.position += Vector3.left * (SpeedController.Instance.Speed * _multiplier * Time.deltaTime);
        }
    }
}
