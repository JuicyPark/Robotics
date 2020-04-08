using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDragger : MonoBehaviour
{
    Part selectedPart;
    Vector2 positionBuffer;

    void LateUpdate()
    {
        DragPart();
    }

    bool CheckObject(Object obj)
    {
        if (obj == null)
            return false;
        return true;
    }

    RaycastHit2D FindNearFrame()
    {
        selectedPart.collider2D.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(selectedPart.transform.position, Vector2.zero);
        selectedPart.collider2D.enabled = true;
        return hit;
    }

    void MovePart(RaycastHit2D hit)
    {
        if (hit.collider == null)
            return;

        Frame nearFrame = hit.transform.GetComponent<Frame>();

        if (nearFrame != null)
        {
            selectedPart.transform.position = hit.transform.position + Vector3.back;
            nearFrame.OnSideFrames();
        }
        else
            selectedPart.transform.position = positionBuffer;
    }

    void DragPart()
    {
        if (!CheckObject(InputManager.Instance.selectedCollider))
            return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            selectedPart = InputManager.Instance.selectedCollider.GetComponent<Part>();
            positionBuffer = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        }

        if (!CheckObject(selectedPart))
            return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            selectedPart.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            RaycastHit2D hit = FindNearFrame();
            MovePart(hit);

            selectedPart = null;
        }
    }
}
