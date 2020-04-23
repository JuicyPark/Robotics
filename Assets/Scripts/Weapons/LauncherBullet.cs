using UnityEngine;
using System.Collections;

public class LauncherBullet : Launcher
{
    protected override void CreateWeaponFactory()
    {
        weaponFactory = new Factory(weaponPrefab, 10);
    }
}
