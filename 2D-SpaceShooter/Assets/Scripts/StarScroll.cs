﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScroll : MonoBehaviour
{
    private float _scrollSpeed = -5f;
    private Vector2 _startPos;
        
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * _scrollSpeed, 20);
        transform.position = _startPos + Vector2.right * newPos;
    }
}
