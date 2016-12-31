using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    [SerializeField]
    private float speedMultiplier = 1f;
    private const float SPEED_DAMPEN = 0.2f;

    private Renderer _renderer;
    private float _currentTime = 0;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = _currentTime * speedMultiplier * SPEED_DAMPEN;
        _renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        _currentTime += SpeedController.Instance.GetDeltaTime(Time.deltaTime);
    }
}
