using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 selectedPosition;
    public Collider2D selectedCollider;

    void Update()
    {
        ClickObject();
    }

    void ClickObject()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            selectedPosition = Input.GetTouch(0).position;
            selectedCollider = SelectBlock();
        }
    }

    Collider2D SelectBlock()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
            return hit.transform.gameObject.GetComponent<Collider2D>();
        return null;
    }
}
