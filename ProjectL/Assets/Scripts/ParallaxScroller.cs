using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    [SerializeField]
    private float speedMultiplier = 1;
    private Renderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * (0.15f * speedMultiplier);
        _renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
