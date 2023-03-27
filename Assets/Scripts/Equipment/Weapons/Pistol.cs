using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : EntityWeapon
{
    public Pistol()
    {
        Type = WeaponType.Pistol;

        SlotType = SlotType.Weapon;
    }

    public override string IconName => "Pistol";
}