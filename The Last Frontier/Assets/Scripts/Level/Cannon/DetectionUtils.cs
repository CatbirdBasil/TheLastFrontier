using UnityEngine;

namespace Level.Cannon
{
    public class DetectionUtils
    {
        public static bool IsOnPauseButton(Vector2 position)
        {
            return position.y > 3.7 && position.x > 9.8;
        }

        public static Vector2 GetOnScreenInputPosition()
        {
            if (Input.touchCount != 0)
            {
                var touch = Input.GetTouch(0);
                return Camera.main.ScreenToWorldPoint(touch.position);
            }
            
            if (Input.GetMouseButton(0))
            {
                return Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            return Vector2.negativeInfinity;
        }
    }
}