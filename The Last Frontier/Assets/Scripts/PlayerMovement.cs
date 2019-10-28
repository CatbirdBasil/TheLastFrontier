using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    Vector2 position;

    void Update()
    {
        /*Touch[] touches = Input.touches;

        foreach (Touch touch in touches)
        {

        }*/


        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);
            position = Camera.main.ScreenToWorldPoint(touch.position);
        } else if (Input.GetMouseButton(0)) {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void FixedUpdate()
    {
        Vector2 lookDirection = position - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
