using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Bullet_0,
    Bullet_1
}

public class WeaponManager : MonoBehaviour
{
    public GameObject bullet_0;
    public GameObject bullet_1;

    public GameObject playerBullet;

    private IWeapon weapon;

    

    private void SetWeaponType (WeaponType weaponType)
    {
        Component c = gameObject.GetComponent<IWeapon>() as Component;
        if(c != null)
        {
            Destroy(c);
        }

        switch(weaponType)
        {
            case WeaponType.Bullet_0:
                {
                    weapon = gameObject.AddComponent<Bullet_0>();
                    playerBullet = bullet_0;
                }
                break;
            case WeaponType.Bullet_1:
                {
                    weapon = gameObject.AddComponent<Bullet_1>();
                    playerBullet = bullet_1;
                }
                break;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
       SetWeaponType (WeaponType.Bullet_0);
    }

    public void ChangeToBullet_0() // ÃÑ¾Ë 1¹ß
    {
        SetWeaponType(WeaponType.Bullet_0);
    }

    public void ChangeToBullet_1() // ÃÑ¾Ë 2¹ß
    {
        SetWeaponType(WeaponType.Bullet_1);
    }

    public void Fire(GameObject player)
    {
        weapon.Shoot(playerBullet, player);
    }
}
