using UnityEngine;

public class Launcher : MonoBehaviour
{
    public bool readyToFire;
    protected Factory weaponFactory;

    [SerializeField]
    protected Weapon weaponPrefab;
    [SerializeField]
    protected int weaponAmount = 10;

    [SerializeField]
    protected float delayTime = 0.3f;
    protected float elapsedTime;

    public virtual void FireWeapon()
    {
        readyToFire = false;
        Weapon weapon = weaponFactory.Get();
        weapon.Activate(transform.position);
        weapon.Destroyed += OnWeaponDestroyed;
    }
    protected virtual void CreateWeaponFactory()
    {
        weaponFactory = new Factory(weaponPrefab, weaponAmount);
    }

    void OnWeaponDestroyed(Weapon weapon)
    {
        weapon.Destroyed -= OnWeaponDestroyed;
        weaponFactory.RestoreObject(weapon);
    }

    void Start()
    {
        CreateWeaponFactory();
    }

    void Update()
    {
        if (elapsedTime < delayTime)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            elapsedTime = 0;
            readyToFire = true;
        }
    }
}
