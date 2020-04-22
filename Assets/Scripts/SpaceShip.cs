using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField]
    Status status;

    [SerializeField]
    List<Launcher> launchers = new List<Launcher>();

    public void TargetToMove(Vector3 position)
    {
        transform.position = position;
    }

    public void ActiveObject(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void HideObject()
    {
        gameObject.SetActive(false);
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
        foreach (var launcher in launchers)
        {
            if (launcher.readyToFire)
            {
                launcher.FireWeapon();
            }
        }
    }
}