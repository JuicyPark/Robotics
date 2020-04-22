using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeField : MonoBehaviour
{
    public Vector2 size;

    [SerializeField]
    BoxCollider2D boxCollider;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            SetSizeUp();
        if (Input.GetKey(KeyCode.DownArrow))
            SetSizeDown();
    }

    public void SetSizeUp()
    {
        size += Vector2.up * Time.deltaTime;
        SetColliderSize();
    }

    public void SetSizeDown()
    {
        size -= Vector2.up * Time.deltaTime;
        SetColliderSize();
    }

    void SetColliderSize()
    {
        spriteRenderer.size = size;
        boxCollider.size = size;
        boxCollider.offset = Vector2.up * (size.y * 0.5f);
    }
}
