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

    [SerializeField]
    SafeField safeFieldPrefab;
    SafeField safeField;

    void Start()
    {
        spaceShip = Instantiate(spaceShipPrefab);
        safeField = Instantiate(safeFieldPrefab);
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
        spaceShip.status.LackedMana += safeField.SetSizeDown;
    }

    void UnBindEvents()
    {
        touchController.ScreenTouched -= spaceShip.TargetToMove;
        touchController.ScreenTouchBegan -= spaceShip.ActiveObject;
        touchController.ScreenTouchEnded -= spaceShip.HideObject;
        spaceShip.status.LackedMana -= safeField.SetSizeDown;
    }
}
