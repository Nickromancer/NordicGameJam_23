using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour, IClickable
{
    [Range(0, 1)]
    public float MoveFactor = 1;

    private Camera _camera;
    public Vector3 _lastpos = Vector3.zero;
    private bool _moving = false;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!_moving) return;
        
        var movement = _lastpos;
        UpdateLastPos();
        movement -= _lastpos;
        transform.position -= movement*MoveFactor;
    }

    private void UpdateLastPos() => _lastpos = _camera.ScreenToWorldPoint(Input.mousePosition);

    public void OnClick()
    {
        UpdateLastPos();
        _moving = true;
    }

    public void OnClickUp()
    {
        _moving = false;
    }
}
