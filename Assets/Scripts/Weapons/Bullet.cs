using UnityEngine;
using System.Collections;

public class Bullet : Weapon
{
    protected override void AttackWeapon()
    {
        transform.position += transform.up * weaponSpeed * Time.deltaTime;
    }

    protected override bool IsArrivedToTarget()
    {
        return transform.position.y > 10;
    }
}
