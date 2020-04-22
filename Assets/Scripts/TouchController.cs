using UnityEngine;
using System;

public class TouchController : MonoBehaviour
{
    public Action<Vector3> ScreenTouchBegan;
    public Action<Vector3> ScreenTouched;
    public Action ScreenTouchEnded;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ScreenTouchBegan?.Invoke(GetInputPosition(Input.mousePosition));
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            ScreenTouched?.Invoke(GetInputPosition(Input.mousePosition));
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            ScreenTouchEnded?.Invoke();
        }
    }

    Vector3 GetInputPosition(Vector3 mousePosition)
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
        point.z = 0;
        return point;
    }
}
