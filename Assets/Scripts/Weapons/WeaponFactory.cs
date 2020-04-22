using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponFactory
{
    Weapon weapon;
    int weaponAmount;

    List<Weapon> weapons = new List<Weapon>();

    public WeaponFactory(Weapon weapon, int weaponAmount)
    {
        this.weapon = weapon;
        this.weaponAmount = weaponAmount;
    }

    public Weapon Get()
    {
        if(weapons.Count==0)
        {
            CreatePool();
        }

        int lastIndex = weapons.Count - 1;
        var obj = weapons[lastIndex];
        obj.gameObject.SetActive(true);
        weapons.RemoveAt(lastIndex);
        return obj;
    }

    public void RestoreObject(Weapon recycleObject)
    {
        recycleObject.gameObject.SetActive(false);
        weapons.Add(recycleObject);
    }

    void CreatePool()
    {
        for (int i = 0; i < weaponAmount; i++)
        {
            Weapon obj = GameObject.Instantiate(weapon);
            obj.gameObject.SetActive(false);
            weapons.Add(obj);
        }
    }
}
