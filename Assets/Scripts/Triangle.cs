using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 5f);
    }
}
