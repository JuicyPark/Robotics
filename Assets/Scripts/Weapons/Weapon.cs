using UnityEngine;
using System.Collections;
using System;

public abstract class Weapon : MonoBehaviour
{
    public Action<Weapon> Destroyed;

    [SerializeField]
    protected float weaponSpeed  = 5f;
    [SerializeField]
    protected float weaponDamage = 10f;

    protected abstract void AttackWeapon();
    protected abstract bool IsArrivedToTarget();

    public void Activate(Vector3 position)
    {
        transform.position = position;
    }

    void Update()
    {
        AttackWeapon();

        if (IsArrivedToTarget())
        {
            Destroyed?.Invoke(this);
        }
    }
}
