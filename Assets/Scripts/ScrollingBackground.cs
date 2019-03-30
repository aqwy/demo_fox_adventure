using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 0.3f;

    private Vector2 _offset;
    private Renderer _render;
    void Start()
    {
        _render = GetComponent<Renderer>();
    }

    void Update()
    {
        _offset = new Vector2(Time.time * speed, 0f);
        _render.material.mainTextureOffset = _offset;
    }
}
