using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TouchController touchController;

    [SerializeField]
    SpaceShip spaceShipPrefab;
    SpaceShip spaceShip;

    void Start()
    {
        spaceShip = Instantiate(spaceShipPrefab);
        BindEvents();
    }

    void OnDestroy()
    {
        UnBindEvents();
    }

    void BindEvents()
    {
        touchController.ScreenTouched += spaceShip.TargetToMove;
        touchController.ScreenTouchBegan += spaceShip.ActiveObject;
        touchController.ScreenTouchEnded += spaceShip.HideObject;
    }

    void UnBindEvents()
    {
        touchController.ScreenTouched -= spaceShip.TargetToMove;
        touchController.ScreenTouchBegan -= spaceShip.ActiveObject;
        touchController.ScreenTouchEnded -= spaceShip.HideObject;
    }
}
