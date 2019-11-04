﻿using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    private Vector2 position;
    public Rigidbody2D rb;

    private void Update()
    {
        /*Touch[] touches = Input.touches;

        foreach (Touch touch in touches)
        {

        }*/


        if (Input.touchCount != 0)
        {
            var touch = Input.GetTouch(0);
            position = Camera.main.ScreenToWorldPoint(touch.position);
        }
        else if (Input.GetMouseButton(0))
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        var lookDirection = position - rb.position;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}