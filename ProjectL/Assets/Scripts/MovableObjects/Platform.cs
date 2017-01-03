using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Platform : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetPlatformSprite(Sprite platformSprite)
    {
        _spriteRenderer.sprite = platformSprite;
    }
}
