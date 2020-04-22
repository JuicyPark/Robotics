using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public Status status;

    [SerializeField]
    List<Launcher> launchers = new List<Launcher>();

    [SerializeField]
    GameObject spaceShipObject;

    float traceSpeed = 0.3f;

    public void TargetToMove(Vector3 position)
    {
        transform.position = Vector2.MoveTowards(transform.position, position, traceSpeed);
    }

    public void ActiveObject(Vector3 position)
    {
        status.isActivate = true;
        transform.position = position;
        spaceShipObject.SetActive(true);
    }

    public void HideObject()
    {
        status.isActivate = false;
        spaceShipObject.SetActive(false);
    }

    void TakeAbility(Launcher launcher)
    {
        launchers.Add(launcher);
    }

    void Start()
    {
        Launcher[] getLaunchers = GetComponentsInChildren<Launcher>();
        foreach (var launcher in getLaunchers)
        {
            TakeAbility(launcher);
        }
    }

    void Update()
    {
        if (!status.isActivate)
            return;

        foreach (var launcher in launchers)
        {
            if (launcher.readyToFire)
            {
                launcher.FireWeapon();
            }
        }
    }
}