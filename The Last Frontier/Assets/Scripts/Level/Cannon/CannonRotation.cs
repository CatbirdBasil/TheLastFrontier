using Level.Cannon;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    private Vector2 position;
    public Rigidbody2D rb;

    private void Update()
    {
//        if (Input.touchCount != 0)
//        {
//            var touch = Input.GetTouch(0);
//            position = Camera.main.ScreenToWorldPoint(touch.position);
//        }
//        else if (Input.GetMouseButton(0))
//        {
//            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        }

        if (!PauseMenu.GameIsPaused && (Input.touchCount != 0 || Input.GetMouseButton(0)))
        {
            Vector2 positionToSet = DetectionUtils.GetOnScreenInputPosition();
            if (!Vector2.negativeInfinity.Equals(positionToSet))
            {
                position = positionToSet;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!DetectionUtils.IsOnPauseButton(position))
        {
            var lookDirection = position - rb.position;
            var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
}