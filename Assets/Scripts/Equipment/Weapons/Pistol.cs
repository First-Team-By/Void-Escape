using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : EntityWeapon
{
    public Pistol()
    {
        Type = WeaponType.Pistol;
    }

    public override string IconName => "Pistol";
}